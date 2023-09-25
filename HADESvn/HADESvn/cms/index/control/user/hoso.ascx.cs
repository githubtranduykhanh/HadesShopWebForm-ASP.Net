using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.index.control.user
{
    public partial class hoso : System.Web.UI.UserControl
    {
        private string id = "";
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if((Boolean)Session["user"] == true)
            {
                HienThiThongTin();
            }
            else
            {
                HienThiThongTinEmty();
            }
        }
        private void HienThiThongTin()
        {
            id = Session["MAND"].ToString();
            var MaKH = Convert.ToInt64(id);        
            var dt = (from a in db.db_KhachHangs
                      where a.MaKH == MaKH
                      select a);
            if (dt != null && dt.Count() > 0)
            {
                List<db_KhachHang> listKH = dt.ToList();
                foreach (var item in listKH)
                {

                    tbHoTen.Text = item.TenKh.ToString();
                    tbEmail.Text = item.EmailKH.ToString();
                    tbSoDienThoai.Text = item.sdtKH.ToString();
                    tbDiaChi.Text = item.DiaChiKH.ToString();
                                       
                    ltrAnhDaiDien.Text = "<img class='img-ho-so'src='/assets/img/KhachHang/" + item.AnhDaiDien + @"'/>";
                    hdTenAnhDaiDienCu.Value = item.AnhDaiDien.ToString();
                }
            }
        }
        private void HienThiThongTinEmty()
        {
            tbHoTen.Text = "";
            tbEmail.Text = "";
            tbSoDienThoai.Text = "";
            tbDiaChi.Text = "";
            ltrAnhDaiDien.Text = "";
        }
        protected void btnluuthongtin_Click(object sender, EventArgs e)
        {
            string tenAnhDaiDien = "";
            var MaKH = Convert.ToInt64(id);
            db_KhachHang infoKH = new db_KhachHang();
            infoKH = db.db_KhachHangs.Where(s => s.MaKH == MaKH).Single();
            infoKH.TenKh = tbHoTen.Text;
            infoKH.EmailKH = tbEmail.Text;
            infoKH.sdtKH = tbSoDienThoai.Text;
            infoKH.DiaChiKH = tbDiaChi.Text;
            if (FileUploadanh.HasFiles)
            {
                if (FileUploadanh.FileName.EndsWith(".jpeg") || FileUploadanh.FileName.EndsWith(".jpg") || FileUploadanh.FileName.EndsWith(".png") || FileUploadanh.FileName.EndsWith(".gif"))
                {
                    infoKH.AnhDaiDien = FileUploadanh.FileName;
                    FileUploadanh.SaveAs(Server.MapPath("\\assets\\img\\KhachHang\\") + infoKH.AnhDaiDien);
                    tenAnhDaiDien = infoKH.AnhDaiDien;
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
            HienThiThongTin();
        }
    }
}