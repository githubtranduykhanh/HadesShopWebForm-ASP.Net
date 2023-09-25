using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.ThongKe.Ajax
{
    public partial class ThongKe : System.Web.UI.Page
    {
        string thaotac = "";
        DataClasses1DataContext db = new DataClasses1DataContext();

        public static List<db_DonDatHang> listDonHang = new List<db_DonDatHang>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ThaoTac"] != null)
            {
                thaotac = Request.Params["ThaoTac"];
            }

            switch (thaotac)
            {
                case "LayRaThoiGianTrongNgay":
                    LayRaThoiGianTrongNgay();
                    break;
                case "LayRaThongTinSoLuongThongKeTrongNgay":
                    LayRaThongTinSoLuongThongKeTrongNgay();
                    break;
                case "LayRaThongTinTongTienThongKeTrongNgay":
                    LayRaThongTinTongTienThongKeTrongNgay();
                    break;
                case "LayRaThongTinHoaTienThongKeTrongNgay":
                    LayRaThongTinHoaTienThongKeTrongNgay();
                    break;
                case "LayRaThongTinLocThongKeTrongNgay":
                    LayRaThongTinLocThongKeTrongNgay();
                    break;
                case "LayRaThongTinLocThongKe":
                    LayRaThongTinLocThongKe();
                    break;
                case "locKetQua":
                    locKetQua();
                    break;
                case "locKetQuaSL":
                    locKetQuaSL();
                    break;
                case "locKetQuaHT":
                    locKetQuaHT();
                    break;
            }
        }
        private void LayRaThoiGianTrongNgay()
        {      
            string ketQua = DateTime.Now.ToString("yyyy-MM-ddThh:mm");
            Response.Write(ketQua);
        }
        private void LayRaThongTinLocThongKeTrongNgay()
        {
            string ketQua = "";
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd");
            string dateTimeEnd = DateTime.Now.ToString("yyyy-MM-ddThh:mm");
            var data = from cd in db.db_DonDatHangs
                       where cd.NgayTao >= DateTime.Parse(dateTime) && cd.NgayTao <= DateTime.Parse(dateTimeEnd)
                       orderby cd.NgayTao descending
                       select cd;
            if (data.Count() > 0 && data != null)
            {
                ketQua += @"<h1 style='color: var(--text-color); text-align:center;margin-bottom: 30px;'>Đơn Hàng Tìm Kiếm</h1>";
                ketQua += @"
                            <table class='table-style table-style-cart table-customer table table-hover table-striped'>
                                <thead class='table-style-thead table-style-thead-customer'>
                                    <tr class='table-style-tr'>                                       
                                        <th scope='col' >Tên khách hàng</th>     
                                        <th scope='col' >Ngày nhận</th>
                                        <th scope='col' >Tổng tiền</th>
                                        <th scope='col' >Tình trạng</th>
                                        <th scope='col' >Khách hàng</th>                                                       
                                     </tr>         
                                 </thead>                
                             <tbody>
                        ";
                foreach (var item in data.ToList())
                {
                    ketQua += @"
                    <tr id='maDong_" + item.MaDonDatHang + @"'>
                            <th scope='row'>" + item.TenKH + @"</th>
                            <td>" + ((DateTime)item.NgayTao).ToString("dd/MM/yyyy hh:mm") + @"</td>                          
                            <td>" + string.Format("{0:0,000}", item.ThanhTienDH) + @"đ</td>
                            <td>" + HienThiTinhTrangDonHang(item.TinhTrangDonHang.ToString()) + @"</td>
                            <td>
                                Mã KH: " + item.MaKH + @"<br/>
                                Số điện thoại KH: " + item.sdtKH + @"<br/>
                                Email KH: " + item.EmailKH + @"<br/>
                            </td>                         
                    </tr>    
                ";
                }

                ketQua += @"
                            </tbody>
                        </table>
                            ";
            }
            else
            {
                ketQua += "Không có đơn hàng :((";
            }
           

            Response.Write(ketQua);
        }
        private void LayRaThongTinLocThongKe()
        {
            string ketQua = "";
            string dateTimeStar = Convert.ToDateTime(Request.Params["TuNgay"]).ToString("yyyy-MM-ddThh:mm");
            string dateTimeEnd = Convert.ToDateTime(Request.Params["DenNgay"]).ToString("yyyy-MM-ddThh:mm");            
            var data = from cd in db.db_DonDatHangs
                       where cd.NgayTao >= DateTime.Parse(dateTimeStar) && cd.NgayTao <= DateTime.Parse(dateTimeEnd)
                       orderby cd.NgayTao descending
                       select cd;
            if (data.Count() > 0 && data != null)
            {
                ketQua += @"<h1 style='color: var(--text-color); text-align:center;margin-bottom: 30px;'>Đơn Hàng Tìm Kiếm</h1>";
                ketQua += @"
                            <table class='table-style table-style-cart table-customer table table-hover table-striped'>
                                <thead class='table-style-thead table-style-thead-customer'>
                                    <tr class='table-style-tr'>                                       
                                        <th scope='col' >Tên khách hàng</th>     
                                        <th scope='col' >Ngày nhận</th>
                                        <th scope='col' >Tổng tiền</th>
                                        <th scope='col' >Tình trạng</th>
                                        <th scope='col' >Khách hàng</th>                                                       
                                     </tr>         
                                 </thead>                
                             <tbody>
                        ";
                foreach (var item in data.ToList())
                {
                    ketQua += @"
                    <tr id='maDong_" + item.MaDonDatHang + @"'>
                            <th scope='row'>" + item.TenKH + @"</th>
                            <td>" + ((DateTime)item.NgayTao).ToString("dd/MM/yyyy hh:mm") + @"</td>                          
                            <td>" + string.Format("{0:0,000}", item.ThanhTienDH) + @"đ</td>
                            <td>" + HienThiTinhTrangDonHang(item.TinhTrangDonHang.ToString()) + @"</td>
                            <td>
                                Mã KH: " + item.MaKH + @"<br/>
                                Số điện thoại KH: " + item.sdtKH + @"<br/>
                                Email KH: " + item.EmailKH + @"<br/>
                            </td>                         
                    </tr>    
                ";
                }

                ketQua += @"
                            </tbody>
                        </table>
                            ";
            }
            else
            {
                ketQua += "Không có đơn hàng :((";
            }


            Response.Write(ketQua);
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
        private void locKetQua()
        {
            double soLuong = 0;
            string dateTimeStar = Convert.ToDateTime(Request.Params["TuNgay"]).ToString("yyyy-MM-ddThh:mm");
            string dateTimeEnd = Convert.ToDateTime(Request.Params["DenNgay"]).ToString("yyyy-MM-ddThh:mm");
            string dateTime = DateTime.Now.ToString("yyyy-MM-ddThh:mm");
            var sumDH = (from p in db.db_DonDatHangs
                         where p.NgayTao >= DateTime.Parse(dateTimeStar) && p.NgayTao <= DateTime.Parse(dateTimeEnd)
                         select p).ToList();
            foreach (var item in sumDH)
            {
                
                    soLuong += (double)item.ThanhTienDH;
                
            }
            Response.Write(soLuong);
        }
        private void locKetQuaSL()
        {
            int soLuong = 0;
            string dateTimeStar = Convert.ToDateTime(Request.Params["TuNgay"]).ToString("yyyy-MM-ddThh:mm");
            string dateTimeEnd = Convert.ToDateTime(Request.Params["DenNgay"]).ToString("yyyy-MM-ddThh:mm");
            string dateTime = DateTime.Now.ToString("yyyy-MM-ddThh:mm");
            var sumDH = (from p in db.db_DonDatHangs
                         where p.NgayTao >= DateTime.Parse(dateTimeStar) && p.NgayTao <= DateTime.Parse(dateTimeEnd)
                         select p).ToList();
            foreach (var item in sumDH)
            {
               
                    soLuong += 1;
                
            }
            Response.Write(soLuong);
        }
        private void locKetQuaHT()
        {
            double tien = 0;
            string dateTimeStar = Convert.ToDateTime(Request.Params["TuNgay"]).ToString("yyyy-MM-ddThh:mm");
            string dateTimeEnd = Convert.ToDateTime(Request.Params["DenNgay"]).ToString("yyyy-MM-ddThh:mm");
            string dateTime = DateTime.Now.ToString("yyyy-MM-ddThh:mm");
            var sumDH = (from p in db.db_DonDatHangs    
                         where p.NgayTao >= DateTime.Parse(dateTimeStar) && p.NgayTao <= DateTime.Parse(dateTimeEnd)
                         select p).ToList();
            foreach (var item in sumDH)
            {
                
                    tien += (double)item.ThanhTienDH;
                
            }
            double ketQua = (tien * 20) / 100;
            Response.Write(ketQua);
        }
        private void LayRaThongTinSoLuongThongKeTrongNgay()
        {
            //List<db_DonDatHang> listDonHang = new List<db_DonDatHang>();

            //var sumDH = (from p in db.db_DonDatHangs
            //             where p.NgayTao == DateTime.Parse(dateTime)
            //             select p).ToList();
            //listDonHang = sumDH;
            ////var sumTongTien = sumDH.Select(c => c.MaDonDatHang).Sum();
            //int ketQua = listDonHang.Sum(e=> e.MaDonDatHang);
            int soLuong = 0;
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd");
            var sumDH = (from p in db.db_DonDatHangs                        
                        select p).ToList();       
            foreach (var item in sumDH)
            {
                if (Convert.ToDateTime(item.NgayTao).ToString("yyyy-MM-dd") == dateTime)
                {
                    soLuong += 1;
                }
            }          
            Response.Write(soLuong);
        }
        private void LayRaThongTinTongTienThongKeTrongNgay()
        {
            //List<db_DonDatHang> listDonHang = new List<db_DonDatHang>();
            //string dateTime = DateTime.Now.ToString("yyyy-MM-dd");
            //var sumDH = (from p in db.db_DonDatHangs
            //             where p.NgayTao == DateTime.Parse(dateTime)
            //             select p).ToList();
            //listDonHang = sumDH;
            ////var sumTongTien = sumDH.Select(c => c.MaDonDatHang).Sum();
            //double ketQua = (double)listDonHang.Sum(e => e.ThanhTienDH);
            double soLuong = 0 ;
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd");
            var sumDH = (from p in db.db_DonDatHangs
                         select p).ToList();
            foreach (var item in sumDH)
            {
                if (Convert.ToDateTime(item.NgayTao).ToString("yyyy-MM-dd") == dateTime)
                {
                    soLuong += (double)item.ThanhTienDH;
                }
            }
            Response.Write(soLuong);
        }
        private void LayRaThongTinHoaTienThongKeTrongNgay()
        {
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd");
            double tien = 0;           
            var sumDHt = (from p in db.db_DonDatHangs
                         select p).ToList();
            foreach (var item in sumDHt)
            {
                if (Convert.ToDateTime(item.NgayTao).ToString("yyyy-MM-dd") == dateTime)
                {
                    tien += (double)item.ThanhTienDH;
                }
            }            
            double ketQua = (tien * 20) / 100;
            Response.Write(ketQua);           
        }
    }
}