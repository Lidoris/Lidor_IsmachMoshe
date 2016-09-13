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

            //_model._dbManager.PopulateDB();
           
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
            if (!_model._shoppingCart.selectedItems.Any())
            {
                MessageBox.Show("נא הכנס פריטים לסל לצורך החישוב");
            }
            else
            {
                _model.FindTheMinPricesForAllChains();
                chain bestRankChain = _model.FindBestRank();
                if (bestRankChain != null)
                {
                    bestChainLabel.ForeColor = Color.CadetBlue;
                    bestChainLabel.Text = "הרשת המשתלמת ביותר לסל זה היא " + bestRankChain.chain_name;
                    bestChainLabel.Left = this.Width / 2 - bestChainLabel.Width / 2;
                }
                else
                {
                    bestChainLabel.ForeColor = Color.Red;
                    bestChainLabel.Text = "לא נמצאה רשת מומלצת לסל קניות זה";
                }

                this.Height = 750;
                CreateResultTabControl();
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

        private void shoppingCartListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            detailsItemListBox.Items.Clear();
            item selectedItem;
            if((item)shoppingCartListBox.SelectedItem != null)
            {
                selectedItem = (item)shoppingCartListBox.SelectedItem;
                detailsItemListBox.Items.Add("שם המוצר : " + selectedItem.item_name);
                detailsItemListBox.Items.Add("ברקוד : " + selectedItem.item_code);
                detailsItemListBox.Items.Add("יצרן : " + selectedItem.manufacturer_name);
                detailsItemListBox.Items.Add("תיאור : " + selectedItem.manufacturer_item_description);
                detailsItemListBox.Items.Add("כמות באריזה : " + selectedItem.quantity_in_package + selectedItem.unit_quantity);
                detailsItemListBox.Visible = true;
                detailsItemGroupBox.Visible = true;
            }
            else
            {
                detailsItemListBox.Visible = false;
                detailsItemGroupBox.Visible = false;
            }
        }

        private void CreateResultTabControl()
        {
            Label totalCartPriceLabel;
            List<item> missingItems;
            resultTabControl.Controls.Clear();

            foreach (var chain in _model._dbManager.GetChains())
            {
                totalCartPriceLabel = new Label();
                resultTabControl.Controls.Add(new TabPage() { Name = chain.chain_name, Text = chain.chain_name, RightToLeft = RightToLeft.Yes });

                var dataGridView = new DataGridView() { DataSource = _model._minPricesForAllChains[chain.chain_id] };
                dataGridView.Width = resultTabControl.Width - 10;
                dataGridView.Height = resultTabControl.Height - 100;
                dataGridView.DataBindingComplete += dataGridView_DataBindingComplete;
                resultTabControl.Controls[chain.chain_name].Controls.Add(dataGridView);

                missingItems = _model.FindMissingItemsInCart(chain);
                if (missingItems.Count > 0)
                {
                    Label missingItemsLabel = new Label();

                    StringBuilder builder = new StringBuilder(" שים לב! ישנם מוצרים החסרים בסל זה : ");
                    foreach (var item in missingItems)
                    {
                        builder.Append(item.item_name + " ");
                    }

                    missingItemsLabel.Text = builder.ToString();
                    resultTabControl.Controls[chain.chain_name].Controls.Add(missingItemsLabel);
                    missingItemsLabel.Top = dataGridView.Height;
                    missingItemsLabel.AutoSize = true;
                    missingItemsLabel.Left = dataGridView.Right - missingItemsLabel.Width;
                }

                totalCartPriceLabel.Text = "מחיר סופי : " + _model.TotalCartPrice(chain) + " שח ";
                resultTabControl.Controls[chain.chain_name].Controls.Add(totalCartPriceLabel);
                totalCartPriceLabel.Top = 180;
                totalCartPriceLabel.AutoSize = true;
                totalCartPriceLabel.Font = new Font("Arial", 14F);
            }
        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (sender is DataGridView)
            {
                var dataGridView = sender as DataGridView;
                dataGridView.Columns["store"].Visible = false;
                dataGridView.Columns["store_key"].Visible = false;
                dataGridView.Columns["item_code"].HeaderText = "ברקוד";
                dataGridView.Columns["price1"].HeaderText = "מחיר";
                dataGridView.Columns["item"].HeaderText = "מוצר";
                dataGridView.Columns["item"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
