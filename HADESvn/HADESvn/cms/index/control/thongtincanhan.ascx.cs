using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.index.control
{
    public partial class thongtincanhan : System.Web.UI.UserControl
    {
        private string modul = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["modul"] != null)
                modul = Request.QueryString["modul"];
            switch (modul)
            {
                case "HoSo":
                    UserPlaceHolder.Controls.Add(LoadControl("user/hoso.ascx"));
                    break;
                case "MatKhau":
                    UserPlaceHolder.Controls.Add(LoadControl("user/matkhau.ascx"));
                    break;
                case "DonHang":
                    UserPlaceHolder.Controls.Add(LoadControl("user/donhang.ascx"));
                    break;
                default:
                    UserPlaceHolder.Controls.Add(LoadControl("user/matkhau.ascx"));
                    break;
            }
        }
    }
}