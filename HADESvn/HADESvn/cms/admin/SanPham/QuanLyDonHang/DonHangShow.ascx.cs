using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLyDonHang
{
    public partial class DonHangShow : System.Web.UI.UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LayDonHang();

            }
        }
        private void LayDonHang()
        {
            var data = from cd in db.db_DonDatHangs
                       orderby cd.MaDonDatHang descending
                       select cd;
            foreach (var item in data.ToList())
            {
                ltrDonHang.Text += @"
                    <tr id='maDong_" + item.MaDonDatHang + @"'>
                            <th scope='row'>" + item.MaDonDatHang + @"</th>
                            <td>" + ((DateTime)item.NgayTao).ToString("dd/MM/yyyy hh:mm:ss tt") + @"</td>                          
                            <td>" + string.Format("{0:0,000}", item.ThanhTienDH) + @"đ</td>
                            <td>" + HienThiTinhTrangDonHang(item.TinhTrangDonHang.ToString()) + @"</td>
                            <td style='text-align: start;'>
                                Mã KH: " + item.MaKH + @"<br/>
                                Tên KH: " +item.TenKH + @"<br/>
                                Số điện thoại KH: " + item.sdtKH + @"<br/>
                                Email KH: " + item.EmailKH + @"<br/>
                            </td>
                            <td class='td-hel td'>
                                
                                <a href=" + "\"javascript:window.open('SanPham/QuanLyDonHang/ChiTietDonHang?id=" + item.MaDonDatHang + "')\"" + @"><ion-icon name='create-outline'></ion-icon></a>
                                <a href='javascript:XoaDonHang(" + item.MaDonDatHang + @")'><ion-icon name='close-circle-outline'></ion-icon></a>                               
                             </td>
                    </tr>    
                ";
            }
        }
        private string HienThiTinhTrangDonHang(string maTinhTrang)
        {
            string s = maTinhTrang;
            switch (maTinhTrang)
            {
                case "1":
                    s = "Khách hàng đã thanh toán";
                    break;

                case "0":
                    s = "Khách hàng hủy thanh toán";
                    break;
                case "2":
                    s = "Thanh toán khi giao hàng";
                    break;
                default:
                    s = "Chờ KH thanh toán";
                    break;
            }

            return s;
        }
    }
}