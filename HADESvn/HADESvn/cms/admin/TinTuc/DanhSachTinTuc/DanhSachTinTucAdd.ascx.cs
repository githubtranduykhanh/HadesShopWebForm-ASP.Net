using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.TinTuc.DanhSachTinTuc
{
    public partial class DanhSachTinTucAdd : System.Web.UI.UserControl
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
                var TinTucID = Convert.ToInt64(id);
                btnthemmoi.Text = "Chỉnh Sửa";
                var dt = (from a in db.db_TinTucs
                          where a.TinTucID == TinTucID
                          select a);
                if (dt != null && dt.Count() > 0)
                {
                    List<db_TinTuc> listDM = dt.ToList();
                    foreach (var item in listDM)
                    {
                        ddlDanhMucCha.SelectedValue = item.MaDM.ToString();
                        txtTieuDe.Text = item.TieuDe.ToString();
                        txtMoTa.Text = item.MoTa.ToString();
                        txtLuotXem.Text = item.LuotXem.ToString();
                        txtNgayDang.Text = item.NgayDang.ToString();
                        txtThuTu.Text = item.ThuTu.ToString();
                        txtChiTiet.Text = item.ChiTiet.ToString();
                        ltrAnhDaiDien.Text = "<img class='img'src='/assets/img/ItemTinTuc/" + item.AnhDaiDien + @"'/>";
                        hdTenAnhDaiDienCu.Value = item.AnhDaiDien.ToString();
                        RequiredFieldValidator5.Visible = false;
                    }
                }

            }

            else
            {
                btnthemmoi.Text = "Thêm Mới";
                txtLuotXem.Text = "0";
                txtThuTu.Text = "1";
                txtNgayDang.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
            }
        }
        private void LayDanhMucCha()
        {
            var data = from cd in db.db_DanhMucTins
                       select cd;
            ddlDanhMucCha.Items.Clear();
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
                db_TinTuc infoTinTuc = new db_TinTuc();
                infoTinTuc.TieuDe = txtTieuDe.Text;
                infoTinTuc.MoTa = txtMoTa.Text;
                infoTinTuc.LuotXem = Convert.ToInt32(txtLuotXem.Text);
                infoTinTuc.NgayDang = DateTime.Parse(txtNgayDang.Text.ToString());
                infoTinTuc.ThuTu = Convert.ToInt32(txtThuTu.Text);
                infoTinTuc.ChiTiet = txtChiTiet.Text;
                if (FileUploadanh.HasFiles)
                {
                    if (FileUploadanh.FileName.EndsWith(".jpeg") || FileUploadanh.FileName.EndsWith(".jpg") || FileUploadanh.FileName.EndsWith(".png") || FileUploadanh.FileName.EndsWith(".gif"))
                    {
                        infoTinTuc.AnhDaiDien = FileUploadanh.FileName;
                        FileUploadanh.SaveAs(Server.MapPath("\\assets\\img\\ItemTinTuc\\") + infoTinTuc.AnhDaiDien);
                    }
                }
                //infoSP.MOTA = HttpUtility.HtmlEncode(FCKNoidung.Value);
                infoTinTuc.MaDM = Convert.ToInt32(ddlDanhMucCha.SelectedValue);
                db.db_TinTucs.InsertOnSubmit(infoTinTuc);
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Thêm mới thành công !!','success');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Massage", "alert('Thêm mới thành công !!!')", true);
                ClearFrom();
            }
            else
            {
                string tenAnhDaiDien = "";
                long TinTucID = Convert.ToInt64(id);
                db_TinTuc infoTinTuc = new db_TinTuc();
                infoTinTuc = db.db_TinTucs.Where(s => s.TinTucID == TinTucID).Single();
                infoTinTuc.TieuDe = txtTieuDe.Text;
                infoTinTuc.MoTa = txtMoTa.Text;
                infoTinTuc.LuotXem = Convert.ToInt32(txtLuotXem.Text);
                infoTinTuc.NgayDang = DateTime.Parse(txtNgayDang.Text.ToString());
                infoTinTuc.ThuTu = Convert.ToInt32(txtThuTu.Text);
                infoTinTuc.ChiTiet = txtChiTiet.Text;
                if (FileUploadanh.HasFiles)
                {
                    if (FileUploadanh.FileName.EndsWith(".jpeg") || FileUploadanh.FileName.EndsWith(".jpg") || FileUploadanh.FileName.EndsWith(".png") || FileUploadanh.FileName.EndsWith(".gif"))
                    {
                        infoTinTuc.AnhDaiDien = FileUploadanh.FileName;
                        FileUploadanh.SaveAs(Server.MapPath("\\assets\\img\\ItemTinTuc\\") + infoTinTuc.AnhDaiDien);
                        tenAnhDaiDien = infoTinTuc.AnhDaiDien;
                    }
                    if (tenAnhDaiDien == "")
                    {
                        tenAnhDaiDien = hdTenAnhDaiDienCu.Value;

                    }
                }

                //infoSP.MOTA = HttpUtility.HtmlEncode(FCKNoidung.Value);
                infoTinTuc.MaDM = Convert.ToInt32(ddlDanhMucCha.SelectedValue);
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Sửa mới thành công !!!','success');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Massage", "alert('Sua mới thành công !!!')", true);
                ClearFrom();
                Response.Redirect("AdminPage.aspx?modul=TinTuc&modulphu=DanhSachTinTuc");
            }
        }
        private void ClearFrom()
        {
            txtTieuDe.Text = "";
            txtChiTiet.Text = "";
            txtThuTu.Text = "";
            txtLuotXem.Text = "";
            txtNgayDang.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
            txtMoTa.Text = "";
            //FCKNoidung.Value = "";
        }
    }
}