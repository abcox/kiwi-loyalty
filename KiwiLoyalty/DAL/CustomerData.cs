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
        public const string ConnectionString = "Data Source=(local);Initial Catalog=KiwiLoyalty;User ID=kiwiloyalty;Password=kiwi1";

        public CustomerData()
        {

        }

        public Customer GetCustomer(string phoneNumber)
        {

            //Populate the Customer Details
            // create sql connection object.  Be sure to put a valid connection string
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
            //DataSet ds = new DataSet();
            da.Fill(dt);


            //DataTable dt = ds.Tables(0);

            //var result = dt.Rows.OfType<CustomerVisit>().AsEnumerable().ToList();

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
            ;
        }
        
    }
}
