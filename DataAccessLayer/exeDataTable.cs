using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;

namespace DataAccessLayer
{
    public class exeDataTable
    {
        MySqlConnection SQLConn = new MySqlConnection("server=localhost;user id=root;password=12345678;database=arandura;persistsecurityinfo=True");
        MySqlCommand SQLCmd = new MySqlCommand();
        MySqlDataReader SQLRdr;

        public DataTable loadDataTable(string strSQL, ArrayList array = null )
        {
            DataTable dt = new DataTable();

            if (SQLConn.State == ConnectionState.Open)
            {
                SQLConn.Close();
            }
            SQLConn.Open();
            SQLCmd = new MySqlCommand(strSQL, SQLConn);

            if (array!= null)
            {
                object obj = new object();
                int i = 1;
                foreach( object _obj in array)
                {
                    string Name = "@" + i;
                    MySqlParameter SQLParameter = new MySqlParameter();
                    SQLParameter.ParameterName = Name;
                    SQLParameter.Value = _obj.ToString();
                    SQLCmd.Parameters.Add(SQLParameter);
                    i = i + 1;
                    obj = _obj;    
                }
            }
            SQLRdr = SQLCmd.ExecuteReader();
            dt.Load(SQLRdr);
            SQLRdr.Close();
            SQLConn.Close();
            return dt;
        }
    }
}
