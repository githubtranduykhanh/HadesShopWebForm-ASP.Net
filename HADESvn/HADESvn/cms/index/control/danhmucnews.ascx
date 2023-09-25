<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="danhmucnews.ascx.cs" Inherits="HADESvn.cms.index.control.danhmucnews" %>
<div class="container-padding">
    <section class="gallery" id="gallery" style="padding:0;">
        <div class="destination-heading wow bounceInLeft" data-wow-duration="2s" data-wow-delay="2s">
            <%--<span>Our Gallery</span>--%>
            <h1>News</h1>
        </div>
        <div class="box-container">
            <%if (DMTIN != null)
                { %>
            <% foreach (var item in DMTIN)
                {
            %>
            <div class="box wow fadeInLeft" data-wow-duration="1s" data-wow-delay="1.5s">
                <img src='<%="..\\..\\..\\assets\\img\\DanhMuc\\" + item.AnhDaiDien%> ' alt="" />
                <div class="box-content">
                    <span>Hades</span>
                    <a href='<%="ListNews.aspx?MaDM="+item.MaDM%>'>
                        <h3><%=item.TenDM%></h3>
                    </a>
                </div>
            </div>
            <%} %>
            <%} %>
            <%else
                { %>
            <h1>không có sản phẩm nào </h1>
            <%} %>
            <%--<div class="box wow fadeInDown" data-wow-duration="1s" data-wow-delay="2s">
            <img src="../../../assets/img/Greenland.jpg" alt="" />
            <div class="box-content">
                <span>Travel Spot</span>
                <h3>Greenland</h3>
            </div>
        </div>
        <div class="box wow fadeInDown" data-wow-duration="1s" data-wow-delay="2.5s">
            <img src="../../../assets/img/Alaska.jpg" alt="" />
            <div class="box-content">
                <span>Travel Spot</span>
                <h3>Alaska</h3>
            </div>
        </div>
        <div class="box wow fadeInUp" data-wow-duration="1s" data-wow-delay="1s">
            <img src="../../../assets/img/Thailand.jpg" alt="" />
            <div class="box-content">
                <span>Travel Spot</span>
                <h3>Thailand</h3>
            </div>
        </div>
        <div class="box wow fadeInUp" data-wow-duration="1s" data-wow-delay="1.5s">
            <img src="../../../assets/img/Brazil.jpg" alt="" />
            <div class="box-content">
                <span>Travel Spot</span>
                <h3>Brazil</h3>
            </div>
        </div>
        <div class="box wow fadeInRight" data-wow-duration="1s" data-wow-delay="2s">
            <img src="../../../assets/img/Maldive.jpg" alt="" />
            <div class="box-content">
                <span>Travel Spot</span>
                <h3>Maldive</h3>
            </div>
        </div>--%>
        </div>
    </section>
</div>
