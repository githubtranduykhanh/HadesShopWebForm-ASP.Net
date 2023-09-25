<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DonHangShow.ascx.cs" Inherits="HADESvn.cms.admin.SanPham.QuanLyDonHang.DonHangShow" %>
<div class="row g-3 from-margin-lr">
    <div class="col-12">
        <table class="table  table-hover table-cover">
            <thead>
                <tr>
                    <th scope="col">Mã</th>
                    <th scope="col">Ngày nhận</th>
                    <th scope="col">Tổng tiền</th>
                    <th scope="col">Tình trạng</th>
                    <th scope="col">Khách hàng</th>
                    <th scope="col">Công cụ</th>
                </tr>
            </thead>
            <tbody>
                <asp:Literal ID="ltrDonHang" runat="server"></asp:Literal>
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
<script type="text/javascript">
    function XoaDonHang(id) {
        swalWithBootstrapButtons.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            cancelButtonText: 'No, cancel!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {



                $.post("SanPham/QuanLyDonHang/Ajax/DonHang",
                    {
                        "ThaoTac": "XoaDonHang",
                        "id": id
                    },
                    function (data, status) {
                        //alert("Data :" + data + "\n Status :" + status);
                        if (data == 1) {
                            //thực hiện thành công => ẩn dòng vừa xóa đi
                            $("#maDong_" + id).slideUp();
                        }
                    });



                swalWithBootstrapButtons.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )
            } else if (
                /* Read more about handling dismissals below */
                result.dismiss === Swal.DismissReason.cancel
            ) {
                swalWithBootstrapButtons.fire(
                    'Cancelled',
                    'Your imaginary file is safe :)',
                    'error'
                )
            }
        })
        //if (confirm("Bạn chắc chắn muốn xóa đơn hàng này")) {
        //    //Viết code xóa danh mục tại đây

           
        //}
    }
</script>