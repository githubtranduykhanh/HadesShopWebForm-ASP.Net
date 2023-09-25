using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HADESvn.cms.admin.SanPham.QuanLyDanhMuc
{
    public partial class DanhMucShow : System.Web.UI.UserControl
    {
      
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LayDanhMuc();

            }
           

        }
        private void LayDanhMuc()
        {
            var data = from cd in db.db_DanhMucs
                       select cd;
            foreach (var item in data.ToList())
            {
                ltrDanhMuc.Text += @"
                    <tr id='maDong_" + item.MaDM + @"'>
                            <th scope='row'>" + item.MaDM+ @"</th>
                            <td>"+item.TenDM+ @"</td>
                            <td>
                                <img class='img'src='/assets/img/DanhMuc/" + item.AnhDaiDien + @"'/>
                            </td> 
                            <td>" + item.ThuTu+ @"</td>                                     
                            <td class='td'>
                                <a href='javascript:DanhMuc(" + item.MaDM + @")'><ion-icon name='add-circle-outline'></ion-icon></a>
                                <a href='AdminPage.aspx?modul=SanPham&modulphu=DanhMuc&thaotac=ChinhSua&id=" + item.MaDM + @"'><ion-icon name='create-outline'></ion-icon></a>
                                <a href='javascript:XoaDanhMuc("+item.MaDM+@")'><ion-icon name='close-circle-outline'></ion-icon></a>
                             </td>
                    </tr>    
                ";
            }
        }
    }
}