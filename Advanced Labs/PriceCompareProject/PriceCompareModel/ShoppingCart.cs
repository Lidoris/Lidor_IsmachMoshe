using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareModel
{
    public class ShoppingCart 
    {
        public BindingList<item> selectedItems { get; private set; } = new BindingList<item>();
        
        public void AddItemToShoppingCart(item item)
        {
            selectedItems.Add(item);
        }
        
        public void RemoveItemToShoppingCart(item item)
        {
            selectedItems.Remove(item);
        }

        public void ResetShoppingCart()
        {
            selectedItems.Clear();
        }

    }
}
