using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.TinTuc.DanhMucTin
{
    public partial class DanhMucTinAdd : System.Web.UI.UserControl
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
                var MaDM = Convert.ToInt64(id);
                btnthemmoi.Text = "Chỉnh Sửa";
                var dt = (from a in db.db_DanhMucTins
                          where a.MaDM == MaDM
                          select a);
                if (dt != null && dt.Count() > 0)
                {
                    List<db_DanhMucTin> listDM = dt.ToList();
                    foreach (var item in listDM)
                    {
                        ddlDanhMucCha.SelectedValue = item.MaDMCha.ToString();
                        txtTenDanhMuc.Text = item.TenDM.ToString();
                        txtThuTu.Text = item.ThuTu.ToString();
                        ltrAnhDaiDien.Text = "<img class='img'src='/assets/img/DanhMuc/" + item.AnhDaiDien + @"'/>";
                        hdTenAnhDaiDienCu.Value = item.AnhDaiDien.ToString();
                        RequiredFieldValidator5.Visible = false;
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
            var data = from cd in db.db_DanhMucTins
                       select cd;
            ddlDanhMucCha.Items.Add(new ListItem("Danh Muc Cha", "0"));
            if (data != null)
            {
                List<db_DanhMucTin> listDM = data.ToList();
                ddlDanhMucCha.DataSource = listDM;
                ddlDanhMucCha.DataTextField = "TenDM";
                ddlDanhMucCha.DataValueField = "MaDM";
                ddlDanhMucCha.DataBind();
            }
        }
        protected void btnThemmoi_Click(object sender, EventArgs e)
        {
            if (thaotac == "ThemMoi")
            {
                db_DanhMucTin infoDMTin = new db_DanhMucTin();
                infoDMTin.TenDM = txtTenDanhMuc.Text;
                infoDMTin.ThuTu = Convert.ToInt32(txtThuTu.Text);
                if (FileUploadanh.HasFiles)
                {
                    if (FileUploadanh.FileName.EndsWith(".jpeg") || FileUploadanh.FileName.EndsWith(".jpg") || FileUploadanh.FileName.EndsWith(".png") || FileUploadanh.FileName.EndsWith(".gif"))
                    {
                        infoDMTin.AnhDaiDien = FileUploadanh.FileName;
                        FileUploadanh.SaveAs(Server.MapPath("\\assets\\img\\DanhMuc\\") + infoDMTin.AnhDaiDien);
                    }
                }
                //infoSP.MOTA = HttpUtility.HtmlEncode(FCKNoidung.Value);
                infoDMTin.MaDMCha = Convert.ToInt32(ddlDanhMucCha.SelectedValue);
                db.db_DanhMucTins.InsertOnSubmit(infoDMTin);
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Thêm mới thành công !!','success');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Massage", "alert('Thêm mới thành công !!!')", true);
                ClearFrom();
            }
            else
            {
                string tenAnhDaiDien = "";
                long MaDM = Convert.ToInt64(id);
                db_DanhMucTin infoDMTin = new db_DanhMucTin();
                infoDMTin = db.db_DanhMucTins.Where(s => s.MaDM == MaDM).Single();
                infoDMTin.TenDM = txtTenDanhMuc.Text;
                infoDMTin.ThuTu = Convert.ToInt32(txtThuTu.Text);
                if (FileUploadanh.HasFiles)
                {
                    if (FileUploadanh.FileName.EndsWith(".jpeg") || FileUploadanh.FileName.EndsWith(".jpg") || FileUploadanh.FileName.EndsWith(".png") || FileUploadanh.FileName.EndsWith(".gif"))
                    {
                        infoDMTin.AnhDaiDien = FileUploadanh.FileName;
                        FileUploadanh.SaveAs(Server.MapPath("\\assets\\img\\DanhMuc\\") + infoDMTin.AnhDaiDien);
                        tenAnhDaiDien = infoDMTin.AnhDaiDien;
                    }
                    if (tenAnhDaiDien == "")
                    {
                        tenAnhDaiDien = hdTenAnhDaiDienCu.Value;

                    }
                }

                //infoSP.MOTA = HttpUtility.HtmlEncode(FCKNoidung.Value);
                infoDMTin.MaDMCha = Convert.ToInt32(ddlDanhMucCha.SelectedValue);
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Sửa mới thành công !!!','success');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Massage", "alert('Sua mới thành công !!!')", true);
                ClearFrom();
            }
        }
        private void ClearFrom()
        {
            txtTenDanhMuc.Text = "";
            txtThuTu.Text = "";
            //FCKNoidung.Value = "";
        }
    }
}