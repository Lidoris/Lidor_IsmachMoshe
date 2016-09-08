using PriceCompareModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class MainForm : Form
    {
        ModelManagement _model = new ModelManagement();
        
        public MainForm()
        {
            InitializeComponent();

            //manager.PopulateDB();
            //List<item> listToDelete = _model.ItemsNotInAllChains();
            //foreach (var item in listToDelete)
            //{
            //    _model._manager.context.items.Remove(item);
            //    _model._manager.context.SaveChanges();
            //}
            itemsComboBox.DataSource = _model._dbManager.GetItems();
            shoppingCartListBox.DataSource = _model._shoppingCart.selectedItems;
            
        }

        private void AddItemButton_Click(object sender, EventArgs e)
        {
            int amountOfItem;
            item selectedItem = (item)itemsComboBox.SelectedItem;
            if (int.TryParse(amountComboBox.SelectedItem.ToString(), out amountOfItem))
            {
                for (int i = 0; i < amountOfItem; i++)
                {
                    _model._shoppingCart.AddItemToShoppingCart(selectedItem);
                }
            }
        }
        
        private void CompareButton_Click(object sender, EventArgs e)
        {
            _model.FindTheMinPricesForAllChains();
            //DisplayCartForChain()

        }
        private void DisplayCartForChain(chain chain)
        {
            foreach (var item in _model._shoppingCart.selectedItems)
            {
                Label itemLabel = new Label();
                Label priceLabel = new Label();

                tableLayoutPanel.RowCount = 4;
            }
        }

        private void itemsComboBox_TextUpdate(object sender, EventArgs e)
        {
            itemsComboBox.DroppedDown = true;
        }

        private void itemsComboBox_Leave(object sender, EventArgs e)
        {
            itemsComboBox.SelectedIndex = itemsComboBox.FindString(itemsComboBox.Text);
        }

        private void resetShoppingCartButton_Click(object sender, EventArgs e)
        {
            _model._shoppingCart.ResetShoppingCart();
        }

        
        private void deleteItemButton_Click(object sender, EventArgs e)
        {
            if (shoppingCartListBox.SelectedItem!= null)
            {
                _model._shoppingCart.RemoveItemToShoppingCart(shoppingCartListBox.SelectedItem as item);
            }
            else
            {
                MessageBox.Show("יש לבחור פריט לצורך מחיקה");
            }
        }
    }
}
