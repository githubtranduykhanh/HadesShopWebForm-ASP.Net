<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="lienhe.ascx.cs" Inherits="HADESvn.cms.index.control.lienhe" %>
<div class="container-padding">
    <img src="../../../assets/img/img-product-heading.JPG" alt="" class="img-heading" />
    <div class="flex-content ">
        <div class="map slideright ">
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3929.107887631924!2d105.72064291474227!3d10.007946492845722!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31a08903d92d1d0d%3A0x2c147a40ead97caa!2zVHLGsOG7nW5nIMSQ4bqhaSBo4buNYyBOYW0gQ-G6p24gVGjGoQ!5e0!3m2!1svi!2s!4v1667742487290!5m2!1svi!2s" style="border: 0; width: 100%; height: 100%;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
        </div>
        <div class="contact-from slideleft">
            <div class="from-input">
                <div class="text-field">
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="from-input-text" type="text" placeholder="First Name"></asp:TextBox>
                    <%--<input type="text" placeholder="First Name" class="from-input-text"/>--%>
                </div>
                <div class="text-field">
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="from-input-text" type="text" placeholder="Last Name"></asp:TextBox>
                    <%--                 <input type="text" placeholder="Last Name" class="from-input-text"/>--%>
                </div>
            </div>
            <div class="text-field">
                <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="from-input-text" type="email" placeholder="Email Address"></asp:TextBox>
                <%--<input type="text" placeholder="Email Address" class="from-input-text" />--%>
            </div>
            <div class="text-field">
                 <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="from-input-text" type="number" placeholder="Mobile Number"></asp:TextBox>
                <%--<input type="text" placeholder="Mobile Number" class="from-input-text" />--%>
            </div>
            <div class="text-field">
                <asp:TextBox ID="txtMessage" runat="server" cols="30" rows="7" CssClass="from-input-text" type="text" TextMode="MultiLine" placeholder="Write your message here..."></asp:TextBox>
                <%--<textarea name="" id="" cols="30" rows="7" placeholder="Write your message here..." class="from-input-text"></textarea>--%>
            </div>
            <asp:Button ID="btnSend" runat="server" Text="Send"  CssClass="btn btn-login btn-contact-from" OnClick="btnSend_Click"/>
            <%--<button class="btn btn-login btn-contact-from">Send</button>--%>
        </div>
    </div>
</div>
