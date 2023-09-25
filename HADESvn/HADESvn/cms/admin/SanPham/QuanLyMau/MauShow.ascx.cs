using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLyMau
{
    public partial class MauShow : System.Web.UI.UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LayMau();
        }
        private void LayMau()
        {
            var data = from cd in db.db_Maus
                       select cd;
            foreach (var item in data.ToList())
            {
                ltrMau.Text += @"
                    <tr id='maDong_" + item.MauID + @"'>
                            <th scope='row'>" + item.MauID + @"</th>
                            <td>" + item.TenMau + @"</td>
                                                                
                            <td class='td'>                               
                                <a href='AdminPage.aspx?modul=SanPham&modulphu=Mau&thaotac=ChinhSua&id=" + item.MauID + @"'><ion-icon name='create-outline'></ion-icon></a>
                                <a href='javascript:XoaMau(" + item.MauID + @")'><ion-icon name='close-circle-outline'></ion-icon></a>
                            </td>
                    </tr>    
                ";
            }
        }
    }
}