using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.TaiKhoan
{
    public partial class TaiKhoanShow : System.Web.UI.UserControl
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
            var data = from cd in db.db_DangKies
                       select cd;
            foreach (var item in data.ToList())
            {
                ltrTaiKhoan.Text += @"
                    <tr id='maDong_" + item.TenDangNhap + @"'>
                            <th scope='row'>" + item.TenDangNhap + @"</th>
                            <td>" + item.EmailDK + @"</td>
                            <td>" + item.DiaChiDK + @"</td> 
                            <td>" + item.TenDayDu + @"</td>
                            <td>" + ((DateTime)item.NgaySinh).ToString("dd/MM/yyyy") + @"</td>
                            <td>" + item.GioiTinhDK + @"</td>
                            <td class='td'>
                                <a href='AdminPage.aspx?modul=TaiKhoan&modulphu=TaiKhoan&thaotac=ChinhSua&id=" + item.TenDangNhap + @"'><ion-icon name='create-outline'></ion-icon></a>
                                <a href=javascript:XoaTaiKhoan('" + item.TenDangNhap + @"')><ion-icon name='close-circle-outline'></ion-icon></a>
                             </td>
                    </tr>    
                ";
            }
        }
    }
}