using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.TaiKhoan
{
    public partial class TaiKhoanAdd : System.Web.UI.UserControl
    {
        private string thaotac = "";
        private string id = "";//lấy id của danh mục cần chỉnh sửa
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["thaotac"] != null)
                thaotac = Request.QueryString["thaotac"];
            if (Request.QueryString["id"] != null)
                id = Request.QueryString["id"];
            if (!IsPostBack)
            {

                LayQuyenDangNhap();
                HienThiThongTin(id);

            }
        }
        private void HienThiThongTin(string id)
        {

            if (thaotac == "ChinhSua")
            {
                
                btnthemmoi.Text = "Chỉnh Sửa";
                var dt = (from a in db.db_DangKies
                          where a.TenDangNhap == id
                          select a);
                if (dt != null && dt.Count() > 0)
                {
                    List<db_DangKy> listDM = dt.ToList();
                    foreach (var item in listDM)
                    {
                        dropQuyen.SelectedValue = item.MaQuyen.ToString();
                        txtTenDK.Text = item.TenDangNhap.ToString();
                        txtEmail.Text = item.EmailDK.ToString();
                        txtDiaChi.Text = item.DiaChiDK.ToString();
                        txtHoten.Text = item.TenDayDu.ToString();
                        txtNgaySinh.Text = Convert.ToDateTime(item.NgaySinh).ToString("yyyy-MM-dd");
                        dropGioiTinh.SelectedValue = item.GioiTinhDK.ToString().Trim();

                        hdMatKhauCu.Value = item.MatKhau.ToString();
                        RequiredFieldValidator2.Visible = false;
                                         
                    }
                }

            }

            else
            {
                btnthemmoi.Text = "Thêm Mới";
            }
        }    
        private void LayQuyenDangNhap()
        {
            var data = from cd in db.db_QuyenDangNhaps
                       select cd;
            dropQuyen.Items.Clear();
            if (data != null)
            {
                List<db_QuyenDangNhap> listQDN = data.ToList();
                dropQuyen.DataSource = listQDN;
                dropQuyen.DataTextField = "TenQuyen";
                dropQuyen.DataValueField = "MaQuyen";
                dropQuyen.DataBind();
            }
        }
        protected void btnThemmoi_Click(object sender, EventArgs e)
        {
            if (thaotac == "ThemMoi")
            {
                string matKhau = HADESvn.MaHoa.MaHoaMD5(txtMK.Text);

                db_DangKy infoDK = new db_DangKy();
                infoDK.TenDangNhap = txtTenDK.Text;
                infoDK.MatKhau = matKhau;
                infoDK.EmailDK = txtEmail.Text;
                infoDK.DiaChiDK = txtDiaChi.Text;
                infoDK.TenDayDu = txtHoten.Text;
                infoDK.NgaySinh = DateTime.Parse(txtNgaySinh.Text.ToString());

                //if (FileUploadanh.HasFiles)
                //{
                //    if (FileUploadanh.FileName.EndsWith(".jpeg") || FileUploadanh.FileName.EndsWith(".jpg") || FileUploadanh.FileName.EndsWith(".png") || FileUploadanh.FileName.EndsWith(".gif"))
                //    {
                //        infoDM.AnhDaiDien = FileUploadanh.FileName;
                //        FileUploadanh.SaveAs(Server.MapPath("\\assets\\img\\DanhMuc\\") + infoDM.AnhDaiDien);
                //    }
                //}
                //infoSP.MOTA = HttpUtility.HtmlEncode(FCKNoidung.Value);
                infoDK.MaQuyen = Convert.ToInt32(dropQuyen.SelectedValue);
                infoDK.GioiTinhDK = dropGioiTinh.SelectedValue;
                db.db_DangKies.InsertOnSubmit(infoDK);
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Thêm mới thành công !!','success');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Massage", "alert('Thêm mới thành công !!!')", true);
                ClearFrom();
            }
            else
            {

                string matKhau = "";
                if (txtMK.Text != "")
                    matKhau = HADESvn.MaHoa.MaHoaMD5(txtMK.Text);
                else
                    matKhau = hdMatKhauCu.Value;//TRƯỜNG hợp ko nhập mật khẩu thì lấy lại mật khẩu cũ
                
               
                db_DangKy infoDK = new db_DangKy();
                infoDK = db.db_DangKies.Where(s => s.TenDangNhap == id).Single();
                infoDK.TenDangNhap = txtTenDK.Text;
                infoDK.MatKhau = matKhau;
                infoDK.EmailDK = txtEmail.Text;
                infoDK.DiaChiDK = txtDiaChi.Text;
                infoDK.TenDayDu = txtHoten.Text;
                infoDK.NgaySinh = DateTime.Parse(txtNgaySinh.Text.ToString());
                //if (FileUploadanh.HasFiles)
                //{
                //    if (FileUploadanh.FileName.EndsWith(".jpeg") || FileUploadanh.FileName.EndsWith(".jpg") || FileUploadanh.FileName.EndsWith(".png") || FileUploadanh.FileName.EndsWith(".gif"))
                //    {
                //        infoDM.AnhDaiDien = FileUploadanh.FileName;
                //        FileUploadanh.SaveAs(Server.MapPath("\\assets\\img\\DanhMuc\\") + infoDM.AnhDaiDien);
                //        tenAnhDaiDien = infoDM.AnhDaiDien;
                //    }
                //    if (tenAnhDaiDien == "")
                //    {
                //        tenAnhDaiDien = hdTenAnhDaiDienCu.Value;
                //    }
                //}

                //infoSP.MOTA = HttpUtility.HtmlEncode(FCKNoidung.Value);
                infoDK.MaQuyen = Convert.ToInt32(dropQuyen.SelectedValue);
                infoDK.GioiTinhDK = dropGioiTinh.SelectedValue;
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Sửa mới thành công !!!','success');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Massage", "alert('Sua mới thành công !!!')", true);
                ClearFrom();
            }
        }
        private void ClearFrom()
        {
            txtTenDK.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtNgaySinh.Text = "";
            txtHoten.Text = "";
            txtMK.Text = "";
            //FCKNoidung.Value = "";
        }
    }
}