using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLySize.Ajax
{
    public partial class Size : System.Web.UI.Page
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
                    case "XoaSize":
                        XoaSize();
                        break;

                }
            }
            else
            {
                Response.Redirect("/cms/index/page/Index.aspx");
            }
            
        }
        private void XoaSize()
        {
            string SizeIDs = "";
            if (Request.Params["SizeID"] != null)
            {
                SizeIDs = Request.Params["SizeID"];

                //Thực hiện code xóa
                //B1: Xóa ảnh đại diện đã lưu trên server - tạm b
                //B2: Xóa dữ liệu trên sqlserver
                int SizeID = Convert.ToInt32(SizeIDs);
                var size = db.db_Sizes.Single(a => a.SizeID == SizeID);
                db.db_Sizes.DeleteOnSubmit(size);
                db.SubmitChanges();

                // Trả về thông báo 1 thực hiện thành công 2 thực hiện không thành công
                Response.Write("1");
            }
        }
    }
}