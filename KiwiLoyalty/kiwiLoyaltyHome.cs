﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace KiwiLoyalty
{
    public partial class KiwiLoyaltyHomeForm : Form
    {
        public KiwiLoyaltyHomeForm()
        {
            InitializeComponent();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
                       
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void homeButtonQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();    
        }

        private void homeNewCustomerButton_Click(object sender, EventArgs e)
        {
            
            newCustomerEntryForm f2 = new newCustomerEntryForm();
            f2.ShowDialog();
            
          


        }

        private void homeViewCustomerInformation_Click(object sender, EventArgs e)
        {
            customerInformationForm f2 = new customerInformationForm();
            f2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void homeAddPointsButton_Click(object sender, EventArgs e)
        {
            customerPointsAdditionForm f2 = new customerPointsAdditionForm();
            f2.ShowDialog();
        }

        private void homeRedeemCustomerPointsButton_Click(object sender, EventArgs e)
        {
            RedeemCustomerPointsForm f2 = new RedeemCustomerPointsForm();
            f2.ShowDialog();
        }
    }
}
