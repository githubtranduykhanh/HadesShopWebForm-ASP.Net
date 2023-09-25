using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HADESvn.cms.index.page.SanPham.Ajax
{
    public partial class XuLyThanhToan : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public static List<db_DonDatHang> listDDH = new List<db_DonDatHang>();
        public static db_SanPham infoSP = new db_SanPham();
        public static db_KhachHang infoShowKH = new db_KhachHang();
        private string thaotac = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            thaotac = Request.Params["ThaoTac"];
            switch (thaotac)
            {
                
                case "LayTongSoSanPhamTrongGioHang":
                    LayTongSoSanPhamTrongGioHang();
                    break;
                case "LayTongTienTrongGioHang":
                    LayTongTienTrongGioHang();
                    break;              
                case "GuiDonHangThanhToan":
                    GuiDonHangThanhToan();
                    break;                              
                case "LayThongTinGioHangThanhToan":
                    LayThongTinGioHangThanhToan();
                    break;
                case "LayTongTienThanhToan":
                    LayTongTienThanhToan();
                    break;

            }
        }
        private void LayThongTinGioHangThanhToan()
        {
            string ketQua = "";
           
            //Nếu tồn tại giỏ hàng thì mới lấy ra kết quả
            if (Session["Cart"] != null)
            {
                //Khai báo datatable để chứa giỏ hàng
                DataTable cart = new DataTable();
                cart = (DataTable)Session["Cart"];
                if (cart.Rows.Count > 0)
                {
                    ketQua += @"
                            <table class='table-style'>                                                
                                 <tbody> ";

                    //Chạy vòng lặp và xuất dữ liệu trong giỏ hàng ra dạng bảng
                    for (int i = 0; i < cart.Rows.Count; i++)
                    {

                        ketQua += @"
                    <tr id='maDongThanhToan_" + cart.Rows[i]["ID"] + @"' class='table-style-tr-item'>    
                            <td class='img-padding-cart'>
                                <img class='img img-size-cart'src='/assets/img/SanPham/" + cart.Rows[i]["ANH"] + @"'/>
                            </td> 
                            <td>" + cart.Rows[i]["Name"] + @"</td>                            
                            
                            <td>" + cart.Rows[i]["Quantity"] + @"</td>                           
                            <td>" + string.Format("{0:0,000}", int.Parse(cart.Rows[i]["Price"].ToString())) + @"đ</td>                           
                    </tr>    
                    ";
                    }

                    ketQua += @"
                        </tbody>
                    </table>";

                    ketQua += @"
                        <div class='space-between'>
                            <h3>Tổng số sản phẩm:</h3>
                            <h3 id='TongSoSPTrongGioHangThanhToan'>0</h3>               
                        </div>
                        <div class='space-between'>
                            <h3>Tổng tiền:</h3>                          
                            <h3 id='TongTienTrongGioHangThanhToan'>0</h3>                                                                    
                        </div>
                            
                    ";
                }
                else
                {
                    ketQua += @"
                        <img src='/assets/img/empty-cart.jpg' alt='' class='img-heading'/>
                    ";
                }



            }
            else
            {
                ketQua += @"
                        <img src='/assets/img/empty-cart.jpg' alt='' class='img-heading'/>
                    ";
                //if ((Boolean)Session["user"] == false)
                //{
                //    ketQua += @"
                //        <img src='/assets/img/empty-cart.jpg' alt='' class='img-heading'/>
                //    ";
                //}
                //else
                //{
                //    ketQua += "";
                //}

            }

            Response.Write(ketQua);
        }
        private void LayTongTienTrongGioHang()
        {
            double tongTien = 0;

            //Nếu tồn tại giỏ hàng thì mới lấy ra kết quả
            if (Session["Cart"] != null)
            {
                //Khai báo datatable để chứa giỏ hàng
                DataTable cart = new DataTable();
                cart = (DataTable)Session["Cart"];

                //Chạy vòng lặp và tính ra tổng tiền (Thành tiền = Số lượng * Đơn giá)
                for (int i = 0; i < cart.Rows.Count; i++)
                {
                    tongTien += int.Parse(cart.Rows[i]["Money"].ToString());
                }
            }

            Response.Write(string.Format("{0:0,000}", tongTien));
        }
        private void LayTongTienThanhToan()
        {
            double tongTien = 0;

            //Nếu tồn tại giỏ hàng thì mới lấy ra kết quả
            if (Session["Cart"] != null)
            {
                //Khai báo datatable để chứa giỏ hàng
                DataTable cart = new DataTable();
                cart = (DataTable)Session["Cart"];

                //Chạy vòng lặp và tính ra tổng tiền (Thành tiền = Số lượng * Đơn giá)
                for (int i = 0; i < cart.Rows.Count; i++)
                {
                    tongTien += int.Parse(cart.Rows[i]["Money"].ToString());
                }
            }

            Response.Write(tongTien);
        }
        private void LayTongSoSanPhamTrongGioHang()
        {
            int tongSo = 0;

            //Nếu tồn tại giỏ hàng thì mới lấy ra kết quả
            if (Session["Cart"] != null)
            {
                //Khai báo datatable để chứa giỏ hàng
                DataTable cart = new DataTable();
                cart = (DataTable)Session["Cart"];

                //Chạy vòng lặp và đếm tổng số sản phẩm trong giỏ hàng
                for (int i = 0; i < cart.Rows.Count; i++)
                {
                    tongSo += int.Parse(cart.Rows[i]["Quantity"].ToString());
                }
            }

            Response.Write(tongSo);
        }
        private string XuLyThongTinKhachHang(string hoTen, string diaChi, string soDienThoai, string email)
        {
            //Lấy danh sách khách hàng theo email --> nếu chưa có --> Thêm mới, nếu đã có thì không thực hiện gì nữa
            var dt = (from s in db.db_KhachHangs
                      where s.EmailKH == email
                      select s);
            //var tb = db.db_KhachHangs.Single(s => s.EmailKH == email);     
            //var dt = db.db_KhachHangs.Single(a => a.EmailKH == email);
            if (dt.Count() == 0)
            {
                //Thêm mới khách hàng với mật khẩu chính là email của khách hàng
                string matKhau = HADESvn.MaHoa.MaHoaMD5(email);
                db_KhachHang infoDK = new db_KhachHang();
                infoDK.TenKh = hoTen;
                infoDK.EmailKH = email;
                infoDK.MatKhau = matKhau;
                infoDK.sdtKH = soDienThoai;
                infoDK.DiaChiKH = diaChi;
                infoDK.AnhDaiDien = "";
                db.db_KhachHangs.InsertOnSubmit(infoDK);
                db.SubmitChanges();
                //Thực hiện lấy lại thông tin khách hàng vừa thêm và trả về mã khách hàng

                return infoDK.MaKH.ToString();
            }
            else

                return dt.SingleOrDefault().MaKH.ToString();
        }
        private void GuiDonHangThanhToan()
        {
            string ketQua = "";

            //Lấy các thông tin người dùng gửi lên
            string hoTen = Request.Params["hoTen"];
            string diaChi = Request.Params["diaChi"];
            string soDienThoai = Request.Params["soDienThoai"];
            string email = Request.Params["email"];
            string phuongThucThanhToan = Request.Params["phuongThucThanhToan"];
            //Nếu tồn tại giỏ hàng thì mới xử lý đặt hàng
            if (Session["Cart"] != null)
            {
                //Khai báo datatable để chứa giỏ hàng
                DataTable cart = new DataTable();
                cart = (DataTable)Session["Cart"];

                #region Lặp trong giỏ hàng để lấy ra tổng tiền
                double tongTien = 0;
                for (int i = 0; i < cart.Rows.Count; i++)
                {
                    tongTien += int.Parse(cart.Rows[i]["Money"].ToString());
                }
                #endregion

                #region Kiểm tra và thêm thông tin vào bảng Khách hàng

                string maKH = XuLyThongTinKhachHang(hoTen, diaChi, soDienThoai, email);

                #endregion

                //Lấy ngày giờ hiện tại trả về dạng số để làm mã thanh toán trực tuyến              

                #region Thêm thông tin vào bảng Đơn đặt hàng
                //Tạo đơn đặt hàng
                string ngayTao = DateTime.Now.ToString("yyyy-MM-ddThh:mm");
                db_DonDatHang infoDDH = new db_DonDatHang();
                infoDDH.NgayTao = DateTime.Parse(ngayTao);
                infoDDH.ThanhTienDH = tongTien;
                infoDDH.TinhTrangDonHang = "2";
                infoDDH.MaKH = Convert.ToInt32(maKH);
                infoDDH.TenKH = hoTen;
                infoDDH.sdtKH = soDienThoai;
                infoDDH.EmailKH = email;
                infoDDH.DiaChiKH = diaChi;
                db.db_DonDatHangs.InsertOnSubmit(infoDDH);
                db.SubmitChanges();

                //Lấy ra thông tin Đơn đặt hàng vừa tạo

                var infoDDHDes = (from p in db.db_DonDatHangs
                                  where p.MaKH == Convert.ToInt32(maKH)
                                  orderby p.MaDonDatHang descending
                                  select p).First();
                string maDonDatHang = infoDDHDes.MaDonDatHang.ToString();
                #endregion

                #region Đọc giỏ hàng và thêm từng sản phẩm vào bảng Chi tiết đơn đặt hàng
                List<db_ChiTietDonDatHang> chitietdondathang = new List<db_ChiTietDonDatHang>();

                for (int i = 0; i < cart.Rows.Count; i++)
                {
                    db_ChiTietDonDatHang infoCTDDH = new db_ChiTietDonDatHang();
                    infoCTDDH.MaSP = Convert.ToInt32(cart.Rows[i]["ID"]);
                    infoCTDDH.MaDonDatHang = Convert.ToInt32(maDonDatHang);
                    infoCTDDH.SoLuongDat = Convert.ToInt32(cart.Rows[i]["Quantity"]);
                    infoCTDDH.DonGiaDat = Convert.ToInt32(cart.Rows[i]["Price"]);
                    chitietdondathang.Add(infoCTDDH);
                }
                db.db_ChiTietDonDatHangs.InsertAllOnSubmit(chitietdondathang);
                db.SubmitChanges();

                #endregion
                #region Xóa session giỏ hàng
                Session["Cart"] = null;
                #endregion
            }
            else
                ketQua = "Giỏ hàng đã hết hạn, vui lòng thực hiện chọn lại sản phẩm và đặt hàng lại";

            Response.Write(ketQua);
        }
    }
}