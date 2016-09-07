using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareModel
{
    public class ShoppingCart : IEnumerable
    {
        public List<item> selectedItems { get; private set; } = new List<item>();
        public ShoppingCart()
        {
            selectedItems = new List<item>();
        }

        public void AddItemToShoppingCart(item item)
        {
            selectedItems.Add(item);
        }

        public IEnumerator GetEnumerator()
        {
            return selectedItems.GetEnumerator();
        }

        public void RemoveItemToShoppingCart(item item)
        {
            selectedItems.Remove(item);
        }
    }
}
