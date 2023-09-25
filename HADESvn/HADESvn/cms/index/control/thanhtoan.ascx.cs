using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.index.control
{
    public partial class thanhtoan : System.Web.UI.UserControl
    {
        #region Khai báo các biến lấy ra thông tin của khách hàng nếu họ đã đăng nhập

        protected string hoTen = "";
        protected string diaChi = "";
        protected string email = "";
        protected string soDienThoai = "";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LayRaThongTinKhachHangDaDangNhap();

        }

        private void LayRaThongTinKhachHangDaDangNhap()
        {
            //Nếu khách hàng đã đăng nhập
            if ((Boolean)Session["user"] == true)
            {
                //Lấy thông tin đã lưu khi khách hàng đăng nhập
                hoTen = Session["TENND"].ToString();
                diaChi = Session["DIACHI"].ToString();
                soDienThoai = Session["SDT"].ToString();
                email = Session["EMAIL"].ToString();
            }
        }
    }
}