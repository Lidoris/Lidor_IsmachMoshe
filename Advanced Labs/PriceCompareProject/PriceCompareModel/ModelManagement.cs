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
        public DBManager _dbManager { get; private set; } = new DBManager();
        public ShoppingCart _shoppingCart { get; private set; } = new ShoppingCart();
        public Dictionary<long, List<price>> _minPricesForAllChains { get; private set; } = new Dictionary<long, List<price>>();
        public Dictionary<long, float> _chainRank { get; private set; } = new Dictionary<long, float>();

        public price FindMinPriceForItemAndChain(item item, chain chain)
        {
            price minPrice; 

            if (chain != null)
            {
                minPrice = _minPricesForAllChains[chain.chain_id].Find(x => x.item_code == item.item_code);
            }
            else
            {
                minPrice = null;
            }

            return minPrice;
        }

        public List<price> GetMinimumPricesForChian(chain chain)
        {
            return _minPricesForAllChains[chain.chain_id];
        }
        
        public void FindTheMinPricesForAllChains()
        {
            List<price> allPricesForCurChain;

            _minPricesForAllChains.Clear();
            _chainRank.Clear();
            
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

        public void UpdateChainRank(item item) // Chain Rank helps us decide which chain is the best
        {
            List<price> pricesForItem = new List<price>();

            foreach (var pair in _minPricesForAllChains)
            {
                price price = pair.Value.Find(x => x.item_code == item.item_code);
                if (price != null)
                {
                    pricesForItem.Add(price);
                }
             }

            price maxPrice = pricesForItem.Maximum();

            foreach (var chain in _dbManager.GetChains())
            {
                price curPrice = pricesForItem.Find(x => x.store.chain_id == chain.chain_id);
                
                if (curPrice != null) 
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

        public List<string> FindMissingItemsInCart(chain chain)
        {
            List<string> listOfMissingItems = new List<string>();
            foreach (var item in _shoppingCart.selectedItems)
            {
                if (_minPricesForAllChains[chain.chain_id].Find(x=> x.item_code == item.item_code)== null)
                {
                    if (!listOfMissingItems.Contains(item.item_name))
                    {
                        listOfMissingItems.Add(item.item_name);
                    }
                }
            }
            
            return listOfMissingItems;
        }

        public float TotalCartPrice(chain chain)
        {
            float sum = 0;
            foreach (var price in _minPricesForAllChains[chain.chain_id])
            {
                sum += price.price1;
            }

            return sum;
        }
    }
}
