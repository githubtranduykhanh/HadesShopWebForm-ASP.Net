using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.TinTuc.DanhSachTinTuc
{
    public partial class DanhSachTinTucLoadControl : System.Web.UI.UserControl
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
                    AdminPlaceHolder.Controls.Add(LoadControl("DanhSachTinTucAdd.ascx"));
                    break;

                case "HienThi":
                    AdminPlaceHolder.Controls.Add(LoadControl("DanhSachTinTucShow.ascx"));
                    break;

                default:
                    AdminPlaceHolder.Controls.Add(LoadControl("DanhSachTinTucShow.ascx"));
                    break;
            }
        }
    }
}