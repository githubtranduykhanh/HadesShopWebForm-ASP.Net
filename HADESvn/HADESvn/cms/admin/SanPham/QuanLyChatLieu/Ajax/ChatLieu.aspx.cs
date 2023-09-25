using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLyChatLieu.Ajax
{
    public partial class ChatLieu : System.Web.UI.Page
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
                    case "XoaChatLieu":
                        XoaChatLieu();
                        break;
                }
            }
            else
            {
                Response.Redirect("/cms/index/page/Index.aspx");
            }
            
        }
        private void XoaChatLieu()
        {
            string ChatLieuIDs = "";
            if (Request.Params["ChatLieuID"] != null)
            {
                ChatLieuIDs = Request.Params["ChatLieuID"];

                //Thực hiện code xóa
                //B1: Xóa ảnh đại diện đã lưu trên server - tạm b
                //B2: Xóa dữ liệu trên sqlserver
                int ChatLieuID = Convert.ToInt32(ChatLieuIDs);
                var chatLieu = db.db_ChatLieus.Single(a => a.ChatLieuID == ChatLieuID);
                db.db_ChatLieus.DeleteOnSubmit(chatLieu);
                db.SubmitChanges();

                // Trả về thông báo 1 thực hiện thành công 2 thực hiện không thành công
                Response.Write("1");
                
            }
        }
       

    }
}