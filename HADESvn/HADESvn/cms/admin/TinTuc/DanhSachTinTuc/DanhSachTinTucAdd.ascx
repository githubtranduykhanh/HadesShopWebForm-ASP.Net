<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DanhSachTinTucAdd.ascx.cs" Inherits="HADESvn.cms.admin.TinTuc.DanhSachTinTuc.DanhSachTinTucAdd" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<ul class="nav nav-tabs">
    <li class="nav-item">
        <a class="nav-link"  href="AdminPage.aspx?modul=TinTuc&modulphu=DanhMucTin&thaotac=HienThi">Quản Lý Danh Sách Tin Tức</a>
    </li>
    <li class="nav-item">
        <a class="nav-link active" aria-current="page" href="AdminPage.aspx?modul=TinTuc&modulphu=DanhSachTinTuc&thaotac=HienThi">Quản Lý Tin Tức</a>
    </li>     
</ul>
<div class="row g-3 from-margin-lr">
    <div class="col-md-12 col-btn-add">
        <a href="AdminPage.aspx?modul=TinTuc&modulphu=DanhSachTinTuc&thaotac=HienThi" class="btn btn-not btn-add"><ion-icon name="apps-outline"></ion-icon>Xem Tin Tức</a>
    </div>
    <div class="col-md-4">
        <label for="inputEmail4" class="form-label">Danh Mục Tin</label>
        <asp:DropDownList ID="ddlDanhMucCha" runat="server" CssClass="form-select" AppendDataBoundItems="true">
        </asp:DropDownList>
    </div>
    <div class="col-md-4">
        <label for="inputPassword4" class="form-label">Tiêu đề</label>
        <asp:TextBox ID="txtTieuDe" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtTieuDe" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-4">
        <label for="inputPassword4" class="form-label">Mô tả</label>
        <asp:TextBox ID="txtMoTa" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtMoTa" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-3">
        <label for="inputPassword4" class="form-label">Lượt xem</label>
        <asp:TextBox ID="txtLuotXem" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtLuotXem" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-3">
        <label for="inputPassword4" class="form-label">Ngày đăng</label>
        <asp:TextBox ID="txtNgayDang" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="txtNgayDang" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
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
        <label for="inputAddress" class="form-label">Bài viết chi tiết</label>
        <CKEditor:CKEditorControl ID="txtChiTiet" runat="server" FilebrowserImageBrowseUrl="ckeditor/ckfinder/ckfinder.aspx?type=Images&path=pic"></CKEditor:CKEditorControl>
        <%--<asp:TextBox ID="txtChiTiet" runat="server" TextMode="MultiLine" CssClass="form-control text-area"></asp:TextBox>--%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="txtChiTiet" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>

    <div class="col-12">
        <asp:Button ID="btnthemmoi" runat="server" Text="Thêm" OnClick="btnThemmoi_Click" CssClass="btn btn-not" />
    </div>
</div>