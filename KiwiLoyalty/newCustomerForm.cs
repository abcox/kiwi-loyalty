using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

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
                // create sql connection object.  Be sure to put a valid connection string
                SqlConnection Con = new SqlConnection("Data Source=HAYDEN-HOME-PC\\SQLEXPRESS;Initial Catalog=KiwiLoyalty;User ID=kiwiloyalty;Password=kiwi1");
                // create command object with SQL query and link to connection object
                SqlCommand Cmd = new SqlCommand("INSERT INTO tblCustomer " +
            "(firstName, lastName, phoneNumber, email, emailAuth, birthday) " +
                    "VALUES(@firstName, @lastName, @phoneNumber, @email, @emailAuth, @birthday)",
            Con);

                // create your parameters
                Cmd.Parameters.Add("@firstName", SqlDbType.VarChar);
                Cmd.Parameters.Add("@lastName", SqlDbType.VarChar);
                Cmd.Parameters.Add("@phoneNumber", SqlDbType.VarChar);
                Cmd.Parameters.Add("@email", SqlDbType.VarChar);
                Cmd.Parameters.Add("@birthday", SqlDbType.DateTime);
                Cmd.Parameters.AddWithValue("@emailAuth", newCustomerEntryFormEmailAuthorisationCheckBox.Checked);

                // set values to parameters from textboxes
                Cmd.Parameters["@firstName"].Value = newCustomerEntryFormFirstNameTextBox.Text;
                Cmd.Parameters["@lastName"].Value = newCustomerEntryFormLastNameTextBox.Text;
                Cmd.Parameters["@phoneNumber"].Value = newCustomerEntryFormPhoneNumberTextBox.Text;
                Cmd.Parameters["@email"].Value = newCustomerEntryFormEmailTextBox.Text;
                Cmd.Parameters["@birthday"].Value = newCustomerEntryFormBirthdayPicker.Text;

                // open sql connection
                Con.Open();

                // execute the query and return number of rows affected, should be one

                //Catch SQL Errors



                int RowsAffected = Cmd.ExecuteNonQuery();

                // close connection when done
                Con.Close();
                MessageBox.Show("The Customer was successfully saved to the database.");
                //newCustomerEntryFirstNameTextBox.Clear();
                //newCustomerEntryFormLastNameTextBox.Clear();
                //newCustomerEntryFormPhoneNumberTextBox.Clear();
                //newCustomerEntryFormBirthdayPicker.ResetText();
                
                this.Close();
            }
            catch (SqlException f) when (f.Number == 2627)
            {
                MessageBox.Show("That Phone Number Already Exists in the Database. Please Enter another number or use existing customer entry form.");
            }

            catch (SqlException f) when (f.Number == 8152)
            {
                MessageBox.Show("One of your fields is too long, fix it.");
            }


            finally
            {
                
            }
        }
    }
}
