using KiwiLoyalty.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.DataSetExtensions;
using System.Linq;
using System.Text;
using System.Reflection;

namespace KiwiLoyalty.DAL
{
    class CustomerData
    {
        // "Data Source=HAYDEN-HOME-PC\\SQLEXPRESS;Initial Catalog=KiwiLoyalty;User ID=kiwiloyalty;Password=kiwi1"
        public const string ConnectionString = "Data Source=(local);Initial Catalog=KiwiLoyalty;User ID=kiwiloyalty;Password=kiwi1";

        public CustomerData()
        {

        }

        public Customer GetCustomer(string phoneNumber)
        {
            SqlConnection Con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand("select * from tblCustomer where phoneNumber = @phoneNumber", Con);

            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);

            Con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            Customer customer = null;

            if (dr.HasRows)
            {
                dr.Read();
                customer = new Customer();
                customer.BirthDate = dr.IsDBNull(dr.GetOrdinal("birthday")) ? (DateTime?)null : dr.GetDateTime(dr.GetOrdinal("birthday"));
                customer.EmailAddress = dr.IsDBNull(dr.GetOrdinal("email")) ? null : dr.IsDBNull(dr.GetOrdinal("email")) ? null : dr.GetString(dr.GetOrdinal("email"));
                customer.FirstName = dr.IsDBNull(dr.GetOrdinal("firstName")) ? null : dr.GetString(dr.GetOrdinal("firstName"));
                customer.Id = dr.GetInt32(dr.GetOrdinal("customerNumber"));
                customer.LastName = dr.IsDBNull(dr.GetOrdinal("lastName")) ? null : dr.GetString(dr.GetOrdinal("lastName"));
                customer.PhoneNumber = dr.IsDBNull(dr.GetOrdinal("phoneNumber")) ? null : dr.GetString(dr.GetOrdinal("phoneNumber"));
                customer.PointsBalance = dr.IsDBNull(dr.GetOrdinal("pointsBalanceCurrent")) ? (int?)null : dr.GetInt32(dr.GetOrdinal("pointsBalanceCurrent"));
                customer.PointsTotal = dr.IsDBNull(dr.GetOrdinal("pointsBalanceLifetime")) ? (int?)null : dr.GetInt32(dr.GetOrdinal("pointsBalanceLifetime"));
            }
            Con.Close();
            return customer;        
        }

        public IEnumerable<CustomerVisit> GetCustomerVisits(string phoneNumber)
        {
            //fill Visits Data Table
            SqlConnection cnn = new SqlConnection(ConnectionString);

            var sql = "select dateOfEntry as Date, entryType as Type, pointsAdded as Plus, pointsRedeemed as Minus, RedeemedReason as Notes from tblvisits where phoneNumber = @phoneNumber";

            cnn.Open();

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            var result = dt.AsEnumerable().Select(m => new CustomerVisit()
            {
                Date = m.Field<DateTime>("Date"),
                Type = m.Field<string>("Type"),
                Plus = m.Field<double>("Plus"),
                Minus = m.Field<double>("Minus"),
                Notes = m.Field<string>("Type"),
                //Description = m.Field<string>("Description"),
                //Balance = m.Field<double>("Balance"),
            }).ToList();

            cnn.Close();

            return result;
        }
        
        public void AddCustomer(Customer customer)
        {
            // create sql connection object.  Be sure to put a valid connection string
            SqlConnection cnn = new SqlConnection(ConnectionString);

            // create command object with SQL query and link to connection object
            SqlCommand cmd = new SqlCommand("INSERT INTO tblCustomer " +
                "(firstName, lastName, phoneNumber, email, emailAuth, birthday) " +
                "VALUES(@firstName, @lastName, @phoneNumber, @email, @emailAuth, @birthday)",
                cnn);

            cmd.Parameters.AddWithValue("@birthday", customer.BirthDate);
            cmd.Parameters.AddWithValue("@email", customer.EmailAddress);
            cmd.Parameters.AddWithValue("@emailAuth", customer.IsEmailAuthorized);
            cmd.Parameters.AddWithValue("@firstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@lastName", customer.LastName);
            cmd.Parameters.AddWithValue("@phoneNumber", customer.PhoneNumber);

            // open sql connection
            cnn.Open();

            // execute the query and return number of rows affected, should be one

            //Catch SQL Errors

            int RowsAffected = cmd.ExecuteNonQuery();

            // close connection when done
            cnn.Close();            
        }

        public void AddCustomerPoints(CustomerPointsEntry entry)
        {
            // create sql connection object.  Be sure to put a valid connection string
            SqlConnection cnn = new SqlConnection(ConnectionString);

            // create command object with SQL query and link to connection object
            SqlCommand cmd = new SqlCommand(
                "exec sp_AddPoints @phoneNumber, @pointsAdded, @dateOfEntry, @entryType,@pointsRedeemed",
                cnn
                );

            cmd.Parameters.AddWithValue("@phoneNumber", entry.PhoneNumber);
            cmd.Parameters.AddWithValue("@pointsAdded", entry.PointsAdded);
            cmd.Parameters.AddWithValue("@dateOfEntry", entry.EntryDate);
            cmd.Parameters.AddWithValue("@entryType", entry.EntryType);
            cmd.Parameters.AddWithValue("@pointsRedeemed", entry.PointsRedeemed);

            // open sql connection
            cnn.Open();

            // execute the query and return number of rows affected, should be one

            //Catch SQL Errors

            int RowsAffected = cmd.ExecuteNonQuery();

            // close connection when done
            cnn.Close();
        }
    }
}
