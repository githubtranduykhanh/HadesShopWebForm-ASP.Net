<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="thanhtoan.ascx.cs" Inherits="HADESvn.cms.index.control.thanhtoan" %>
<%--<script src="https://code.jquery.com/jquery-3.6.0.js"></script>--%>
<div style="padding: 90px;">
    <div class="container-product-details container-product-details-cart" style="margin: 40px 0 40px 0;">
        <div class="cart-left-flex">
            <h1 style="color: var(--text-color); text-align: center;">Thông Tin Giao Hàng</h1>
            <div class="text-field">
                <input id="tbHoTen" type="text" placeholder="Your Name" value="<%=hoTen%>" />
            </div>
            <div class="row-flex">
                <div class="text-field col-flex-2">
                    <input id="tbEmail" type="email" placeholder="Email Address" value="<%=email%>" />
                </div>
                <div class="text-field col-flex-2">
                    <input id="tbSoDienThoai" type="text" placeholder="Mobile Number" value="<%=soDienThoai%>"/>
                </div>
            </div>
            <div class="text-field">
                <input id="tbDiaChi" type="text" placeholder="Your Address" value="<%=diaChi%>" />
            </div>
            <div class="row-flex">
                <div class="text-field col-flex-3">
                    <%--<select class="custom-dropdown-select">
                        <option>Chọn Tỉnh / Thành</option>
                        <option>Giá: Giảm dần</option>
                        <option>Tên: A-Z</option>
                        <option>Tên: Z-A</option>
                    </select>--%>
                    <select class="custom-dropdown-select" id="customer_shipping_province" name="customer_shipping_province">
                        <option value="null" selected="">Chọn tỉnh / thành </option>
                        <option  >Hồ Chí Minh</option>
                        <option >Hà Nội</option>
                        <option >Đà Nẵng</option>
                        <option >An Giang</option>
                        <option >Bà Rịa - Vũng Tàu</option>
                        <option >Bình Dương</option>
                        <option >Bình Phước</option>
                        <option >Bình Thuận</option>
                        <option >Bình Định</option>
                        <option >Bạc Liêu</option>
                        <option >Bắc Giang</option>
                        <option >Bắc Kạn</option>
                        <option >Bắc Ninh</option>
                        <option >Bến Tre</option>
                        <option >Cao Bằng</option>
                        <option >Cà Mau</option>
                        <option >Cần Thơ</option>
                        <option >Gia Lai</option>
                        <option >Hà Giang</option>
                        <option >Hà Nam</option>
                        <option >Hà Tĩnh</option>
                        <option >Hòa Bình</option>
                        <option >Hưng Yên</option>
                        <option >Hải Dương</option>
                        <option >Hải Phòng</option>
                        <option >Hậu Giang</option>
                        <option >Khánh Hòa</option>
                        <option >Kiên Giang</option>
                        <option >Kon Tum</option>
                        <option>Lai Châu</option>
                        <option>Long An</option>
                        <option>Lào Cai</option>
                        <option >Lâm Đồng</option>
                        <option >Lạng Sơn</option>
                        <option >Nam Định</option>
                        <option >Nghệ An</option>
                        <option >Ninh Bình</option>
                        <option >Ninh Thuận</option>
                        <option >Phú Thọ</option>
                        <option >Phú Yên</option>
                        <option >Quảng Bình</option>
                        <option >Quảng Nam</option>
                        <option >Quảng Ngãi</option>
                        <option >Quảng Ninh</option>
                        <option >Quảng Trị</option>
                        <option >Sóc Trăng</option>
                        <option >Sơn La</option>
                        <option >Thanh Hóa</option>
                        <option >Thái Bình</option>
                        <option >Thái Nguyên</option>
                        <option >Thừa Thiên Huế</option>
                        <option >Tiền Giang</option>
                        <option >Trà Vinh</option>
                        <option >Tuyên Quang</option>
                        <option >Tây Ninh</option>
                        <option >Vĩnh Long</option>
                        <option >Vĩnh Phúc</option>
                        <option >Yên Bái</option>
                        <option >Điện Biên</option>
                        <option >Đắk Lắk</option>
                        <option >Đắk Nông</option>
                        <option >Đồng Nai</option>
                        <option >Đồng Tháp</option>
                    </select>

                <%--    <select class="custom-dropdown-select" id="customer_shipping_province" name="customer_shipping_province">
                        <option data-code="null" value="null" selected="">Chọn tỉnh / thành </option>
                        <option data-code="HC" value="50">Hồ Chí Minh</option>
                        <option data-code="HI" value="1">Hà Nội</option>
                        <option data-code="DA" value="32">Đà Nẵng</option>
                        <option data-code="AG" value="57">An Giang</option>
                        <option data-code="BV" value="49">Bà Rịa - Vũng Tàu</option>
                        <option data-code="BI" value="47">Bình Dương</option>
                        <option data-code="BP" value="45">Bình Phước</option>
                        <option data-code="BU" value="39">Bình Thuận</option>
                        <option data-code="BD" value="35">Bình Định</option>
                        <option data-code="BL" value="62">Bạc Liêu</option>
                        <option data-code="BG" value="15">Bắc Giang</option>
                        <option data-code="BK" value="4">Bắc Kạn</option>
                        <option data-code="BN" value="18">Bắc Ninh</option>
                        <option data-code="BT" value="53">Bến Tre</option>
                        <option data-code="CB" value="3">Cao Bằng</option>
                        <option data-code="CM" value="63">Cà Mau</option>
                        <option data-code="CN" value="59">Cần Thơ</option>
                        <option data-code="GL" value="41">Gia Lai</option>
                        <option data-code="HG" value="2">Hà Giang</option>
                        <option data-code="HM" value="23">Hà Nam</option>
                        <option data-code="HT" value="28">Hà Tĩnh</option>
                        <option data-code="HO" value="11">Hòa Bình</option>
                        <option data-code="HY" value="21">Hưng Yên</option>
                        <option data-code="HD" value="19">Hải Dương</option>
                        <option data-code="HP" value="20">Hải Phòng</option>
                        <option data-code="HU" value="60">Hậu Giang</option>
                        <option data-code="KH" value="37">Khánh Hòa</option>
                        <option data-code="KG" value="58">Kiên Giang</option>
                        <option data-code="KT" value="40">Kon Tum</option>
                        <option data-code="LI" value="8">Lai Châu</option>
                        <option data-code="LA" value="51">Long An</option>
                        <option data-code="LO" value="6">Lào Cai</option>
                        <option data-code="LD" value="44">Lâm Đồng</option>
                        <option data-code="LS" value="13">Lạng Sơn</option>
                        <option data-code="ND" value="24">Nam Định</option>
                        <option data-code="NA" value="27">Nghệ An</option>
                        <option data-code="NB" value="25">Ninh Bình</option>
                        <option data-code="NT" value="38">Ninh Thuận</option>
                        <option data-code="PT" value="16">Phú Thọ</option>
                        <option data-code="PY" value="36">Phú Yên</option>
                        <option data-code="QB" value="29">Quảng Bình</option>
                        <option data-code="QM" value="33">Quảng Nam</option>
                        <option data-code="QG" value="34">Quảng Ngãi</option>
                        <option data-code="QN" value="14">Quảng Ninh</option>
                        <option data-code="QT" value="30">Quảng Trị</option>
                        <option data-code="ST" value="61">Sóc Trăng</option>
                        <option data-code="SL" value="9">Sơn La</option>
                        <option data-code="TH" value="26">Thanh Hóa</option>
                        <option data-code="TB" value="22">Thái Bình</option>
                        <option data-code="TY" value="12">Thái Nguyên</option>
                        <option data-code="TT" value="31">Thừa Thiên Huế</option>
                        <option data-code="TG" value="52">Tiền Giang</option>
                        <option data-code="TV" value="54">Trà Vinh</option>
                        <option data-code="TQ" value="5">Tuyên Quang</option>
                        <option data-code="TN" value="46">Tây Ninh</option>
                        <option data-code="VL" value="55">Vĩnh Long</option>
                        <option data-code="VT" value="17">Vĩnh Phúc</option>
                        <option data-code="YB" value="10">Yên Bái</option>
                        <option data-code="DB" value="7">Điện Biên</option>
                        <option data-code="DC" value="42">Đắk Lắk</option>
                        <option data-code="DO" value="43">Đắk Nông</option>
                        <option data-code="DN" value="48">Đồng Nai</option>
                        <option data-code="DT" value="56">Đồng Tháp</option>
                    </select>--%>
                </div>
                <div class="text-field col-flex-3">
                    <input id="huyen" type="text" placeholder="Quận / Huyện *" />
                    <%--<select class="custom-dropdown-select" >
                        <option>Chọn Quận / Huyện</option>
                        <option>Giá: Giảm dần</option>
                        <option>Tên: A-Z</option>
                        <option>Tên: Z-A</option>                       
                    </select>--%>
                </div>
                <div class="text-field col-flex-3">
                    <input id="xa" type="text" placeholder="Phường / Xã *" />
                    <%--<select class="custom-dropdown-select">
                        <option>Chọn Phường / Xã</option>
                        <option>Giá: Giảm dần</option>
                        <option>Tên: A-Z</option>
                        <option>Tên: Z-A</option>                       
                    </select>--%>
                </div>
            </div>
            <div class="CacHinhThucThanhToan" style="color:#000;font-size:14px;margin:20px 18px 0">
                <div class="goiY" style="margin-bottom:18px;">
                    Quý khách vui lòng chọn một trong các hình thức thanh toán dưới đây để thanh toán cho đơn hàng của mình
                </div>
                <div style="display:flex;">                    
                    <input id="rbChuyenKhoan" type="radio" name="rbHinhThucThanhToan" style="cursor:pointer;"/><label for="rbChuyenKhoan" style="cursor:pointer;margin-left:10px">Thanh toán khi giao hàng</label>                    
                </div><br/>
                <div style="display:flex;">                    
                    <input id="rbOnepay" type="radio" name="rbHinhThucThanhToan" checked="checked" style="cursor:pointer"/><label for="rbOnepay" style="cursor:pointer;margin-left:10px">Thanh toán trực tuyến qua thẻ ATM</label>
                    <div class="paymentInfo">                               
                        <div class="cb"><!----></div>
                    </div>                                      
                </div><br/>              
            </div>
            <div>
                <a href="javacript://" onclick="GuiDonHangThanhToan()" class="button-default btn-key">Hoàn Thành Đơn Hàng</a>
            </div>
        </div>
        <div class="cart-right-flex cart-pay">
            <div id="DonHangThanhToan"></div>
        </div>
    </div>
