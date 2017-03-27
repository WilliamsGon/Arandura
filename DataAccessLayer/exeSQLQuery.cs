using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;

namespace DataAccessLayer
{
    public class exeSQLQuery
    {
        MySqlConnection SQLConn = new MySqlConnection("server=localhost;user id=root;password=12345678;database=arandura;persistsecurityinfo=True");
        MySqlCommand SQLCmd = new MySqlCommand();

        public void SQLQuery_Execute(string strSQL)
        {
            SQLConn.Open();
            SQLCmd = new MySqlCommand(strSQL, SQLConn);
            //Execute
            SQLCmd.ExecuteNonQuery();
            SQLConn.Close();
        }
       public object SQLQueryParameter_ReturnScalar(ArrayList Array, string strSQL)
        {
	        string eSQL = null;
	        SQLConn.Open();
	        SQLCmd = new MySqlCommand(strSQL, SQLConn);
            if (Array != null)
            { 
                Object obj = default(Object);
	            int i = 1;

                foreach ( object _obj in Array) 
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

	        //Execute
	        eSQL = (SQLCmd.ExecuteScalar()).ToString();
	        SQLConn.Close();

	        return eSQL;
        }

        public void SQLQueryParameter_Execute(ArrayList array, string strSQL)
       {
           SQLConn.Open();
           SQLCmd = new MySqlCommand(strSQL, SQLConn);
            Object obj = default(Object);
            int i = 1;
            foreach ( Object _obj in array)
            {
	            string Name = "@" + i;
	            MySqlParameter SQLParameter = new MySqlParameter();
	            SQLParameter.ParameterName = Name;
	            SQLParameter.Value = _obj;
	            SQLCmd.Parameters.Add(SQLParameter);
	            i = i + 1;
                obj = _obj;
            }

            SQLCmd.ExecuteNonQuery();
            SQLConn.Close();
       }
    }
}
