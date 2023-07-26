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
    public partial class chitiet : System.Web.UI.Page
    {
        string stcn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\IS_385_V\Sach\Sach\Sach\App_Data\databaseSach.mdf;Integrated Security=True";
        //XuLyClass connect = new XuLyClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            string q;
            if (Context.Items["mh"] == null)
                q = "select * from SanPham";
            else
            {
                string mahang = Context.Items["mh"].ToString();
                q = "select * from SanPham where MaSanPham = '" + mahang + "'";
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(q, stcn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.DataList1.DataSource = (dt);
                // this.DataList1.DataSource = connect.GetData(q);
                this.DataList1.DataBind();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button mua = (Button)sender;
            string masanpham = mua.CommandArgument.ToString();
            DataListItem item = (DataListItem)mua.Parent;
            string soLuong = ((TextBox)item.FindControl("TextBox1")).Text;
            if (Request.Cookies["TenKH"] == null) return;
            string ten = Request.Cookies["TenKH"].Value;
            SqlConnection con = new SqlConnection(stcn);
            con.Open();
            string query = "select * from DonHang " + "where TenKH ='"
                + ten + "' and MaSanPham='" + masanpham + "'";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                reader.Close();
                command = new SqlCommand(
                    "update DonHang set SoLuong=SoLuong+" + soLuong + 
                    "where TenKH='" + ten + "' and MaSanPham='" + masanpham + "'", con
                    );
            }
            else
            {
                reader.Close();
                command = new SqlCommand("insert into DonHang" + 
                        "(TenKH,MaSanPham,SoLuong) values('" + ten + "', '" + masanpham + "', " + soLuong + ")", con);
            }
            command.ExecuteNonQuery();
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("giohang.aspx");        }
    }
}