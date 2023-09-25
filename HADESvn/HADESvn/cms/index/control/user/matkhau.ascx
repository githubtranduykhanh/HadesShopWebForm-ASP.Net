<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="matkhau.ascx.cs" Inherits="HADESvn.cms.index.control.user.matkhau" %>
<div style="padding:0 280px;">
    <h1 style="color: var(--text-color); text-align: center;">Mật Khẩu Của Tôi</h1>
<div class="from-mat-khau">
    <label for="txtMatKhauCu" class="label">Your  Password</label>
    <div class="text-field field">
        <asp:TextBox ID="txtMatKhauCu" runat="server" placeholder="Your  Password" type="password"></asp:TextBox>
        <div class="toggle-password">
          <svg
            xmlns="http://www.w3.org/2000/svg"
            class="eye eye-open"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
            stroke-width="2"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              d="M15 12a3 3 0 11-6 0 3 3 0 016 0z"
            />
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z"
            />
          </svg>
          <svg
            xmlns="http://www.w3.org/2000/svg"
            class="eye eye-close"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
            stroke-width="2"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              d="M13.875 18.825A10.05 10.05 0 0112 19c-4.478 0-8.268-2.943-9.543-7a9.97 9.97 0 011.563-3.029m5.858.908a3 3 0 114.243 4.243M9.878 9.878l4.242 4.242M9.88 9.88l-3.29-3.29m7.532 7.532l3.29 3.29M3 3l3.59 3.59m0 0A9.953 9.953 0 0112 5c4.478 0 8.268 2.943 9.543 7a10.025 10.025 0 01-4.132 5.411m0 0L21 21"
            />
          </svg>
        </div>
        <%--<input id="tbDiaChi" type="text" placeholder="Your Address" />--%>
    </div>
    <label for="txtMatKhauMoi" class="label">New Your  Password</label>
    <div class="text-field field">       
        <asp:TextBox ID="txtMatKhauMoi" runat="server" placeholder="New Your Password" type="password"></asp:TextBox>
         <div class="toggle-password">
          <svg
            xmlns="http://www.w3.org/2000/svg"
            class="eye eye-open"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
            stroke-width="2"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              d="M15 12a3 3 0 11-6 0 3 3 0 016 0z"
            />
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z"
            />
          </svg>
          <svg
            xmlns="http://www.w3.org/2000/svg"
            class="eye eye-close"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
            stroke-width="2"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              d="M13.875 18.825A10.05 10.05 0 0112 19c-4.478 0-8.268-2.943-9.543-7a9.97 9.97 0 011.563-3.029m5.858.908a3 3 0 114.243 4.243M9.878 9.878l4.242 4.242M9.88 9.88l-3.29-3.29m7.532 7.532l3.29 3.29M3 3l3.59 3.59m0 0A9.953 9.953 0 0112 5c4.478 0 8.268 2.943 9.543 7a10.025 10.025 0 01-4.132 5.411m0 0L21 21"
            />
          </svg>
        </div>
        <%--<input id="tbDiaChi" type="text" placeholder="Your Address" />--%>
    </div>
     <label for="txtNhapLaiMatKhau" class="label">Re-enter Your Password</label>
    <div class="text-field field">
        
        <asp:TextBox ID="txtNhapLaiMatKhau" runat="server" placeholder="Re-enter Your Password" type="password"></asp:TextBox>
            <div class="toggle-password">
          <svg
            xmlns="http://www.w3.org/2000/svg"
            class="eye eye-open"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
            stroke-width="2"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              d="M15 12a3 3 0 11-6 0 3 3 0 016 0z"
            />
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z"
            />
          </svg>
          <svg
            xmlns="http://www.w3.org/2000/svg"
            class="eye eye-close"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
            stroke-width="2"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              d="M13.875 18.825A10.05 10.05 0 0112 19c-4.478 0-8.268-2.943-9.543-7a9.97 9.97 0 011.563-3.029m5.858.908a3 3 0 114.243 4.243M9.878 9.878l4.242 4.242M9.88 9.88l-3.29-3.29m7.532 7.532l3.29 3.29M3 3l3.59 3.59m0 0A9.953 9.953 0 0112 5c4.478 0 8.268 2.943 9.543 7a10.025 10.025 0 01-4.132 5.411m0 0L21 21"
            />
          </svg>
        </div>
        <%--<input id="tbDiaChi" type="text" placeholder="Your Address" />--%>
    </div>
    <div style="margin-top: 47px;">
        <asp:Button ID="btnlaumk" runat="server" Text="Lưu Mật Khẩu" CssClass="button-default btn-key btn-link-thanhtoan" OnClick="btnlaumk_Click" />
        <%--            <a href="javacript://" class="button-default btn-key">Lưu Thông Tin</a>--%>
    </div>   
</div>
</div>

