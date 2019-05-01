using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KiwiLoyalty.Models;
using KiwiLoyalty.DAL;

namespace KiwiLoyalty
{
    public partial class customerPointsAdditionForm : Form
    {
        public customerPointsAdditionForm()
        {
            InitializeComponent();
        }

        private void customerInformationFormExitButton_Click(object sender, EventArgs e)
        {
            //Go Back to the Home Screen
            this.Close();
        }

        private void addCustomerPointsFormAddPointsButton_Click(object sender, EventArgs e)
        {
            try
            {
                var entry = new CustomerPointsEntry();
                entry.EntryDate = Convert.ToDateTime(addCustomerPointsFormDateOfVisitPicker.Text);
                entry.EntryType = "add";
                entry.PhoneNumber = addCustomerPointsFormPhoneTextBox.Text;
                entry.PointsAdded = Convert.ToSingle(addCustomerPointsFormPointsTextBox.Text);
                entry.PointsRedeemed = Convert.ToSingle(0);

                var customerData = new CustomerData();
                customerData.AddCustomerPoints(entry);

                MessageBox.Show("Points Added Successfully");
                this.Close();
            }
            //catch (SqlException f) when (f.Number == 2627)
            //{
            //    MessageBox.Show("That Phone Number Already Exists in the Database. Please Enter another number or use existing customer entry form.");
            //}
            //catch (SqlException f) when (f.Number == 8152)
            //{
            //    MessageBox.Show("One of your fields is too long, fix it.");
            //}
            //finally
            //{
            //}
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred with message: {ex.Message}");
            }
        }

        private void addCustomerPointsFormPhoneTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void addCustomerPointsFormPhoneNumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void addCustomerPointsFormPointsTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void addCustomerPointsFormPointsTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.SelectAll();
        }

        private void customerPointsAdditionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
