<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThanhToanTrucTuyen.aspx.cs" Inherits="HADESvn.cms.index.page.ThanhToanTrucTuyen" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VNPAY DEMO</title>
    <link href="../../../Styles/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container" style="margin-bottom: 70px;">
        <div class="header clearfix">
            <h3 class="text-muted">VNPAY</h3>
        </div>
        <div class="table-responsive">
            <form id="form1" runat="server">
                <div class="row" style="width: 100%;">
                    <div class="col-md-6">
                        <h3>Thông tin thanh toán</h3>

                        <div class="form-group">
                            <label>Loại hàng hóa (*) </label>
                            <asp:DropDownList ID="orderCategory" runat="server" CssClass="form-control">
                                <asp:ListItem Value="topup" Text="Nạp tiền điện thoại"></asp:ListItem>
                                <asp:ListItem Value="billpayment" Text="Thanh toán hóa đơn"></asp:ListItem>
                                <asp:ListItem Value="fashion" Text="Thời trang"></asp:ListItem>
                                <asp:ListItem Value="other" Text="Thanh toán trực tuyến"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <label>Số tiền Thanh toán(*)</label>
                            <asp:TextBox ID="txtTongTien" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Nội dung thanh toán (*)</label>
                            <asp:TextBox ID="txtOrderDesc" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Ngân hàng</label>
                            <asp:DropDownList ID="cboBankCode" runat="server" CssClass="form-control">
                                <asp:ListItem Value="" Text="Không chọn"></asp:ListItem>
                                <asp:ListItem Value="VNPAYQR" Text="VNPAYQR"></asp:ListItem>
                                <asp:ListItem Value="VNBANK" Text="LOCAL BANK"></asp:ListItem>
                                <asp:ListItem Value="INTCARD" Text="INTERNATIONAL CARD"></asp:ListItem>
                                <asp:ListItem Value="VISA" Text="VISA"></asp:ListItem>
                                <asp:ListItem Value="MASTERCARD" Text="MASTERCARD"></asp:ListItem>
                                <asp:ListItem Value="JCB" Text="JCB"></asp:ListItem>
                                <asp:ListItem Value="UPI" Text="UPI"></asp:ListItem>
                                <asp:ListItem Value="NCB" Text="Ngan hang NCB"></asp:ListItem>
                                <asp:ListItem Value="SACOMBANK" Text="Ngan hang SacomBank"></asp:ListItem>
                                <asp:ListItem Value="EXIMBANK" Text="Ngan hang EximBank"></asp:ListItem>
                                <asp:ListItem Value="MSBANK" Text="Ngan hang MSBANK"></asp:ListItem>
                                <asp:ListItem Value="NAMABANK" Text="Ngan hang NamABank "></asp:ListItem>
                                <asp:ListItem Value="VNMART" Text="Vi dien tu VNPAY"></asp:ListItem>
                                <asp:ListItem Value="VIETINBANK" Text="Ngan hang Vietinbank"></asp:ListItem>
                                <asp:ListItem Value="VIETCOMBANK" Text="Ngan hang VCB"></asp:ListItem>
                                <asp:ListItem Value="HDBANK" Text="Ngan hang HDBank"></asp:ListItem>
                                <asp:ListItem Value="DONGABANK" Text="Ngan hang Dong A"></asp:ListItem>
                                <asp:ListItem Value="TPBANK" Text="Ngân hàng TPBank"></asp:ListItem>
                                <asp:ListItem Value="OJB" Text="Ngân hàng OceanBank"></asp:ListItem>
                                <asp:ListItem Value="BIDV" Text="Ngân hàng BIDV"></asp:ListItem>
                                <asp:ListItem Value="TECHCOMBANK" Text="Ngân hàng Techcombank"></asp:ListItem>
                                <asp:ListItem Value="VPBANK" Text="Ngan hang VPBank"></asp:ListItem>
                                <asp:ListItem Value="AGRIBANK" Text="Ngan hang Agribank"></asp:ListItem>
                                <asp:ListItem Value="ACB" Text="Ngan hang ACB"></asp:ListItem>
                                <asp:ListItem Value="OCB" Text="Ngan hang Phuong Dong"></asp:ListItem>
                                <asp:ListItem Value="SCB" Text="Ngan hang SCB"></asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="form-group">
                            <label>Ngôn ngữ  (*)</label>
                            <asp:DropDownList ID="cboLanguage" CssClass="form-control" runat="server">
                                <asp:ListItem Value="vn" Text="Tiếng Việt"></asp:ListItem>
                                <asp:ListItem Value="en" Text="English"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Thời hạn thanh toán</label>
                            <asp:TextBox ID="txtExpire" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <h3>Thông tin hóa đơn</h3>
                        </div>
                        <div class="form-group">
                            <label>Họ tên (*)</label>
                            <asp:TextBox ID="txt_billing_fullname" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Email (*)</label>
                            <asp:TextBox ID="txt_billing_email" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Số điện thoại (*)</label>
                            <asp:TextBox ID="txt_billing_mobile" runat="server" CssClass="form-control"></asp:TextBox>

                        </div>
                        <div class="form-group">
                            <label>Địa chỉ (*)</label>
                            <asp:TextBox ID="txt_billing_addr1" runat="server" CssClass="form-control"></asp:TextBox>

                        </div>
                        <div class="form-group">
                            <label>Mã bưu điện (*)</label>
                            <asp:TextBox ID="txt_postalcode" runat="server" CssClass="form-control">100000</asp:TextBox>
                        </div>
                    </div>
                </div>


                <div class="form-group">
                    <asp:Button ID="btnPay" runat="server" Text="Thanh Toán" CssClass="btn" OnClick="btnPay_Click" style="background:#ee9ca7;color:#fff;"/>
                </div>
            </form>
            <asp:Label runat="server" ID="lblMessage" ForeColor="#FF3300"></asp:Label>
        </div>
    </div>

</body>
</html>
