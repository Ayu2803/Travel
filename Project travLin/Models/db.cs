    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using System.Net.Sockets;

namespace Gamers_Arena.Models
{
    public class db
    {

        //SqlConnection connection = new SqlConnection("workstation id=Minordb.mssql.somee.com;packet size=4096;user id=travelin_minor_SQLLogin_1;pwd=486ri2z58d;data source=Minordb.mssql.somee.com;persist security info=False;initial catalog=Minordb;TrustServerCertificate=True");

        SqlConnection connection = new SqlConnection("Data Source=AYUSHI;Initial Catalog=Mini;Integrated Security=True");

        public int InserUpdateDelete(string command)
        {


            SqlCommand cmd = new SqlCommand(command, connection);
            connection.Open();
            int d = cmd.ExecuteNonQuery();
            connection.Close();



            return d;


        }

        public DataTable SelectStatment(string command)
        {

            SqlDataAdapter adapter = new SqlDataAdapter(command, connection);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;


        }



    }
}