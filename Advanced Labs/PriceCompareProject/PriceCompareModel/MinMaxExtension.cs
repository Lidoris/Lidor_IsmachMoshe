using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareModel
{
    static class MinMaxExtension
    {
        static public price Minimum(this List<price> listOfPrices)
        {
            price minPrice = listOfPrices[0];
            foreach (var price in listOfPrices)
            {
                if (price != null)
                {
                    if (price.price1 < minPrice.price1)
                    {
                        minPrice = price;
                    }
                }
            }

            return minPrice;
        }

        static public price Maximum (this List<price> listOfPrices)
        {
            float max = 0;
            price maxPrice = null;
            foreach (var price in listOfPrices)
            {
                if (price != null)
                {
                    if (price.price1 > max)
                    {
                        max = price.price1;
                        maxPrice = price;
                    }
                }
            }

            return maxPrice;
        }
    }
}
