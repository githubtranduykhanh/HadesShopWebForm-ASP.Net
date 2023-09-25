using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.Menu.Ajax
{
    public partial class Menu : System.Web.UI.Page
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
                    case "XoaMenu":
                        XoaMenu();
                        break;

                }
            }
            else
            {
                Response.Redirect("/cms/index/page/Index.aspx");
            }
           
        }
        private void XoaMenu()
        {
            string MaMenu = "";
            if (Request.Params["MaMenu"] != null)
            {
                MaMenu = Request.Params["MaMenu"];

                //Thực hiện code xóa
                //B1: Xóa ảnh đại diện đã lưu trên server - tạm b
                //B2: Xóa dữ liệu trên sqlserver
                int MaMenus = Convert.ToInt32(MaMenu);
                var meNu = db.db_Menus.Single(a => a.MaMenu == MaMenus);
                db.db_Menus.DeleteOnSubmit(meNu);
                db.SubmitChanges();

                // Trả về thông báo 1 thực hiện thành công 2 thực hiện không thành công
                Response.Write("1");
            }
        }
    }
}