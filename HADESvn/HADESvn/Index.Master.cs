using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
namespace HADESvn
{
    public partial class Index : System.Web.UI.MasterPage
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public static List<db_DanhMuc> DMSP = new List<db_DanhMuc>();
        public static List<db_KhachHang> listKH = new List<db_KhachHang>();
        public static List<db_DangKy> listDK = new List<db_DangKy>();
        public static db_KhachHang infoShowKH = new db_KhachHang();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDMSP();
                
            }
            loadUser();
        }
        public void loadDMSP()
        {
            var dt = (from q in db.db_DanhMucs
                      select q);
            if (dt != null && dt.Count() > 0)
            {
                DMSP = dt.ToList();
            }
        }
        //Hàm kiểm tra xem nhập email theo đúng định dạng chưa
        public static bool IsEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            return Regex.IsMatch(email, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            if (txtEmailDK.Text == "" || txtTenDK.Text == "" || txtSDTDK.Text == "" && txtMKDK.Text == "")
            {
                //ScriptManager.RegisterStartupScript(this, typeof(string), "message", "alert('Vui lòng nhập thông tin đầy đủ')", true);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Vui lòng nhập đầy đủ thông tin !!!','warning');", true);
            }
            else
            {
                if (HADESvn.Email.IsEmail(txtEmailDK.Text))
                {
                    string matKhau = "";
                    matKhau = HADESvn.MaHoa.MaHoaMD5(txtMKDK.Text);
                    db_KhachHang infoDK = new db_KhachHang();
                    infoDK.TenKh = txtTenDK.Text;
                    infoDK.EmailKH = txtEmailDK.Text;
                    infoDK.MatKhau = matKhau;
                    infoDK.sdtKH = txtSDTDK.Text;
                    infoDK.DiaChiKH = txtDiaChi.Text;
                    if (FileUploadanh.HasFiles)
                    {
                        if (FileUploadanh.FileName.EndsWith(".jpeg") || FileUploadanh.FileName.EndsWith(".jpg") || FileUploadanh.FileName.EndsWith(".png") || FileUploadanh.FileName.EndsWith(".gif"))
                        {
                            infoDK.AnhDaiDien = FileUploadanh.FileName;
                            FileUploadanh.SaveAs(Server.MapPath("\\assets\\img\\KhachHang\\") + infoDK.AnhDaiDien);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Vui lòng chọn ảnh jpg,png hoặc jpeg !!','warning');", true);
                        }
                    }
                    db.db_KhachHangs.InsertOnSubmit(infoDK);
                    db.SubmitChanges();
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "Massage", "alert('Thêm mới thành công !!')", true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Tạo tài khoản thành công !!','success');", true);
                    txtTenDK.Text = "";
                    txtEmailDK.Text = "";
                    txtMKDK.Text = "";
                    txtSDTDK.Text = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Email không hợp lệ !!!','warning');", true);
                }
            }
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtEmailDN.Text == "" || txtMKDN.Text == "")
            {
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "alert('Vui lòng nhập đầy đủ thông tin !!!')", true);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Vui lòng nhập đầy đủ thông tin !!!','warning');", true);

            }
            else
            {
                if (IsEmail(txtEmailDN.Text) == true)
                {
                    string matKhau = "";
                    matKhau = HADESvn.MaHoa.MaHoaMD5(txtMKDN.Text);
                    db_KhachHang infoDN = new db_KhachHang();
                    db_DangKy infoAdmin = new db_DangKy();
                    var user = from p in db.db_KhachHangs
                               where (p.EmailKH == txtEmailDN.Text && p.MatKhau == matKhau)
                               select p;
                    var admin = from p in db.db_DangKies
                                where (p.EmailDK == txtEmailDN.Text && p.MatKhau == matKhau)
                                select p;
                    if (user.Count() > 0)
                    {
                        infoDN = user.First();
                        Session["user"] = true;
                        Session["MAND"] = infoDN.MaKH.ToString();
                        Session["TENND"] = infoDN.TenKh;
                        Session["SDT"] = infoDN.sdtKH;
                        Session["EMAIL"] = infoDN.EmailKH;
                        Session["DIACHI"] = infoDN.DiaChiKH;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Đăng nhập thành công !!!','success');", true);
                        //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "alert('đăng nhập thành công !!!')", true);

                    }
                    else if (admin.Count() > 0)
                    {
                        infoAdmin = admin.First();
                        Session["admin"] = true;
                        Session["TENADMIN"] = infoAdmin.TenDayDu;
                        //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "alert('đăng nhập thành công !!!')", true);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Đăng nhập thành công !!!','success');", true);
                        Response.Redirect("\\cms\\admin\\AdminPage.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Đăng nhập thất bại !!!','warning');", true);
                        //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "alert('đăng nhập thất bại !!!')", true);
                        txtEmailDN.Text = "";
                        txtMKDN.Text = "";
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Email không hợp lệ !!!','warning');", true);
                }
                

            }
        }
        public void loadUser()
        {
            string matKhau = "";
            matKhau = HADESvn.MaHoa.MaHoaMD5(txtMKDN.Text);
            var dt1 = (from q in db.db_KhachHangs
                       where (q.EmailKH == txtEmailDN.Text && q.MatKhau == matKhau)
                       select q);
            if (dt1 != null && dt1.Count() > 0)
            {
                infoShowKH = dt1.First();
            }
        }

        protected void btnlinkDX_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Đăng xuất thành công !!!','success');", true);
            Session["user"] = false;
            Session["MAND"] = null;
            Session["TENND"] = null;
            Session["SDT"] = null;
            Session["EMAIL"] = null;
            Session["DIACHI"] = null;
            Response.Redirect("/cms/index/page/Index.aspx");
        }       
    }
}