using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public static db_DangKy infoAdmin = new db_DangKy();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Boolean)Session["admin"] == true)
            {
                loadAdmin();

            }
        }
        public void loadAdmin()
        {          
            var dt1 = (from q in db.db_DangKies
                       where q.TenDayDu == Session["TENADMIN"].ToString()
                       select q);
            if (dt1 != null && dt1.Count() > 0)
            {
                infoAdmin = dt1.First();
            }
            
        }

        protected void btnlinkDX_Click(object sender, EventArgs e)
        {
            Session["admin"] = false;
            Response.Redirect("/cms/index/page/Index.aspx");
        }
    }
}