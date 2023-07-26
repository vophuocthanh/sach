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
    public partial class giohang : System.Web.UI.Page
    {
        string stcn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\IS_385_V\Sach\Sach\Sach\App_Data\databaseSach.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string q = "select DonHang.MaSanPham,TenSanPham,MoTa,GiaSanPham,SoLuong,"
                + "SoLuong*GiaSanPham as ThanhTien from DonHang,SanPham "
                + " where SanPham.MaSanPham = DonHang.MaSanPham";
                SqlDataAdapter da = new SqlDataAdapter(q, stcn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();
                //Tính tổng thành tiền: duyệt dataTable
                double tong = 0;
                foreach (DataRow row in dt.Rows)
                {
                    double thanhtien = Convert.ToDouble(row["thanhtien"]);
                    tong = tong + thanhtien;
                }
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}