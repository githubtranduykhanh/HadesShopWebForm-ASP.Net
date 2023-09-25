<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listnews.ascx.cs" Inherits="HADESvn.cms.index.control.listnews" %>
<div style="padding: 90px;">
    <div class="destination-heading wow bounceInLeft" data-wow-duration="2s" data-wow-delay="2s">
            <span>List News</span>
            <h1><%=infoDanhMucTin.TenDM%></h1>
        </div>
    <div class="container-product-details">
        
        <div class="box-container container-list-new">
            <%if (ListTinTuc != null)
                { %>
            <% foreach (var item in ListTinTuc)
                {
            %>
            <div class="box wow fadeInDown" data-wow-duration="2s" data-wow-delay="1s">
                <div class="image">
                    <img src='<%="..\\..\\..\\assets\\img\\ItemTinTuc\\" + item.AnhDaiDien%> ' alt=""/>
                </div>
                <div class="box-content">
                    <h3><%=item.TieuDe %></h3>
                    <h4><%=item.NgayDang%></h4>
                    <p>
                        <%=item.MoTa%>
                    </p>
                    <a href='<%="ItemNew.aspx?TinTucID="+item.TinTucID%>'>Read More
                    <ion-icon name="chevron-forward-outline"></ion-icon>
                    </a>
                </div>
            </div>
            <%} %>
            <%} %>
            <%else
                { %>
            <h1>không có tin tuc nào </h1>
            <%} %>
        </div>
    </div>
</div>
