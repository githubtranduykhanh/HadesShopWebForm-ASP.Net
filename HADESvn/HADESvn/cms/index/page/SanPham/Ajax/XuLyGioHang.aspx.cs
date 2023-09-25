using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HADESvn.cms.index.control.SanPham.Ajax
{

    public partial class XuLyGioHang : System.Web.UI.Page
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
                case "ThemVaoGioHang":
                    ThemVaoGioHang();
                    break;
                case "LayThongTinGioHang":
                    LayThongTinGioHang();
                    break;
                case "LayTongSoSanPhamTrongGioHang":
                    LayTongSoSanPhamTrongGioHang();
                    break;
                case "LayTongTienTrongGioHang":
                    LayTongTienTrongGioHang();
                    break;
                case "XoaSPTrongGioHang":
                    XoaSPTrongGioHang();
                    break;
                case "CapNhatSoLuongVaoGioHang":
                    CapNhatSoLuongVaoGioHang();
                    break;
                //case "GuiDonHangThanhToan":
                //    GuiDonHangThanhToan();
                //    break;
                case "LaySanPhamTimKiem":
                    LaySanPhamTimKiem();
                    break;
                case "LayRaThongTinDonHangNguoiDung":
                    LayRaThongTinDonHangNguoiDung();
                    break;
                //case "LayThongTinGioHangThanhToan":
                //    LayThongTinGioHangThanhToan();
                //    break;

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
        private void LayThongTinGioHang()
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
                    ketQua += @"<h1 style='color:var(--text-color);margin-bottom:23px;text-align:center;'>Giỏ Hàng</h1>";
                    ketQua += @"
                            <table class='table-style'>
                                <thead class='table-style-thead'>
                                    <tr class='table-style-tr'>                                                                              
                                        <th scope='col' class='table-style-th__img'>Ảnh</th>
                                        <th scope='col' class='table-style-th__name'>Tên</th>
                                        <th scope='col' class='table-style-th__price'>Giá</th>
                                        <th scope='col' class='table-style-th__quantity'>Số Lượng</th>
                                        <th scope='col' class='table-style-th__price'>Thành Tiền</th>
                                        <th scope='col' class='table-style-th__setting'>Xem & Xoá</th>                          
                                     </ tr >         
                                 </thead>                
                                 <tbody> ";

                    //Chạy vòng lặp và xuất dữ liệu trong giỏ hàng ra dạng bảng
                    for (int i = 0; i < cart.Rows.Count; i++)
                    {

                        ketQua += @"
                    <tr id='maDong_" + cart.Rows[i]["ID"] + @"' class='table-style-tr-item'>        
                            <td class='img-padding-cart'>
                                <img class='img img-size-cart'src='/assets/img/SanPham/" + cart.Rows[i]["ANH"] + @"'/>
                            </td>
                            <td>" + cart.Rows[i]["Name"] + @"</td>                          
                            <td>" + string.Format("{0:0,000}", int.Parse(cart.Rows[i]["Price"].ToString())) + @"đ</td>
                            <td><input onchange='CapNhatSoLuongVaoGioHang(" + cart.Rows[i]["ID"] + @")' id='quantity_" + cart.Rows[i]["ID"] + @"' name='updates[]' min='1' type='number' value='" + cart.Rows[i]["Quantity"] + @"' class=''></td>
                            <td>" + string.Format("{0:0,000}", int.Parse(cart.Rows[i]["Money"].ToString())) + @"đ</td>
                            <td> 
                                <div  class='flex-center'>
                                <a href='ChiTietSanPham?MaSP=" + cart.Rows[i]["ID"] + @"'><ion-icon name='eye-outline'></ion-icon></a>
                                <a href='javascript://' onclick='XoaSPTrongGioHang(" + cart.Rows[i]["ID"] + @")'><ion-icon name='close-circle-outline'></ion-icon></a>     
                                </div>
                             </td>
                    </tr>    
                    ";
                    }

                    ketQua += @"
                        </tbody>
                    </table>";

                    //ketQua += @"
                    //    <div class='flex-end'>
                    //        <h3>Tổng số sản phẩm:</h3>
                    //        <h3 id='TongSoSPTrongGioHang'>0</h3>
                    //        <h3>Tổng tiền:</h3>
                    //        <h3 id='TongTienTrongGioHang'>0</h3>
                    //        <h3>VND</h3>
                    //    </div>
                    //";
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
        //private void LayThongTinGioHangThanhToan()
        //{
        //    string ketQua = "";

        //    //Nếu tồn tại giỏ hàng thì mới lấy ra kết quả
        //    if (Session["Cart"] != null)
        //    {
        //        //Khai báo datatable để chứa giỏ hàng
        //        DataTable cart = new DataTable();
        //        cart = (DataTable)Session["Cart"];
        //        if (cart.Rows.Count > 0)
        //        {
        //            ketQua += @"
        //                    <table class='table-style'>                                                
        //                         <tbody> ";

        //            //Chạy vòng lặp và xuất dữ liệu trong giỏ hàng ra dạng bảng
        //            for (int i = 0; i < cart.Rows.Count; i++)
        //            {

        //                ketQua += @"
        //            <tr id='maDongThanhToan_" + cart.Rows[i]["ID"] + @"' class='table-style-tr-item'>    
        //                    <td>
        //                        <img class='img'src='/assets/img/SanPham/" + cart.Rows[i]["ANH"] + @"'/>
        //                    </td> 
        //                    <td>" + cart.Rows[i]["Name"] + @"</td>                            
                            
        //                    <td>"+ cart.Rows[i]["Quantity"] + @"</td>                           
        //                    <td>" + cart.Rows[i]["Price"] + @"đ</td>                           
        //            </tr>    
        //            ";
        //            }

        //            ketQua += @"
        //                </tbody>
        //            </table>";

        //            ketQua += @"
        //                <div class='space-between'>
        //                    <h3>Tổng số sản phẩm:</h3>
        //                    <h3 class='TongSoSPTrongGioHangThanhToan'>0</h3>               
        //                </div>
        //                <div class='space-between'>
        //                    <h3>Tổng tiền:</h3>                          
        //                    <h3 class='TongTienTrongGioHangThanhToan'>0</h3>                                                                    
        //                </div>
                            
        //            ";
        //        }
        //        else
        //        {
        //            ketQua += @"
        //                <img src='/assets/img/empty-cart.jpg' alt='' class='img-heading'/>
        //            ";
        //        }



        //    }
        //    else
        //    {
        //        ketQua += @"
        //                <img src='/assets/img/empty-cart.jpg' alt='' class='img-heading'/>
        //            ";
        //        //if ((Boolean)Session["user"] == false)
        //        //{
        //        //    ketQua += @"
        //        //        <img src='/assets/img/empty-cart.jpg' alt='' class='img-heading'/>
        //        //    ";
        //        //}
        //        //else
        //        //{
        //        //    ketQua += "";
        //        //}

        //    }

        //    Response.Write(ketQua);
        //}
        private void ThemVaoGioHang()
        {
            string ketQua = "";

            string inputID = Request.Params["id"];
            int inputIDs = Convert.ToInt32(inputID);
            string soLuong = Request.Params["soLuong"];

            //Lấy thông tin chi tiết sản phẩm được add vào giỏ hàng

            var dt = from q in db.db_SanPhams
                     where q.MaSP == inputIDs
                     select q;  // tim sp theo id input
            if (dt.Count() > 0)//Nếu tồn tại sản phẩm mới thực hiện thao tác
            {
                infoSP = dt.First();
                //Khai báo datatable để lưu thông tin sản phẩm vào giỏ hàng lần đầu tiên
                DataTable cart = new DataTable();
                //Nếu chưa có giỏ hàng --> tạo giỏ hàng
                if (Session["Cart"] == null)
                {
                    //Nếu chưa có giỏ hàng, tạo giỏ hàng thông qua DataTable với 4 cột chính
                    //ID (Mã sản phẩm), Name (Tên sản phẩm)
                    //Price (Giá tiền), Quantity (Số lượng)
                    cart.Columns.Add("ID");
                    cart.Columns.Add("ANH");
                    cart.Columns.Add("Name");
                    cart.Columns.Add("Price");
                    cart.Columns.Add("Quantity");
                    cart.Columns.Add("Money");
                    //Sau khi tạo xong thì lưu lại vào session
                    DataRow dr = cart.NewRow();
                    dr["ID"] = inputID;
                    dr["ANH"] = infoSP.AnhSP;
                    dr["Name"] = infoSP.TenSP;
                    dr["Price"] = infoSP.GiaSP;
                    dr["Quantity"] = soLuong;
                    dr["Money"] = int.Parse(dr["Price"].ToString()) * int.Parse(dr["Quantity"].ToString());
                    cart.Rows.Add(dr);
                    Session["Cart"] = cart;
                }
                //Nếu đã có giỏ hàng --> thêm mới sản phẩm vào giỏ hàng
                else
                {
                    //Khai báo datatable để chứa giỏ hàng
                    cart = Session["Cart"] as DataTable;
                    bool isExisted = false;

                    foreach (DataRow dr in cart.Rows)
                    {
                        if (dr["ID"].ToString() == inputID.ToString())
                        {
                            dr["Quantity"] = int.Parse(dr["Quantity"].ToString()) + int.Parse(soLuong);
                            dr["Money"] = int.Parse(dr["Price"].ToString()) * int.Parse(dr["Quantity"].ToString());
                            isExisted = true;
                            break;
                        }
                    }
                    if (!isExisted)//Chưa có sản phẩm trong giỏ hàng
                    {

                        DataRow dr = cart.NewRow();
                        dr["ID"] = inputID;
                        dr["ANH"] = infoSP.AnhSP;
                        dr["Name"] = infoSP.TenSP;
                        dr["Price"] = infoSP.GiaSP;
                        dr["Quantity"] = soLuong;
                        dr["Money"] = int.Parse(dr["Price"].ToString()) * int.Parse(dr["Quantity"].ToString());
                        cart.Rows.Add(dr);
                    }
                    //Lưu lại thông tin giỏ hàng mới nhất vào session["Cart"]
                    Session["Cart"] = cart;
                }
            }
            else
            {
                ketQua = "Không tồn tại sản phẩm này";
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

            Response.Write(string.Format("{0:0,000}",tongTien));
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
        private void XoaSPTrongGioHang()
        {
            //Lấy id sản phẩm cần loại khỏi giỏ hàng
            string idSanPham = Request.Params["idSanPham"];

            //Nếu tồn tại giỏ hàng thì mới lấy ra kết quả
            if (Session["Cart"] != null)
            {
                //Khai báo datatable để chứa giỏ hàng
                DataTable cart = new DataTable();
                cart = (DataTable)Session["Cart"];

                //Lặp qua danh sách sản phẩm trong giỏ hàng --> Loại sản phẩm theo id truyền lên
                for (int i = 0; i < cart.Rows.Count; i++)
                {
                    if (cart.Rows[i]["ID"].ToString() == idSanPham)
                        cart.Rows[i].Delete();
                }

                //Gán lại vào session
                Session["Cart"] = cart;
            }

            Response.Write("");
        }
        private void CapNhatSoLuongVaoGioHang()
        {
            //Lấy id sản phẩm cần loại khỏi giỏ hàng
            string idSanPham = Request.Params["idSanPham"];
            string soLuongMoi = Request.Params["soLuongMoi"];

            //Nếu tồn tại giỏ hàng thì mới lấy ra kết quả
            if (Session["Cart"] != null)
            {
                //Khai báo datatable để chứa giỏ hàng
                DataTable cart = new DataTable();
                cart = (DataTable)Session["Cart"];

                //Lặp qua danh sách sản phẩm trong giỏ hàng --> Cập nhật số lượng cho sản phẩm theo id được yêu cầu
                for (int i = 0; i < cart.Rows.Count; i++)
                {
                    if (cart.Rows[i]["ID"].ToString() == idSanPham)
                        cart.Rows[i]["Quantity"] = soLuongMoi;
                    cart.Rows[i]["Money"] = int.Parse(cart.Rows[i]["Price"].ToString()) * int.Parse(cart.Rows[i]["Quantity"].ToString());
                }

                //Gán lại vào session
                Session["Cart"] = cart;
            }

            Response.Write("");
        }
        //private void GuiDonHangThanhToan()
        //{
        //    string ketQua = "";

        //    //Lấy các thông tin người dùng gửi lên
        //    string hoTen = Request.Params["hoTen"];
        //    string diaChi = Request.Params["diaChi"];
        //    string soDienThoai = Request.Params["soDienThoai"];
        //    string email = Request.Params["email"];
        //    string phuongThucThanhToan = Request.Params["phuongThucThanhToan"];
        //    //Nếu tồn tại giỏ hàng thì mới xử lý đặt hàng
        //    if (Session["Cart"] != null)
        //    {
        //        //Khai báo datatable để chứa giỏ hàng
        //        DataTable cart = new DataTable();
        //        cart = (DataTable)Session["Cart"];

        //        #region Lặp trong giỏ hàng để lấy ra tổng tiền
        //        double tongTien = 0;
        //        for (int i = 0; i < cart.Rows.Count; i++)
        //        {
        //            tongTien += int.Parse(cart.Rows[i]["Money"].ToString());
        //        }
        //        #endregion

        //        #region Kiểm tra và thêm thông tin vào bảng Khách hàng

        //        string maKH = XuLyThongTinKhachHang(hoTen, diaChi, soDienThoai, email);

        //        #endregion

        //        //Lấy ngày giờ hiện tại trả về dạng số để làm mã thanh toán trực tuyến              

        //        #region Thêm thông tin vào bảng Đơn đặt hàng
        //        //Tạo đơn đặt hàng
        //        string ngayTao = DateTime.Now.ToString();
        //        db_DonDatHang infoDDH = new db_DonDatHang();
        //        infoDDH.NgayTao = DateTime.Parse(ngayTao);
        //        infoDDH.ThanhTienDH = tongTien;
        //        infoDDH.TinhTrangDonHang = "0";
        //        infoDDH.MaKH = Convert.ToInt32(maKH);
        //        infoDDH.TenKH = hoTen;
        //        infoDDH.sdtKH = soDienThoai;
        //        infoDDH.EmailKH = email;
        //        infoDDH.DiaChiKH = diaChi;
        //        db.db_DonDatHangs.InsertOnSubmit(infoDDH);
        //        db.SubmitChanges();

        //        //Lấy ra thông tin Đơn đặt hàng vừa tạo

        //        var infoDDHDes = (from p in db.db_DonDatHangs
        //                          where p.MaKH == Convert.ToInt32(maKH)
        //                          orderby p.MaDonDatHang  descending
        //                          select p).First();
        //        string maDonDatHang = infoDDHDes.MaDonDatHang.ToString();
        //        #endregion

        //        #region Đọc giỏ hàng và thêm từng sản phẩm vào bảng Chi tiết đơn đặt hàng
        //        List<db_ChiTietDonDatHang> chitietdondathang = new List<db_ChiTietDonDatHang>();
                
        //        for (int i = 0; i < cart.Rows.Count; i++)
        //        {
        //            db_ChiTietDonDatHang infoCTDDH = new db_ChiTietDonDatHang();
        //            infoCTDDH.MaSP = Convert.ToInt32(cart.Rows[i]["ID"]);
        //            infoCTDDH.MaDonDatHang = Convert.ToInt32(maDonDatHang);
        //            infoCTDDH.SoLuongDat = Convert.ToInt32(cart.Rows[i]["Quantity"]);
        //            infoCTDDH.DonGiaDat = Convert.ToInt32(cart.Rows[i]["Price"]);
        //            chitietdondathang.Add(infoCTDDH);                              
        //        }
        //        db.db_ChiTietDonDatHangs.InsertAllOnSubmit(chitietdondathang);
        //        db.SubmitChanges();

        //        #endregion
        //        #region Xóa session giỏ hàng
        //        Session["Cart"] = null;
        //        #endregion
        //    }
        //    else
        //        ketQua = "Giỏ hàng đã hết hạn, vui lòng thực hiện chọn lại sản phẩm và đặt hàng lại";

        //    Response.Write(ketQua);
        //}
        private void LaySanPhamTimKiem()
        {
            string ketQua = "";
            string searchValue = Request.Params["searchValue"];
            var dt = (from p in db.db_SanPhams
                              where p.TenSP.Trim().Contains(searchValue)                 
                              select p);
            if(dt.Count()>0 && dt != null)
            {
                foreach (var item in dt.ToList())
                {
                    ketQua += @"
                     <div class='box wow fadeInDown box-list - product' data-wow-duration='2s' data-wow-delay='2s'>
                        <div class='image image-list-product'>
                            <img src = '../../../assets/img/SanPham/" + item.AnhSP + @"' alt='' />
                         </div>
                        <div class='box-content'>
                            <h3>" + item.TenSP + @"</h3>
                            <h4>" + string.Format("{0:0,000}", item.GiaSP) + @"đ</h4>
                            <p>
                               " + item.MotaSP + @"
                            </p>
                            <a href = 'ChiTietSanPham.aspx?MaSP=" + item.MaSP+ @"' > Read More
                                <ion-icon name='chevron-forward-outline'></ion-icon>
                            </a>
                        </div>
                    </div>                       
                    ";
                }
            }
            else
            {
                ketQua += @"<h1 class='emty-sp'>Không Tìm Thấy Sản Phẩm Này :(( </h1>";
            }

            Response.Write(ketQua);
        }
        private void LayRaThongTinDonHangNguoiDung()
        {
            string ketQua = "";
            string maKhacHang = "";
            //Nếu khách hàng đã đăng nhập
            if ((Boolean)Session["user"] == true)
            {
                //Lấy thông tin đã lưu khi khách hàng đăng nhập
                int MaKH;
                maKhacHang = Session["MAND"].ToString();
                MaKH = Convert.ToInt32(maKhacHang);
                var data = from cd in db.db_DonDatHangs
                           where cd.MaKH == MaKH
                           orderby cd.NgayTao descending
                           select cd;
                ketQua += @"<h1 style='color: var(--text-color); text-align:center;margin-bottom: 30px;'>Đơn Hàng Của Tôi</h1>";
                ketQua += @"
                            <table class='table-style table-style-cart table-customer'>
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
                            <td>" + ((DateTime)item.NgayTao).ToString("dd/MM/yyyy hh:mm:ss tt") + @"</td>                          
                            <td>" + string.Format("{0:0,000}", item.ThanhTienDH) + @"đ</td>
                            <td>" + HienThiTinhTrangDonHang(item.TinhTrangDonHang.ToString()) + @"</td>
                            <td>                              
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
                ketQua += @"
                             <img src='/assets/img/empty-cart.jpg' alt='' class='img-heading'/>
                            ";
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
    }
}
