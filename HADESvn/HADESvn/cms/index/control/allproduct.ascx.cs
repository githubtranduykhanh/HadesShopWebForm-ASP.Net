using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.index.control
{
    public partial class allproduct : System.Web.UI.UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();       
        public static List<db_DanhMuc> listDM = new List<db_DanhMuc>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDMSP();

            }
        }
        public void loadDMSP()
        {
            var dt = (from q in db.db_DanhMucs
                      select q);
            if (dt != null && dt.Count() > 0)
            {
                listDM = dt.ToList();
            }
        }
    }
}