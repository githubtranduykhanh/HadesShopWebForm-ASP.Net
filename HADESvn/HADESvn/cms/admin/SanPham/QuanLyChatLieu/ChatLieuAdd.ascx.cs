using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLyChatLieu
{
    public partial class ChatLieuAdd : System.Web.UI.UserControl
    {
        private string thaotac = "";
        private string id = "";//lấy id của danh mục cần chỉnh sửa
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["thaotac"] != null)
                thaotac = Request.QueryString["thaotac"];
            if (Request.QueryString["id"] != null)
                id = Request.QueryString["id"];
            if (!IsPostBack)
            {
            
                HienThiThongTin(id);
            }
        }
        private void HienThiThongTin(string id)
        {
            
            if (thaotac == "ChinhSua")
            {
                var ChatLieuID = Convert.ToInt64(id);
                btnthemmoi.Text = "Chỉnh Sửa";


                var dt = (from a in db.db_ChatLieus
                          where a.ChatLieuID == ChatLieuID
                          select a);
                if (dt != null && dt.Count() > 0)
                {
                    List<db_ChatLieu> listDM = dt.ToList();
                    foreach (var item in listDM)
                    {                 
                        txtChatLieu.Text = item.TenChatLieu.ToString();                       
                    }
                }
            }

            else
            {
                btnthemmoi.Text = "Thêm Mới";
            }

        }
        protected void btnThemmoi_Click(object sender, EventArgs e)
        {
            if (thaotac == "ThemMoi")
            {
                db_ChatLieu infoCL = new db_ChatLieu();
                infoCL.TenChatLieu = txtChatLieu.Text;
                
                //infoSP.MOTA = HttpUtility.HtmlEncode(FCKNoidung.Value);
                
                db.db_ChatLieus.InsertOnSubmit(infoCL);
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Thêm mới thành công !!','success');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Massage", "alert('Thêm mới thành công !!!')", true);
                ClearFrom();
            }
            else
            {
                
                long ChatLieuID = Convert.ToInt64(id);
                db_ChatLieu infoCL = new db_ChatLieu();
                infoCL = db.db_ChatLieus.Where(s => s.ChatLieuID == ChatLieuID).Single();
                infoCL.TenChatLieu = txtChatLieu.Text;
                               
                //infoSP.MOTA = HttpUtility.HtmlEncode(FCKNoidung.Value);               
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Sửa mới thành công !!!','success');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Massage", "alert('Sua mới thành công !!!')", true);
                ClearFrom();
            }
        }
        private void ClearFrom()
        {
            txtChatLieu.Text = "";
            //FCKNoidung.Value = "";
        }
    }
}