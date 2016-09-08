using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.IO.Compression;
using System.Xml.Linq;
using System.Collections;

namespace PriceCompareModel
{
    public class DBManager
    {
        public PriceCompareDBEntitie _context;

        public DBManager()
        {
            _context = new PriceCompareDBEntitie();
        }
        
        public List<item> GetItems()
        {
            return _context.items.ToList();
        }

        public List<chain> GetChains()
        {
            return _context.chains.ToList();
        }
        public List<price> GetPrices()
        {
            return _context.prices.ToList();
        }
        public List<store> GetStores()
        {
            return _context.stores.ToList();
        }

        public void DecompressAllFiles()
        {
            DirectoryInfo allPrices = new DirectoryInfo(@"C:\finalProject_PriceCompare\AllPrices\bin\prices");
            foreach (var subDirectories in allPrices.GetDirectories())
            {
                foreach (var file in subDirectories.GetFiles())
                {
                    if ((file.Name.StartsWith("PriceFull") || file.Name.StartsWith("PricesFull")) && (file.Extension == ".gz" || file.Extension == ".zip") && !subDirectories.GetFiles(file.Name.Remove(file.Name.Length - file.Extension.Length) + ".xml").Any())
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
           // using (PriceCompareDBEntitie context = new PriceCompareDBEntitie())
            //{
                chain curChain;
                List<store> listOfStores = new List<store>();
                List<item> listOfItems = new List<item>();
                List<price> listOfPrices = new List<price>();
                DirectoryInfo allPrices = new DirectoryInfo(@"C:\finalProject_PriceCompare\AllPrices\bin\prices");
                allPrices.GetDirectories();
                foreach (var subDirectory in allPrices.GetDirectories())
                {
                    DecompressAllFiles();

                    if (subDirectory.Name == "logs" )
                    {
                        continue;
                    }

                    string StoreFilePath = subDirectory.GetFiles().Where(t => t.Name.StartsWith("Stores")).Single().FullName;
                    XDocument storesDoc = XDocument.Load(StoreFilePath);

                    curChain = ChainToDB(storesDoc, _context);
                    chain existingChain = _context.chains.FirstOrDefault(c => c.chain_id == curChain.chain_id);
                    _context.SaveChanges();

                    if (existingChain == null)
                    {
                        _context.chains.Add(curChain);
                    }

                    listOfStores = StoresToDB(storesDoc, _context, curChain);
                    listOfStores.ForEach(s =>
                    {
                        _context.stores.Add(s);
                        _context.SaveChanges();
                    });

                    FileInfo[] priceFullXmlFiles = subDirectory.GetFiles("PriceFull*.xml");
                    foreach (var file in priceFullXmlFiles)
                    {
                        listOfItems = ItemsToDB(file, _context);
                        foreach (item item in listOfItems)
                        {
                            var existingItem = _context.items.FirstOrDefault(i => i.item_code == item.item_code);
                            if (existingItem == null)
                            {
                                _context.items.Add(item);
                                _context.SaveChanges();
                            }

                        }
                    }

                    foreach (var file in priceFullXmlFiles)
                    {
                        listOfPrices = PricesToDB(file, _context);
                        foreach (price price in listOfPrices)
                        {
                            var existingPrice = _context.prices.FirstOrDefault(p => p.item_code == price.item_code && p.store_key == price.store_key);
                            if (existingPrice == null)
                            {
                                _context.prices.Add(price);
                                _context.SaveChanges();
                            }
                        }
                   // }
               }
            }
        }
    
        private chain ChainToDB(XDocument storesDoc, PriceCompareDBEntitie context)
        {
            XElement root = storesDoc.Root;
            chain chain = new chain();

            long chain_id;
            long.TryParse(root.Element("ChainId").Value, out chain_id);
            chain.chain_id = chain_id;
            chain.chain_name = root.Element("ChainName").Value;

            return chain;
        }

        private List<store> StoresToDB(XDocument storesDoc, PriceCompareDBEntitie context, chain chain)
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
                    existingStore.chain_id = chain.chain_id;
                    existingStore.store_type = null;
                    existingStore.store_name = Store.Element("StoreName").Value;
                    existingStore.address = Store.Element("Address").Value;
                    existingStore.city = Store.Element("City").Value;
                }
            }

            return listOfStores;
        }

        private List<item> ItemsToDB(FileInfo xmlFile, PriceCompareDBEntitie context)
        {
            XDocument doc = XDocument.Load(xmlFile.FullName);
            List<item> listOfItems = new List<item>();
            long item_code;

            foreach (XElement itemElement in doc.Root.Element("Items").Elements("Item"))
            {
                item item = new item();
                long.TryParse(itemElement.Element("ItemCode").Value, out item_code);
                item.item_code = item_code;
                item.item_type = itemElement.Element("ItemType").Value;
                item.item_name = itemElement.Element("ItemName").Value;
                item.manufacturer_name = itemElement.Element("ManufacturerName").Value;
                item.manufacturer_item_description = itemElement.Element("ManufacturerItemDescription").Value;
                item.unit_quantity = itemElement.Element("UnitQty").Value;
                item.quantity_in_package = itemElement.Element("Quantity").Value;

                var existingItem = context.items.FirstOrDefault(i => i.item_code == item.item_code);
                if (existingItem == null )
                {
                    listOfItems.Add(item);
                }
                else
                {
                    existingItem.item_type = itemElement.Element("ItemType").Value;
                    existingItem.item_name = itemElement.Element("ItemName").Value;
                    existingItem.manufacturer_name = itemElement.Element("ManufacturerName").Value;
                    existingItem.manufacturer_item_description = itemElement.Element("ManufacturerItemDescription").Value;
                    existingItem.unit_quantity = itemElement.Element("UnitQty").Value;
                    existingItem.quantity_in_package = itemElement.Element("Quantity").Value;
                }
            }

            return listOfItems;
        }

        private List<price> PricesToDB(FileInfo xmlFile, PriceCompareDBEntitie context)
        {
            XDocument doc = XDocument.Load(xmlFile.FullName);
            List<price> listOfPrices = new List<price>();
            long chain_id;
            long item_code;
            int store_id;
            float priceOfItem;

            foreach (XElement itemElement in doc.Root.Element("Items").Elements("Item"))
            {
                long.TryParse(itemElement.Element("ItemCode").Value, out item_code);
                long.TryParse(doc.Root.Element("ChainId").Value, out chain_id);
                var existingItem = context.items.FirstOrDefault(i => i.item_code == item_code );
                if (existingItem != null)
                {
                    price price = new price();
                    price.item_code = existingItem.item_code;
                    int.TryParse(doc.Root.Element("StoreId").Value, out store_id);
                    var existingStore = context.stores.FirstOrDefault(s => s.store_id == store_id && s.chain_id == chain_id);
                    price.store_key = existingStore.store_key;
                    float.TryParse(itemElement.Element("ItemPrice").Value, out priceOfItem);
                    price.price1 = priceOfItem;
                    //var existingPrice = context.prices.FirstOrDefault(p => p.item_code == price.item_code &&  p.store_key == price.store_key);
                    //if (existingPrice == null)
                    //{
                        listOfPrices.Add(price);
                    //}
                }
            }

            return listOfPrices;
        }
    }
}