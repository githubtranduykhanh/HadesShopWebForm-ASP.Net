<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuAdd.ascx.cs" Inherits="HADESvn.cms.admin.Menu.MenuAdd" %>
<ul class="nav nav-tabs">
    <li class="nav-item">
        <a class="nav-link" href="AdminPage.aspx?modul=Menu&modulphu=DanhSachMenu">Danh Sách Menu</a>
    </li>
    <li class="nav-item">
        <a class="nav-link active" aria-current="page" href="AdminPage.aspx?modul=Menu&modulphu=DanhSachMenu&thaotac=ThemMoi">Thêm Mới Menu</a>
    </li>    
</ul>
<div class="row g-3 from-margin-lr">
    <div class="col-md-12 col-btn-add">
        <a href="AdminPage.aspx?modul=Menu&modulphu=DanhSachMenu" class="btn btn-not btn-add"><ion-icon name="apps-outline"></ion-icon>Xem Menu</a>
    </div>
    <div class="col-md-3">
        <label for="inputEmail4" class="form-label">Menu cha</label>
        <asp:DropDownList ID="ddlMenuCha" runat="server" CssClass="form-select" AppendDataBoundItems="true">
        </asp:DropDownList>
    </div>
    <div class="col-md-3">
        <label for="inputPassword4" class="form-label">Tên menu</label>
        <asp:TextBox ID="tbTenMenu" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="tbTenMenu" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-3">
        <label for="inputPassword4" class="form-label">Liên kết</label>
        <asp:TextBox ID="tbLienKet" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="tbLienKet" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-3">
        <label for="inputAddress" class="form-label">Thứ Tự</label>
        <asp:TextBox ID="tbThuTu" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="tbThuTu" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="col-12">
        <asp:Button ID="btnthemmoi" runat="server" Text="Thêm" OnClick="btnThemmoi_Click" CssClass="btn btn-not" />
    </div>
</div>