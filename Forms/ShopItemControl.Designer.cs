namespace Space_Shooter_game.Forms
{
    partial class ShopItemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopItemControl));
            item = new PictureBox();
            state_icon = new PictureBox();
            price = new Label();
            pictureBox1 = new PictureBox();
            buy_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)item).BeginInit();
            ((System.ComponentModel.ISupportInitialize)state_icon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // item
            // 
            item.Location = new Point(3, 3);
            item.Name = "item";
            item.Size = new Size(220, 170);
            item.TabIndex = 0;
            item.TabStop = false;
            // 
            // state_icon
            // 
            state_icon.Anchor = AnchorStyles.None;
            state_icon.Location = new Point(62, 55);
            state_icon.Name = "state_icon";
            state_icon.Size = new Size(100, 60);
            state_icon.TabIndex = 1;
            state_icon.TabStop = false;
            // 
            // price
            // 
            price.AutoSize = true;
            price.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            price.Location = new Point(115, 195);
            price.Name = "price";
            price.Size = new Size(27, 31);
            price.TabIndex = 2;
            price.Text = "0";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(80, 191);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 40);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // buy_btn
            // 
            buy_btn.BackColor = Color.DarkGreen;
            buy_btn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buy_btn.Location = new Point(61, 237);
            buy_btn.Name = "buy_btn";
            buy_btn.Size = new Size(103, 50);
            buy_btn.TabIndex = 4;
            buy_btn.Text = "Buy";
            buy_btn.UseVisualStyleBackColor = false;
            // 
            // ShopItemControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGreen;
            Controls.Add(buy_btn);
            Controls.Add(pictureBox1);
            Controls.Add(price);
            Controls.Add(state_icon);
            Controls.Add(item);
            DoubleBuffered = true;
            Name = "ShopItemControl";
            Size = new Size(225, 300);
            ((System.ComponentModel.ISupportInitialize)item).EndInit();
            ((System.ComponentModel.ISupportInitialize)state_icon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox item;
        private PictureBox state_icon;
        private Label price;
        private PictureBox pictureBox1;
        private Button buy_btn;
    }
}
