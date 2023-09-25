using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLyMau
{
    public partial class MauLoadControl : System.Web.UI.UserControl
    {
        private string thaotac = "null";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["thaotac"] != null)
                thaotac = Request.QueryString["thaotac"];
            switch (thaotac)
            {
                case "ThemMoi":
                case "ChinhSua":
                    AdminPlaceHolder.Controls.Add(LoadControl("MauAdd.ascx"));
                    break;

                case "HienThi":
                    AdminPlaceHolder.Controls.Add(LoadControl("MauShow.ascx"));
                    break;

                default:
                    AdminPlaceHolder.Controls.Add(LoadControl("MauShow.ascx"));
                    break;

            }
        }
    }
}