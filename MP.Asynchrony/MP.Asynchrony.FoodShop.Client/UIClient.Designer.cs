namespace MP.Asynchrony.FoodShop.Client
{
    partial class UIClient
    {
        private System.ComponentModel.IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.productsListBox = new System.Windows.Forms.ListBox();
            this.orderButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.totalCountLabel = new System.Windows.Forms.Label();
            this.removeFromOrderButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.orderSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.orderSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Products";
            // 
            // productsListBox
            // 
            this.productsListBox.FormattingEnabled = true;
            this.productsListBox.Location = new System.Drawing.Point(16, 34);
            this.productsListBox.Name = "productsListBox";
            this.productsListBox.Size = new System.Drawing.Size(561, 95);
            this.productsListBox.TabIndex = 1;
            // 
            // orderButton
            // 
            this.orderButton.Location = new System.Drawing.Point(298, 135);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(279, 23);
            this.orderButton.TabIndex = 2;
            this.orderButton.Text = "Add bo order";
            this.orderButton.UseVisualStyleBackColor = true;
            this.orderButton.Click += new System.EventHandler(this.orderButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Your order";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "TOTAL COUNT:";
            // 
            // totalCountLabel
            // 
            this.totalCountLabel.AutoSize = true;
            this.totalCountLabel.Location = new System.Drawing.Point(106, 363);
            this.totalCountLabel.Name = "totalCountLabel";
            this.totalCountLabel.Size = new System.Drawing.Size(0, 13);
            this.totalCountLabel.TabIndex = 6;
            this.totalCountLabel.Text = "0";
            // 
            // removeFromOrderButton
            // 
            this.removeFromOrderButton.Location = new System.Drawing.Point(444, 363);
            this.removeFromOrderButton.Name = "removeFromOrderButton";
            this.removeFromOrderButton.Size = new System.Drawing.Size(132, 23);
            this.removeFromOrderButton.TabIndex = 7;
            this.removeFromOrderButton.Text = "Remove from order";
            this.removeFromOrderButton.UseVisualStyleBackColor = true;
            this.removeFromOrderButton.Click += new System.EventHandler(this.removeFromOrderButton_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(13, 185);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 8;
            // 
            // orderListBox
            // 
            this.orderListBox.DataSource = this.orderSource;
            this.orderListBox.FormattingEnabled = true;
            this.orderListBox.Location = new System.Drawing.Point(16, 236);
            this.orderListBox.Name = "orderListBox";
            this.orderListBox.Size = new System.Drawing.Size(560, 121);
            this.orderListBox.TabIndex = 9;
            // 
            // UIClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 399);
            this.Controls.Add(this.orderListBox);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.removeFromOrderButton);
            this.Controls.Add(this.totalCountLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.orderButton);
            this.Controls.Add(this.productsListBox);
            this.Controls.Add(this.label1);
            this.Name = "UIClient";
            this.Text = "UIClient";
            ((System.ComponentModel.ISupportInitialize)(this.orderSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox productsListBox;
        private System.Windows.Forms.Button orderButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label totalCountLabel;
        private System.Windows.Forms.Button removeFromOrderButton;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.BindingSource orderSource;
        private System.Windows.Forms.ListBox orderListBox;
    }
}

