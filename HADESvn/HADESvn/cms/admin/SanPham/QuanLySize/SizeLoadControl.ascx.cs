using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLySize
{
    public partial class SizeLoadControl : System.Web.UI.UserControl
    {
        private string thaotac = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["thaotac"] != null)
                thaotac = Request.QueryString["thaotac"];
            switch (thaotac)
            {
                case "ThemMoi":
                case "ChinhSua":
                    AdminPlaceHolder.Controls.Add(LoadControl("SizeAdd.ascx"));
                    break;

                case "HienThi":
                    AdminPlaceHolder.Controls.Add(LoadControl("SizeShow.ascx"));
                    break;

                default:
                    AdminPlaceHolder.Controls.Add(LoadControl("SizeShow.ascx"));
                    break;

            }
        }
    }
}