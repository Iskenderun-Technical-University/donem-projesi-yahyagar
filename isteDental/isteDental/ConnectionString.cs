using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;




namespace isteDental
{
    internal class ConnectionString
    {
        public SqlConnection Getcon()
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yahya\Documents\dentalDB.mdf;Integrated Security=True;Connect Timeout=30";
            return baglanti;
        }
    }
}
