using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sach
{
    public class XuLyClass
    {
        SqlConnection conn;
        private void Open()
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\IS_385_V\Sach\Sach\Sach\App_Data\databaseSach.mdf;Integrated Security=True");
        }
        private void Close()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            catch (Exception)
            {

                dt = null;
            }
            finally
            {
                Close();
            }
            return dt;
        }
    }
}