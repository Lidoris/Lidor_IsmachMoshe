namespace PrimesCalculator_Async
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.calculateButton = new System.Windows.Forms.Button();
            this.EndTextBox = new System.Windows.Forms.TextBox();
            this.StartTextBox = new System.Windows.Forms.TextBox();
            this.outputFileTextBox = new System.Windows.Forms.TextBox();
            this.amountOfPrimesLabel = new System.Windows.Forms.Label();
            this.outputFileLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(217, 93);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(102, 41);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(37, 93);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(174, 41);
            this.calculateButton.TabIndex = 7;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // EndTextBox
            // 
            this.EndTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.EndTextBox.Location = new System.Drawing.Point(181, 27);
            this.EndTextBox.Name = "EndTextBox";
            this.EndTextBox.Size = new System.Drawing.Size(138, 30);
            this.EndTextBox.TabIndex = 6;
            this.EndTextBox.Text = "End";
            // 
            // StartTextBox
            // 
            this.StartTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.StartTextBox.Location = new System.Drawing.Point(37, 27);
            this.StartTextBox.Name = "StartTextBox";
            this.StartTextBox.Size = new System.Drawing.Size(138, 30);
            this.StartTextBox.TabIndex = 5;
            this.StartTextBox.Text = "Start";
            this.StartTextBox.UseWaitCursor = true;
            // 
            // outputFileTextBox
            // 
            this.outputFileTextBox.Location = new System.Drawing.Point(122, 63);
            this.outputFileTextBox.Name = "outputFileTextBox";
            this.outputFileTextBox.Size = new System.Drawing.Size(197, 24);
            this.outputFileTextBox.TabIndex = 10;
            // 
            // amountOfPrimesLabel
            // 
            this.amountOfPrimesLabel.AutoSize = true;
            this.amountOfPrimesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.amountOfPrimesLabel.Location = new System.Drawing.Point(51, 152);
            this.amountOfPrimesLabel.Name = "amountOfPrimesLabel";
            this.amountOfPrimesLabel.Size = new System.Drawing.Size(27, 20);
            this.amountOfPrimesLabel.TabIndex = 11;
            this.amountOfPrimesLabel.Text = "---";
            // 
            // outputFileLabel
            // 
            this.outputFileLabel.AutoSize = true;
            this.outputFileLabel.Location = new System.Drawing.Point(34, 66);
            this.outputFileLabel.Name = "outputFileLabel";
            this.outputFileLabel.Size = new System.Drawing.Size(83, 18);
            this.outputFileLabel.TabIndex = 12;
            this.outputFileLabel.Text = "Output File:";
            // 
            // PrimesCalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 200);
            this.Controls.Add(this.outputFileLabel);
            this.Controls.Add(this.amountOfPrimesLabel);
            this.Controls.Add(this.outputFileTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.EndTextBox);
            this.Controls.Add(this.StartTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "PrimesCalculatorForm";
            this.Text = "Primes Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.TextBox EndTextBox;
        private System.Windows.Forms.TextBox StartTextBox;
        private System.Windows.Forms.TextBox outputFileTextBox;
        private System.Windows.Forms.Label amountOfPrimesLabel;
        private System.Windows.Forms.Label outputFileLabel;
    }
}

