<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="Sach.product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="4" EditItemStyle-Font-Size="Medium">
        <ItemTemplate>
            <div class="product" style="height: 400px; padding: 20px 0;">
                <div style="margin: 10px 0;">
                    <asp:Image CssClass="image" ID="Image1" runat="server" ImageUrl='<%# "~/images/" + Eval("HinhAnh")%>'/>
                </div>
                <br />
                <asp:Label ID="Label1" CssClass="text" runat="server" Text='<%# Eval("TenSanPham") %>' ></asp:Label>
                <br />
                <div class="price">
                    Giá: <asp:Label ID="Label2" runat="server" Text='<%# Eval("GiaSanPham")+" USD" %>' ></asp:Label>
                </div>
                <br /> 
                <asp:LinkButton runat="server" CssClass="details" CommandArgument='<%# Eval("MaSanPham")%>' OnClick="Unnamed1_Click" >Chi Tiết</asp:LinkButton>
                </div>
        </ItemTemplate>
        </asp:DataList> 
</asp:Content>
