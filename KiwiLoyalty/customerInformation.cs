using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KiwiLoyalty
{
    public partial class customerInformationForm : Form
    {
        public customerInformationForm()
        {
            InitializeComponent();
        }

        private void customerInformationSearchButton_Click(object sender, EventArgs e)
        {
            {
                var customerData = new DAL.CustomerData();
                var customer = customerData.GetCustomer(customerInformationFormPhoneNumberTextBox.Text);

                if (customer == null) return;

                customerInformationFormFirstNameTextBox.Text = customer.FirstName;
                customerInformationFormLastNameTextBox.Text = customer.LastName;
                customerInformationFormEmailTextBox.Text = customer.EmailAddress;
                customerInformationFormBirthdayPicker.Text = customer.BirthDate?.ToShortDateString();
                customerInformationCurrentPointsBalanceTextBox.Text = customer.PointsBalance.ToString();
                customerInformationFormLifetimePointsBalanceTextBox.Text = customer.PointsTotal.ToString();

                var visits = customerData.GetCustomerVisits(customer.PhoneNumber);

                customerInformationVisitsDataGridView.DataSource = visits;
                customerInformationVisitsDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
        }

        private void customerInformationFormSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // create sql connection object.  Be sure to put a valid connection string
                SqlConnection Con = new SqlConnection("Data Source=HAYDEN-HOME-PC\\SQLEXPRESS;Initial Catalog=KiwiLoyalty;User ID=kiwiloyalty;Password=kiwi1");
                
                // create command object with SQL query and link to connection object
                SqlCommand Cmd = new SqlCommand("update tblCustomer set firstName = @firstName, lastName = @lastName , email = @email, emailAuth = @emailAuth, birthday = @birthday where phoneNumber = @phoneNumber", Con);

                // create your parameters
                Cmd.Parameters.Add("@firstName", SqlDbType.VarChar);
                Cmd.Parameters.Add("@lastName", SqlDbType.VarChar);
                Cmd.Parameters.Add("@phoneNumber", SqlDbType.VarChar);
                Cmd.Parameters.Add("@email", SqlDbType.VarChar);
                Cmd.Parameters.Add("@birthday", SqlDbType.DateTime);
                Cmd.Parameters.AddWithValue("@emailAuth", customerInformationFormEmailAuthorisationCheckBox.Checked);

                // set values to parameters from textboxes
                Cmd.Parameters["@firstName"].Value = customerInformationFormFirstNameTextBox.Text;
                Cmd.Parameters["@lastName"].Value = customerInformationFormLastNameTextBox.Text;
                Cmd.Parameters["@phoneNumber"].Value = customerInformationFormPhoneNumberTextBox.Text;
                Cmd.Parameters["@email"].Value = customerInformationFormEmailTextBox.Text;
                Cmd.Parameters["@birthday"].Value = customerInformationFormBirthdayPicker.Text;

                // open sql connection
                Con.Open();

                // execute the query
                Cmd.ExecuteNonQuery();

                //Catch SQL Errors

                // close connection when done

                Con.Close();

                MessageBox.Show("The Customer was successfully updated to the database.");
                


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

        private void customerInformationFormExitButton_Click(object sender, EventArgs e)
        {
            //Go Back to the Home Screen
            this.Close();
        }

        private void customerInformationForm_Load(object sender, EventArgs e)
        {
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }
