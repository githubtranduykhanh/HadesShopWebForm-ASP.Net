using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLyMau
{
    public partial class MauAdd : System.Web.UI.UserControl
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
                var MauID = Convert.ToInt64(id);
                btnthemmoi.Text = "Chỉnh Sửa";


                var dt = (from a in db.db_Maus
                          where a.MauID == MauID
                          select a);
                if (dt != null && dt.Count() > 0)
                {
                    List<db_Mau> listDM = dt.ToList();
                    foreach (var item in listDM)
                    {
                        txtMau.Text = item.TenMau.ToString();
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
                db_Mau infoMau = new db_Mau();
                infoMau.TenMau = txtMau.Text;

                //infoSP.MOTA = HttpUtility.HtmlEncode(FCKNoidung.Value);

                db.db_Maus.InsertOnSubmit(infoMau);
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Thêm mới thành công !!','success');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Massage", "alert('Thêm mới thành công !!!')", true);
                ClearFrom();
            }
            else
            {

                long MauID = Convert.ToInt64(id);
                db_Mau infoMau = new db_Mau();
                infoMau = db.db_Maus.Where(s => s.MauID == MauID).Single();
                infoMau.TenMau = txtMau.Text;

                //infoSP.MOTA = HttpUtility.HtmlEncode(FCKNoidung.Value);               
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Sửa mới thành công !!!','success');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Massage", "alert('Sua mới thành công !!!')", true);
                ClearFrom();
            }
        }
        private void ClearFrom()
        {
            txtMau.Text = "";
            //FCKNoidung.Value = "";
        }
    }
}