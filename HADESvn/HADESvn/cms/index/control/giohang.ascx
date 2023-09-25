<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="giohang.ascx.cs" Inherits="HADESvn.cms.index.control.giohang" %>
<%--<script src="https://code.jquery.com/jquery-3.6.0.js"></script>--%>
<div style="padding: 90px;">
    <div class="container-product-details container-product-details-cart" style="margin: 40px 0 40px 0;">
        <div class="cart-left-flex">
            <div id="BangThongTinGioHang" style="margin: 30px 0 0 0;">
            </div>          
        </div>
        <div class="cart-right-flex" style="max-height: 210px;">
            <a href="https://localhost:44385/cms/index/page/ThanhToan" class="button-default btn-key" id="btn_Link_Thanh_Toan">Thanh Toán</a>
            <%--<asp:Button ID="btn_Link_Thanh_Toan" runat="server" Text="Thanh Toán" CssClass="button-default btn-key btn-link-thanhtoan" OnClick="btn_Link_Thanh_Toan_Click"/>--%>
            <div style="margin: 5px 10px 0px;">
                <div class='space-between'>
                    <h3>Tổng số sản phẩm:</h3>
                    <h3 id="TongSoSPTrongGioHang">0</h3>
                </div>
                <div class='space-between'>
                    <h3>Tổng tiền:</h3>
                    <h3 id="TongTienTrongGioHang">0</h3>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    //Viết ajax lấy thông tin giỏ hàng từ session
    function LayThongTinGioHang() {
        $.post("SanPham/Ajax/XuLyGioHang",
            {
                "ThaoTac": "LayThongTinGioHang"
            },
            function (data, status) {
                //alert("Data :" + data + "\n Status :" + status);
                $("#BangThongTinGioHang").html(data);
            });
    }
    //function LayRaThongTinDonHangNguoiDung() {
    //    $.post("SanPham/Ajax/XuLyGioHang",
    //        {
    //            "ThaoTac": "LayRaThongTinDonHangNguoiDung"
    //        },
    //        function (data, status) {
    //            //alert("Data :" + data + "\n Status :" + status);
    //            $("#DonHangNguoiDung").html(data);
    //        });
    //}
    function LayTongSoSanPhamTrongGioHang() {
        $.post("SanPham/Ajax/XuLyGioHang",
            {
                "ThaoTac": "LayTongSoSanPhamTrongGioHang"
            },
            function (data, status) {
                //alert("Data :" + data + "\n Status :" + status);
                $("#TongSoSPTrongGioHang").html(data);
            });
    }
    function LayTongTienTrongGioHang() {
        $.post("SanPham/Ajax/XuLyGioHang",
            {
                "ThaoTac": "LayTongTienTrongGioHang"
            },
            function (data, status) {
                //alert("Data :" + data + "\n Status :" + status);
                $("#TongTienTrongGioHang").html(data);
                $("#TongTienTrongGioHang").append(" VND");
                if (data == "0,000") {                  
                    $("#btn_Link_Thanh_Toan").on("click", function (e) {                                                    
                        e.preventDefault();
                        alertSweetalert2('Giỏ hàng đã hết hạn', 'warning');
                    });
                    
                }

            });
    }
    //Gọi hàm lần đầu để khi load trang sẽ lấy ra thông tin luôn
    

    //Hàm xóa 1 sản phẩm trong giỏ hàng
    function XoaSPTrongGioHang(idSanPham) {
        ////Hỏi để xác nhận lại yêu cầu xóa từ người dùng
        ///* confirm("Bạn muốn xóa sản phẩm này khỏi giỏ hàng?")*/
        //if (alertSweetalert2('Đã thêm sản phẩm vào giỏ hàng thành công !!!', 'deleted') === true) {

        //    $.post("SanPham/Ajax/XuLyGioHang",
        //        {
        //            "ThaoTac": "XoaSPTrongGioHang",
        //            "idSanPham": idSanPham
        //        },
        //        function (data, status) {
        //            //alert("Data :" + data + "\n Status :" + status);

        //            //Nếu không có lỗi (tức là xóa thành công) --> ẩn dòng chứa sản phẩm khỏi bảng hiển thị giỏ hàng --> Gọi hàm cập nhật số lượng, tổng tiền
        //            if (data === "") {
        //                $("#maDong_" + idSanPham).remove();

        //                LayTongSoSanPhamTrongGioHang();
        //                LayTongTienTrongGioHang();
        //            }
        //        });
        //}
        //const swalWithBootstrapButtons = Swal.mixin({
        //    customClass: {
        //        confirmButton: 'btn btn-alert-confirm',
        //        cancelButton: 'btn btn-alert-cance'
        //    },
        //    buttonsStyling: false
        //})

        swalWithBootstrapButtons.fire({
            title: 'Xác nhận xóa?',
            text: "Bạn có muốn xóa sản phẩm này",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            cancelButtonText: 'No, cancel!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.post("SanPham/Ajax/XuLyGioHang",
                    {
                        "ThaoTac": "XoaSPTrongGioHang",
                        "idSanPham": idSanPham
                    },
                    function (data, status) {
                        //alert("Data :" + data + "\n Status :" + status);

                        //Nếu không có lỗi (tức là xóa thành công) --> ẩn dòng chứa sản phẩm khỏi bảng hiển thị giỏ hàng --> Gọi hàm cập nhật số lượng, tổng tiền
                        if (data === "") {
                            $("#maDong_" + idSanPham).slideUp();

                            LayTongSoSanPhamTrongGioHang();
                            LayTongTienTrongGioHang();
                        }
                    });
                swalWithBootstrapButtons.fire(
                    'Deleted!',
                    'Bạn đã xóa thành sản phẩm thành công',
                    'success'
                )
            } else if (
                /* Read more about handling dismissals below */
                result.dismiss === Swal.DismissReason.cancel
            ) {
                swalWithBootstrapButtons.fire(
                    'Cancelled',
                    'Sản phẩm vẫn còn trong giỏ hàng)',
                    'error'
                )
            }
        })

    }
    //Hàm cập nhật số lượng cho một sản phẩm trong giỏ hàng
    function CapNhatSoLuongVaoGioHang(idSanPham) {

        //Lấy số lượng mới sửa từ textbox
        var soLuongMoi = $("#quantity_" + idSanPham).val();

        $.post("SanPham/Ajax/XuLyGioHang",
            {
                "ThaoTac": "CapNhatSoLuongVaoGioHang",
                "idSanPham": idSanPham,
                "soLuongMoi": soLuongMoi
            },
            function (data, status) {
                //alert("Data :" + data + "\n Status :" + status);

                //Nếu không có lỗi (tức là xóa thành công) --> ẩn dòng chứa sản phẩm khỏi bảng hiển thị giỏ hàng --> Gọi hàm cập nhật số lượng, tổng tiền
                if (data === "") {
                    LayTongSoSanPhamTrongGioHang();
                    LayTongTienTrongGioHang();
                }
            });
    }

    //Hàm gửi đơn hàng
    //function GuiDonHangThanhToan() {
    //    //Kiểm tra xem khách hàng đã nhập đủ họ tên và số điện thoại chưa
    //    if ($("#tbHoTen").val() !== "" && $("#tbSoDienThoai").val() !== "") {

    //        $.post("SanPham/Ajax/XuLyGioHang",
    //            {
    //                "ThaoTac": "GuiDonHangThanhToan",
    //                "hoTen": $("#tbHoTen").val(),
    //                "diaChi": $("#tbDiaChi").val(),
    //                "soDienThoai": $("#tbSoDienThoai").val(),
    //                "email": $("#tbEmail").val(),

    //            },
    //            function (data, status) {
    //                if (data === "") {
    //                    /*alert("Bạn đã gửi đơn hàng thành công");*/
    //                    alertSweetalert2('Bạn đã gửi đơn hàng thành công !!!', 'success');
    //                    LayThongTinGioHang();                       
    //                    LayRaThongTinDonHangNguoiDung();
    //                }
    //            });

    //    }
    //    else {
    //        /*alert("Vui lòng nhập đầy đủ Họ tên và Số điện thoại để đặt hàng");*/
    //        alertSweetalert2('Vui lòng nhập đầy đủ Họ tên và Số điện thoại để đặt hàng !!!', 'warning');
    //    }
    //}
    $(document)
        .ready(function () {
            LayThongTinGioHang();
            LayTongSoSanPhamTrongGioHang();
            LayTongTienTrongGioHang();
        });
</script>
