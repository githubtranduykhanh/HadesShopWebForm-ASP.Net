<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="index.ascx.cs" Inherits="HADESvn.cms.index.control.index" %>
<div class="banner">
    <div class="bg">
        <img src="../../../assets/img/slideshow_0.jpg" alt="" class="cover" />

        <div class="bg-content">
            <div class="header-text">
                <h1 class="slide-top">Explore The World</h1>
                <h1 class="slide-top">Explore The World</h1>
            </div>
            <a href="https://localhost:44385/cms/index/page/AllProduct" class="btn bg-btn slide-left">Boot Now</a>
        </div>
        <div class="searchBox slide-bottom">
            <div class="inputBox">
                <%--<p>Enter Location</p>
                    <input type="text" placeholder="Ex: Maldives"/>--%>
                <img src="../../../assets/img/img_noti_new_1.jpg" class="cover-noti" />
            </div>
            <div class="inputBox">
                <%-- <p>Chech In</p>
                    <input type="date" />--%>
                <img src="../../../assets/img/img_noti_new_2.jpg" class="cover-noti" />
            </div>
            <div class="inputBox">
                <%-- <p>Chech Out</p>
                    <input type="date" />--%>
                <img src="../../../assets/img/img_noti_new_3.jpg" class="cover-noti" />
            </div>
            <div class="inputBox">
                <%--<p class="white">_</p>
                    <input type="submit" value="Find" />--%>
                <img src="../../../assets/img/img_noti_new_4.jpg" class="cover-noti" />
            </div>
        </div>
    </div>
</div>
<section class="about" id="about">
    <div class="video-container wow fadeInLeft" data-wow-duration="1s">
        <video src="../../../assets/img/production ID_4729790.mp4" muted autoplay loop class="video"></video>
        <div class="controls">
            <span class="controls-btn" data-src="../../../assets/img/production ID_4729790.mp4"></span>
            <span class="controls-btn" data-src="../../../assets/img/video.mp4"></span>
            <span class="controls-btn" data-src="../../../assets/img/Pexels Videos 2169880.mp4"></span>
        </div>
    </div>
    <div class="about-content">
        <span class="wow fadeInRight" data-wow-duration="1s">Why choose us?</span>
        <h3 class="wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.5s">Streetwear Brand Limited</h3>
        <p class="wow fadeInRight" data-wow-duration="1s" data-wow-delay="1s">
            Lorem ipsum dolor sit amet consectetur adipisicing elit. Provident ullam cupiditate laudantium ea quidem! Dicta ducimus soluta eius iure quidem.
                 Error laboriosam cupiditate quidem doloremque sint impedit quae. Iure, tempore!
        </p>
        <a href="#" class="btn btn-key wow fadeInRight" data-wow-duration="1s" data-wow-delay="1.5s">Read more</a>
    </div>
