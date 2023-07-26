using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Sach
{
    public partial class product : System.Web.UI.Page
    {
        // string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\IS_385_V\Sach\Sach\Sach\App_Data\databaseSach.mdf;Integrated Security=True";
        XuLyClass connect = new XuLyClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            string q;
            if (Context.Items["ml"] == null)
                q = "select * from SanPham";
            else
            {
                string maloai = Context.Items["ml"].ToString();
                q = "select * from SanPham where MaLoaiSP = '" + maloai + "'";
            }
            try
            {
                // SqlDataAdapter da = new SqlDataAdapter(q, stcn);
                // DataTable dt = new DataTable();
                // da.Fill(dt);
                this.DataList1.DataSource = connect.GetData(q);
                this.DataList1.DataBind();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string mahang = ((LinkButton)sender).CommandArgument;
            Context.Items["mh"] = mahang;
            Server.Transfer("chitiet.aspx");
        }
    }
}