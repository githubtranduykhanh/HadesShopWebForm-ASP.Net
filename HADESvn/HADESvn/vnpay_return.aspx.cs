using System;
using System.Configuration;
using log4net;
using System.Linq;
using System.Data;
using System.Collections.Generic;

namespace HADESvn
{
    public partial class vnpay_return : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public static List<db_DonDatHang> listDDH = new List<db_DonDatHang>();
        public static db_SanPham infoSP = new db_SanPham();
        public static db_KhachHang infoShowKH = new db_KhachHang();
        private string thaotac = "";
        private static readonly ILog log =
           LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            thaotac = Request.Params["ThaoTac"];
            switch (thaotac)
            {

                case "GuiDonHangThanhToanTrucTuyen":
                    GuiDonHangThanhToanTrucTuyen();
                    break;

            }
            log.InfoFormat("Begin VNPAY Return, URL={0}", Request.RawUrl);
            if (Request.QueryString.Count > 0)
            {
                string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"]; //Chuoi bi mat
                var vnpayData = Request.QueryString;
                VnPayLibrary vnpay = new VnPayLibrary();

                foreach (string s in vnpayData)
                {
                    //get all querystring data
                    if (!string.IsNullOrEmpty(s) && s.StartsWith("vnp_"))
                    {
                        vnpay.AddResponseData(s, vnpayData[s]);
                    }
                }
                //vnp_TxnRef: Ma don hang merchant gui VNPAY tai command=pay    
                //vnp_TransactionNo: Ma GD tai he thong VNPAY
                //vnp_ResponseCode:Response code from VNPAY: 00: Thanh cong, Khac 00: Xem tai lieu
                //vnp_SecureHash: HmacSHA512 cua du lieu tra ve

                long orderId = Convert.ToInt64(vnpay.GetResponseData("vnp_TxnRef"));
                long vnpayTranId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
                string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
                string vnp_TransactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
                String vnp_SecureHash = Request.QueryString["vnp_SecureHash"];
                String TerminalID = Request.QueryString["vnp_TmnCode"];
                long vnp_Amount = Convert.ToInt64(vnpay.GetResponseData("vnp_Amount")) / 100;
                String bankCode = Request.QueryString["vnp_BankCode"];
                //string vnp_Bill_Mobile = vnpay.GetResponseData("vnp_Bill_Mobile");
                //string vnp_Bill_Email = vnpay.GetResponseData("vnp_Bill_Email");
                //string vnp_Bill_Address = vnpay.GetResponseData("vnp_Bill_Address");
                //string vnp_Bill_FirstName = vnpay.GetResponseData("vnp_Bill_FirstName");
                //string vnp_Bill_LastName = vnpay.GetResponseData("vnp_Bill_LastName");
                //string fullname = vnp_Bill_FirstName + vnp_Bill_LastName;
                String vnp_OrderInfo = Request.QueryString["vnp_OrderInfo"];
                


                bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, vnp_HashSecret);
                if (checkSignature)
                {
                    if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                    {
                        //Thanh toan thanh cong
                        displayMsg.InnerText = "Giao dịch được thực hiện thành công. Cảm ơn quý khách đã sử dụng dịch vụ";
                        log.InfoFormat("Thanh toan thanh cong, OrderId={0}, VNPAY TranId={1}", orderId, vnpayTranId);
                    }
                    else
                    {
                        //Thanh toan khong thanh cong. Ma loi: vnp_ResponseCode
                        displayMsg.InnerText = "Có lỗi xảy ra trong quá trình xử lý.Mã lỗi: " + vnp_ResponseCode;
                        log.InfoFormat("Thanh toan loi, OrderId={0}, VNPAY TranId={1},ResponseCode={2}", orderId, vnpayTranId, vnp_ResponseCode);
                    }
                    displayTmnCode.InnerText = "Mã Website (Terminal ID):" + TerminalID;
                    displayTxnRef.InnerText = "Mã giao dịch thanh toán:" + orderId.ToString();
                    displayVnpayTranNo.InnerText = "Mã giao dịch tại VNPAY:" + vnpayTranId.ToString();
                    displayAmount.InnerText = "Số tiền thanh toán (VND):" + vnp_Amount.ToString();
                    displayBankCode.InnerText = "Ngân hàng thanh toán:" + bankCode;
                    //displayFullName.InnerText = "Tên khách hàng thanh toán:" + fullname;
                    //displayEmail.InnerText = "Email thanh toán:" + vnp_Bill_Email;
                    //displayMobile.InnerText = "SĐT thanh toán:" + vnp_Bill_Mobile;
                    //displayAddress.InnerText = "Địa chỉ thanh toán:" + vnp_Bill_Address;
                    displayInfo.InnerText = "Nội dung:" + vnp_OrderInfo;
                }
                else
                {
                    log.InfoFormat("Invalid signature, InputData={0}", Request.RawUrl);
                    displayMsg.InnerText = "Có lỗi xảy ra trong quá trình xử lý";
                }
            }

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
        private void GuiDonHangThanhToanTrucTuyen()
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
                infoDDH.TinhTrangDonHang = "1";
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/cms/index/page/Index.aspx");
        }
    }
}