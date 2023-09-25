using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.index.control
{
    public partial class sanphamtheodanhmuc : System.Web.UI.UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public static List<db_SanPham> listSP = new List<db_SanPham>();
        public static List<db_DanhMuc> listDM = new List<db_DanhMuc>();
        public static db_DanhMuc infoDMSP = new db_DanhMuc();
        public long inputID;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["MaDM"] != "" && long.TryParse(Request.QueryString["MaDM"], out inputID))
            {
                inputID = Convert.ToInt64(Request.QueryString["MaDM"]);
                LoadSanPhamTheoDanhMuc(inputID);
            }
            else
            {
                Response.Redirect("\\cms\\index\\page\\Error.aspx");
            }
            if (!IsPostBack)
            {
                loadDMSP();
            }

        }
        public void LoadSanPhamTheoDanhMuc(long MaDM)
        {
            var dt1 = (from a in db.db_DanhMucs
                       where a.MaDM == MaDM
                       select a);
            var dt = (from q in db.db_SanPhams
                      where q.MaDM == MaDM
                      select q).Take(8);
            if (dt != null && dt.Count() > 0)
            {
                listSP = dt.ToList();
                infoDMSP = dt1.First();
            }
            else
                listSP = null;
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