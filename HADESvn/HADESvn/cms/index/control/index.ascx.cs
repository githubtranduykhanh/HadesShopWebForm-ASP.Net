using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.index.control
{
    public partial class index : System.Web.UI.UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public static List<db_SanPham> SP = new List<db_SanPham>();
        public static List<db_DanhMucTin> DMTIN = new List<db_DanhMucTin>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadSP();
                loadDMTIN();
                ltrNhomSanPham.Text = LayNhomSanPham();
            }
        }
        public void loadSP()
        {
            var dt = (from q in db.db_SanPhams
                      select q).Take(8);
            if (dt != null && dt.Count() > 0)
            {
                SP = dt.ToList();
            }
        }
        public void loadDMTIN()
        {
            var dt = (from q in db.db_DanhMucTins
                      select q).Take(6);
            if (dt != null && dt.Count() > 0)
            {
                DMTIN = dt.ToList();
            }
        }
        private string LayNhomSanPham()
        {
            string s = "";
            var data = from q in db.db_NhomSanPhams
                        select q;
            if (data != null && data.Count() > 0)
            {
                foreach (var item in data.ToList())
                {
                    s += @"<section class='destination'>
                                <div class='destination-heading wow bounceInLeft' data-wow-duration='2s' data-wow-delay='2s'>
                                    <span>Our " + item.TenNhom+ @"</span>
                                    <h1>Make your "+ item.TenNhom.ToLower() + @" </h1>
                                </div>";

                    s += "<div class='list-product-slider box-container'>";
                    s += LayDanhSachSanPhamTheoNhom(item.NhomID.ToString(),item.SoSPHienThi.ToString());
                    s += "</div>";
                    s += "</section>";    


                }
            }

            return s;
        }
        private string LayDanhSachSanPhamTheoNhom(string NhomID, string SoSPHienThi)
        {
            string s = "";
            int nhomid = Convert.ToInt32(NhomID);
            int soSpHienThi = Convert.ToInt32(SoSPHienThi);
            var data = (from q in db.db_SanPhams
                       where q.NhomID == nhomid
                       select q).Take(soSpHienThi);
            if (data != null && data.Count() > 0)
            {
                foreach (var item in data.ToList())
                {
                    s += @"
                        <div class='box item-prpduct-slider'>
                            <div class='image'>
                                <img src='../../../assets/img/SanPham/" + item.AnhSP + @"'alt='' />
                            </div>
                            <div class='box-content'>
                                <h3 class='list-product-name'>" + item.TenSP + @"</h3>
                                <h4>" + string.Format("{0:0,000}", item.GiaSP) + @"đ</h4>
                                <p>" + item.MotaSP + @"</p>
                                <a href='ChiTietSanPham.aspx?MaSP=" + item.MaSP + @"'> Read More<ion-icon name='chevron-forward-outline'></ion-icon></a>
                            </div>
                        </div>
                    ";
                }
            }
            return s;
        }
    }
}