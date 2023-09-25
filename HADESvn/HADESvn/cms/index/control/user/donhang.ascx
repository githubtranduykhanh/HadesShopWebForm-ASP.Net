<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="donhang.ascx.cs" Inherits="HADESvn.cms.index.control.user.donhang" %>
<div id="DonHangNguoiDung"></div>
<script type="text/javascript">
    function LayRaThongTinDonHangNguoiDung() {
        $.post("SanPham/Ajax/XuLyGioHang",
            {
                "ThaoTac": "LayRaThongTinDonHangNguoiDung"
            },
            function (data, status) {
                //alert("Data :" + data + "\n Status :" + status);
                $("#DonHangNguoiDung").html(data);
            });
    }
    $(document)
        .ready(function () {
            LayRaThongTinDonHangNguoiDung()
        });
</script>
