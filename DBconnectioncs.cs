using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBankAccountManagementSystem
{
    class DBconnectioncs
    {
        //data members

        // connection string
        public SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-SF8JS4G5;Initial Catalog=DBSProject;Integrated Security=SSPI;User ID=sa;Password=Contra#entry1?");
        public SqlCommand cmd = new SqlCommand();


        //consructor
        public DBconnectioncs()
        { }
                     
        //function members

        public void Inserts(string query) // insert / update / delete
        {
            conn.Open();
            cmd.CommandText = query;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();


        }

        public DataTable Select(string query) // select query
        {
            conn.Open();
            cmd.CommandText = query;
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
    }
}