</div>
<script type="text/javascript">
    console.log($("#customer_shipping_province").val());   
    //Viết ajax lấy thông tin giỏ hàng từ session
    function LayThongTinGioHangThanhToan() {
        $.post("SanPham/Ajax/XuLyThanhToan",
            {
                "ThaoTac": "LayThongTinGioHangThanhToan"
            },
            function (data, status) {
                //alert("Data :" + data + "\n Status :" + status);
                $("#DonHangThanhToan").html(data);
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
        $.post("SanPham/Ajax/XuLyThanhToan",
            {
                "ThaoTac": "LayTongSoSanPhamTrongGioHang"
            },
            function (data, status) {
                //alert("Data :" + data + "\n Status :" + status);
                $("#TongSoSPTrongGioHangThanhToan").html(data);
            });
    }
    function LayTongTienTrongGioHang() {
        $.post("SanPham/Ajax/XuLyThanhToan",
            {
                "ThaoTac": "LayTongTienTrongGioHang"
            },
            function (data, status) {
                //alert("Data :" + data + "\n Status :" + status);
                $("#TongTienTrongGioHangThanhToan").html(data);
                $("#TongTienTrongGioHangThanhToan").append(" VND");
            });
    }
    //Gọi hàm lần đầu để khi load trang sẽ lấy ra thông tin luôn
    $(document)
        .ready(function () {
            LayThongTinGioHangThanhToan();
            setTimeout(function () {
                LayTongSoSanPhamTrongGioHang();
            }, 90);
            setTimeout(function () {
                LayTongTienTrongGioHang();
            }, 90);
        });

    //Hàm xóa 1 sản phẩm trong giỏ hàng
    //function XoaSPTrongGioHang(idSanPham) {
    //    ////Hỏi để xác nhận lại yêu cầu xóa từ người dùng
    //    ///* confirm("Bạn muốn xóa sản phẩm này khỏi giỏ hàng?")*/
    //    //if (alertSweetalert2('Đã thêm sản phẩm vào giỏ hàng thành công !!!', 'deleted') === true) {

    //    //    $.post("SanPham/Ajax/XuLyGioHang",
    //    //        {
    //    //            "ThaoTac": "XoaSPTrongGioHang",
    //    //            "idSanPham": idSanPham
    //    //        },
    //    //        function (data, status) {
    //    //            //alert("Data :" + data + "\n Status :" + status);

    //    //            //Nếu không có lỗi (tức là xóa thành công) --> ẩn dòng chứa sản phẩm khỏi bảng hiển thị giỏ hàng --> Gọi hàm cập nhật số lượng, tổng tiền
    //    //            if (data === "") {
    //    //                $("#maDong_" + idSanPham).remove();

    //    //                LayTongSoSanPhamTrongGioHang();
    //    //                LayTongTienTrongGioHang();
    //    //            }
    //    //        });
    //    //}
    //    //const swalWithBootstrapButtons = Swal.mixin({
    //    //    customClass: {
    //    //        confirmButton: 'btn btn-alert-confirm',
    //    //        cancelButton: 'btn btn-alert-cance'
    //    //    },
    //    //    buttonsStyling: false
    //    //})

    //    swalWithBootstrapButtons.fire({
    //        title: 'Xác nhận xóa?',
    //        text: "Bạn có muốn xóa sản phẩm này",
    //        icon: 'warning',
    //        showCancelButton: true,
    //        confirmButtonText: 'Yes, delete it!',
    //        cancelButtonText: 'No, cancel!',
    //        reverseButtons: true
    //    }).then((result) => {
    //        if (result.isConfirmed) {
    //            $.post("SanPham/Ajax/XuLyGioHang",
    //                {
    //                    "ThaoTac": "XoaSPTrongGioHang",
    //                    "idSanPham": idSanPham
    //                },
    //                function (data, status) {
    //                    //alert("Data :" + data + "\n Status :" + status);

    //                    //Nếu không có lỗi (tức là xóa thành công) --> ẩn dòng chứa sản phẩm khỏi bảng hiển thị giỏ hàng --> Gọi hàm cập nhật số lượng, tổng tiền
    //                    if (data === "") {
    //                        $("#maDongThanhToan_" + idSanPham).slideUp();

    //                        LayTongSoSanPhamTrongGioHang();
    //                        LayTongTienTrongGioHang();
    //                    }
    //                });
    //            swalWithBootstrapButtons.fire(
    //                'Deleted!',
    //                'Bạn đã xóa thành sản phẩm thành công',
    //                'success'
    //            )
    //        } else if (
    //            /* Read more about handling dismissals below */
    //            result.dismiss === Swal.DismissReason.cancel
    //        ) {
    //            swalWithBootstrapButtons.fire(
    //                'Cancelled',
    //                'Sản phẩm vẫn còn trong giỏ hàng)',
    //                'error'
    //            )
    //        }
    //    })

    //}
    //Hàm cập nhật số lượng cho một sản phẩm trong giỏ hàng
    //function CapNhatSoLuongVaoGioHang(idSanPham) {

    //    //Lấy số lượng mới sửa từ textbox
    //    var soLuongMoi = $("#quantity_" + idSanPham).val();

    //    $.post("SanPham/Ajax/XuLyGioHang",
    //        {
    //            "ThaoTac": "CapNhatSoLuongVaoGioHang",
    //            "idSanPham": idSanPham,
    //            "soLuongMoi": soLuongMoi
    //        },
    //        function (data, status) {
    //            //alert("Data :" + data + "\n Status :" + status);

    //            //Nếu không có lỗi (tức là xóa thành công) --> ẩn dòng chứa sản phẩm khỏi bảng hiển thị giỏ hàng --> Gọi hàm cập nhật số lượng, tổng tiền
    //            if (data === "") {
    //                LayTongSoSanPhamTrongGioHang();
    //                LayTongTienTrongGioHang();
    //            }
    //        });
    //}

    //Hàm gửi đơn hàng
    function GuiDonHangThanhToan() {
        //Kiểm tra xem khách hàng đã nhập đủ họ tên và số điện thoại chưa
        if ($("#tbHoTen").val() == "" || $("#tbSoDienThoai").val() == "" || $("#huyen").val() == "" || $("#xa").val() == "" || $("#customer_shipping_province").val() == "null") {
            
            /*alert("Vui lòng nhập đầy đủ Họ tên và Số điện thoại để đặt hàng");*/
            alertSweetalert2('Vui lòng nhập đầy đủ Họ tên và Số điện thoại để đặt hàng !!!', 'warning');
        }
        else {
            var phuongthucthanhtoan = "";
            if ($("#rbChuyenKhoan").is(":checked")) phuongthucthanhtoan = "ThanhToanKhiGiaoHang";
            if ($("#rbOnepay").is(":checked")) phuongthucthanhtoan = "Onepay";           
            var diaChi = `${$("#customer_shipping_province").val()}, ${$("#huyen").val()}, ${$("#xa").val()}`;
            if (phuongthucthanhtoan != "Onepay") {
                $.post("SanPham/Ajax/XuLyThanhToan",
                    {
                        "ThaoTac": "GuiDonHangThanhToan",
                        "hoTen": $("#tbHoTen").val(),
                        "diaChi": diaChi,
                        "soDienThoai": $("#tbSoDienThoai").val(),
                        "email": $("#tbEmail").val(),
                        "phuongThucThanhToan": phuongthucthanhtoan
                    },
                    function (data, status) {
                        if (data === "") {
                            /*alert("Bạn đã gửi đơn hàng thành công");*/
                            alertSweetalert2('Bạn đã gửi đơn hàng thành công !!!', 'success');
                            LayThongTinGioHangThanhToan();
                        }
                        else {
                            alertSweetalert2(data, 'warning');
                        }
                    });
            }
            else {
                $.post("SanPham/Ajax/XuLyThanhToan",
                    {
                        "ThaoTac": "LayTongTienThanhToan"
                    },
                    function (data, status) {
                        var tongTien = data;
                        $.post("/vnpay_return",
                            {
                                "ThaoTac": "GuiDonHangThanhToanTrucTuyen",
                                "hoTen": $("#tbHoTen").val(),
                                "diaChi": diaChi,
                                "soDienThoai": $("#tbSoDienThoai").val(),
                                "email": $("#tbEmail").val(),
                                "phuongThucThanhToan": phuongthucthanhtoan
                            },
                            function (data, status) {
                                //$.post("ThanhToanTrucTuyen",
                                //    {                                       
                                //        "hoTentt": $("#tbHoTen").val(),
                                //        "diaChitt": diaChi,
                                //        "soDienThoaitt": $("#tbSoDienThoai").val(),
                                //        "emailtt": $("#tbEmail").val(),
                                //        "tongTien": tongTien
                                //    },
                                //    function (data, status) {
                                //         alert("Data :" + data + "\n Status :" + status);
                                        
                                //    });
                            });
                        //alert("Data :" + data + "\n Status :" + status);
                        location.href = `/cms/index/page/ThanhToanTrucTuyen?hoTentt=${$("#tbHoTen").val()}&diaChitt=${diaChi}&soDienThoaitt=${$("#tbSoDienThoai").val()}&emailtt=${$("#tbEmail").val()}&tongTien=${tongTien}`;
                    });
                
            }
            
        }
    }

</script>
