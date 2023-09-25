using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.TinTuc.DanhSachTinTuc.Ajax
{
    public partial class DanhSachTinTuc : System.Web.UI.Page
    {
        string thaotac = "";
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Boolean)Session["admin"] == true)
            {
                if (Request.Params["ThaoTac"] != null)
                {
                    thaotac = Request.Params["ThaoTac"];
                }

                switch (thaotac)
                {
                    case "XoaTinTuc":
                        XoaTinTuc();
                        break;

                }
            }
            else
            {
                Response.Redirect("/cms/index/page/Index.aspx");
            }
            
        }
        private void XoaTinTuc()
        {
            string TinTucID = "";
            if (Request.Params["TinTucID"] != null)
            {
                TinTucID = Request.Params["TinTucID"];

                //Thực hiện code xóa
                //B1: Xóa ảnh đại diện đã lưu trên server - tạm b
                //B2: Xóa dữ liệu trên sqlserver
                int TinTucIDs = Convert.ToInt32(TinTucID);
                var tinTuc = db.db_TinTucs.Single(a => a.TinTucID == TinTucIDs);
                db.db_TinTucs.DeleteOnSubmit(tinTuc);
                db.SubmitChanges();

                // Trả về thông báo 1 thực hiện thành công 2 thực hiện không thành công
                Response.Write("1");
            }
        }
    }
}