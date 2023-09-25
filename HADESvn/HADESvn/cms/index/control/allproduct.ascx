<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="allproduct.ascx.cs" Inherits="HADESvn.cms.index.control.allproduct" %>
<div class="container-padding">
    <img src="../../../assets/img/img-product-heading.JPG" alt="" class="img-heading" />
    <div class="row-list-product">
        <div class="col-list-product-3">
            <img src="../../../assets/img/careers_10.jpg" alt="" class="img-prodeuct-logo" onclick="clickMe()"/>
            <ul class="ul-list-product-3">                 
                 <%foreach (var item in listDM)
                    { %>
                <li class="li-list-product-3" onclick="SanPhamTheoDanhMuc(<%=item.MaDM%>)"><a href="javacript://" class="btn-madm"  data-madm="<%=item.MaDM%>"><%=item.TenDM %></a></li>

                <%} %>
            </ul>
        </div>

        <div class="col-list-product-9">
            <div class="option-browse-tags">
                <span class="custom-dropdown">
                    <select class="custom-dropdown-select" onchange="CapNhatSanPhamTheoOption()">
                        <option>Giá: Tăng dần</option>
                        <option>Giá: Giảm dần</option>
                        <option>Tên: A-Z</option>
                        <option>Tên: Z-A</option>
                        <%--<option>Cũ nhất</option>
                        <option>Mới nhất</option>
                        <option>Bán chạy nhất</option>
                        <option>Tồn kho: Giảm dần</option>--%>
                    </select>
                </span>
            </div>
            <div class="box-container box-container-product" id="man-container-product">
               <%-- <%if (listSP != null)
                    { %>
                <% foreach (var item in listSP)
                    {
                %>
                <div class="box wow fadeInDown box-list-product" data-wow-duration="2s" data-wow-delay="1s">
                    <div class="image image-list-product" style="height: 100%;">
                        <img src='<%="..\\..\\..\\assets\\img\\SanPham\\" + item.AnhSP%> ' alt="" />
                    </div>
                    <div class="box-content">
                        <h3 class="list-product-name"><%=item.TenSP %></h3>
                        <h4><%=item.GiaSP %>đ</h4>
                        <p>
                            <%=item.MotaSP %>
                        </p>
                        <a href='<%="ChiTietSanPham.aspx?MaSP="+item.MaSP%>' class="list-product-price">Read More
                    <ion-icon name="chevron-forward-outline"></ion-icon>
                        </a>
                    </div>
                </div>
                <%} %>
                <%} %>
                <%else
                    { %>
                <h1>không có sản phẩm nào </h1>
                <%} %>--%>
                <%--<div class="box wow fadeInDown box-list-product" data-wow-duration="2s" data-wow-delay="2s">
                    <div class="image image-list-product">
                        <img src="../../../assets/img/cart-8.jpg" alt="" />
                    </div>
                    <div class="box-content">
                        <h3>Tours & Travel</h3>
                        <h4>250000đ</h4>
                        <p>
                            Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eius maxime est inventore veniam esse.
                     Nisi, rem amet consequuntur quia enim ut excepturi ipsam culpa beatae sit dolor unde aperiam. Sit!
                        </p>
                        <a href="#">Read More
                            <ion-icon name="chevron-forward-outline"></ion-icon>
                        </a>
                    </div>
                </div>--%>
            </div>
            <div id="load-message"></div>
        </div>
    </div>
