using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.TinTuc.DanhSachTinTuc
{
    public partial class DanhSachTinTucShow : System.Web.UI.UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LayTinTuc();

            }
        }
        private void LayTinTuc()
        {
            var data = from cd in db.db_TinTucs
                       select cd;
            foreach (var item in data.ToList())
            {
                ltrTinTuc.Text += @"
                    <tr id='maDong_" + item.TinTucID + @"'>
                            <th scope='row'>" + item.TinTucID + @"</th>
                            <td>" + item.TieuDe + @"</td>
                            <td>
                                <img class='img'src='/assets/img/ItemTinTuc/" + item.AnhDaiDien + @"'/>
                            </td> 
                            <td>" + item.LuotXem + @"</td> 
                            <td>" + item.NgayDang + @"</td>
                            <td>" + item.ThuTu + @"</td>                                     
                            <td class='td'>
                                <a href='#'><ion-icon name='add-circle-outline'></ion-icon></a>
                                <a href='AdminPage.aspx?modul=TinTuc&modulphu=DanhSachTinTuc&thaotac=ChinhSua&id=" + item.TinTucID + @"'><ion-icon name='create-outline'></ion-icon></a>
                                <a href='javascript:XoaTinTuc(" + item.TinTucID + @")'><ion-icon name='close-circle-outline'></ion-icon></a>
                             </td>
                    </tr>    
                ";
            }
        }
    }
}