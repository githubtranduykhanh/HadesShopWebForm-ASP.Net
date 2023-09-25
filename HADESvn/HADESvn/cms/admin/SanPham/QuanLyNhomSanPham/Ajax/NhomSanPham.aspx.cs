using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLyNhomSanPham.Ajax
{
    public partial class NhomSanPham : System.Web.UI.Page
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
                    case "XoaNhomSanPham":
                        XoaNhomSanPham();
                        break;

                }
            }
            else
            {
                Response.Redirect("/cms/index/page/Index.aspx");
            }
            
        }
        private void XoaNhomSanPham()
        {
            string NhomID = "";
            if (Request.Params["NhomID"] != null)
            {
                NhomID = Request.Params["NhomID"];

                //Thực hiện code xóa
                //B1: Xóa ảnh đại diện đã lưu trên server - tạm b
                //B2: Xóa dữ liệu trên sqlserver
                int NhomIDs = Convert.ToInt32(NhomID);
                var nhomSanPham = db.db_NhomSanPhams.Single(a => a.NhomID == NhomIDs);
                db.db_NhomSanPhams.DeleteOnSubmit(nhomSanPham);
                db.SubmitChanges();

                // Trả về thông báo 1 thực hiện thành công 2 thực hiện không thành công
                Response.Write("1");
            }
        }
    }
}