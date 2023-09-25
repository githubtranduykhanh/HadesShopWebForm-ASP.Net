<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SizeShow.ascx.cs" Inherits="HADESvn.cms.admin.SanPham.QuanLySize.SizeShow" %>
<ul class="nav nav-tabs">
  <li class="nav-item">
    <a class="nav-link" href="AdminPage.aspx?modul=SanPham&modulphu=DanhSachSanPham&thaotac=HienThi">Quản Lý Sản Phẩm</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" href="AdminPage.aspx?modul=SanPham&modulphu=DanhMuc&thaotac=HienThi">Quản lý Danh Mục</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" href="AdminPage.aspx?modul=SanPham&modulphu=ChatLieu&thaotac=HienThi">Quản Lý Chất Liệu</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" href="AdminPage.aspx?modul=SanPham&modulphu=Mau&thaotac=HienThi">Quản Lý Màu</a>
  </li>
    <li class="nav-item">
    <a class="nav-link active" aria-current="page" href="AdminPage.aspx?modul=SanPham&modulphu=Size&thaotac=HienThi">Quản Lý Size</a>
  </li>
    <li class="nav-item">
    <a class="nav-link" href="AdminPage.aspx?modul=SanPham&modulphu=NhomSanPham&thaotac=HienThi">Quản Lý Nhóm</a>
  </li>
</ul>
<div class="row g-3 from-margin-lr">
    <div class="col-md-12 col-btn-add">
        <a href="AdminPage.aspx?modul=SanPham&modulphu=Size&thaotac=ThemMoi" class="btn btn-not btn-add"><ion-icon name="add-circle-outline"></ion-icon>Thêm Size</a>
    </div>
    <div class="col-12">
        <table class="table  table-hover table-cover">
            <thead>
                <tr>
                    <th scope="col">Mã</th>
                    <th scope="col">Tên Size</th>
                    <th scope="col">Công cụ</th>
                    
                </tr>
            </thead>
            <tbody>
                <asp:Literal ID="ltrSize" runat="server"></asp:Literal>
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
    function XoaSize(SizeID) {
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



                $.post("SanPham/QuanLySize/Ajax/Size",
                    {
                        "ThaoTac": "XoaSize",
                        "SizeID": SizeID
                    },
                    function (data, status) {
                        //alert("Data :" + data + "\n Status :" + status);
                        if (data == 1) {
                            //thực hiện thành công => ẩn dòng vừa xóa đi
                            $("#maDong_" + SizeID).slideUp();

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
        //if (confirm("Bạn chắc chắn muốn xóa Size này")) {
        //    //Viết code xóa màu tại đây

            
        //}
    }
</script>