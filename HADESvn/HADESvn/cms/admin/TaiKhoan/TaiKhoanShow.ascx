<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TaiKhoanShow.ascx.cs" Inherits="HADESvn.cms.admin.TaiKhoan.TaiKhoanShow" %>
<div class="row g-3 from-margin-lr">
    <div class="col-md-12 col-btn-add">
        <a href="AdminPage?modul=TaiKhoan&modulphu=TaiKhoan&thaotac=ThemMoi" class="btn btn-not btn-add"><ion-icon name="add-circle-outline"></ion-icon>Thêm Tài Khoản</a>
    </div>
    <div class="col-12">
        <table class="table  table-hover table-cover">
            <thead>
                <tr>
                    <th scope="col">Tên đăng nhập</th>
                    <th scope="col">Email</th>
                    <th scope="col">Địa chỉ</th>
                    <th scope="col">Họ tên</th>
                    <th scope="col">Ngày sinh</th>
                    <th scope="col">Giới tính</th>
                    <th scope="col">Công cụ</th>
                    
                </tr>
            </thead>
            <tbody>
                <asp:Literal ID="ltrTaiKhoan" runat="server"></asp:Literal>
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
    function XoaTaiKhoan(TenDangNhap) {
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



                $.post("TaiKhoan/Ajax/TaiKhoan",
                    {
                        "ThaoTac": "XoaTaiKhoan",
                        "TenDangNhap": TenDangNhap
                    },
                    function (data, status) {
                        //alert("Data :" + data + "\n Status :" + status);
                        if (data == 1) {
                            //thực hiện thành công => ẩn dòng vừa xóa đi
                            $("#maDong_" + TenDangNhap).slideUp();

                        }

                        else {
                            alert(data);
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
        //if (confirm("Bạn chắc chắn muốn xóa tài khoản này")) {
        //    //Viết code xóa màu tại đây

           
        //}
    }
</script>