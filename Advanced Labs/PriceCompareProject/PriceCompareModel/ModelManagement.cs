using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareModel
{
    public class ModelManagement
    {
        public DBManager _dbManager = new DBManager();
        public ShoppingCart _shoppingCart = new ShoppingCart();
        public Dictionary<long, List<price>> _minPricesForAllChains = new Dictionary<long, List<price>>(); // לשנות הרשאות גישה
        Dictionary<long, float> _chainRank = new Dictionary<long, float>();

        public List<price> GetMinimumPricesForChian(chain chain)
        {
            return _minPricesForAllChains[chain.chain_id];
        }

        public List<item> ItemsNotInAllChains()// למחוק
        {
            List<item> list = new List<item>();

            foreach (var item in _dbManager._context.items)
            {
                if(!IsItemInAllChains(item))
                {
                    list.Add(item);
                }
            }
            return list;
            
        }

        public bool IsItemInAllChains(item item)
        {
            foreach (var chain in _dbManager._context.chains)
            {
                if (!IsItemInChain(item, chain))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsItemInChain(item item , chain chain) // למחוק
        {
            foreach (var price in item.prices)
            {
                if (price.store.chain_id == chain.chain_id)
                    return true;
            }
            return false;
        }

        public void FindTheMinPricesForAllChains() //1
        {
            List<price> allPricesForCurChain;
            foreach (var chain in _dbManager.GetChains())
            {
                _minPricesForAllChains.Add(chain.chain_id, new List<price>());
                foreach (var item in _shoppingCart.selectedItems)
                {
                    allPricesForCurChain = new List<price>();
                    foreach (var price in item.prices)// adding all prices for the current chain in the list
                    {
                        if(price.store.chain_id == chain.chain_id)
                        {
                            allPricesForCurChain.Add(price); 
                        }
                    }

                    if (allPricesForCurChain.Any()) //if there is at least one item
                    {
                        _minPricesForAllChains[chain.chain_id].Add(allPricesForCurChain.Minimum()); // adding the minimun price to the final list
                    }
                    //else
                    //{

                    //}
                }
            }

            InitChainRank();
            foreach (var item in _shoppingCart.selectedItems)
            {
                UpdateChainRank(item);
            }
        }

        public void InitChainRank()
        {
            foreach(var chain in _dbManager.GetChains())
            {
                _chainRank.Add(chain.chain_id, 0);
            }
        }

        public void UpdateChainRank(item item) // עידכון דרוג 2
        {
            List<price> pricesForItem = new List<price>();

            foreach (var pair in _minPricesForAllChains)
            {
                pricesForItem.Add(pair.Value.Find(x => x.item_code == item.item_code));

             }

            price maxPrice = pricesForItem.Maximum();

            foreach(var chain in _dbManager.GetChains())
            {
                _chainRank[chain.chain_id] += (maxPrice.price1 - pricesForItem.Find(x => x.store.chain_id == chain.chain_id).price1) ;
            }
        }


    }
}
