using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin
{
    public partial class AdminControl : System.Web.UI.UserControl
    {
        private string modul = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["modul"] != null)
                modul = Request.QueryString["modul"];
            switch (modul)
            {
                case "SanPham":
                    AdminPlaceHolder.Controls.Add(LoadControl("SanPham/SanPhamLoadControl.ascx"));
                    break;

                case "TaiKhoan":
                    AdminPlaceHolder.Controls.Add(LoadControl("TaiKhoan/TaiKhoanLoadControl.ascx"));
                    break;

                case "QuangCao":
                    AdminPlaceHolder.Controls.Add(LoadControl("QuangCao/QuangCaoLoadControl.ascx"));
                    break;

                case "TinTuc":
                    AdminPlaceHolder.Controls.Add(LoadControl("TinTuc/TinTucLoadControl.ascx"));
                    break;

                case "KhachHang":
                    AdminPlaceHolder.Controls.Add(LoadControl("KhachHang/KhachHangLoadControl.ascx"));
                    break;

                case "Menu":
                    AdminPlaceHolder.Controls.Add(LoadControl("Menu/MenuLoadControl.ascx"));
                    break;
                case "ThongKe":
                    AdminPlaceHolder.Controls.Add(LoadControl("ThongKe/ThongKeLoadControl.ascx"));
                    break;

                default:
                    AdminPlaceHolder.Controls.Add(LoadControl("ThongKe/ThongKeLoadControl.ascx"));
                    break;
            }
        }
    }
}