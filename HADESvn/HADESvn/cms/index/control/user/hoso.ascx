<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="hoso.ascx.cs" Inherits="HADESvn.cms.index.control.user.hoso" %>
<h1 style="color: var(--text-color); text-align: center;">Hồ Sơ Của Tôi</h1>

<div class="row-flex">
    <div class="col-flex-9">
        
        <div class="text-field">
            <asp:TextBox ID="tbHoTen" runat="server" placeholder="Your Name" type="text"></asp:TextBox>
<%--            <input id="tbHoTen"   />--%>
        </div>
        <div class="row-flex">
            <div class="text-field col-flex-2">
                <asp:TextBox ID="tbEmail" runat="server" placeholder="Email Address" type="email"></asp:TextBox>
                <%--<input id="tbEmail" type="text" placeholder="Email Address" />--%>
            </div>
            <div class="text-field col-flex-2">
                <asp:TextBox ID="tbSoDienThoai" runat="server" placeholder="Mobile Number" type="text"></asp:TextBox>
                <%--<input id="tbSoDienThoai" type="text" placeholder="Mobile Number" />--%>
            </div>
        </div>
        <div class="text-field">
            <asp:TextBox ID="tbDiaChi" runat="server" placeholder="Your Address" type="text"></asp:TextBox>
            <%--<input id="tbDiaChi" type="text" placeholder="Your Address" />--%>
        </div>
        <div style="margin-top: 47px;">
            <asp:Button ID="btnluuthongtin" runat="server" Text="Lưu Thông Tin"  CssClass="button-default btn-key btn-link-thanhtoan" OnClick="btnluuthongtin_Click" />
<%--            <a href="javacript://" class="button-default btn-key">Lưu Thông Tin</a>--%>
        </div>
    </div>
    <div class="col-flex-3">
        <div class="text-field text-field--not-margin" style="text-align:center;">
            <asp:HiddenField ID="hdTenAnhDaiDienCu" runat="server" />
            <asp:Literal ID="ltrAnhDaiDien" runat="server"></asp:Literal>
            <asp:FileUpload ID="FileUploadanh" runat="server" CssClass="form-control" Style="margin-top: 30px;" />
        </div>

    </div>
</div>


