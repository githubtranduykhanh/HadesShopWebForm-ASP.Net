<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KhachHangShow.ascx.cs" Inherits="HADESvn.cms.admin.KhachHang.KhachHangShow" %>
<div class="row g-3 from-margin-lr">
    <div class="col-12">
        <table class="table  table-hover table-cover table-customer">
            <thead>
                <tr>
                    <th scope="col">Mã khách hàng</th>
                    <th scope="col">Tên khách hàng</th>
                    <th scope="col">Địa chỉ</th>
                    <th scope="col">Số điện thoại</th>
                    <th scope="col">Email</th>                                   
                </tr>
            </thead>
            <tbody>
                <asp:Literal ID="ltrKhachHang" runat="server"></asp:Literal>
                <%--<tr>
                    <th scope="row">1</th>
                    <td>Mark</td>
                    <td>Otto</td>
                    <td>@mdo</td>
                    <td class="td">
                        <a href="#"><ion-icon name="add-circle-outline"></ion-icon></a>
                        <a href="#"><ion-icon name="create-outline"></ion-icon></a>
                        <a href="#"><ion-icon name="close-circle-outline"></ion-icon></a>
                    </td>
                </tr>   --%>             
            </tbody>
        </table>
    </div>
</div>