</div>
<script src="https://code.jquery.com/jquery-3.6.0.js"></script>
<script type="text/javascript">
    var limit = 8;
    var start = 0;
    var action = 'inactive';
    function clickMe() {
        $.post("SanPham/Ajax/XuLySanPham",
            {
                "ThaoTac": "clickMe",               
            },
            function (data, status) {
                //alert("Data :" + data + "\n Status :" + status);
                console.log(data);
            });
    };
    $(".btn-madm").each(function () {
        $(this).on("click", function (e) {
            /*var maDm = e.target.dataset["madm"];*/
            e.preventDefault();          
        })       
    });
    
    function SanPhamTheoDanhMuc(MaDM) {
       
        $.post("SanPham/Ajax/XuLySanPham",
            {
                "ThaoTac": "SanPhamTheoDanhMuc",
                "MaDM": MaDM,
                
            },
            function (data, status) {
                //alert("Data :" + data + "\n Status :" + status);
                $("#man-container-product").html(data);
                if (data == "") {
                    $("#load-message").html("");
                    action = 'active';
                }
                else {
                    $("#load-message").html("");
                    action = 'active';
                }
            });
    }
    function CapNhatSanPhamTheoOption() {
        var optionSanPham = $(".custom-dropdown-select").val();
        switch (optionSanPham) {
            case "Giá: Tăng dần":
                limit = 8;
                start = 0;
                SanPhamTangDan(limit, start);
                break;
            case "Giá: Giảm dần":
                limit = 8;
                start = 0;
                SanPhamGiamDan(limit,start);
                break;
            case "Tên: A-Z":
                limit = 8;
                start = 0;
                SanPhamAtoZ(limit, start);
                break;
            case "Tên: Z-A":
                limit = 8;
                start = 0;
                SanPhamZtoA(limit, start);
                break;
            default:
                SanPhamTangDan(limit, start);

        }
        function SanPhamTangDan(limit, start) {
            $.post("SanPham/Ajax/XuLySanPham",
                {
                    "ThaoTac": "SanPhamTangDan",
                    "limit": limit,
                    "start": start
                },
                function (data, status) {
                    //alert("Data :" + data + "\n Status :" + status);
                    $("#man-container-product").html(data);
                    if (data == "") {
                        $("#load-message").html("");
                        action = 'active';
                    }
                    else {
                        $("#load-message").html(`<div class= "music-waves-2">
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                    </div >`
                        );
                        action = 'inactiveTangDan';
                    }
                });
        }
        function SanPhamGiamDan(limit, start) {
            
            $.post("SanPham/Ajax/XuLySanPham",
                {
                    "ThaoTac": "SanPhamGiamDan",
                    "limit": limit,
                    "start": start
                },
                function (data, status) {
                    //alert("Data :" + data + "\n Status :" + status);
                    $("#man-container-product").html(data);
                    if (data == "") {
                        $("#load-message").html("");
                        action = 'active';
                    }
                    else {
                        $("#load-message").html(`<div class= "music-waves-2">
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                    </div >`
                        );                        
                        action = 'inactiveGiamDan';
                    }                
                });
        }
        function SanPhamAtoZ(limit, start) {
            $.post("SanPham/Ajax/XuLySanPham",
                {
                    "ThaoTac": "SanPhamAtoZ",
                    "limit": limit,
                    "start": start
                },
                function (data, status) {
                    //alert("Data :" + data + "\n Status :" + status);
                    $("#man-container-product").html(data);
                    if (data == "") {
                        $("#load-message").html("");
                        action = 'active';
                    }
                    else {
                        $("#load-message").html(`<div class= "music-waves-2">
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                    </div >`
                        );
                        action = 'inactiveAtoZ';
                    }
                });
        }
        function SanPhamZtoA(limit, start) {
            $.post("SanPham/Ajax/XuLySanPham",
                {
                    "ThaoTac": "SanPhamZtoA",
                    "limit": limit,
                    "start": start
                },
                function (data, status) {
                    //alert("Data :" + data + "\n Status :" + status);
                    $("#man-container-product").html(data);
                    if (data == "") {
                        $("#load-message").html("");
                        action = 'active';
                    }
                    else {
                        $("#load-message").html(`<div class= "music-waves-2">
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                    </div >`
                        );
                        action = 'inactiveZtoA';
                    }
                });
        }
       
    }
    //function LayTatCaSanPham() {
    //    $.post("SanPham/Ajax/XuLySanPham",
    //        {
    //            "ThaoTac": "LayTatCaSanPham"
    //        },
    //        function (data, status) {
    //            //alert("Data :" + data + "\n Status :" + status);
    //            $("#man-container-product").html(data);
    //        });
    //}
    
    function LayTatCaSanPham(limit, start) {
        $.post("SanPham/Ajax/XuLySanPham",
            {
                "ThaoTac": "LayTatCaSanPham",
                "limit": limit,
                "start": start
            },
            function (data, status) {               
                $("#man-container-product").append(data);
                if (data == "") {
                    $("#load-message").html("");                   
                    action = 'active';
                }
                else {
                    $("#load-message").html(`<div class= "music-waves-2">
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                    </div >`
                    );
                    action = 'inactive';
                }
            });
    }
    $(document)
        .ready(function () {                    
            if (action == 'inactive') {
                action = 'active';
                LayTatCaSanPham(limit, start);
            }
            $(window).scroll(function () {
                if ($(window).scrollTop() >= $("#man-container-product").height() - ($("#load-message").height() + 10) && action == 'inactive') {
                    action = 'active';
                    start = start + limit;                  
                    setTimeout(function () {
                        LayTatCaSanPham(limit, start);
                    }, 800);
                } else if ($(window).scrollTop() >= $("#man-container-product").height() - ($("#load-message").height() + 10) && action == 'inactiveGiamDan') {
                    action = 'active';
                    start = start + limit;
                    setTimeout(function () {
                        inactiveGiamDan(limit, start);
                    }, 800);
                } else if ($(window).scrollTop() >= $("#man-container-product").height() - ($("#load-message").height() + 10) && action == 'inactiveTangDan') {
                    action = 'active';
                    start = start + limit;
                    setTimeout(function () {
                        inactiveTangDan(limit, start);
                    }, 800);
                } else if ($(window).scrollTop() >= $("#man-container-product").height() - ($("#load-message").height() + 10) && action == 'inactiveAtoZ') {
                    action = 'active';
                    start = start + limit;
                    setTimeout(function () {
                        inactiveAtoZ(limit, start);
                    }, 800);
                } else if ($(window).scrollTop() >= $("#man-container-product").height() - ($("#load-message").height() + 10) && action == 'inactiveZtoA') {
                    action = 'active';
                    start = start + limit;
                    setTimeout(function () {
                        inactiveZtoA(limit, start);
                    }, 800);
                }             
            });         
        });

    //function inactiveDanhMuc(limit, start, MaDanhMuc) {
    //    $.post("SanPham/Ajax/XuLySanPham",
    //        {
    //            "ThaoTac": "SanPhamGiamDan",
    //            "MaDM": MaDanhMuc,
    //            "limit": limit,
    //            "start": start
    //        },
    //        function (data, status) {
    //            //alert("Data :" + data + "\n Status :" + status);
    //            $("#man-container-product").append(data);
    //            if (data == "") {
    //                $("#load-message").html("");
    //                action = 'active';
    //            }
    //            else {
    //                $("#load-message").html(`<div class= "music-waves-2">
    //                                      <span></span>
    //                                      <span></span>
    //                                      <span></span>
    //                                      <span></span>
    //                                      <span></span>
    //                                      <span></span>
    //                                      <span></span>
    //                                </div >`
    //                );
    //                action = MaDanhMuc;
    //            }
    //        });
    //}
    function inactiveGiamDan(limit, start) {        
        $.post("SanPham/Ajax/XuLySanPham",
            {
                "ThaoTac": "SanPhamGiamDan",
                "limit": limit,
                "start": start
            },
            function (data, status) {
                //alert("Data :" + data + "\n Status :" + status);
                $("#man-container-product").append(data);
                if (data == "") {
                    $("#load-message").html("");
                    action = 'active';
                }
                else {
                    $("#load-message").html(`<div class= "music-waves-2">
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                    </div >`
                    );                    
                    action = 'inactiveGiamDan';
                }
            });
    }
    function inactiveTangDan(limit, start) {
        $.post("SanPham/Ajax/XuLySanPham",
            {
                "ThaoTac": "SanPhamTangDan",
                "limit": limit,
                "start": start
            },
            function (data, status) {
                //alert("Data :" + data + "\n Status :" + status);
                $("#man-container-product").append(data);
                if (data == "") {
                    $("#load-message").html("");
                    action = 'active';
                }
                else {
                    $("#load-message").html(`<div class= "music-waves-2">
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                    </div >`
                    );
                    action = 'inactiveTangDan';
                }
            });
    }
    function inactiveAtoZ(limit, start) {
        $.post("SanPham/Ajax/XuLySanPham",
            {
                "ThaoTac": "SanPhamAtoZ",
                "limit": limit,
                "start": start
            },
            function (data, status) {
                //alert("Data :" + data + "\n Status :" + status);
                $("#man-container-product").append(data);
                if (data == "") {
                    $("#load-message").html("");
                    action = 'active';
                }
                else {
                    $("#load-message").html(`<div class= "music-waves-2">
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                    </div >`
                    );
                    action = 'inactiveAtoZ';
                }
            });
    }
    function inactiveZtoA(limit, start) {
        $.post("SanPham/Ajax/XuLySanPham",
            {
                "ThaoTac": "SanPhamZtoA",
                "limit": limit,
                "start": start
            },
            function (data, status) {
                //alert("Data :" + data + "\n Status :" + status);
                $("#man-container-product").append(data);
                if (data == "") {
                    $("#load-message").html("");
                    action = 'active';
                }
                else {
                    $("#load-message").html(`<div class= "music-waves-2">
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                          <span></span>
                                    </div >`
                    );
                    action = 'inactiveZtoA';
                }
            });
    }
</script>