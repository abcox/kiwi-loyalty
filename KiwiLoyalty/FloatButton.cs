using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace KiwiLoyalty
{





    public partial class FloatButton : Form
    {
        public FloatButton()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FloatButton_Load(object sender, EventArgs e)
        {
       
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            KiwiLoyaltyHomeForm f2 = new KiwiLoyaltyHomeForm();
            f2.Show();
        }
    }
    }

