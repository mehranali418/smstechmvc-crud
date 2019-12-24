using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMSTech
{
    public class dbMethods
    {
        SqlConnection sqlcon= new SqlConnection(ConnectionString.Path);
        SqlCommand cmd;
        SqlDataAdapter da;
        
            
        public DataTable DataTableReader(string Qurry,DataTable dt)
        {
            sqlcon.Open();
            cmd = new SqlCommand(Qurry,sqlcon);
            da = new SqlDataAdapter(cmd);
             
            da.Fill(dt);
            sqlcon.Close();
            return dt;


        }


    }
}