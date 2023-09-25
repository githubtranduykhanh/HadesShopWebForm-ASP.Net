﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vnpay_refund.aspx.cs" Inherits="HADESvn.vnpay_refund" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VNPAY DEMO REFUND</title>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="header clearfix">

            <h3 class="text-muted">VNPAY DEMO REFUND</h3>
        </div>
        <form id="form1" runat="server">
            <div class="form-group">
                <label>Mã giao dịch hoàn(*)</label>
                <asp:TextBox ID="OrderId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Số tiền hoàn(*)</label>
                <asp:TextBox ID="Amount" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Kiểu hoàn tiền(*)</label>
                <asp:DropDownList ID="RefundCategory" runat="server" CssClass="form-control">
                    <asp:ListItem Value="02" Text="Hoàn tiền toàn phần"></asp:ListItem>
                    <asp:ListItem Value="03" Text="Hoàn tiền một phần"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label>Thời gian thanh toán(*)</label>
                <asp:TextBox ID="payDate" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Email khởi tạo hoàn(*)</label>
                <asp:TextBox ID="Email" runat="server" CssClass="form-control"></asp:TextBox>

            </div>
            <asp:Button ID="btnSearch" runat="server" Text="Refund" CssClass="btn btn-default" OnClick="btnRefund_Click" />
            <div runat="server" id="display" style="padding-top: 20px"></div>
            <div runat="server" id="displaymessage" style="padding-top: 20px"></div>
        </form>
    </div>
</body>
</html>
