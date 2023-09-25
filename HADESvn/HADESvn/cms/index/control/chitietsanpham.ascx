<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="chitietsanpham.ascx.cs" Inherits="HADESvn.cms.index.control.chitietsanpham" %>
<div style="padding: 90px;">
    <div class="container-product-details">
        <div class="img-product-details">
            <img src='<%="..\\..\\..\\assets\\img\\SanPham\\" + infoSP.AnhSP%> ' alt="" />
        </div>
        <div class="content-product-details">
            <h2><%=infoSP.TenSP %></h2>
            <p><%=string.Format("{0:0,000}",infoSP.GiaSP)%>đ</p>
            <div class="text-field input-product-details">
            <input id="quantity" type="number" name="quantity" min="1" value="1"/>
             </div>
            <div class="content-product-details-group">
                <div class="product-details-group">
                    <span>Size: <asp:Literal ID="ltrKichThuoc" runat="server"></asp:Literal></span>
                </div>
                <div class="product-details-group">
                    <span>Coler: <asp:Literal ID="ltrMau" runat="server"></asp:Literal></span>
                </div>
                <div class="product-details-group">
                    <span>Material: <asp:Literal ID="ltrChatLieu" runat="server"></asp:Literal></span>
                </div>
                <div class="product-details-group">
                    <span><%=infoSP.MotaSP%></span>
                </div>
            </div>
            <div class="button-group">
                <a id="buy-now" class="btn btn-key" href="javascript:MuaNgay()">Buy Now</a>
                <a id="add-to-cart" class="btn btn-add-cart" href="javascript:ThemVaoGioHang()">Add Cart</a>             
            </div>
        </div>
    </div>
</div>
<%--Các script xử lý giỏ hàng--%>
<script type="text/javascript">
    function ThemVaoGioHang() {
        var id = "<%=inputID%>";
        var soLuong = $("#quantity").val();

        $.post("SanPham/Ajax/XuLyGioHang",
         {
             "ThaoTac": "ThemVaoGioHang",
             "id": id,
             "soLuong": soLuong
         },
         function (data, status) {
             //alert("Data :" + data + "\n Status :" + status);
             if (data == "") {
                 //thực hiện thành công => thông báo
                 /*alert("Đã thêm sản phẩm vào giỏ hàng thành công");*/
                 alertSweetalert2('Đã thêm vào giỏ hàng :))', 'addCart');
             } else {
                 alert(data);
             }
         });
    }

    function MuaNgay() {
        var id = "<%=inputID%>";
        var soLuong = $("#quantity").val();

        $.post("SanPham/Ajax/XuLyGioHang",
         {
             "ThaoTac": "ThemVaoGioHang",
             "id": id,
             "soLuong": soLuong
         },
         function (data, status) {
             //alert("Data :" + data + "\n Status :" + status);
             if (data == "") {
                 //thực hiện thành công => thông báo
                 /*alert("Đã thêm sản phẩm vào giỏ hàng thành công");*/
                 alertSweetalert2('Đã thêm sản phẩm vào giỏ hàng thành công !!!', 'success');
                 //Đẩy về trang hiển thị giỏ hàng
                 location.href = "/cms/index/page/GioHang";
             } else {
                 alert(data);
             }
         });
    }
</script>