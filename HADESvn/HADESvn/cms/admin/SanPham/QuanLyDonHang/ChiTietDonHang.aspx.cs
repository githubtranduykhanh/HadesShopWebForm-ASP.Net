using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLySanPham
{
    public partial class ChiTietDonHang : System.Web.UI.Page
    {
        private string id = "";
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
                id = Request.QueryString["id"];

            if (!IsPostBack)
                LayThongTinDonHang();
        }
        private void LayThongTinDonHang()
        {
            int MaDonDatHang = Convert.ToInt32(id);
            var madonhang = db.db_DonDatHangs.Single(a => a.MaDonDatHang == MaDonDatHang);
            
            if (madonhang != null)
            {
                ltrNgayDat.Text = ((DateTime)madonhang.NgayTao).ToString("dd/MM/yyyy");//Hiển thị ra ngày đặt hàng dạng ngày/tháng/năm              
                ltrMaDonHang.Text = madonhang.MaDonDatHang.ToString();

                ltrMaKH.Text = madonhang.MaKH.ToString();
                ltrTenKH.Text = madonhang.TenKH.ToString();
                ltrSoDTKH.Text = madonhang.sdtKH.ToString();
                ltrEmailKH.Text = madonhang.EmailKH.ToString();
                ltrDiaChiKH.Text = madonhang.DiaChiKH.ToString();

                ltrTongTienDonHang.Text = string.Format("{0:0,000}", double.Parse(madonhang.ThanhTienDH.ToString())) + "đ";


                ltrDanhSachSanPham.Text = LayDanhSachSanPhamTrongDonHang(madonhang.MaDonDatHang.ToString());
            }
        }
        private string LayDanhSachSanPhamTrongDonHang(string maDonHang)
        {
            string s = "";
            int MaDonDatHang = Convert.ToInt32(maDonHang);
            var chiTietDonHang = db.db_ChiTietDonDatHangs.Where(a => a.MaDonDatHang == MaDonDatHang).ToList();
            int i = 0;
            foreach (var item in chiTietDonHang.ToList())
            {
                
                s += @"
                    <tr>
                        <td>" + (i += 1) + @"</td>
                        <td>" + item.MaSP + @"</td>
                        <td>" + LayTenSanPhamTheoMaSP(item.MaSP.ToString()) + @"</td>
                        <td class='tar'>" + string.Format("{0:0,000}",item.DonGiaDat) + @"đ</td>
                        <td class='tar'>" + item.SoLuongDat + @"</td>
                        <td class='tar'>" + string.Format("{0:0,000}",(double.Parse(item.DonGiaDat.ToString()) * double.Parse(item.SoLuongDat.ToString()))) + @"đ</td>
                    </tr>
                    ";
            }

            return s;
        }

        private string LayTenSanPhamTheoMaSP(string maSP)
        {
            int maSPs = Convert.ToInt32(maSP);
            var sanPham = db.db_SanPhams.Where(a => a.MaSP == maSPs).First();
            if (sanPham != null)
                return sanPham.TenSP.ToString();
            return "";
        }
    }
}