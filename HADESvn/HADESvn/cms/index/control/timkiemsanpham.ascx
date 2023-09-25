<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="timkiemsanpham.ascx.cs" Inherits="HADESvn.cms.index.control.timkiemsanpham" %>
<div class="container-padding">
    <img src="../../../assets/img/img-product-heading.JPG" alt="" class="img-heading" />
    <div class="row-list-product">
        <div class="col-list-product-3">
            <img src="../../../assets/img/careers_10.jpg" alt="" class="img-prodeuct-logo"/>
        </div>

        <div class="col-list-product-9">
            <div class="box-container box-container-product">
                <%if (listSP != null)
                    { %>
                <% foreach (var item in listSP)
                    {
                %>
                <div class="box wow fadeInDown box-list-product" data-wow-duration="2s" data-wow-delay="1s">
                    <div class="image image-list-product">
                        <img src='<%="..\\..\\..\\assets\\img\\SanPham\\" + item.AnhSP%> ' alt="" />
                    </div>
                    <div class="box-content">
                        <h3 class="list-product-name"><%=item.TenSP %></h3>
                        <h4><%=string.Format("{0:0,000}",item.GiaSP)%>đ</h4>
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
                <%} %>
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
        </div>
    </div>
</div>