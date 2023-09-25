using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.index.control
{
    public partial class timkiemsanpham : System.Web.UI.UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public static List<db_SanPham> listSP = new List<db_SanPham>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string TenSP;
            if (Request.QueryString["TenSanPham"] != "")
            {
                TenSP = Request.QueryString["TenSanPham"];
                LoadSanPhamTen(TenSP);
            }
            else
            {
                Response.Redirect("\\cms\\index\\page\\Error.aspx");
            }
        }
        public void LoadSanPhamTen(string TenSanPham)
        {

            var dt = (from q in db.db_SanPhams
                      where q.TenSP.Trim().Contains(TenSanPham)
                      select q);
            if (dt != null && dt.Count() > 0)
            {
                listSP = dt.ToList();
            }
            else
                listSP = null;
        }
    }
}