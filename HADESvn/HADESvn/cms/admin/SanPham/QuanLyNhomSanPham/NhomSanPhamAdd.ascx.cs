using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLyNhomSanPham
{
    public partial class NhomSanPhamAdd : System.Web.UI.UserControl
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
                var NhomID = Convert.ToInt64(id);
                btnthemmoi.Text = "Chỉnh Sửa";
                var dt = (from a in db.db_NhomSanPhams
                          where a.NhomID == NhomID
                          select a);
                if (dt != null && dt.Count() > 0)
                {
                    List<db_NhomSanPham> listNhomSP = dt.ToList();
                    foreach (var item in listNhomSP)
                    {

                        tbTenNhomSP.Text = item.TenNhom.ToString();
                        tbThuTu.Text = item.ThuTu.ToString();
                        tbSoSanPhamHienThi.Text = item.SoSPHienThi.ToString();
                        
                        ltrAnhDaiDien.Text = "<img class='img'src='/assets/img/SanPham/" + item.AnhDaiDien + @"'/>";
                        hdTenAnhDaiDienCu.Value = item.AnhDaiDien.ToString();
                        
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
                


                db_NhomSanPham infoNhomSP = new db_NhomSanPham();
                infoNhomSP.TenNhom = tbTenNhomSP.Text;               
                infoNhomSP.ThuTu = Convert.ToInt32(tbThuTu.Text);
                infoNhomSP.SoSPHienThi = Convert.ToInt32(tbSoSanPhamHienThi.Text);
                

                if (FileUploadanh.HasFiles)
                {
                    if (FileUploadanh.FileName.EndsWith(".jpeg") || FileUploadanh.FileName.EndsWith(".jpg") || FileUploadanh.FileName.EndsWith(".png") || FileUploadanh.FileName.EndsWith(".gif"))
                    {
                        infoNhomSP.AnhDaiDien = FileUploadanh.FileName;
                        FileUploadanh.SaveAs(Server.MapPath("\\assets\\img\\SanPham\\") + infoNhomSP.AnhDaiDien);
                    }
                }
                //infoSP.MOTA = HttpUtility.HtmlEncode(FCKNoidung.Value);
                
                db.db_NhomSanPhams.InsertOnSubmit(infoNhomSP);
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Thêm mới thành công !!','success');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Massage", "alert('Thêm mới thành công !!!')", true);
                ClearFrom();
            }
            else
            {

                string tenAnhDaiDien = "";
                var NhomID = Convert.ToInt64(id);
                db_NhomSanPham infoNhomSP = new db_NhomSanPham();
                infoNhomSP = db.db_NhomSanPhams.Where(s => s.NhomID == NhomID).Single();
                infoNhomSP.TenNhom = tbTenNhomSP.Text;
                infoNhomSP.ThuTu = Convert.ToInt32(tbThuTu.Text);
                infoNhomSP.SoSPHienThi = Convert.ToInt32(tbSoSanPhamHienThi.Text);
                if (FileUploadanh.HasFiles)
                {
                    if (FileUploadanh.FileName.EndsWith(".jpeg") || FileUploadanh.FileName.EndsWith(".jpg") || FileUploadanh.FileName.EndsWith(".png") || FileUploadanh.FileName.EndsWith(".gif"))
                    {
                        infoNhomSP.AnhDaiDien = FileUploadanh.FileName;
                        FileUploadanh.SaveAs(Server.MapPath("\\assets\\img\\SanPham\\") + infoNhomSP.AnhDaiDien);
                        tenAnhDaiDien = infoNhomSP.AnhDaiDien;
                    }
                    if (tenAnhDaiDien == "")
                    {
                        tenAnhDaiDien = hdTenAnhDaiDienCu.Value;
                    }
                }

                //infoSP.MOTA = HttpUtility.HtmlEncode(FCKNoidung.Value);
                
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Sửa mới thành công !!!','success');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Massage", "alert('Sua mới thành công !!!')", true);
                ClearFrom();
            }
        }
        private void ClearFrom()
        {
            tbTenNhomSP.Text = "";
            tbThuTu.Text = "";
            tbSoSanPhamHienThi.Text = "";
            //FCKNoidung.Value = "";
        }
    }
}