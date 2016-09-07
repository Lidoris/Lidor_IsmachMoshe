namespace PriceCompareWinFormsUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label item_nameLabel;
            System.Windows.Forms.Label manufacturer_nameLabel;
            System.Windows.Forms.Label manufacturer_item_descriptionLabel;
            System.Windows.Forms.Label unit_quantityLabel;
            System.Windows.Forms.Label quantity_in_packageLabel;
            this.priceCompareDBDataSet = new PriceCompareWinFormsUI.PriceCompareDBDataSet();
            this.shoppingCartBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AddItemButton = new System.Windows.Forms.Button();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemsTableAdapter = new PriceCompareWinFormsUI.PriceCompareDBDataSetTableAdapters.itemsTableAdapter();
            this.tableAdapterManager = new PriceCompareWinFormsUI.PriceCompareDBDataSetTableAdapters.TableAdapterManager();
            this.item_nameLabel1 = new System.Windows.Forms.Label();
            this.manufacturer_nameLabel1 = new System.Windows.Forms.Label();
            this.manufacturer_item_descriptionLabel1 = new System.Windows.Forms.Label();
            this.unit_quantityLabel1 = new System.Windows.Forms.Label();
            this.quantity_in_packageLabel1 = new System.Windows.Forms.Label();
            this.itemslistBox = new System.Windows.Forms.ListBox();
            this.shoppingCartListBox = new System.Windows.Forms.ListBox();
            item_nameLabel = new System.Windows.Forms.Label();
            manufacturer_nameLabel = new System.Windows.Forms.Label();
            manufacturer_item_descriptionLabel = new System.Windows.Forms.Label();
            unit_quantityLabel = new System.Windows.Forms.Label();
            quantity_in_packageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.priceCompareDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoppingCartBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // item_nameLabel
            // 
            item_nameLabel.AutoSize = true;
            item_nameLabel.Location = new System.Drawing.Point(20, 321);
            item_nameLabel.Name = "item_nameLabel";
            item_nameLabel.Size = new System.Drawing.Size(77, 17);
            item_nameLabel.TabIndex = 12;
            item_nameLabel.Text = "item name:";
            // 
            // manufacturer_nameLabel
            // 
            manufacturer_nameLabel.AutoSize = true;
            manufacturer_nameLabel.Location = new System.Drawing.Point(20, 344);
            manufacturer_nameLabel.Name = "manufacturer_nameLabel";
            manufacturer_nameLabel.Size = new System.Drawing.Size(135, 17);
            manufacturer_nameLabel.TabIndex = 14;
            manufacturer_nameLabel.Text = "manufacturer name:";
            // 
            // manufacturer_item_descriptionLabel
            // 
            manufacturer_item_descriptionLabel.AutoSize = true;
            manufacturer_item_descriptionLabel.Location = new System.Drawing.Point(20, 367);
            manufacturer_item_descriptionLabel.Name = "manufacturer_item_descriptionLabel";
            manufacturer_item_descriptionLabel.Size = new System.Drawing.Size(199, 17);
            manufacturer_item_descriptionLabel.TabIndex = 16;
            manufacturer_item_descriptionLabel.Text = "manufacturer item description:";
            // 
            // unit_quantityLabel
            // 
            unit_quantityLabel.AutoSize = true;
            unit_quantityLabel.Location = new System.Drawing.Point(20, 390);
            unit_quantityLabel.Name = "unit_quantityLabel";
            unit_quantityLabel.Size = new System.Drawing.Size(89, 17);
            unit_quantityLabel.TabIndex = 18;
            unit_quantityLabel.Text = "unit quantity:";
            // 
            // quantity_in_packageLabel
            // 
            quantity_in_packageLabel.AutoSize = true;
            quantity_in_packageLabel.Location = new System.Drawing.Point(20, 413);
            quantity_in_packageLabel.Name = "quantity_in_packageLabel";
            quantity_in_packageLabel.Size = new System.Drawing.Size(135, 17);
            quantity_in_packageLabel.TabIndex = 20;
            quantity_in_packageLabel.Text = "quantity in package:";
            // 
            // priceCompareDBDataSet
            // 
            this.priceCompareDBDataSet.DataSetName = "PriceCompareDBDataSet";
            this.priceCompareDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // shoppingCartBindingSource
            // 
            this.shoppingCartBindingSource.DataSource = typeof(PriceCompareModel.ShoppingCart);
            // 
            // AddItemButton
            // 
            this.AddItemButton.Location = new System.Drawing.Point(23, 441);
            this.AddItemButton.Name = "AddItemButton";
            this.AddItemButton.Size = new System.Drawing.Size(304, 33);
            this.AddItemButton.TabIndex = 12;
            this.AddItemButton.Text = "Add item to shopping cart -->";
            this.AddItemButton.UseVisualStyleBackColor = true;
            this.AddItemButton.Click += new System.EventHandler(this.AddItemButton_Click);
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataMember = "items";
            this.itemsBindingSource.DataSource = this.priceCompareDBDataSet;
            // 
            // itemsTableAdapter
            // 
            this.itemsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.chainsTableAdapter = null;
            this.tableAdapterManager.itemsTableAdapter = this.itemsTableAdapter;
            this.tableAdapterManager.pricesTableAdapter = null;
            this.tableAdapterManager.storesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = PriceCompareWinFormsUI.PriceCompareDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // item_nameLabel1
            // 
            this.item_nameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemsBindingSource, "item_name", true));
            this.item_nameLabel1.Location = new System.Drawing.Point(225, 321);
            this.item_nameLabel1.Name = "item_nameLabel1";
            this.item_nameLabel1.Size = new System.Drawing.Size(100, 23);
            this.item_nameLabel1.TabIndex = 13;
            this.item_nameLabel1.Text = "label1";
            // 
            // manufacturer_nameLabel1
            // 
            this.manufacturer_nameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemsBindingSource, "manufacturer_name", true));
            this.manufacturer_nameLabel1.Location = new System.Drawing.Point(225, 344);
            this.manufacturer_nameLabel1.Name = "manufacturer_nameLabel1";
            this.manufacturer_nameLabel1.Size = new System.Drawing.Size(100, 23);
            this.manufacturer_nameLabel1.TabIndex = 15;
            this.manufacturer_nameLabel1.Text = "label1";
            // 
            // manufacturer_item_descriptionLabel1
            // 
            this.manufacturer_item_descriptionLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemsBindingSource, "manufacturer_item_description", true));
            this.manufacturer_item_descriptionLabel1.Location = new System.Drawing.Point(225, 367);
            this.manufacturer_item_descriptionLabel1.Name = "manufacturer_item_descriptionLabel1";
            this.manufacturer_item_descriptionLabel1.Size = new System.Drawing.Size(100, 23);
            this.manufacturer_item_descriptionLabel1.TabIndex = 17;
            this.manufacturer_item_descriptionLabel1.Text = "label1";
            // 
            // unit_quantityLabel1
            // 
            this.unit_quantityLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemsBindingSource, "unit_quantity", true));
            this.unit_quantityLabel1.Location = new System.Drawing.Point(225, 390);
            this.unit_quantityLabel1.Name = "unit_quantityLabel1";
            this.unit_quantityLabel1.Size = new System.Drawing.Size(100, 23);
            this.unit_quantityLabel1.TabIndex = 19;
            this.unit_quantityLabel1.Text = "label1";
            // 
            // quantity_in_packageLabel1
            // 
            this.quantity_in_packageLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemsBindingSource, "quantity_in_package", true));
            this.quantity_in_packageLabel1.Location = new System.Drawing.Point(225, 413);
            this.quantity_in_packageLabel1.Name = "quantity_in_packageLabel1";
            this.quantity_in_packageLabel1.Size = new System.Drawing.Size(100, 23);
            this.quantity_in_packageLabel1.TabIndex = 21;
            this.quantity_in_packageLabel1.Text = "label1";
            // 
            // itemslistBox
            // 
            this.itemslistBox.DataSource = this.itemsBindingSource;
            this.itemslistBox.DisplayMember = "item_name";
            this.itemslistBox.FormattingEnabled = true;
            this.itemslistBox.ItemHeight = 16;
            this.itemslistBox.Location = new System.Drawing.Point(23, 42);
            this.itemslistBox.Name = "itemslistBox";
            this.itemslistBox.Size = new System.Drawing.Size(290, 260);
            this.itemslistBox.TabIndex = 22;
            // 
            // shoppingCartListBox
            // 
            this.shoppingCartListBox.FormattingEnabled = true;
            this.shoppingCartListBox.ItemHeight = 16;
            this.shoppingCartListBox.Location = new System.Drawing.Point(377, 42);
            this.shoppingCartListBox.Name = "shoppingCartListBox";
            this.shoppingCartListBox.Size = new System.Drawing.Size(255, 292);
            this.shoppingCartListBox.TabIndex = 23;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 511);
            this.Controls.Add(this.shoppingCartListBox);
            this.Controls.Add(this.itemslistBox);
            this.Controls.Add(item_nameLabel);
            this.Controls.Add(this.item_nameLabel1);
            this.Controls.Add(manufacturer_nameLabel);
            this.Controls.Add(this.manufacturer_nameLabel1);
            this.Controls.Add(manufacturer_item_descriptionLabel);
            this.Controls.Add(this.manufacturer_item_descriptionLabel1);
            this.Controls.Add(unit_quantityLabel);
            this.Controls.Add(this.unit_quantityLabel1);
            this.Controls.Add(quantity_in_packageLabel);
            this.Controls.Add(this.quantity_in_packageLabel1);
            this.Controls.Add(this.AddItemButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.priceCompareDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoppingCartBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PriceCompareDBDataSet priceCompareDBDataSet;
        private System.Windows.Forms.BindingSource shoppingCartBindingSource;
        private System.Windows.Forms.Button AddItemButton;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private PriceCompareDBDataSetTableAdapters.itemsTableAdapter itemsTableAdapter;
        private PriceCompareDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label item_nameLabel1;
        private System.Windows.Forms.Label manufacturer_nameLabel1;
        private System.Windows.Forms.Label manufacturer_item_descriptionLabel1;
        private System.Windows.Forms.Label unit_quantityLabel1;
        private System.Windows.Forms.Label quantity_in_packageLabel1;
        private System.Windows.Forms.ListBox itemslistBox;
        private System.Windows.Forms.ListBox shoppingCartListBox;
    }
}

