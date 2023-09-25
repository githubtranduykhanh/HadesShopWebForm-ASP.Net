using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLySanPham
{
    public partial class SanPhamAdd : System.Web.UI.UserControl
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
                LoadDM();
                LoadMau();
                LoadSize();
                LoadChatLieu();
                LoadNhom();
                HienThiThongTin(id);
            }
           
        }
        private void LoadDM()
        {
            var data = from cd in db.db_DanhMucs
                       select cd;
            if (data != null)
            {
                List<db_DanhMuc> listDM = data.ToList();
                dropDanhMuc.DataSource = listDM;
                dropDanhMuc.DataTextField = "TenDM";
                dropDanhMuc.DataValueField = "MaDM";
                dropDanhMuc.DataBind();
            }
        }
        private void LoadMau()
        {
            var data = from cd in db.db_Maus
                       select cd;
            if (data != null)
            {
                List<db_Mau> listDM = data.ToList();
                dropmau.DataSource = listDM;
                dropmau.DataTextField = "TenMau";
                dropmau.DataValueField = "MauID";
                dropmau.DataBind();
            }
        }
        private void LoadSize()
        {
            var data = from cd in db.db_Sizes
                       select cd;
            if (data != null)
            {
                List<db_Size> listDM = data.ToList();
                dropSize.DataSource = listDM;
                dropSize.DataTextField = "TenSize";
                dropSize.DataValueField = "SizeID";
                dropSize.DataBind();
            }
        }
        private void LoadChatLieu()
        {
            var data = from cd in db.db_ChatLieus
                       select cd;
            if (data != null)
            {
                List<db_ChatLieu> listDM = data.ToList();
                dropChatLieu.DataSource = listDM;
                dropChatLieu.DataTextField = "TenChatLieu";
                dropChatLieu.DataValueField = "ChatLieuID";
                dropChatLieu.DataBind();
            }
        }
        private void LoadNhom()
        {
            var data = from cd in db.db_NhomSanPhams
                       select cd;
            if (data != null)
            {
                List<db_NhomSanPham> listDM = data.ToList();
                dropNhom.DataSource = listDM;
                dropNhom.DataTextField = "TenNhom";
                dropNhom.DataValueField = "NhomID";
                dropNhom.DataBind();
            }
        }
        private void HienThiThongTin(string id)
        {

            if (thaotac == "ChinhSua")
            {
                
                var MaSP = Convert.ToInt64(id);
                btnthemmoi.Text = "Chỉnh Sửa";
                var dt = (from a in db.db_SanPhams
                          where a.MaSP == MaSP
                          select a);
                if (dt != null && dt.Count() > 0)
                {
                    List<db_SanPham> listSP = dt.ToList();
                    foreach (var item in listSP)
                    {
                        dropDanhMuc.SelectedValue = item.MaDM.ToString();
                        txtTenSP.Text = item.TenSP.ToString();
                        txtgia.Text = item.GiaSP.ToString();
                        txtTao.Text = Convert.ToDateTime(item.NgayTao).ToString("yyyy-MM-ddThh:mm");
                        txtHuy.Text = Convert.ToDateTime(item.NgayHuy).ToString("yyyy-MM-ddThh:mm");
                        txtMota.Text = item.MotaSP.ToString();

                        dropmau.SelectedValue = item.MauID.ToString();
                        dropSize.SelectedValue = item.SizeID.ToString();
                        dropNhom.SelectedValue = item.NhomID.ToString();
                        dropChatLieu.SelectedValue = item.ChatLieuID.ToString();

                        ltrAnhDaiDien.Text = "<img class='img'src='/assets/img/SanPham/" + item.AnhSP + @"'/>";
                        hdTenAnhDaiDienCu.Value = item.AnhSP.ToString();
                    }
                }

            }

            else
            {
                btnthemmoi.Text = "Thêm Mới";
                txtTao.Text = DateTime.Now.ToString("yyyy-MM-ddThh:mm");
                txtHuy.Text = DateTime.Now.ToString("yyyy-MM-ddThh:mm");
            }
        }
        protected void btnThemmoi_Click(object sender, EventArgs e)
        {
            if (thaotac == "ThemMoi" || thaotac == null)
            {
                db_SanPham infoSP = new db_SanPham();
                infoSP.TenSP = txtTenSP.Text;
                infoSP.GiaSP = Convert.ToInt32(txtgia.Text);
                infoSP.NgayTao = DateTime.Parse(txtTao.Text.ToString());
                infoSP.NgayHuy = DateTime.Parse(txtHuy.Text.ToString());
                infoSP.MotaSP = txtMota.Text;
                if (FileUploadanh.HasFiles)
                {
                    infoSP.AnhSP = FileUploadanh.FileName;
                    FileUploadanh.SaveAs(Server.MapPath("\\assets\\img\\SanPham\\") + infoSP.AnhSP);
                }

                //infoSP.MOTA = HttpUtility.HtmlEncode(FCKNoidung.Value);
                infoSP.MaDM = Convert.ToInt32(dropDanhMuc.SelectedValue);
                infoSP.MauID = Convert.ToInt32(dropmau.SelectedValue);
                infoSP.SizeID = Convert.ToInt32(dropSize.SelectedValue);
                infoSP.NhomID = Convert.ToInt32(dropNhom.SelectedValue);
                infoSP.ChatLieuID = Convert.ToInt32(dropChatLieu.SelectedValue);
                db.db_SanPhams.InsertOnSubmit(infoSP);
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Thêm mới thành công !!','success');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Massage", "alert('Thêm mới thành công !!!')", true);
                ClearFrom();
            }
            if(thaotac == "ChinhSua")
            {
                string tenAnhDaiDien = "";
                var MaSP = Convert.ToInt64(id);
                db_SanPham infoSP = new db_SanPham();
                infoSP = db.db_SanPhams.Where(s => s.MaSP == MaSP).Single();
                infoSP.TenSP = txtTenSP.Text;
                infoSP.GiaSP = Convert.ToInt32(txtgia.Text);
                infoSP.NgayTao = DateTime.Parse(txtTao.Text.ToString());
                infoSP.NgayHuy = DateTime.Parse(txtHuy.Text.ToString());
                infoSP.MotaSP = txtMota.Text;
                if (FileUploadanh.HasFiles)
                {
                    if (FileUploadanh.FileName.EndsWith(".jpeg") || FileUploadanh.FileName.EndsWith(".jpg") || FileUploadanh.FileName.EndsWith(".png") || FileUploadanh.FileName.EndsWith(".gif"))
                    {
                        infoSP.AnhSP = FileUploadanh.FileName;
                        FileUploadanh.SaveAs(Server.MapPath("\\assets\\img\\DanhMuc\\") + infoSP.AnhSP);
                        tenAnhDaiDien = infoSP.AnhSP;
                    }
                    if (tenAnhDaiDien == "")
                    {
                        tenAnhDaiDien = hdTenAnhDaiDienCu.Value;
                    }
                }
                //infoSP.MOTA = HttpUtility.HtmlEncode(FCKNoidung.Value);
                infoSP.MaDM = Convert.ToInt32(dropDanhMuc.SelectedValue);
                infoSP.MauID = Convert.ToInt32(dropmau.SelectedValue);
                infoSP.SizeID = Convert.ToInt32(dropSize.SelectedValue);
                infoSP.NhomID = Convert.ToInt32(dropNhom.SelectedValue);
                infoSP.ChatLieuID = Convert.ToInt32(dropChatLieu.SelectedValue);
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Sửa mới thành công !!!','success');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Massage", "alert('Sua mới thành công !!!')", true);
                ClearFrom();
            }
        }
        private void ClearFrom()
        {
            txtTenSP.Text = "";
            txtgia.Text = "";
            txtMota.Text = "";
            txtTao.Text = DateTime.Now.ToString("yyyy-MM-ddThh:mm");
            txtHuy.Text = DateTime.Now.ToString("yyyy-MM-ddThh:mm");
            //FCKNoidung.Value = "";
        }

    }
}