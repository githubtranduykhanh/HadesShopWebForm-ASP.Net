using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.index.control
{
    public partial class danhmucnews : System.Web.UI.UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();      
        public static List<db_DanhMucTin> DMTIN = new List<db_DanhMucTin>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                loadDMTIN();
            }
        }
        public void loadDMTIN()
        {
            var dt = (from q in db.db_DanhMucTins
                      select q).Take(6);
            if (dt != null && dt.Count() > 0)
            {
                DMTIN = dt.ToList();
            }
        }
    }
}