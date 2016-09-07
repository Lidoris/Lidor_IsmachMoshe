using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriceCompareModel;

namespace PriceCompareWinFormsUI
{
    public partial class MainForm : Form
    {
        public PriceCompareDBEntitie _db { get; } = new PriceCompareDBEntitie();
        public ShoppingCart shoppingCart { get; private set; } = new ShoppingCart();

        public MainForm()
        {
            InitializeComponent();
            _db.items.ToList().ForEach(i => itemslistBox.Items.Add(i));
            
        }

        private void itemsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.itemsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.priceCompareDBDataSet);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'priceCompareDBDataSet.prices' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'priceCompareDBDataSet.items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.priceCompareDBDataSet.items);
            // TODO: This line of code loads data into the 'priceCompareDBDataSet.items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.priceCompareDBDataSet.items);

        }

        private void AddItemButton_Click(object sender, EventArgs e)
        {

            shoppingCart.AddItemToShoppingCart((item)itemslistBox.SelectedItem);          

            UpdatingShoppingCartListBox();
        }

        public void UpdatingShoppingCartListBox()
        {
            shoppingCart.selectedItems.ForEach(i => shoppingCartListBox.Items.Add(i));
        }
    }
}
