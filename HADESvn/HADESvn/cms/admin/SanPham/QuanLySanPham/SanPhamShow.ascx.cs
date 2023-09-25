using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLySanPham
{
    public partial class SanPhamShow : System.Web.UI.UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LaySanPham();

            }
        }
        private void LaySanPham()
        {
            var data = from cd in db.db_SanPhams
                       select cd;
            foreach (var item in data.ToList())
            {
                ltrSanPham.Text += @"
                    <tr id='maDong_" + item.MaSP + @"'>
                            <th scope='row'>" + item.MaSP + @"</th>
                            <td>" + item.TenSP + @"</td>
                            <td>
                                <img class='img'src='/assets/img/SanPham/" + item.AnhSP + @"'/>
                            </td> 
                            <td>" + string.Format("{0:0,000}", item.GiaSP) + @"đ</td>
                            <td>" + ((DateTime)item.NgayTao).ToString("dd/MM/yyyy hh:mm:ss tt") + @"</td>
                            <td class='td'>
                                
                                <a href='AdminPage.aspx?modul=SanPham&modulphu=DanhSachSanPham&thaotac=ChinhSua&id=" + item.MaSP + @"'><ion-icon name='create-outline'></ion-icon></a>
                                <a href='javascript:XoaSanPham(" + item.MaSP + @")'><ion-icon name='close-circle-outline'></ion-icon></a>                               
                             </td>
                    </tr>    
                ";
            }
        }
    }
}