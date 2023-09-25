using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.TinTuc.DanhMucTin
{
    public partial class DanhMucTinLoadControl : System.Web.UI.UserControl
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
                    AdminPlaceHolder.Controls.Add(LoadControl("DanhMucTinAdd.ascx"));
                    break;

                case "HienThi":
                    AdminPlaceHolder.Controls.Add(LoadControl("DanhMucTinShow.ascx"));
                    break;

                default:
                    AdminPlaceHolder.Controls.Add(LoadControl("DanhMucTinShow.ascx"));
                    break;
            }
        }
    }
}