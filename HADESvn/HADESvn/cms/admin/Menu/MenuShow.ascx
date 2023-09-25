<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuShow.ascx.cs" Inherits="HADESvn.cms.admin.Menu.MenuShow" %>
<ul class="nav nav-tabs">
    <li class="nav-item">
        <a class="nav-link active" aria-current="page" href="AdminPage.aspx?modul=Menu&modulphu=DanhSachMenu">Danh Sách Menu</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="AdminPage.aspx?modul=Menu&modulphu=DanhSachMenu&thaotac=ThemMoi">Thêm Mới Menu</a>
    </li>    
</ul>
<div class="row g-3 from-margin-lr">
    <div class="col-md-12 col-btn-add">
        <a href="AdminPage.aspx?modul=Menu&modulphu=DanhSachMenu&thaotac=ThemMoi" class="btn btn-not btn-add"><ion-icon name="add-circle-outline"></ion-icon>Thêm Menu</a>
    </div>
    <div class="col-12">
        <table class="table  table-hover table-cover">
            <thead>
                <tr>
                    <th scope="col">Mã</th>
                    <th scope="col">Tên menu</th>
                    <th scope="col">Thứ tự</th>                  
                    <th scope="col">Công cụ</th>                
                </tr>
            </thead>
            <tbody>
                <asp:Literal ID="ltrMenu" runat="server"></asp:Literal>
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
    function XoaMenu(MaMenu) {
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
                $.post("Menu/Ajax/Menu",
                    {
                        "ThaoTac": "XoaMenu",
                        "MaMenu": MaMenu
                    },
                    function (data, status) {
                        //alert("Data :" + data + "\n Status :" + status);
                        if (data == 1) {
                            //thực hiện thành công => ẩn dòng vừa xóa đi
                            $("#maDong_" + MaMenu).slideUp();

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
        //if (confirm("Bạn chắc chắn muốn xóa menu này")) {
        //    //Viết code xóa danh mục tại đây

            
        //}
    }
</script>