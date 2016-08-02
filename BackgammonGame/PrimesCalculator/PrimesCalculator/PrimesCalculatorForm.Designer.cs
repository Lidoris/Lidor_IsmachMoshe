namespace PrimesCalculator
{
    partial class PrimesCalculatorForm
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
            this.firstNumTextBox = new System.Windows.Forms.TextBox();
            this.secondNumTextBox = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.primeNumbersListBox = new System.Windows.Forms.ListBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstNumTextBox
            // 
            this.firstNumTextBox.Location = new System.Drawing.Point(57, 57);
            this.firstNumTextBox.Name = "firstNumTextBox";
            this.firstNumTextBox.Size = new System.Drawing.Size(75, 22);
            this.firstNumTextBox.TabIndex = 0;
            this.firstNumTextBox.UseWaitCursor = true;
            // 
            // secondNumTextBox
            // 
            this.secondNumTextBox.Location = new System.Drawing.Point(159, 57);
            this.secondNumTextBox.Name = "secondNumTextBox";
            this.secondNumTextBox.Size = new System.Drawing.Size(75, 22);
            this.secondNumTextBox.TabIndex = 1;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(57, 100);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(177, 25);
            this.calculateButton.TabIndex = 2;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // primeNumbersListBox
            // 
            this.primeNumbersListBox.FormattingEnabled = true;
            this.primeNumbersListBox.ItemHeight = 16;
            this.primeNumbersListBox.Location = new System.Drawing.Point(57, 193);
            this.primeNumbersListBox.Name = "primeNumbersListBox";
            this.primeNumbersListBox.Size = new System.Drawing.Size(177, 164);
            this.primeNumbersListBox.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(61, 142);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(172, 26);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // PrimesCalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 388);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.primeNumbersListBox);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.secondNumTextBox);
            this.Controls.Add(this.firstNumTextBox);
            this.Name = "PrimesCalculatorForm";
            this.Text = "Primes Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstNumTextBox;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.TextBox secondNumTextBox;
        private System.Windows.Forms.ListBox primeNumbersListBox;
        private System.Windows.Forms.Button cancelButton;
    }
}

