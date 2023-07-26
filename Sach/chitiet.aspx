<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="chitiet.aspx.cs" Inherits="Sach.chitiet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="margin: 30px 0 20px; font-size: 36px">Chi Tiết Sản Phẩm</h1>
        <asp:DataList ID="DataList1" runat="server" >
            <ItemTemplate>
                <div class="main" style="display: flex;">
                    <div style="width: 520px; margin-left: 20px; display: flex; align-items: center; justify-content: center; margin-bottom: 20px;">
                    <asp:Image CssClass="hinhsp" ID="Image1" runat="server" ImageUrl='<%# "~/images/" + Eval("HinhAnh")%>'/>
                    <br/>
                </div>
                <div class="quality" style="margin-left: -120px;">
                    <div style="margin-bottom: 16px;">
                        <asp:Label ID="Label1" runat="server" CssClass="details-text" Text='<%# Eval("TenSanPham") %>'></asp:Label>
                    </div>
                    <br />
                    <div style="margin-bottom: 16px;">
                        <asp:Label ID="Label2" CssClass="details-desc" runat="server" Text='<%# Eval("MoTa") %>'></asp:Label>
                     </div>
                    <br />
                    <div class="details-price" style="margin-bottom: 16px;">
                        Giá: <asp:Label ID="Label3" runat="server" Text='<%# Eval("GiaSanPham")+ " USD" %>' ></asp:Label>
                    </div>
                    <div style="margin-bottom: 16px;">
                        So luong <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                     </div>
                    <div style="display: flex; margin-bottom: 16px;">
                        <div style="margin-bottom: 16px; margin-right: 10px;;">
                            <asp:Button ID="Button1" runat="server" Text="Mua Hang" OnClick="Button1_Click" CommandArgument='<%# Eval("MaSanPham") %>'/>
                        </div>
                        <div style="margin-bottom: 16px;">
                            <asp:Button ID="Button2" runat="server" Text="Xem gio hang" OnClick="Button2_Click" />
                       </div>
                    </div>
                    </div>
                </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
</asp:Content>
