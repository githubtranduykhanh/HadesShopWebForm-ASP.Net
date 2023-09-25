using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLyDonHang
{
    public partial class DonHangLoadControl : System.Web.UI.UserControl
    {
        private string thaotac = "null";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["thaotac"] != null)
                thaotac = Request.QueryString["thaotac"];
            switch (thaotac)
            {
                case "HienThi":
                    plLoadControl.Controls.Add(LoadControl("DonHangShow.ascx"));
                    break;

                case "ChiTiet":
                    plLoadControl.Controls.Add(LoadControl("DonHangChiTiet.ascx"));
                    break;

                default:
                    plLoadControl.Controls.Add(LoadControl("DonHangShow.ascx"));
                    break;

            }
        }
    }
}