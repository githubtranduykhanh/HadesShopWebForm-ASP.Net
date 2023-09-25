using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.index.control
{
    public partial class itemnew : System.Web.UI.UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public static db_TinTuc infoTinTuc = new db_TinTuc();
        public long id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["TinTucID"] != "" && long.TryParse(Request.QueryString["TinTucID"], out id))               
            {
                
                id = Convert.ToInt64(Request.QueryString["TinTucID"]);
                loadinfoTinTuc(id);
            }
            else
            {
                Response.Redirect("\\cms\\index\\page\\Error.aspx");
            }

        }
        public void loadinfoTinTuc(long id)
        {
            var dt = (from q in db.db_TinTucs
                      where q.TinTucID == id
                      select q);
            if (dt != null && dt.Count() > 0)
            {
                infoTinTuc = dt.First();
            }
        }
    }
}