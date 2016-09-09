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
        public Dictionary<long, float> _chainRank = new Dictionary<long, float>();

        public price FindMinPriceForItemAndChain(item item , chain chain)
        {
            return _minPricesForAllChains[chain.chain_id].Find(x => x.item_code == item.item_code);
        }

        public List<price> GetMinimumPricesForChian(chain chain)
        {
            return _minPricesForAllChains[chain.chain_id];
        }
        
        public void FindTheMinPricesForAllChains() //1
        {
            _minPricesForAllChains.Clear();
            _chainRank.Clear();
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

            foreach (var chain in _dbManager.GetChains())
            {
                price minPrice;
                try
                {
                    minPrice = pricesForItem.Find(x => x.store.chain_id == chain.chain_id);
                }
                catch (NullReferenceException e)
                {
                    minPrice = null;
                }

                if (minPrice != null) 
                {
                    _chainRank[chain.chain_id] += (maxPrice.price1 - pricesForItem.Find(x => x.store.chain_id == chain.chain_id).price1);
                }
            }
        }

        public chain FindBestRank()
        {
            long bestRankChain = 0;
            float bestRank = 0 ;
            foreach (var pair in _chainRank)
            {
                if(pair.Value > bestRank)
                {
                    bestRank = pair.Value;
                    bestRankChain = pair.Key;
                }
            }

            return _dbManager.GetChains().Find(c => c.chain_id == bestRankChain);
        }

    }
}
