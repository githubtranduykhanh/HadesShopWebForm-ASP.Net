using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.index.control
{
    public partial class chitietsanpham : System.Web.UI.UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public static db_SanPham infoSP = new db_SanPham();
        public long inputID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["MaSP"] != "" && long.TryParse(Request.QueryString["MaSP"], out inputID))
            {
                inputID = Convert.ToInt64(Request.QueryString["MaSP"]);
                LoadSP(inputID);
            }
            else
            {
                Response.Redirect("\\cms\\index\\page\\Error.aspx");
            }
        }
        public void LoadSP(long MaSP)
        {
            try
            {
                var dt = from q in db.db_SanPhams
                         where q.MaSP == MaSP
                         select q;
                if (dt != null && dt.Count() > 0)
                {
                    infoSP = dt.First();
                    ltrKichThuoc.Text = LayTenKichThuoc(infoSP.SizeID.ToString());
                    ltrMau.Text = LayTenMau(infoSP.MauID.ToString());
                    ltrChatLieu.Text = LayTenChatLieu(infoSP.ChatLieuID.ToString());
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
            }
        }
        private string LayTenKichThuoc(string SizeID)
        {
            int SizeIDs = Convert.ToInt32(SizeID);
            var dt = (from q in db.db_Sizes
                     where q.SizeID == SizeIDs
                     select q).First();
            if (dt != null)
                return dt.TenSize.ToString();
            else
                return "";
        }

        private string LayTenMau(string MauID)
        {
            int MauIDs = Convert.ToInt32(MauID);
            var dt = (from q in db.db_Maus
                      where q.MauID == MauIDs
                      select q).First();
            if (dt != null)
                return dt.TenMau.ToString();
            else
                return "";
        }

        private string LayTenChatLieu(string ChatLieuID)
        {
            int ChatLieuIDs = Convert.ToInt32(ChatLieuID);
            var dt = (from q in db.db_ChatLieus
                      where q.ChatLieuID == ChatLieuIDs
                      select q).First();
            if (dt != null)
                return dt.TenChatLieu.ToString();
            else
                return "";
        }
    }
}