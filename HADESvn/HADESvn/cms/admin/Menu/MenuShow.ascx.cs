using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.Menu
{
    public partial class MenuShow : System.Web.UI.UserControl
    {
        string mamenucha = "0";
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mamenucha"] != null)
                mamenucha = Request.QueryString["mamenucha"];
            if (!IsPostBack)
                LayMenu();
        }
        private void LayMenu()
        {
            var data = from cd in db.db_Menus
                       select cd;
            foreach (var item in data.ToList())
            {
                ltrMenu.Text += @"
                    <tr id='maDong_" + item.MaMenu + @"'>
                            <th scope='row'>" + item.MaMenu + @"</th>
                            <td>" + item.TenMenu + @"</td>                           
                            <td>" + item.ThuTuMenu + @"</td>                                     
                            <td class='td'>
                                <a href='#'><ion-icon name='add-circle-outline'></ion-icon></a>
                                <a href='AdminPage.aspx?modul=Menu&modulphu=DanhSachMenu&thaotac=ChinhSua&id=" + item.MaMenu + @"'><ion-icon name='create-outline'></ion-icon></a>
                                <a href='javascript:XoaMenu(" + item.MaMenu + @")'><ion-icon name='close-circle-outline'></ion-icon></a>
                            </td>
                    </tr>    
                ";
            }
        }
    }
}