<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="thongtincanhan.ascx.cs" Inherits="HADESvn.cms.index.control.thongtincanhan" %>
<div class="container-padding page-bang-size">
    <div class="row-list-product">
        <div class="col-list-product-3">
            <ul class="ul-list-product-3">                            
                <li class="li-list-product-3"><a href='<%="ThongTinCaNhan.aspx?modul=HoSo"%>' class="btn-madm btn-thong-tin-user"><ion-icon name="document-text-outline"></ion-icon>
                    <span>Hồ Sơ</span></a></li>    
                <li class="li-list-product-3"><a href='<%="ThongTinCaNhan.aspx?modul=MatKhau"%>' class="btn-madm btn-thong-tin-user"><ion-icon name="key-outline"></ion-icon>
                    <span>Đổi Mật Khẩu</span></a></li>
                <li class="li-list-product-3"><a href='<%="ThongTinCaNhan.aspx?modul=DonHang"%>' class="btn-madm btn-thong-tin-user"><ion-icon name="receipt-outline"></ion-icon>
                    <span>Đơn Mua</span></a></li>
            </ul>
        </div>
        <div class="col-list-product-9">
            <asp:PlaceHolder ID="UserPlaceHolder" runat="server"></asp:PlaceHolder>
        </div>
    </div>
</div>
