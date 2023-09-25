<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vnpay_return.aspx.cs" Inherits="HADESvn.vnpay_return" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RETURN URL FROM VNPAY</title>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="header clearfix">

            <h3 class="text-muted">Kết quả thanh toán</h3>
        </div>
        <form id="form1" runat="server">
            <div class="table-responsive">
                <div runat="server" id="displayMsg"></div>
            </div>
            <div class="table-responsive">
                <div runat="server" id="displayTmnCode"></div>
            </div>
            <div class="table-responsive">
                <div runat="server" id="displayTxnRef"></div>
            </div>
            <div class="table-responsive">
                <div runat="server" id="displayVnpayTranNo"></div>
            </div>
            <div class="table-responsive">
                <div runat="server" id="displayAmount"></div>
            </div>
            <div class="table-responsive">
                <div runat="server" id="displayFullName"></div>
            </div>
            <div class="table-responsive">
                <div runat="server" id="displayEmail"></div>
            </div>
            <div class="table-responsive">
                <div runat="server" id="displayMobile"></div>
            </div>
            <div class="table-responsive">
                <div runat="server" id="displayAddress"></div>
            </div>        
             <div class="table-responsive">
                <div runat="server" id="displayInfo"></div>
            </div>
            <div class="table-responsive">
                <div runat="server" id="displayBankCode"></div>
            </div>
            <div class="table-responsive">
                <asp:Button ID="Button1" runat="server" Text="Tiếp Tục Mua Hàng" CssClass="btn" OnClick="Button1_Click" style="background:#ee9ca7;color:#fff;margin-top:10px;"/>
            </div>
        </form>
    </div>
</body>
</html>
