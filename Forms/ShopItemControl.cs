using Microsoft.VisualBasic.Devices;
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

        public bool IsOwned
        {
            get => !state_icon.Visible;
            set
            {
                state_icon.Visible = !value;
                buy_btn.Visible = !value;
            }
        }
    }
}
