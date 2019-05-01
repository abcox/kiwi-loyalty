using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KiwiLoyalty
{
    public partial class newCustomerEntryForm : Form
    {
        public newCustomerEntryForm()
        {
            InitializeComponent();
        }

        

        private void newCustomerEntryFormCancelButton_Click(object sender, EventArgs e)
        {
            //Go Back to the Home Screen
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void newCustomerEntryForm_Load(object sender, EventArgs e)
        {

        }

        private void newCustomerFormSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                var customer = new Models.Customer();
                customer.BirthDate = Convert.ToDateTime(newCustomerEntryFormBirthdayPicker.Text);
                customer.EmailAddress = newCustomerEntryFormEmailTextBox.Text;
                customer.FirstName = newCustomerEntryFormFirstNameTextBox.Text;
                customer.IsEmailAuthorized = newCustomerEntryFormEmailAuthorisationCheckBox.Checked;
                customer.LastName = newCustomerEntryFormLastNameTextBox.Text;
                customer.PhoneNumber = newCustomerEntryFormPhoneNumberTextBox.Text;
                var customerData = new DAL.CustomerData();
                customerData.AddCustomer(customer);
                MessageBox.Show("The Customer was successfully saved to the database.");
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
    }
}
