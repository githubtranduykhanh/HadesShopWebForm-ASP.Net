using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.TaiKhoan.Ajax
{
    public partial class TaiKhoan : System.Web.UI.Page
    {
        string thaotac = "";
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Boolean)Session["admin"] == true)
            {
                if (Request.Params["ThaoTac"] != null)
                {
                    thaotac = Request.Params["ThaoTac"];
                }

                switch (thaotac)
                {
                    case "XoaTaiKhoan":
                        XoaTaiKhoan();
                        break;

                }
            }
            else
            {
                Response.Redirect("/cms/index/page/Index.aspx");
            }
           
        }
        private void XoaTaiKhoan()
        {
            string TenDangNhap = "";
            if (Request.Params["TenDangNhap"] != null)
            {
                TenDangNhap = Request.Params["TenDangNhap"];

                ////Thực hiện code xóa
                ////B1: Xóa ảnh đại diện đã lưu trên server - tạm b
                ////B2: Xóa dữ liệu trên sqlserver
                //int MaSPs = Convert.ToInt32(MaSP);
                //var sanPham = db.db_SanPhams.Single(a => a.MaSP == MaSPs);
                //db.db_SanPhams.DeleteOnSubmit(sanPham);
                //db.SubmitChanges();

                //// Trả về thông báo 1 thực hiện thành công 2 thực hiện không thành công
                //Response.Write("1");
                //Thực hiện code xóa
                //B2: Xóa dữ liệu trên sqlserver
                if (TenDangNhap.ToLower() != "admin")//Không cho xóa tài khoản Admin
                {
                    var taiKhoan = db.db_DangKies.Single(a => a.TenDangNhap == TenDangNhap);
                    db.db_DangKies.DeleteOnSubmit(taiKhoan);
                    db.SubmitChanges();
                    // Trả về thông báo 1 thực hiện thành công 2 thực hiện không thành công
                    Response.Write("1");
                }
                else
                {
                    Response.Write("Không được xóa tài khoản Admin");
                }
            }
        }
    }
}