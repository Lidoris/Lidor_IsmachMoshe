namespace UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.AddItemButton = new System.Windows.Forms.Button();
            this.shoppingCartListBox = new System.Windows.Forms.ListBox();
            this.CompareButton = new System.Windows.Forms.Button();
            this.itemsComboBox = new System.Windows.Forms.ComboBox();
            this.chooseItemLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.amountComboBox = new System.Windows.Forms.ComboBox();
            this.resetShoppingCartButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.deleteItemButton = new System.Windows.Forms.Button();
            this.bestChainLabel = new System.Windows.Forms.Label();
            this.detailsItemGroupBox = new System.Windows.Forms.GroupBox();
            this.detailsItemListBox = new System.Windows.Forms.ListBox();
            this.resultTabControl = new System.Windows.Forms.TabControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.modelManagementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.detailsItemGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelManagementBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // AddItemButton
            // 
            this.AddItemButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.AddItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddItemButton.Location = new System.Drawing.Point(132, 60);
            this.AddItemButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddItemButton.Name = "AddItemButton";
            this.AddItemButton.Size = new System.Drawing.Size(149, 29);
            this.AddItemButton.TabIndex = 1;
            this.AddItemButton.Text = "הוסף פריט לסל";
            this.AddItemButton.UseVisualStyleBackColor = false;
            this.AddItemButton.Click += new System.EventHandler(this.AddItemButton_Click);
            // 
            // shoppingCartListBox
            // 
            this.shoppingCartListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.shoppingCartListBox.FormattingEnabled = true;
            this.shoppingCartListBox.ItemHeight = 17;
            this.shoppingCartListBox.Location = new System.Drawing.Point(398, 122);
            this.shoppingCartListBox.Margin = new System.Windows.Forms.Padding(4);
            this.shoppingCartListBox.Name = "shoppingCartListBox";
            this.shoppingCartListBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.shoppingCartListBox.Size = new System.Drawing.Size(250, 119);
            this.shoppingCartListBox.TabIndex = 2;
            this.shoppingCartListBox.SelectedIndexChanged += new System.EventHandler(this.shoppingCartListBox_SelectedIndexChanged);
            // 
            // CompareButton
            // 
            this.CompareButton.BackColor = System.Drawing.SystemColors.Control;
            this.CompareButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CompareButton.Location = new System.Drawing.Point(220, 318);
            this.CompareButton.Margin = new System.Windows.Forms.Padding(4);
            this.CompareButton.Name = "CompareButton";
            this.CompareButton.Size = new System.Drawing.Size(127, 52);
            this.CompareButton.TabIndex = 4;
            this.CompareButton.Text = "חשב מחירים";
            this.CompareButton.UseVisualStyleBackColor = false;
            this.CompareButton.Click += new System.EventHandler(this.CompareButton_Click);
            // 
            // itemsComboBox
            // 
            this.itemsComboBox.FormattingEnabled = true;
            this.itemsComboBox.Location = new System.Drawing.Point(478, 62);
            this.itemsComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.itemsComboBox.Name = "itemsComboBox";
            this.itemsComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.itemsComboBox.Size = new System.Drawing.Size(200, 25);
            this.itemsComboBox.TabIndex = 5;
            this.itemsComboBox.TextUpdate += new System.EventHandler(this.itemsComboBox_TextUpdate);
            this.itemsComboBox.Leave += new System.EventHandler(this.itemsComboBox_Leave);
            // 
            // chooseItemLabel
            // 
            this.chooseItemLabel.AutoSize = true;
            this.chooseItemLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chooseItemLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.chooseItemLabel.Location = new System.Drawing.Point(681, 62);
            this.chooseItemLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.chooseItemLabel.Name = "chooseItemLabel";
            this.chooseItemLabel.Size = new System.Drawing.Size(97, 24);
            this.chooseItemLabel.TabIndex = 6;
            this.chooseItemLabel.Text = "בחר פריט:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(370, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "בחר כמות:";
            // 
            // amountComboBox
            // 
            this.amountComboBox.FormattingEnabled = true;
            this.amountComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.amountComboBox.Location = new System.Drawing.Point(326, 62);
            this.amountComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.amountComboBox.Name = "amountComboBox";
            this.amountComboBox.Size = new System.Drawing.Size(42, 25);
            this.amountComboBox.TabIndex = 8;
            this.amountComboBox.Text = "1";
            // 
            // resetShoppingCartButton
            // 
            this.resetShoppingCartButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.resetShoppingCartButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.resetShoppingCartButton.Location = new System.Drawing.Point(36, 60);
            this.resetShoppingCartButton.Margin = new System.Windows.Forms.Padding(4);
            this.resetShoppingCartButton.Name = "resetShoppingCartButton";
            this.resetShoppingCartButton.Size = new System.Drawing.Size(91, 29);
            this.resetShoppingCartButton.TabIndex = 11;
            this.resetShoppingCartButton.Text = "רוקן סל קניות";
            this.resetShoppingCartButton.UseVisualStyleBackColor = false;
            this.resetShoppingCartButton.Click += new System.EventHandler(this.resetShoppingCartButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(67, 4);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Controls.Add(this.AddItemButton);
            this.panel1.Controls.Add(this.amountComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.itemsComboBox);
            this.panel1.Controls.Add(this.resetShoppingCartButton);
            this.panel1.Controls.Add(this.chooseItemLabel);
            this.panel1.Location = new System.Drawing.Point(-7, -30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 106);
            this.panel1.TabIndex = 12;
            // 
            // deleteItemButton
            // 
            this.deleteItemButton.BackColor = System.Drawing.SystemColors.Control;
            this.deleteItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteItemButton.Location = new System.Drawing.Point(128, 318);
            this.deleteItemButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteItemButton.Name = "deleteItemButton";
            this.deleteItemButton.Size = new System.Drawing.Size(84, 52);
            this.deleteItemButton.TabIndex = 13;
            this.deleteItemButton.Text = "מחק פריט";
            this.deleteItemButton.UseVisualStyleBackColor = false;
            this.deleteItemButton.Click += new System.EventHandler(this.deleteItemButton_Click);
            // 
            // bestChainLabel
            // 
            this.bestChainLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bestChainLabel.AutoSize = true;
            this.bestChainLabel.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.bestChainLabel.ForeColor = System.Drawing.Color.CadetBlue;
            this.bestChainLabel.Location = new System.Drawing.Point(116, 387);
            this.bestChainLabel.Name = "bestChainLabel";
            this.bestChainLabel.Size = new System.Drawing.Size(0, 38);
            this.bestChainLabel.TabIndex = 14;
            this.bestChainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // detailsItemGroupBox
            // 
            this.detailsItemGroupBox.Controls.Add(this.detailsItemListBox);
            this.detailsItemGroupBox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.detailsItemGroupBox.ForeColor = System.Drawing.Color.CadetBlue;
            this.detailsItemGroupBox.Location = new System.Drawing.Point(40, 136);
            this.detailsItemGroupBox.Name = "detailsItemGroupBox";
            this.detailsItemGroupBox.Size = new System.Drawing.Size(243, 148);
            this.detailsItemGroupBox.TabIndex = 17;
            this.detailsItemGroupBox.TabStop = false;
            this.detailsItemGroupBox.Text = "פרטי המוצר";
            this.detailsItemGroupBox.Visible = false;
            // 
            // detailsItemListBox
            // 
            this.detailsItemListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailsItemListBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.detailsItemListBox.FormattingEnabled = true;
            this.detailsItemListBox.ItemHeight = 17;
            this.detailsItemListBox.Location = new System.Drawing.Point(6, 24);
            this.detailsItemListBox.Name = "detailsItemListBox";
            this.detailsItemListBox.Size = new System.Drawing.Size(231, 119);
            this.detailsItemListBox.TabIndex = 0;
            this.detailsItemListBox.Visible = false;
            // 
            // resultTabControl
            // 
            this.resultTabControl.Location = new System.Drawing.Point(99, 430);
            this.resultTabControl.Name = "resultTabControl";
            this.resultTabControl.RightToLeftLayout = true;
            this.resultTabControl.SelectedIndex = 0;
            this.resultTabControl.Size = new System.Drawing.Size(598, 250);
            this.resultTabControl.TabIndex = 19;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(354, 82);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(407, 288);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // modelManagementBindingSource
            // 
            this.modelManagementBindingSource.DataSource = typeof(PriceCompareModel.ModelManagement);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(780, 404);
            this.Controls.Add(this.resultTabControl);
            this.Controls.Add(this.detailsItemGroupBox);
            this.Controls.Add(this.bestChainLabel);
            this.Controls.Add(this.deleteItemButton);
            this.Controls.Add(this.CompareButton);
            this.Controls.Add(this.shoppingCartListBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "השוואת מחירים";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.detailsItemGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelManagementBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddItemButton;
        private System.Windows.Forms.ListBox shoppingCartListBox;
        private System.Windows.Forms.Button CompareButton;
        private System.Windows.Forms.ComboBox itemsComboBox;
        private System.Windows.Forms.Label chooseItemLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox amountComboBox;
        private System.Windows.Forms.Button resetShoppingCartButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button deleteItemButton;
        private System.Windows.Forms.Label bestChainLabel;
        private System.Windows.Forms.GroupBox detailsItemGroupBox;
        private System.Windows.Forms.ListBox detailsItemListBox;
        private System.Windows.Forms.BindingSource modelManagementBindingSource;
        private System.Windows.Forms.TabControl resultTabControl;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

