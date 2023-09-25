<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThongKeShow.ascx.cs" Inherits="HADESvn.cms.admin.ThongKe.ThongKeShow" %>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-circle-progress/1.2.2/circle-progress.min.js"></script>
<div class="wrapper">
    <div class="card">
        <div class="circle">
            <div class="bar"></div>
            <div class="box"><span></span></div>
        </div>
        <div class="text">Tổng Số Lượng</div>
        <div class="text-so-luong text"></div>
    </div>
    <div class="card js">
        <div class="circle">
            <div class="bar"></div>
            <div class="box"><span></span></div>
        </div>
        <div class="text">Tổng Tiền</div>
        <div class="text-tong-tien text"></div>
    </div>
    <div class="card react">
        <div class="circle">
            <div class="bar"></div>
            <div class="box"><span></span></div>
        </div>
        <div class="text">Hoàn Tiền</div>
        <div class="text-hoang-tien text"></div>
    </div>
</div>
<div class="row" style="margin: 40px 50px;">
    <div class="col-md-5">
        <input type="datetime-local" name="name" class="form-control data-time-now" id="data-time-star" />
    </div>
    <div class="col-md-5">
        <input type="datetime-local" name="name" class="form-control data-time-now" id="data-time-end" />
    </div>
    <div class="col-md-2">
        <a href="javacript://" onclick="locKetQua()" class="btn btn-key form-control">Lọc Ngay</a>
    </div>
</div>
<div id="bangLoc"></div>
<script type="text/javascript">
    function locKetQua() {
        $.post("ThongKe/Ajax/ThongKe",
            {
                "ThaoTac": "locKetQuaSL",
                "TuNgay": $("#data-time-star").val(),
                "DenNgay": $("#data-time-end").val(),
            },
            function (data, status) {
                $(".text-so-luong").html(data);
                let options = {
                    startAngle: -1.55,
                    size: 150,
                    value: data / 100,
                    fill: { gradient: ['#a445b2', '#fa4299'] }
                }
                $(".circle .bar").circleProgress(options).on('circle-animation-progress',
                    function (event, progress, stepValue) {
                        $(this).parent().find("span").text(String(stepValue.toFixed(2).substr(2)) + "%");
                    });

                $.post("ThongKe/Ajax/ThongKe",
                    {
                        "ThaoTac": "locKetQua",
                        "TuNgay": $("#data-time-star").val(),
                        "DenNgay": $("#data-time-end").val(),
                    },
                    function (data, status) {
                        $(".text-tong-tien").html(data + " VND");
                        $(".js .bar").circleProgress({
                            value: data / 100000000
                        });
                        $.post("ThongKe/Ajax/ThongKe",
                            {
                                "ThaoTac": "locKetQuaHT",
                                "TuNgay": $("#data-time-star").val(),
                                "DenNgay": $("#data-time-end").val(),
                            },
                            function (data, status) {
                                $(".text-hoang-tien").html(data + " VND");
                                $(".react .bar").circleProgress({
                                    value: data / 100000000
                                });
                                $.post("ThongKe/Ajax/ThongKe",
                                    {
                                        "ThaoTac": "LayRaThongTinLocThongKe",
                                        "TuNgay": $("#data-time-star").val(),
                                        "DenNgay": $("#data-time-end").val(),
                                    },
                                    function (data, status) {
                                        $("#bangLoc").html(data);
                                    });
                            });
                    });
            });
    }
    function LayRaThoiGianTrongNgay() {
        $.post("ThongKe/Ajax/ThongKe",
            {
                "ThaoTac": "LayRaThoiGianTrongNgay"
            },
            function (data, status) {
                $(".data-time-now").val(data);

            });
    }
    function LayRaThongTinSoLuongThongKeTrongNgay() {
        $.post("ThongKe/Ajax/ThongKe",
            {
                "ThaoTac": "LayRaThongTinSoLuongThongKeTrongNgay"
            },
            function (data, status) {
                $(".text-so-luong").html(data);

                let options = {
                    startAngle: -1.55,
                    size: 150,
                    value: data / 100,
                    fill: { gradient: ['#a445b2', '#fa4299'] }
                }
                $(".circle .bar").circleProgress(options).on('circle-animation-progress',
                    function (event, progress, stepValue) {
                        $(this).parent().find("span").text(String(stepValue.toFixed(2).substr(2)) + "%");
                    });
            });
    }
    function LayRaThongTinTongTienThongKeTrongNgay() {
        $.post("ThongKe/Ajax/ThongKe",
            {
                "ThaoTac": "LayRaThongTinTongTienThongKeTrongNgay"
            },
            function (data, status) {
                $(".text-tong-tien").html(data + " VND");
                $(".js .bar").circleProgress({
                    value: data / 100000000
                });
            });
    }
    function LayRaThongTinHoaTienThongKeTrongNgay() {
        $.post("ThongKe/Ajax/ThongKe",
            {
                "ThaoTac": "LayRaThongTinHoaTienThongKeTrongNgay"
            },
            function (data, status) {
                $(".text-hoang-tien").html(data + " VND");
                console.log(data / 10000000);
                $(".react .bar").circleProgress({
                    value: data / 100000000
                });
            });
    }
    function LayRaThongTinLocThongKeTrongNgay() {
        $.post("ThongKe/Ajax/ThongKe",
            {
                "ThaoTac": "LayRaThongTinLocThongKeTrongNgay"
            },
            function (data, status) {
                $("#bangLoc").html(data);              
            });
    }
    $(document)
        .ready(function () {
            LayRaThongTinSoLuongThongKeTrongNgay();
            LayRaThongTinTongTienThongKeTrongNgay();
            LayRaThongTinHoaTienThongKeTrongNgay();
            LayRaThoiGianTrongNgay();
            LayRaThongTinLocThongKeTrongNgay();
        });

</script>

