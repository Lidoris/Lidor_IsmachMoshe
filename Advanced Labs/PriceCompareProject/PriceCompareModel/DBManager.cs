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
                chain curChain;
                List<store> listOfStores = new List<store>();
                DirectoryInfo allPrices = new DirectoryInfo(@"C:\finalProject_PriceCompare\AllPrices\bin\prices");
                allPrices.GetDirectories();
                foreach (var subDirectory in allPrices.GetDirectories())
                {

                    DecompressAll();

                    //if (subDirectory.Name == "logs" || subDirectory.Name == "mega" || subDirectory.Name == "shufersal")
                    //{
                    //    continue;
                    //}

                    //string StoreFilePath = subDirectory.GetFiles().Where(t => t.Name.StartsWith("Stores")).Single().FullName;
                    //XDocument storesDoc = XDocument.Load(StoreFilePath);

                    //curChain = AddChainToDB(storesDoc, context);
                    //chain existingChain = context.chains.FirstOrDefault(c => c.chain_id == curChain.chain_id);
                    // context.SaveChanges();

                    //if (existingChain == null)
                    //{
                    //    context.chains.Add(curChain);
                    //}

                    //listOfStores = AddStoresToDB(storesDoc, context, curChain);
                    //var x = listOfStores.Where(a => a.store_id == 0).Any();
                    //listOfStores.ForEach(s => {
                    //    context.stores.Add(s);
                    //    context.SaveChanges();
                    //}
                    //    );
                
                   
                    //foreach (var file in subDirectory.GetFiles("*.xml"))
                    //{
                    //    XmlToDB(file, context);
                    //}
                }

                //context.SaveChanges();
            }
        }

       

        public chain AddChainToDB(XDocument storesDoc, PriceCompareDBEntitie context)
        {
            XElement root = storesDoc.Root;
            chain chain = new chain();
            long chain_id;

            long.TryParse(root.Element("ChainId").Value, out chain_id);
            chain.chain_id = chain_id;
            chain.chain_name = root.Element("ChainName").Value;

            return chain;
        }

        private List<store> AddStoresToDB(XDocument storesDoc, PriceCompareDBEntitie context, chain chain)
        {
            List<store> listOfStores = new List<store>();
            XElement StoresElm = storesDoc.Root.Element("SubChains").Element("SubChain").Element("Stores");
            int store_id;
            
            foreach (var Store in StoresElm.Elements("Store"))
            {
                store store = new store();
                int.TryParse(Store.Element("StoreId").Value, out store_id);
                //int.TryParse(Store.Element("StoreType").Value, out store_type);
                store.store_id = store_id;
               // store.chain = chain;
                store.chain_id = chain.chain_id;
                store.store_type = null;
                store.store_name = Store.Element("StoreName").Value;
                store.address = Store.Element("Address").Value;
                store.city = Store.Element("City").Value;

                var existingStore = context.stores.FirstOrDefault(s => s.store_id == store.store_id && s.chain_id == store.chain_id);

                if (existingStore == null)
                {
                    listOfStores.Add(store);
                }
                else
                {
                    // existingStore.chain = chain;
                    existingStore.chain_id = chain.chain_id;
                    existingStore.store_type = null;
                    existingStore.store_name = Store.Element("StoreName").Value;
                    existingStore.address = Store.Element("Address").Value;
                    existingStore.city = Store.Element("City").Value;
                }
            }
            return listOfStores;
        }

        //public void XmlToDB(FileInfo xmlFile , PriceCompareDBEntitie context)
        //{
        //    XDocument doc = XDocument.Load(xmlFile.FullName);
           
        //    foreach (XElement itemElement in doc.Root.Element("Items").Elements("Item"))
        //    {
        //        item item = new item();
        //        item.item_code = itemElement.Element("ItemCode").Value;
        //        item.item_type = itemElement.Element("ItemType").Value;
        //        item.item_name = itemElement.Element("ItemName").Value;
        //        item.manufacturer_name = itemElement.Element("ManufacturerName").Value;
        //        item.manufacturer_item_description = itemElement.Element("ManufacturerItemDescription").Value;
        //        item.unit_quantity = itemElement.Element("UnitQty").Value;
        //        item.quantity_in_package = itemElement.Element("Quantity").Value;
        //        context.items.Add(item);

        //    }
            

        //}


    }
}
