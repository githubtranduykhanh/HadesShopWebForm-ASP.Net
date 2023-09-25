using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HADESvn;

namespace HADESvn.cms.index.control
{
    public partial class lienhe : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (txtEmailAddress.Text == "" || txtFirstName.Text == "" || txtLastName.Text == "" || txtMessage.Text == "" || txtMobileNumber.Text == "")
            {
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "alert('Vui lòng nhập đầy đủ thông tin !!!')", true);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Vui lòng nhập đầy đủ thông tin !!!','warning');", true);

            }
            else
            {
                if (HADESvn.Email.IsEmail(txtEmailAddress.Text))
                {
                    HADESvn.Email.sendMail(txtFirstName.Text, txtLastName.Text, txtEmailAddress.Text, txtMobileNumber.Text, txtMessage.Text);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Gửi liên hệ thành công :))','success');", true);
                    ClearFrom();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alertSweetalert2('Email không hợp lệ !!!','warning');", true);
                }

            }         
        }
        private void ClearFrom()
        {
            txtEmailAddress.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMessage.Text = "";
            txtMobileNumber.Text = "";
        }
    }
}