</section>
<section class="destination" id="destination">
    <div class="destination-heading wow flipInX" data-wow-duration="2s" data-wow-delay="0.5s">
        <span>Our Product</span>
        <h1>Make your product</h1>
    </div>

    <div class="box-container">
        <%if (SP != null)
            { %>
        <% foreach (var item in SP)
            {
        %>
        <div class="box wow fadeInDown" data-wow-duration="2s" data-wow-delay="1s">
            <div class="image image-min-height">
                <img src= '<%="..\\..\\..\\assets\\img\\SanPham\\" + item.AnhSP%> ' alt="" />
            </div>
            <div class="box-content">
                <h3><%=item.TenSP %></h3>
                <h4><%=string.Format("{0:0,000}",item.GiaSP)%>đ</h4>
                <p>
                    <%=item.MotaSP %>
                </p>
                <a href='<%="ChiTietSanPham.aspx?MaSP="+item.MaSP%>'>Read More
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
        <%--<div class="box wow fadeInDown" data-wow-duration="2s" data-wow-delay="1.5s">
            <div class="image">
                <img src="../../../assets/img/cart-1.jpg" alt=""/>
            </div>
            <div class="box-content">
                <h3>Tours & Travel</h3>
                <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eius maxime est inventore veniam esse.
                     Nisi, rem amet consequuntur quia enim ut excepturi ipsam culpa beatae sit dolor unde aperiam. Sit!</p>
                <a href="#">Read More <ion-icon name="chevron-forward-outline"></ion-icon></a>
            </div>
        </div>
        <div class="box wow fadeInDown" data-wow-duration="2s" data-wow-delay="2s">
            <div class="image">
                <img src="../../../assets/img/cart-8.jpg" alt=""/>
            </div>
            <div class="box-content">
                <h3>Tours & Travel</h3>
                <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eius maxime est inventore veniam esse.
                     Nisi, rem amet consequuntur quia enim ut excepturi ipsam culpa beatae sit dolor unde aperiam. Sit!</p>
                <a href="#">Read More <ion-icon name="chevron-forward-outline"></ion-icon></a>
            </div>
        </div>
        <div class="box wow fadeInDown" data-wow-duration="2s" data-wow-delay="2.5s">
            <div class="image">
                <img src="../../../assets/img/cart-3.jpg" alt=""/>
            </div>
            <div class="box-content">
                <h3>Tours & Travel</h3>
                <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eius maxime est inventore veniam esse.
                     Nisi, rem amet consequuntur quia enim ut excepturi ipsam culpa beatae sit dolor unde aperiam. Sit!</p>
                <a href="#">Read More <ion-icon name="chevron-forward-outline"></ion-icon></a>
            </div>
        </div>
        <div class="box wow fadeInDown" data-wow-duration="2s" data-wow-delay="1s">
            <div class="image">
                <img src="../../../assets/img/cart-4.jpg" alt=""/>
            </div>
            <div class="box-content">
                <h3>Tours & Travel</h3>
                <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eius maxime est inventore veniam esse.
                     Nisi, rem amet consequuntur quia enim ut excepturi ipsam culpa beatae sit dolor unde aperiam. Sit!</p>
                <a href="#">Read More <ion-icon name="chevron-forward-outline"></ion-icon></a>
            </div>
        </div>
        <div class="box wow fadeInDown" data-wow-duration="2s" data-wow-delay="1.5s">
            <div class="image">
                <img src="../../../assets/img/cart-5.jpg" alt=""/>
            </div>
            <div class="box-content">
                <h3>Tours & Travel</h3>
                <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eius maxime est inventore veniam esse.
                     Nisi, rem amet consequuntur quia enim ut excepturi ipsam culpa beatae sit dolor unde aperiam. Sit!</p>
                <a href="#">Read More <ion-icon name="chevron-forward-outline"></ion-icon></a>
            </div>
        </div>
        <div class="box wow fadeInDown" data-wow-duration="2s" data-wow-delay="2s">
            <div class="image">
                <img src="../../../assets/img/cart-6.jpg" alt=""/>
            </div>
            <div class="box-content">
                <h3>Tours & Travel</h3>
                <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eius maxime est inventore veniam esse.
                     Nisi, rem amet consequuntur quia enim ut excepturi ipsam culpa beatae sit dolor unde aperiam. Sit!</p>
                <a href="#">Read More <ion-icon name="chevron-forward-outline"></ion-icon></a>
            </div>
        </div>
        <div class="box wow fadeInDown" data-wow-duration="2s" data-wow-delay="2.5s">
            <div class="image">
                <img src="../../../assets/img/cart-7.jpg" alt=""/>
            </div>
            <div class="box-content">
                <h3>Tours & Travel</h3>
                <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eius maxime est inventore veniam esse.
                     Nisi, rem amet consequuntur quia enim ut excepturi ipsam culpa beatae sit dolor unde aperiam. Sit!</p>
                <a href="#">Read More <ion-icon name="chevron-forward-outline"></ion-icon></a>
            </div>
        </div>--%>
    </div>
</section>
<asp:Literal ID="ltrNhomSanPham" runat="server"></asp:Literal>
<%--<section class="services" id="services">
    <div class="destination-heading wow flipInY" data-wow-duration="2s" data-wow-delay="1.5s">
        <span>Our Services</span>
        <h1>Countless Expericences</h1>
    </div>
    <div class="box-container">
        <div class="box wow slideInLeft" data-wow-duration="1s" data-wow-delay="1.5s">
            <ion-icon name="planet-outline"></ion-icon>
            <h3>WorldWide</h3>
            <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. A cum voluptatum</p>
        </div>
        <div class="box wow slideInLeft" data-wow-duration="1s" data-wow-delay="1.5s">
            <ion-icon name="bicycle-outline"></ion-icon>
            <h3>Adventures</h3>
            <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. A cum voluptatum</p>
        </div>
        <div class="box wow slideInDown" data-wow-duration="1s" data-wow-delay="2s">
            <ion-icon name="fast-food-outline"></ion-icon>
            <h3>Food & Drinks</h3>
            <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. A cum voluptatum</p>
        </div>
        <div class="box wow fadeInUp" data-wow-duration="1s" data-wow-delay="3s">
            <ion-icon name="bed-outline"></ion-icon>
            <h3>Affordable Hotels</h3>
            <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. A cum voluptatum</p>
        </div>
        <div class="box wow slideInRight" data-wow-duration="1s" data-wow-delay="2s">
            <ion-icon name="wallet-outline"></ion-icon>
            <h3>Affordable Price</h3>
            <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. A cum voluptatum</p>
        </div>
        <div class="box wow slideInRight" data-wow-duration="1s" data-wow-delay="2s">
            <ion-icon name="headset-outline"></ion-icon>
            <h3>24/7 Support</h3>
            <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. A cum voluptatum</p>
        </div>
    </div>

</section>--%>
<section class="gallery" id="gallery">
    <div class="destination-heading wow bounceInLeft" data-wow-duration="2s" data-wow-delay="2s">
        <span>Our News</span>
        <h1>We record memories</h1>
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
        <h1>không có tin tức nào </h1>
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
<section class="blogs" id="blogs">
    <div class="destination-heading wow flipInX" data-wow-duration="2s" data-wow-delay="2s">
        <span>Container & Address</span>
        <h1>Contact us</h1>
    </div>
       
        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3929.107887631924!2d105.72064291474227!3d10.007946492845722!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31a08903d92d1d0d%3A0x2c147a40ead97caa!2zVHLGsOG7nW5nIMSQ4bqhaSBo4buNYyBOYW0gQ-G6p24gVGjGoQ!5e0!3m2!1svi!2s!4v1667742487290!5m2!1svi!2s" style="border: 0;border-radius:20px; width: 100%; height: 350px;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
      <%--  <div class="box wow rotateInDownLeft" data-wow-duration="1s" data-wow-delay="1s">
            <div class="image">
                <img src="../../../assets/img/blog-1.jpg" alt="" />
            </div>
            <div class="content">
                <a href="#" class="link">Life is a journey, not a destination </a>
                <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Sint, eveniet?</p>
                <div class="icon">
                    <a href="#">
                        <ion-icon name="time-outline"></ion-icon>
                        21st May, 2022</a>
                    <a href="#">
                        <ion-icon name="person-outline"></ion-icon>
                        By Admin</a>
                </div>
            </div>
        </div>
        <div class="box wow rotateIn" data-wow-duration="1s" data-wow-delay="1.5s">
            <div class="image">
                <img src="../../../assets/img/blog-2.jpg" alt="" />
            </div>
            <div class="content">
                <a href="#" class="link">Life is a journey, not a destination </a>
                <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Sint, eveniet?</p>
                <div class="icon">
                    <a href="#">
                        <ion-icon name="time-outline"></ion-icon>
                        21st May, 2022</a>
                    <a href="#">
                        <ion-icon name="person-outline"></ion-icon>
                        By Admin</a>
                </div>
            </div>
        </div>
        <div class="box wow rotateInUpRight" data-wow-duration="1s" data-wow-delay="1s">
            <div class="image">
                <img src="../../../assets/img/blog-3.jpg" alt="" />
            </div>
            <div class="content">
                <a href="#" class="link">Life is a journey, not a destination </a>
                <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Sint, eveniet?</p>
                <div class="icon">
                    <a href="#">
                        <ion-icon name="time-outline"></ion-icon>
                        21st May, 2022</a>
                    <a href="#">
                        <ion-icon name="person-outline"></ion-icon>
                        By Admin</a>
                </div>
            </div>
        </div>--%>
    
</section>

<%--<section class="destination">
    <div class="destination-heading wow bounceInLeft" data-wow-duration="2s" data-wow-delay="2s">
        <span>Our Gallery</span>
        <h1>We record memories</h1>
    </div>
    <div class="list-product-slider box-container">
        <div class="box item-prpduct-slider">
            <div class="image">
                <img src="../../../assets/img/cart-5.jpg" alt=""/>
            </div>
            <div class="box-content">
                <h3>Tours & Travel</h3>
                <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eius maxime est inventore veniam esse.
                     Nisi, rem amet consequuntur quia enim ut excepturi ipsam culpa beatae sit dolor unde aperiam. Sit!</p>
                <a href="#">Read More <ion-icon name="chevron-forward-outline"></ion-icon></a>
            </div>
        </div>
        <div class="box item-prpduct-slider">
            <div class="image">
                <img src="../../../assets/img/cart-5.jpg" alt=""/>
            </div>
            <div class="box-content">
                <h3>Tours & Travel</h3>
                <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eius maxime est inventore veniam esse.
                     Nisi, rem amet consequuntur quia enim ut excepturi ipsam culpa beatae sit dolor unde aperiam. Sit!</p>
                <a href="#">Read More <ion-icon name="chevron-forward-outline"></ion-icon></a>
            </div>
        </div>
        <div class="box item-prpduct-slider">
            <div class="image">
                <img src="../../../assets/img/cart-5.jpg" alt=""/>
            </div>
            <div class="box-content">
                <h3>Tours & Travel</h3>
                <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eius maxime est inventore veniam esse.
                     Nisi, rem amet consequuntur quia enim ut excepturi ipsam culpa beatae sit dolor unde aperiam. Sit!</p>
                <a href="#">Read More <ion-icon name="chevron-forward-outline"></ion-icon></a>
            </div>
        </div>
         <div class="box item-prpduct-slider">
            <div class="image">
                <img src="../../../assets/img/cart-5.jpg" alt=""/>
            </div>
            <div class="box-content">
                <h3>Tours & Travel</h3>
                <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eius maxime est inventore veniam esse.
                     Nisi, rem amet consequuntur quia enim ut excepturi ipsam culpa beatae sit dolor unde aperiam. Sit!</p>
                <a href="#">Read More <ion-icon name="chevron-forward-outline"></ion-icon></a>
            </div>
        </div>
         <div class="box item-prpduct-slider">
            <div class="image">
                <img src="../../../assets/img/cart-5.jpg" alt=""/>
            </div>
            <div class="box-content">
                <h3>Tours & Travel</h3>
                <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eius maxime est inventore veniam esse.
                     Nisi, rem amet consequuntur quia enim ut excepturi ipsam culpa beatae sit dolor unde aperiam. Sit!</p>
                <a href="#">Read More <ion-icon name="chevron-forward-outline"></ion-icon></a>
            </div>
        </div>
         <div class="box item-prpduct-slider">
            <div class="image">
                <img src="../../../assets/img/cart-5.jpg" alt=""/>
            </div>
            <div class="box-content">
                <h3>Tours & Travel</h3>
                <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eius maxime est inventore veniam esse.
                     Nisi, rem amet consequuntur quia enim ut excepturi ipsam culpa beatae sit dolor unde aperiam. Sit!</p>
                <a href="#">Read More <ion-icon name="chevron-forward-outline"></ion-icon></a>
            </div>
        </div>
    </div>
</section>--%>
