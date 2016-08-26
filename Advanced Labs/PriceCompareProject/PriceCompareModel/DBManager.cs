using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.IO.Compression;
using System.Xml.Linq;

namespace PriceCompareModel
{
    public class DBManager
    {
        public void DecompressAll()
        {
            DirectoryInfo allPrices = new DirectoryInfo(@"C:\finalProject_PriceCompare\AllPrices\bin\prices");
            foreach (var subDirectories in allPrices.GetDirectories())
            {
                foreach (var file in subDirectories.GetFiles())
                {
                    if ((file.Name.StartsWith("PriceFull") || file.Name.StartsWith("PricesFull")) && (file.Extension == ".gz" || file.Extension == ".zip") && !subDirectories.GetFiles(file.Name.Remove(file.Name.Length - file.Extension.Length)).Any())
                    {
                        if (file.Extension == ".gz")
                        {
                            DecompressGZ(file);
                        }
                        else if (file.Extension == ".zip")
                        {
                            DecompressZip(file);
                        }

                    }
                }
            }
        }

        public void DecompressZip(FileInfo fileToDecompress)
        {
            string zipPath = fileToDecompress.FullName;
            string extractPath = fileToDecompress.Name.Remove(fileToDecompress.Name.Length - fileToDecompress.Extension.Length);

            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                    {
                        entry.ExtractToFile(Path.Combine(extractPath, entry.FullName));
                    }
                }
            }
        }

        public void DecompressGZ(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);
                newFileName = newFileName + ".xml";
                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                    }
                }

            }
        }

        public void PopulateDB()
        {
            using (PriceCompareDBEntitie context = new PriceCompareDBEntitie())
            {
                DirectoryInfo allPrices = new DirectoryInfo(@"C:\finalProject_PriceCompare\AllPrices\bin\prices");
                allPrices.GetDirectories();
                foreach (var subDirectory in allPrices.GetDirectories())
                {
                    if (subDirectory.Name == "logs" || subDirectory.Name == "mega" || subDirectory.Name == "shufersal")
                    {
                        continue;
                    }

                    AddChainToDB(subDirectory, context);
                    

                    //foreach (var file in subDirectory.GetFiles("*.xml"))
                    //{
                    //    XmlToDB(file, context);
                    //}
                }

                context.SaveChanges();
            }
        }

        private void AddStoresToDB( XElement StoresElm, PriceCompareDBEntitie context , long chain_id)
        {
            int store_id;
           
            //int? store_type;

            foreach (var Store in StoresElm.Elements("Store"))
            {
                store store = new store();
                int.TryParse(Store.Element("StoreId").Value, out store_id);
               
                //int.TryParse(Store.Element("StoreType").Value, out store_type);
                store.store_id = store_id;

                store.chain_id = chain_id;  
                
                store.store_type = null;
                store.store_name = Store.Element("StoreName").Value;
                store.address = Store.Element("Address").Value;
                store.city = Store.Element("City").Value;
                if (context.stores.Contains(store))
                {
                    context.stores.Remove(store);
                }

                context.stores.Add(store);
                
            }
            
        }

        public void AddChainToDB(DirectoryInfo subDirectory, PriceCompareDBEntitie context)
        {
            string StoreFilePath = subDirectory.GetFiles().Where(t => t.Name.StartsWith("Stores")).Single().FullName;
            XDocument storesDoc = XDocument.Load(StoreFilePath);
            XElement root = storesDoc.Root;
            XElement StoresElm = root.Element("SubChains").Element("SubChain").Element("Stores");
            chain chain = new chain();
            long chain_id;

            long.TryParse(root.Element("ChainId").Value, out chain_id);
            chain.chain_id = chain_id;
            chain.chain_name = root.Element("ChainName").Value;
            if (context.chains.Contains(chain)) 
            {
                context.chains.Remove(chain);
            }

            context.chains.Add(chain);
            AddStoresToDB(StoresElm, context, chain.chain_id);
            
        }
        

        public void XmlToDB(FileInfo xmlFile , PriceCompareDBEntitie context)
        {
            XDocument doc = XDocument.Load(xmlFile.FullName);
           
            foreach (XElement itemElement in doc.Root.Element("Items").Elements("Item"))
            {
                item item = new item();
                item.item_code = itemElement.Element("ItemCode").Value;
                item.item_type = itemElement.Element("ItemType").Value;
                item.item_name = itemElement.Element("ItemName").Value;
                item.manufacturer_name = itemElement.Element("ManufacturerName").Value;
                item.manufacturer_item_description = itemElement.Element("ManufacturerItemDescription").Value;
                item.unit_quantity = itemElement.Element("UnitQty").Value;
                item.quantity_in_package = itemElement.Element("Quantity").Value;
                context.items.Add(item);

            }
            

        }


    }
}
