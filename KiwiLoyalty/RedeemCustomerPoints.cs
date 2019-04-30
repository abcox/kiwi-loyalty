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
    public partial class RedeemCustomerPointsForm : Form
    {
        public RedeemCustomerPointsForm()
        {
            InitializeComponent();
        }

        private void redeemCustomerPointsCancelButton_Click(object sender, EventArgs e)
        {
            //Go Back to the Home Screen
            this.Close();
        }

        private void addCustomerPointsFormTitleLabel_Click(object sender, EventArgs e)
        {

        }

        private void addCustomerPointsFormDateOfVisitPicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void addCustomerPointsFormAddPointsButton_Click(object sender, EventArgs e)
        {
            if  (redeemCustomerPointsMgrCodeTextbox.Text is "1234")
                { 
                try
                {
                    // create sql connection object.  Be sure to put a valid connection string
                    SqlConnection Con = new SqlConnection("Data Source=HAYDEN-HOME-PC\\SQLEXPRESS;Initial Catalog=KiwiLoyalty;User ID=kiwiloyalty;Password=kiwi1");
                    // create command object with SQL query and link to connection object
                    SqlCommand Cmd = new SqlCommand("exec sp_RedeemPoints @phoneNumber, @pointsAdded, @dateOfEntry,@entryType,@pointsRedeemed,@redeemedReason", Con);

                    // create your parameters
                    Cmd.Parameters.Add("@phoneNumber", SqlDbType.VarChar);
                    Cmd.Parameters.Add("@pointsAdded", SqlDbType.Float);
                    Cmd.Parameters.Add("@dateOfEntry", SqlDbType.DateTime);
                    Cmd.Parameters.Add("@entryType", SqlDbType.VarChar);
                    Cmd.Parameters.Add("@pointsRedeemed", SqlDbType.Float);
                    Cmd.Parameters.Add("@redeemedReason", SqlDbType.VarChar);

                    // set values to parameters from textboxes
                    Cmd.Parameters["@phoneNumber"].Value = redeemCustomerPointsFormPhoneTextBox.Text;
                    Cmd.Parameters["@pointsAdded"].Value = Convert.ToSingle(0);
                    Cmd.Parameters["@dateOfEntry"].Value = redeemCustomerPointsFormDateOfVisitPicker.Text;
                    Cmd.Parameters["@entryType"].Value = "redemption";
                    Cmd.Parameters["@pointsRedeemed"].Value = Convert.ToSingle(redeemCustomerPointsFormPointsTextBox.Text);
                    Cmd.Parameters["@redeemedReason"].Value = redeemCustomerPointsRedeemReasonTextBox.Text;


                    // open sql connection
                    Con.Open();

                    // execute the query and return number of rows affected, should be one

                    //Catch SQL Errors



                    int RowsAffected = Cmd.ExecuteNonQuery();

                    // close connection when done
                    Con.Close();
                    MessageBox.Show("Points Redeemed Successfully");
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

            else
            {
                MessageBox.Show("Incorrect Manager Code, Please Try Again.");

            }
        }

        private void addCustomerPointsFormPointsLabel_Click(object sender, EventArgs e)
        {

        }

        private void addCustomerPointsFormPhoneNumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void addCustomerPointsFormPhoneTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void addCustomerPointsFormPointsTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
