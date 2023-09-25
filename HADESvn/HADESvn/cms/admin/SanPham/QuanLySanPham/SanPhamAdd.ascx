<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SanPhamAdd.ascx.cs" Inherits="HADESvn.cms.admin.SanPham.QuanLySanPham.SanPhamAdd" %>
<ul class="nav nav-tabs">
   <li class="nav-item">
    <a class="nav-link active" aria-current="page" href="AdminPage.aspx?modul=SanPham&modulphu=DanhSachSanPham&thaotac=HienThi">Quản Lý Sản Phẩm</a>
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
    <a class="nav-link" href="AdminPage.aspx?modul=SanPham&modulphu=NhomSanPham&thaotac=HienThi">Quản Lý Nhóm</a>
  </li>
</ul>
<div class="row g-3 from-margin-lr">
    <div class="col-md-12 col-btn-add">
        <a href="AdminPage?modul=SanPham&modulphu=DanhSachSanPham&thaotac=HienThi" class="btn btn-not btn-add"><ion-icon name="apps-outline"></ion-icon>Xem Sản Phẩm</a>
    </div>
    <div class="col-md-6">
        <label for="inputState" class="form-label">Danh Mục</label>
        <asp:DropDownList ID="dropDanhMuc" runat="server" CssClass="form-select">           
        </asp:DropDownList>
    </div>
    <div class="col-md-6">
        <label for="inputEmail4" class="form-label">Tên Sản Phẩm</label>
        <asp:TextBox ID="txtTenSP" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtTenSP" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-4">
        <label for="inputPassword4" class="form-label">Gía</label>
        <asp:TextBox ID="txtgia" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtGia" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>  
    <div class="col-md-4">
        <label for="inputState" class="form-label">Hình ảnh</label>
        <asp:HiddenField ID="hdTenAnhDaiDienCu" runat="server" />
        <asp:Literal ID="ltrAnhDaiDien" runat="server"></asp:Literal>
        <asp:FileUpload ID="FileUploadanh" runat="server" CssClass="form-control" />
    </div>
    <div class="col-md-4">
        <label for="inputEmail4" class="form-label">Nhóm</label>
        <asp:DropDownList ID="dropNhom" runat="server" CssClass="form-select">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="dropNhom" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-4">
        <label for="inputEmail4" class="form-label">Size</label>
        <asp:DropDownList ID="dropSize" runat="server" CssClass="form-select">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="dropSize" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>

    <div class="col-md-4">
        <label for="inputState" class="form-label">Màu</label>
        <asp:DropDownList ID="dropmau" runat="server" CssClass="form-select">
        </asp:DropDownList>
    </div>
    <div class="col-md-4">
        <label for="inputState" class="form-label">Chất Liệu</label>
        <asp:DropDownList ID="dropChatLieu" runat="server" CssClass="form-select">
        </asp:DropDownList>
    </div>
    <div class="col-md-6">
        <label for="inputEmail4" class="form-label">Ngày Tạo</label>
        <asp:TextBox ID="txtTao" runat="server" CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtTao" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-6">
        <label for="inputPassword4" class="form-label">Ngày Hủy</label>
        <asp:TextBox ID="txtHuy" runat="server" CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="txtHuy" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="col-12">
        <label for="inputAddress" class="form-label">Mô Tả</label>
        <asp:TextBox ID="txtMota" runat="server" TextMode="MultiLine" CssClass="form-control text-area"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="txtMota" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="col-12">
        <asp:Button ID="btnthemmoi" runat="server" Text="Thêm" OnClick="btnThemmoi_Click" CssClass="btn btn-not" />
    </div>
</div>
