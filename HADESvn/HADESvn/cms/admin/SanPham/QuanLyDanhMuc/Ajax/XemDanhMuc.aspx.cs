using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.admin.SanPham.QuanLyDanhMuc.Ajax
{
    public partial class XemDanhMuc : System.Web.UI.Page
    {
        string thaotac = "";
        DataClasses1DataContext db = new DataClasses1DataContext();
        public static List<db_DanhMuc> DMSP = new List<db_DanhMuc>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Boolean)Session["admin"] == true)
            {
                if (Request.Params["ThaoTac"] != null)
                {
                    thaotac = Request.Params["ThaoTac"];
                }

                switch (thaotac)
                {

                    case "DanhMuc":
                        DanhMuc();
                        break;
                }
            }
            else
            {
                Response.Redirect("/cms/index/page/Index.aspx");
            }
            
        }
        private void DanhMuc()
        {
            string ketQua = "";
            string MaDM = "";
            if (Request.Params["MaDM"] != null)
            {
                MaDM = Request.Params["MaDM"];

                //Thực hiện code xóa
                //B1: Xóa ảnh đại diện đã lưu trên server - tạm b
                //B2: Xóa dữ liệu trên sqlserver
                int MaDMs = Convert.ToInt32(MaDM);

                var dt = (from q in db.db_DanhMucs
                          where q.MaDM == MaDMs
                          select q);
                foreach (var item in dt.ToList())
                {
                    ketQua += @"
                        <div class='box wow fadeInDown' data-wow-duration='2s' data-wow-delay='2s'>
                            <div class='image'>
                                <img src = '/assets/img/SanPham/" + item.AnhDaiDien + @"' alt=''/>
                            </div>
                            <div class='box-content'>
                                <h3> " + item.TenDM + @"</h3>
                                <p>" + item.ThuTu + @"</p>
                                <a href =s'#'> Read More<ion-icon name='chevron-forward-outline'></ion-icon></a>
                             </div>
                        </div>                   
                    ";
                }
                
                //Trả về thông báo 1 thực hiện thành công 2 thực hiện không thành công
                
            }
            Response.Write(ketQua);
        }

    }
}