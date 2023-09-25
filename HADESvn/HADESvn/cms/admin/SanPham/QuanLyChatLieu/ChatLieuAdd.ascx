<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChatLieuAdd.ascx.cs" Inherits="HADESvn.cms.admin.SanPham.QuanLyChatLieu.ChatLieuAdd" %>
<ul class="nav nav-tabs">
  <li class="nav-item">
    <a class="nav-link " href="AdminPage.aspx?modul=SanPham&modulphu=DanhSachSanPham&thaotac=HienThi">Quản Lý Sản Phẩm</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" href="AdminPage.aspx?modul=SanPham&modulphu=DanhMuc&thaotac=HienThi">Quản lý Danh Mục</a>
  </li>
  <li class="nav-item">
    <a class="nav-link active" aria-current="page" href="AdminPage.aspx?modul=SanPham&modulphu=ChatLieu&thaotac=HienThi">Quản Lý Chất Liệu</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" href="AdminPage.aspx?modul=SanPham&modulphu=Mau&thaotac=HienThi">Quản Lý Màu</a>
  </li>
    <li class="nav-item">
    <a class="nav-link" href="AdminPage.aspx?modul=SanPham&modulphu=Size&thaotac=HienThi">Quản Lý Size</a>
  </li>
    <li class="nav-item">
    <a class="nav-link" href="AdminPage.aspx?modul=SanPham&modulphu=NhomSanPham&thaotac=HienThi">Quản Lý Nhóm</a>
  </li>
</ul>
<div class="row g-3 from-margin-lr">
    <div class="col-md-12 col-btn-add">
        <a href="AdminPage.aspx?modul=SanPham&modulphu=ChatLieu&thaotac=HienThi" class="btn btn-not btn-add"><ion-icon name="apps-outline"></ion-icon>Xem Chất Liệu</a>
    </div>
    <div class="col-md-3">
        <label for="inputPassword4" class="form-label">Tên Chat Lieu</label>
        <asp:TextBox ID="txtChatLieu" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtChatLieu" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="col-12">
        <asp:Button ID="btnthemmoi" runat="server" Text="Thêm" OnClick="btnThemmoi_Click" CssClass="btn btn-not" />
    </div>
</div>