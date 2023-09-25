using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.KhachHang
{
    public partial class KhachHangShow : System.Web.UI.UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LayKhachHang();
        }
        private void LayKhachHang()
        {
            var data = from cd in db.db_KhachHangs
                       select cd;
            foreach (var item in data.ToList())
            {
                ltrKhachHang.Text += @"
                    <tr id='maDong_" + item.MaKH + @"'>
                            <th scope='row'>" + item.MaKH + @"</th>
                            <td>" + item.TenKh + @"</td>
                            <td>" + item.DiaChiKH + @"</td>
                            <td>" + item.sdtKH + @"</td>
                            <td>" + item.EmailKH + @"</td>                                                                                       
                    </tr>    
                ";
            }
        }
    }
}