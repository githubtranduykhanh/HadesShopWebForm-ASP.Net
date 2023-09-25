using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.Menu
{
    public partial class MenuAdd : System.Web.UI.UserControl
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

                LayDanhMucCha();
                HienThiThongTin(id);

            }
        }
        private void HienThiThongTin(string id)
        {

            if (thaotac == "ChinhSua")
            {
                var MaMenu = Convert.ToInt64(id);
                btnthemmoi.Text = "Chỉnh Sửa";
                var dt = (from a in db.db_Menus
                          where a.MaMenu == MaMenu
                          select a);
                if (dt != null && dt.Count() > 0)
                {
                    List<db_Menu> listMeNu = dt.ToList();
                    foreach (var item in listMeNu)
                    {
                        ddlMenuCha.SelectedValue = item.MaMenuCha.ToString();
                        tbTenMenu.Text = item.TenMenu.ToString();
                        tbLienKet.Text = item.LienKet.ToString();
                        tbThuTu.Text = item.ThuTuMenu.ToString();
                        
                    }
                }

            }

            else
            {
                btnthemmoi.Text = "Thêm Mới";
            }
        }
        private void LayDanhMucCha()
        {
            var data = from cd in db.db_Menus
                       select cd;
            ddlMenuCha.Items.Add(new ListItem("Danh Muc Cha", "0"));
            if (data != null)
            {
                List<db_Menu> listMenu = data.ToList();
                ddlMenuCha.DataSource = listMenu;
                ddlMenuCha.DataTextField = "TenMenu";
                ddlMenuCha.DataValueField = "TenMenu";
                ddlMenuCha.DataBind();
            }
        }
        protected void btnThemmoi_Click(object sender, EventArgs e)
        {
            if (thaotac == "ThemMoi")
            {
                db_Menu infoMenu = new db_Menu();
                infoMenu.TenMenu = tbTenMenu.Text;
                infoMenu.LienKet = tbLienKet.Text;
                infoMenu.ThuTuMenu = Convert.ToInt32(tbThuTu.Text);
                //infoSP.MOTA = HttpUtility.HtmlEncode(FCKNoidung.Value);
                infoMenu.MaMenuCha = Convert.ToInt32(ddlMenuCha.SelectedValue);
                db.db_Menus.InsertOnSubmit(infoMenu);
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Thêm mới thành công !!','success');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Massage", "alert('Thêm mới thành công !!!')", true);
                ClearFrom();
            }
            else
            {
               
                long MaMenu = Convert.ToInt64(id);
                db_Menu infoMenu = new db_Menu();
                infoMenu = db.db_Menus.Where(s => s.MaMenu == MaMenu).Single();
                infoMenu.TenMenu = tbTenMenu.Text;
                infoMenu.LienKet = tbLienKet.Text;
                infoMenu.ThuTuMenu = Convert.ToInt32(tbThuTu.Text);
                //infoSP.MOTA = HttpUtility.HtmlEncode(FCKNoidung.Value);
                infoMenu.MaMenuCha = Convert.ToInt32(ddlMenuCha.SelectedValue);
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Sửa mới thành công !!!','success');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Massage", "alert('Sua mới thành công !!!')", true);
                ClearFrom();
            }
        }
        private void ClearFrom()
        {
            tbTenMenu.Text = "";
            tbLienKet.Text = "";
            tbThuTu.Text = "";
            //FCKNoidung.Value = "";
        }
    }
}