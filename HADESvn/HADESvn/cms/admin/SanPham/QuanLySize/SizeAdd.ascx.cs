using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLySize
{
    public partial class SizeAdd : System.Web.UI.UserControl
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


                var dt = (from a in db.db_Sizes
                          where a.SizeID == ChatLieuID
                          select a);
                if (dt != null && dt.Count() > 0)
                {
                    List<db_Size> listDM = dt.ToList();
                    foreach (var item in listDM)
                    {
                        txtSize.Text = item.TenSize.ToString();
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
                db_Size infoSize = new db_Size();
                infoSize.TenSize = txtSize.Text;

                //infoSP.MOTA = HttpUtility.HtmlEncode(FCKNoidung.Value);

                db.db_Sizes.InsertOnSubmit(infoSize);
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Thêm mới thành công !!','success');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Massage", "alert('Thêm mới thành công !!!')", true);
                ClearFrom();
            }
            else
            {

                long SizeID = Convert.ToInt64(id);
                db_Size infoSize = new db_Size();
                infoSize = db.db_Sizes.Where(s => s.SizeID == SizeID).Single();
                infoSize.TenSize = txtSize.Text;

                //infoSP.MOTA = HttpUtility.HtmlEncode(FCKNoidung.Value);               
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Sửa mới thành công !!!','success');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Massage", "alert('Sua mới thành công !!!')", true);
                ClearFrom();
            }
        }
        private void ClearFrom()
        {
            txtSize.Text = "";
            //FCKNoidung.Value = "";
        }
    }
}