using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLySize
{
    public partial class SizeShow : System.Web.UI.UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LaySize();
        }
        private void LaySize()
        {
            var data = from cd in db.db_Sizes
                       select cd;
            foreach (var item in data.ToList())
            {
                ltrSize.Text += @"
                    <tr id='maDong_" + item.SizeID + @"'>
                            <th scope='row'>" + item.SizeID + @"</th>
                            <td>" + item.TenSize + @"</td>
                                                                
                            <td class='td'>                               
                                <a href='AdminPage.aspx?modul=SanPham&modulphu=Size&thaotac=ChinhSua&id=" + item.SizeID + @"'><ion-icon name='create-outline'></ion-icon></a>
                                <a href='javascript:XoaSize(" + item.SizeID + @")'><ion-icon name='close-circle-outline'></ion-icon></a>
                            </td>
                    </tr>    
                ";
            }
        }
    }
}