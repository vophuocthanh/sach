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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\IS_385_V\Sach\Sach\Sach\App_Data\databaseSach.mdf;Integrated Security=True";
        // XuLyClass connect = new XuLyClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            string q1 = "select * from LoaiSanPham";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(q1, connect);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.DataList1.DataSource = (dt);
                this.DataList1.DataBind();

            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string maloai = ((LinkButton)sender).CommandArgument;
            Context.Items["ml"] = maloai;
            Server.Transfer("product.aspx");
        }
        
        protected void Login1_Authenticate1(object sender, AuthenticateEventArgs e)
        {
            string ten = this.Login1.UserName;
            string matkhau = this.Login1.Password;
            string sql = "select * from KhachHang where TenKH='" + ten + "' and MatKhau='" + matkhau + "'";
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, connect);
                da.Fill(table);
            }
            catch (SqlException err)
            {
                Response.Write("<b>Error</b>" + err.Message + "<p/>");
            }
            if (table.Rows.Count != 0)
            {
                Response.Cookies["TenKH"].Value = ten;
                Server.Transfer("product.aspx");
            }
            else this.Login1.FailureText = "Tên đăng nhập hay mật khẩu không đúng";
        }
    }
}