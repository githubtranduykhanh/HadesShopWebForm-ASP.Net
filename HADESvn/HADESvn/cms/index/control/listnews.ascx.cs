using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.index.control
{
    public partial class listnews : System.Web.UI.UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public static List<db_TinTuc> ListTinTuc = new List<db_TinTuc>();
        public static List<db_DanhMucTin> listDanhMucTin = new List<db_DanhMucTin>();
        public static db_DanhMucTin infoDanhMucTin = new db_DanhMucTin();
        public long id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["MaDM"] != "" && long.TryParse(Request.QueryString["MaDM"], out id))
            {
                id = Convert.ToInt64(Request.QueryString["MaDM"]);
                loadListTinTuc(id);
                loadlistDanhMucTin(id);
            }
            else
            {
                Response.Redirect("\\cms\\index\\page\\Error.aspx");
            }          
        }
        public void loadListTinTuc(long id)
        {

            var dt = (from q in db.db_TinTucs
                      where q.MaDM == id 
                      select q);
            if (dt != null && dt.Count() > 0)
            {
                ListTinTuc = dt.ToList();
            }
        }
        public void loadlistDanhMucTin(long id)
        {
            var dt = (from q in db.db_DanhMucTins
                      where q.MaDM == id
                      select q);
            if (dt != null && dt.Count() > 0)
            {
                infoDanhMucTin = dt.First();
            }
        }
    }
}