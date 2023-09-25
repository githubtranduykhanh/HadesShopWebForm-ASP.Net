<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DanhMucAdd.ascx.cs" Inherits="HADESvn.cms.admin.SanPham.QuanLyDanhMuc.DanhMucAdd" %>
<ul class="nav nav-tabs">
    <li class="nav-item">
        <a class="nav-link" href="AdminPage.aspx?modul=SanPham&modulphu=DanhSachSanPham&thaotac=HienThi">Quản Lý Sản Phẩm</a>
    </li>
    <li class="nav-item">
        <a class="nav-link active" aria-current="page" href="AdminPage.aspx?modul=SanPham&modulphu=DanhMuc&thaotac=ThemMoi">Quản lý Danh Mục</a>
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
    <a class="nav-link" href="AdminPage.aspx?modul=SanPham&modulphu=NhomSanPham&thaotac=HienThi">Quản Lý Nhóm</a>
  </li>
</ul>
<div class="row g-3 from-margin-lr">
    <div class="col-md-12 col-btn-add">
        <a href="AdminPage.aspx?modul=SanPham&modulphu=DanhMuc&thaotac=HienThi" class="btn btn-not btn-add"><ion-icon name="apps-outline"></ion-icon>Xem Danh Mục</a>
    </div>
    <div class="col-md-3">
        <label for="inputEmail4" class="form-label">Danh Mục Cha</label>
        <asp:DropDownList ID="ddlDanhMucCha" runat="server" CssClass="form-select" AppendDataBoundItems="true">
        </asp:DropDownList>
    </div>
    <div class="col-md-3">
        <label for="inputPassword4" class="form-label">Tên danh mục</label>
        <asp:TextBox ID="txtTenDanhMuc" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtTenDanhMuc" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-3">
        <label for="inputState" class="form-label">Hình ảnh</label>
        <div style="display: flex;">
            <asp:HiddenField ID="hdTenAnhDaiDienCu" runat="server" />
            <asp:Literal ID="ltrAnhDaiDien" runat="server"></asp:Literal>
            <asp:FileUpload ID="FileUploadanh" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="FileUploadanh" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        
    </div>

    <div class="col-md-3">
        <label for="inputAddress" class="form-label">Thứ Tự</label>
        <asp:TextBox ID="txtThuTu" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtThuTu" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>

    <div class="col-12">
        <asp:Button ID="btnthemmoi" runat="server" Text="Thêm" OnClick="btnThemmoi_Click" CssClass="btn btn-not" />
    </div>
</div>
