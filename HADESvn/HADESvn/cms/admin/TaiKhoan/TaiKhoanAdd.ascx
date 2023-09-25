<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TaiKhoanAdd.ascx.cs" Inherits="HADESvn.cms.admin.TaiKhoan.TaiKhoanAdd" %>
<div class="row g-3 from-margin-lr">
    <div class="col-md-12 col-btn-add">
        <a href="AdminPage?modul=TaiKhoan&modulphu=TaiKhoan&thaotac=HienThi" class="btn btn-not btn-add"><ion-icon name="apps-outline"></ion-icon>Xem Tài Khoản</a>
    </div>
    <div class="col-md-4">
        <label for="inputState" class="form-label">Chọn quyền</label>
        <asp:DropDownList ID="dropQuyen" runat="server" CssClass="form-select">           
        </asp:DropDownList>
    </div>
    <div class="col-md-4">
        <label for="inputEmail4" class="form-label">Tên đăng nhập</label>
        <asp:TextBox ID="txtTenDK" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtTenDK" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-4">
        <label for="inputPassword4" class="form-label">Mật khẩu</label>
        <asp:HiddenField ID="hdMatKhauCu" runat="server" /> 
        <asp:TextBox ID="txtMK" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtMK" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    
    
    <%--<div class="col-md-4">
        <label for="inputState" class="form-label">Hình ảnh</label>
        <asp:HiddenField ID="hdTenAnhDaiDienCu" runat="server" />
        <asp:Literal ID="ltrAnhDaiDien" runat="server"></asp:Literal>
        <asp:FileUpload ID="FileUploadanh" runat="server" CssClass="form-control" />      
    </div>--%>
    <div class="col-md-4">
        <label for="inputEmail4" class="form-label">Email</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-4">
        <label for="inputEmail4" class="form-label">Địa chỉ</label>
        <asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtDiaChi" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-4">
        <label for="inputEmail4" class="form-label">Họ tên</label>
        <asp:TextBox ID="txtHoten" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtHoten" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>

    <div class="col-md-6">
        <label for="inputPassword4" class="form-label">Ngày sinh (Tháng/Ngày/Năm)</label>
        <asp:TextBox ID="txtNgaySinh" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="txtNgaySinh" Display="Dynamic" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-6">
        <label for="inputState" class="form-label">Giới tính</label>
        <asp:DropDownList ID="dropGioiTinh" runat="server" CssClass="form-select">
                <asp:ListItem Text="Nam" Value="Nam"></asp:ListItem>
                <asp:ListItem Text="Nữ" Value="Nữ"></asp:ListItem>
                <asp:ListItem Text="Khác" Value="Khác"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="col-12">
        <asp:Button ID="btnthemmoi" runat="server" Text="Thêm" OnClick="btnThemmoi_Click" CssClass="btn btn-not" />
    </div> 
</div>