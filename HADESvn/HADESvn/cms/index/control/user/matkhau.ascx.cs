using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.index.control.user
{
    public partial class matkhau : System.Web.UI.UserControl
    {
        private string id = "";
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnlaumk_Click(object sender, EventArgs e)
        {
            id = Session["MAND"].ToString();
            var MaKH = Convert.ToInt64(id);
            if (txtMatKhauCu.Text == "" || txtMatKhauMoi.Text == ""  || txtNhapLaiMatKhau.Text == "")
            {
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "alert('Vui lòng nhập đầy đủ thông tin !!!')", true);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Vui lòng nhập đầy đủ thông tin !!!','warning');", true);

            }
            else
            {
                
                string matKhauCu = "";
                matKhauCu = HADESvn.MaHoa.MaHoaMD5(txtMatKhauCu.Text);
                string matKhauMoi = "";
                matKhauMoi = HADESvn.MaHoa.MaHoaMD5(txtMatKhauMoi.Text);
                string matKhauNhapLai = "";
                matKhauNhapLai = HADESvn.MaHoa.MaHoaMD5(txtNhapLaiMatKhau.Text);
                db_KhachHang infoDN = new db_KhachHang();              
                infoDN = (from p in db.db_KhachHangs
                           where p.MaKH == MaKH
                           select p).Single();             
                if (infoDN.MatKhau == matKhauCu)
                {
                    if(txtMatKhauMoi.Text == txtNhapLaiMatKhau.Text)
                    {
                        infoDN.MatKhau = matKhauNhapLai;                       
                        db.SubmitChanges();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Đổi mật khẩu thành công !!!','success');", true);
                        ClearFrom();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Vui lòng nhập lại mật khẩu chính xác !!!','warning');", true);
                        //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "alert('đăng nhập thành công !!!')", true);
                        ClearFrom();
                    }

                }              
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Sai mật khẩu !!!','warning');", true);
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "alert('đăng nhập thất bại !!!')", true);
                    ClearFrom();
                }

            }
        }
        private void ClearFrom()
        {
            txtMatKhauCu.Text = "";
            txtMatKhauMoi.Text = "";
            txtNhapLaiMatKhau.Text = "";
        }

       
    }
}