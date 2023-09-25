using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLyChatLieu
{
    public partial class ChatLieuShow : System.Web.UI.UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LayChatLieu();
        }
        private void LayChatLieu()
        {
            var data = from cd in db.db_ChatLieus
                       select cd;
            foreach (var item in data.ToList())
            {
                ltrChatLieu.Text += @"
                    <tr id='maDong_" + item.ChatLieuID + @"'>
                            <th scope='row'>" + item.ChatLieuID + @"</th>
                            <td>" + item.TenChatLieu + @"</td>
                                                                
                            <td class='td'>                               
                                <a href='AdminPage.aspx?modul=SanPham&modulphu=ChatLieu&thaotac=ChinhSua&id=" + item.ChatLieuID + @"'><ion-icon name='create-outline'></ion-icon></a>
                                <a href='javascript:XoaChatLieu(" + item.ChatLieuID + @")'><ion-icon name='close-circle-outline'></ion-icon></a>
                            </td>
                    </tr>    
                ";
            }
        }
    }
}