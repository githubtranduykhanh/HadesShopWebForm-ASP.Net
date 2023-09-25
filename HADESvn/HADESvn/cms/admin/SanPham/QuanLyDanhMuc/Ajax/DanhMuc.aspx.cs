using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLyDanhMuc.Ajax
{
    public partial class DanhMuc : System.Web.UI.Page
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
                    case "XoaDanhMuc":
                        XoaDanhMuc();
                        break;
                }
            }
            else
            {
                Response.Redirect("/cms/index/page/Index.aspx");
            }
            
        }
        private void XoaDanhMuc()
        {
            string MaDM = "";
            if (Request.Params["MaDM"] != null)
            {
                MaDM = Request.Params["MaDM"];

                //Thực hiện code xóa
                //B1: Xóa ảnh đại diện đã lưu trên server - tạm b
                //B2: Xóa dữ liệu trên sqlserver
                int MaDMs = Convert.ToInt32(MaDM);
                var danhMuc = db.db_DanhMucs.Single(a => a.MaDM == MaDMs);
                db.db_DanhMucs.DeleteOnSubmit(danhMuc);
                db.SubmitChanges();
                
                // Trả về thông báo 1 thực hiện thành công 2 thực hiện không thành côngs
                Response.Write("1");
            }
        }
        
    }
}