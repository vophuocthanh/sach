<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="giohang.aspx.cs" Inherits="Sach.giohang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="MaSanPham" HeaderText="Mã Sản Phẩm" />
            <asp:BoundField DataField="TenSanPham" HeaderText="Tên Sản Phẩm" />
            <asp:BoundField DataField="GiaSanPham" HeaderText="Giá Sản Phẩm" />
            <asp:BoundField DataField="SoLuong" HeaderText="Số Lượng" />
            <asp:BoundField DataField="ThanhTien" HeaderText="Thanh Tien" />
        </Columns>

    </asp:GridView>
</asp:Content>
