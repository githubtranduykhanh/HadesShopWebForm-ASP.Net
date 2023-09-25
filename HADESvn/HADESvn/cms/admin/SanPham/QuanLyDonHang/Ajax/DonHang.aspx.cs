using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLyDonHang.Ajax
{
    public partial class DonHang : System.Web.UI.Page
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
                    case "XoaDonHang":
                        XoaDonHang();
                        break;

                }
            }
            else
            {
                Response.Redirect("/cms/index/page/Index.aspx");
            }
            
        }
        private void XoaDonHang()
        {
            string id = "";
            if (Request.Params["id"] != null)
            {
                id = Request.Params["id"];
                
                //Thực hiện code xóa
                //B1: Xóa ảnh đại diện đã lưu trên server - tạm b
                //B2: Xóa dữ liệu trên sqlservers
                int ids = Convert.ToInt32(id);
                db.dondathang_delete(ids);
                //var donHang = db.db_DonDatHangs.Single(a => a.MaDonDatHang == ids);
                //db.db_DonDatHangs.DeleteOnSubmit(donHang);
                db.SubmitChanges();

                // Trả về thông báo 1 thực hiện thành công 2 thực hiện không thành công
                Response.Write("1");
            }
        }
    }
}