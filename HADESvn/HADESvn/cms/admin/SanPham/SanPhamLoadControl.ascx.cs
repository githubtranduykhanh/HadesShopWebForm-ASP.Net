using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham
{
    public partial class SanPhamLoadControl : System.Web.UI.UserControl
    {

        private string modulphu = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["modulphu"] != null)
                modulphu = Request.QueryString["modulphu"];
            switch (modulphu)
            {
                case "DanhMuc":
                    AdminPlaceHolder.Controls.Add(LoadControl("QuanLyDanhMuc/DanhMucLoadControl.ascx"));
                    break;

                case "DanhSachSanPham":
                    AdminPlaceHolder.Controls.Add(LoadControl("QuanLySanPham/SanPhamLoadControlSup.ascx"));
                    break;

                case "Mau":
                    AdminPlaceHolder.Controls.Add(LoadControl("QuanLyMau/MauLoadControl.ascx"));
                    break;

                case "ChatLieu":
                    AdminPlaceHolder.Controls.Add(LoadControl("QuanLyChatLieu/ChatLieuLoadControl.ascx"));
                    break;

                case "Size":
                    AdminPlaceHolder.Controls.Add(LoadControl("QuanLySize/SizeLoadControl.ascx"));
                    break;

                case "NhomSanPham":
                    AdminPlaceHolder.Controls.Add(LoadControl("QuanLyNhomSanPham/NhomLoadControl.ascx"));
                    break;

                case "PhienDauGia":
                    AdminPlaceHolder.Controls.Add(LoadControl("QuanLyPhienDauGia/PhienDauGiaLoadControl.ascx"));
                    break;
                case "DonHang":
                    AdminPlaceHolder.Controls.Add(LoadControl("QuanLyDonHang/DonHangLoadControl.ascx"));
                    break;

                default:
                    AdminPlaceHolder.Controls.Add(LoadControl("QuanLySanPham/SanPhamLoadControlSup.ascx"));
                    break;


            }

        }
        protected string DanhDau(string tenModul, string tenModulPhu, string tenThaoTac)
        {
            string s = "";

            /*Lấy giá trị querystring modul, modulphu, thaotac*/
            string modul = "";
            if (Request.QueryString["modul"] != null)
                modul = Request.QueryString["modul"];

            string modulphu = "";
            if (Request.QueryString["modulphu"] != null)
                modulphu = Request.QueryString["modulphu"];

            string thaotac = "";
            if (Request.QueryString["thaotac"] != null)
                thaotac = Request.QueryString["thaotac"];

            /*So sánh nếu querystring bằng tên modul, modulphu, thaotac truyền vào thì trả về current --> đánh dấu là menu hiện tại*/
            if (modul == tenModul && modulphu == tenModulPhu && thaotac == tenThaoTac)
                s = "current";
            return s;
        }
    }

}