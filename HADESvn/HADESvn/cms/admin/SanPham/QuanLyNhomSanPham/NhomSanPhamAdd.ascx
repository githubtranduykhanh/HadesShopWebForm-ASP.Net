<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NhomSanPhamAdd.ascx.cs" Inherits="HADESvn.cms.admin.SanPham.QuanLyNhomSanPham.NhomSanPhamAdd" %>
<ul class="nav nav-tabs">
    <li class="nav-item">
    <a class="nav-link " href="AdminPage.aspx?modul=SanPham&modulphu=DanhSachSanPham&thaotac=HienThi">Quản Lý Sản Phẩm</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" href="AdminPage.aspx?modul=SanPham&modulphu=DanhMuc&thaotac=HienThi">Quản lý Danh Mục</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" href="AdminPage.aspx?modul=SanPham&modulphu=ChatLieu&thaotac=HienThi">Quản Lý Chất Liệu</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" href="AdminPage.aspx?modul=SanPham&modulphu=Mau&thaotac=HienThi">Quản Lý Màu</a>
  </li>
    <li class="nav-item">
    <a class="nav-link" href="AdminPage.aspx?modul=SanPham&modulphu=Size&thaotac=HienThi">Quản Lý Size</a>
  </li>
    <li class="nav-item">
    <a class="nav-link active" aria-current="page" href="AdminPage.aspx?modul=SanPham&modulphu=NhomSanPham&thaotac=HienThi">Quản Lý Nhóm</a>
  </li>
</ul>
<div class="row g-3 from-margin-lr">
    <div class="col-md-12 col-btn-add">
        <a href="AdminPage?modul=SanPham&modulphu=NhomSanPham&thaotac=HienThi" class="btn btn-not btn-add"><ion-icon name="apps-outline"></ion-icon>Xem Nhóm Sản Phẩm</a>
    </div>
    <div class="col-md-6">
        <label for="inputEmail4" class="form-label">Tên Nhóm</label>
        <asp:TextBox ID="tbTenNhomSP" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="tbTenNhomSP" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>      
    <div class="col-md-4">
        <label for="inputState" class="form-label">Ảnh Đại Diện</label>
        <asp:HiddenField ID="hdTenAnhDaiDienCu" runat="server" />
        <asp:Literal ID="ltrAnhDaiDien" runat="server"></asp:Literal>
        <asp:FileUpload ID="FileUploadanh" runat="server" CssClass="form-control" />
    </div>
    <div class="col-md-6">
        <label for="inputEmail4" class="form-label">Thứ tự</label>
        <asp:TextBox ID="tbThuTu" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="tbThuTu" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-6">
        <label for="inputPassword4" class="form-label">Số sản phẩm hiển thị</label>
        <asp:TextBox ID="tbSoSanPhamHienThi" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="tbSoSanPhamHienThi" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="col-12">
        <asp:Button ID="btnthemmoi" runat="server" Text="Thêm" OnClick="btnThemmoi_Click" CssClass="btn btn-not" />
    </div>
</div>