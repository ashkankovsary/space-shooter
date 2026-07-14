using Microsoft.VisualBasic.Devices;
using Space_Shooter_game.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Space_Shooter_game.Forms
{
    public partial class ShopItemControl : UserControl
    {
        public ShopItemControl()
        {
            InitializeComponent();
        }
        public bool IsBuyed = false;
        public bool IsActived = false;
        public int ItemId;
        public string Category;
        public Image ItemImage
        {
            get => item.Image;
            set => item.Image = value;
        }

        public string Price
        {
            get => price.Text;
            set => price.Text = value;
        }

        public bool Isowned
        {
            get => !state_icon.Visible;
            set
            {
                state_icon.Visible = !value;
                buy_btn.Visible = !value;
            }
        }

        public void UpdateItem(int ItemId)
        {
            IsBuyed = Database.IsOwned(ItemId);
            IsActived = Database.IsSelected(ItemId);
            int item_price = Database.GetItemPrice(ItemId);
            if (!IsBuyed)
            {
                state_icon.Visible = true;
                buy_btn.Text = "Buy";
                pictureBox1.Visible = true;
                price.Visible = true;
                price.Text = item_price.ToString();
            }
            else if (!IsActived)
            {
                state_icon.Visible = false;
                buy_btn.Text = "Use";
                buy_btn.BackColor = Color.Red;
                pictureBox1.Visible = false;
                price.Visible = false;
            }
            else
            {
                state_icon.Visible = false;
                buy_btn.Text = "Active";
                buy_btn.BackColor = Color.Blue;
                pictureBox1.Visible = false;
                price.Visible = false;
            }
        }
    }
}
