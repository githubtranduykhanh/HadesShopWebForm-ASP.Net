using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLyNhomSanPham
{
    public partial class NhomSanPhamShow : System.Web.UI.UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LayTaiKhoan();

            }
        }
        private void LayTaiKhoan()
        {
            var data = from cd in db.db_NhomSanPhams
                       select cd;
            foreach (var item in data.ToList())
            {
                ltrNhomSanPham.Text += @"
                    <tr id='maDong_" + item.NhomID + @"'>
                            <th scope='row'>" + item.NhomID + @"</th>
                            <td>" + item.TenNhom + @"</td>
                            <td>
                                <img class='img'src='/assets/img/SanPham/" + item.AnhDaiDien + @"'/>
                            </td> 
                            <td>" + item.ThuTu + @"</td>
                            <td>" + item.SoSPHienThi + @"</td>
                            <td class='td'>
                                <a href='AdminPage.aspx?modul=SanPham&modulphu=NhomSanPham&thaotac=ChinhSua&id=" + item.NhomID + @"'><ion-icon name='create-outline'></ion-icon></a>
                                <a href='javascript:XoaNhomSanPham(" + item.NhomID + @")'><ion-icon name='close-circle-outline'></ion-icon></a>
                             </td>
                    </tr>    
                ";
            }
        }
    }
}