﻿namespace UI
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
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddItemButton
            // 
            this.AddItemButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.AddItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddItemButton.Location = new System.Drawing.Point(121, 27);
            this.AddItemButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddItemButton.Name = "AddItemButton";
            this.AddItemButton.Size = new System.Drawing.Size(112, 32);
            this.AddItemButton.TabIndex = 1;
            this.AddItemButton.Text = "הוסף פריט לסל";
            this.AddItemButton.UseVisualStyleBackColor = false;
            this.AddItemButton.Click += new System.EventHandler(this.AddItemButton_Click);
            // 
            // shoppingCartListBox
            // 
            this.shoppingCartListBox.FormattingEnabled = true;
            this.shoppingCartListBox.ItemHeight = 17;
            this.shoppingCartListBox.Location = new System.Drawing.Point(218, 100);
            this.shoppingCartListBox.Margin = new System.Windows.Forms.Padding(4);
            this.shoppingCartListBox.Name = "shoppingCartListBox";
            this.shoppingCartListBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.shoppingCartListBox.Size = new System.Drawing.Size(409, 191);
            this.shoppingCartListBox.TabIndex = 2;
            // 
            // CompareButton
            // 
            this.CompareButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CompareButton.Location = new System.Drawing.Point(148, 226);
            this.CompareButton.Margin = new System.Windows.Forms.Padding(4);
            this.CompareButton.Name = "CompareButton";
            this.CompareButton.Size = new System.Drawing.Size(108, 55);
            this.CompareButton.TabIndex = 4;
            this.CompareButton.Text = "חשב מחירים";
            this.CompareButton.UseVisualStyleBackColor = true;
            this.CompareButton.Click += new System.EventHandler(this.CompareButton_Click);
            // 
            // itemsComboBox
            // 
            this.itemsComboBox.FormattingEnabled = true;
            this.itemsComboBox.Location = new System.Drawing.Point(416, 32);
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
            this.chooseItemLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chooseItemLabel.Location = new System.Drawing.Point(624, 34);
            this.chooseItemLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.chooseItemLabel.Name = "chooseItemLabel";
            this.chooseItemLabel.Size = new System.Drawing.Size(78, 19);
            this.chooseItemLabel.TabIndex = 6;
            this.chooseItemLabel.Text = "בחר פריט:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(313, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
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
            this.amountComboBox.Location = new System.Drawing.Point(241, 30);
            this.amountComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.amountComboBox.Name = "amountComboBox";
            this.amountComboBox.Size = new System.Drawing.Size(64, 25);
            this.amountComboBox.TabIndex = 8;
            this.amountComboBox.Text = "1";
            // 
            // resetShoppingCartButton
            // 
            this.resetShoppingCartButton.BackColor = System.Drawing.SystemColors.Control;
            this.resetShoppingCartButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.resetShoppingCartButton.Location = new System.Drawing.Point(148, 191);
            this.resetShoppingCartButton.Margin = new System.Windows.Forms.Padding(4);
            this.resetShoppingCartButton.Name = "resetShoppingCartButton";
            this.resetShoppingCartButton.Size = new System.Drawing.Size(108, 29);
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
            this.panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel1.Controls.Add(this.AddItemButton);
            this.panel1.Controls.Add(this.amountComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.itemsComboBox);
            this.panel1.Controls.Add(this.chooseItemLabel);
            this.panel1.Location = new System.Drawing.Point(-4, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 81);
            this.panel1.TabIndex = 12;
            // 
            // deleteItemButton
            // 
            this.deleteItemButton.BackColor = System.Drawing.SystemColors.Control;
            this.deleteItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteItemButton.Location = new System.Drawing.Point(148, 154);
            this.deleteItemButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteItemButton.Name = "deleteItemButton";
            this.deleteItemButton.Size = new System.Drawing.Size(108, 29);
            this.deleteItemButton.TabIndex = 13;
            this.deleteItemButton.Text = "מחק פריט";
            this.deleteItemButton.UseVisualStyleBackColor = false;
            this.deleteItemButton.Click += new System.EventHandler(this.deleteItemButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.ForeColor = System.Drawing.Color.OliveDrab;
            this.label2.Location = new System.Drawing.Point(391, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 39);
            this.label2.TabIndex = 14;
            this.label2.Text = "v";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.08316F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.91684F));
            this.tableLayoutPanel.Location = new System.Drawing.Point(194, 403);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(457, 67);
            this.tableLayoutPanel.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(845, 699);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deleteItemButton);
            this.Controls.Add(this.CompareButton);
            this.Controls.Add(this.resetShoppingCartButton);
            this.Controls.Add(this.shoppingCartListBox);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "השוואת מחירים";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    }
}

