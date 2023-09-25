using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HADESvn.cms.index.page.SanPham.Ajax
{

    public partial class XuLySanPham : System.Web.UI.Page
    {
        private string thaotac = "";
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            thaotac = Request.Params["ThaoTac"];
            switch (thaotac)
            {
                case "SanPhamTheoDanhMuc":
                    SanPhamTheoDanhMuc();
                    break;
                case "LayTatCaSanPham":
                    LayTatCaSanPham();
                    break;
                case "SanPhamTangDan":
                    SanPhamTangDan();
                    break;
                case "SanPhamGiamDan":
                    SanPhamGiamDan();
                    break;
                case "SanPhamAtoZ":
                    SanPhamAtoZ();
                    break;
                case "SanPhamZtoA":
                    SanPhamZtoA();
                    break;
                case "clickMe":
                    clickMe();
                    break;


            }
        }
        private void clickMe()
        {
           
            string[] charArray = { "<h1>Hello</h1>", "Hello"};
            Response.Write(charArray);
        }
        private void SanPhamTheoDanhMuc()
        {
            string ketQua = "";
            string MaDM = Request.Params["MaDM"];
            
            int maDMs = Convert.ToInt32(MaDM);
            var data = from cd in db.db_SanPhams
                       where cd.MaDM == maDMs
                       select cd;
            if (data.Count() > 0 && data != null)
            {
                foreach (var item in data.ToList())
                {
                    ketQua += @"
                    <div class='box wow fadeInDown box-list-product' data-wow-duration='2s' data-wow-delay='1s'>
                      <div class='image image-list-product' style='height: 100%;'>
                        <img src='../../../assets/img/SanPham/" + item.AnhSP + @"'alt='' />
                    </div>
                    <div class='box-content'>
                        <h3 class='list-product-name'>" + item.TenSP + @"</h3>
                        <h4>" + string.Format("{0:0,000}", item.GiaSP) + @"đ</h4>
                        <p>
                            " + item.MotaSP + @"
                        </p>
                        <a href='ChiTietSanPham.aspx?MaSP=" + item.MaSP+ @"' class='list-product-price'>Read More
                      <ion-icon name='chevron-forward-outline'></ion-icon>
  
                          </a>
  
                      </div>
  
                  </div>
                  ";
                }
            }
            Response.Write(ketQua);
        }
        private void LayTatCaSanPham()
        {
            string ketQua = "";
            int limit = Convert.ToInt32(Request.Params["limit"]);           
            int start = Convert.ToInt32(Request.Params["start"]);           
            var data = (from cd in db.db_SanPhams                      
                       select cd).Skip(start).Take(limit);
            if (data.Count() > 0 && data != null)
            {
                foreach (var item in data.ToList())
                {
                    ketQua += @"
                    <div class='box wow fadeInDown box-list-product' data-wow-duration='2s' data-wow-delay='1s'>
                      <div class='image image-list-product' style='height: 100%;'>
                        <img src='../../../assets/img/SanPham/" + item.AnhSP + @"'alt='' />
                    </div>
                    <div class='box-content'>
                        <h3 class='list-product-name'>" + item.TenSP + @"</h3>
                        <h4>" + string.Format("{0:0,000}", item.GiaSP) + @"đ</h4>
                        <p>
                            " + item.MotaSP + @"
                        </p>
                        <a href='ChiTietSanPham.aspx?MaSP=" + item.MaSP + @"' class='list-product-price'>Read More
                      <ion-icon name='chevron-forward-outline'></ion-icon>
  
                          </a>
  
                      </div>
  
                  </div>
                  ";
                }
            }
            Response.Write(ketQua);
        }    
        private void SanPhamTangDan()
        {
            string ketQua = "";
            int limit = Convert.ToInt32(Request.Params["limit"]);
            int start = Convert.ToInt32(Request.Params["start"]);
            var data = (from cd in db.db_SanPhams
                       orderby cd.GiaSP 
                       select cd).Skip(start).Take(limit);
            if (data.Count() > 0 && data != null)
            {
                foreach (var item in data.ToList())
                {
                    ketQua += @"
                    <div class='box wow fadeInDown box-list-product' data-wow-duration='2s' data-wow-delay='1s'>
                      <div class='image image-list-product' style='height: 100%;'>
                        <img src='../../../assets/img/SanPham/" + item.AnhSP + @"'alt='' />
                    </div>
                    <div class='box-content'>
                        <h3 class='list-product-name'>" + item.TenSP + @"</h3>
                        <h4>" + string.Format("{0:0,000}", item.GiaSP) + @"đ</h4>
                        <p>
                            " + item.MotaSP + @"
                        </p>
                        <a href='ChiTietSanPham.aspx?MaSP=" + item.MaSP + @"' class='list-product-price'>Read More
                      <ion-icon name='chevron-forward-outline'></ion-icon>
  
                          </a>
  
                      </div>
  
                  </div>
                  ";
                }
            }
            Response.Write(ketQua);
        }
        private void SanPhamGiamDan()
        {
            string ketQua = "";
            int limit = Convert.ToInt32(Request.Params["limit"]);
            int start = Convert.ToInt32(Request.Params["start"]);
            var data = (from cd in db.db_SanPhams
                       orderby cd.GiaSP descending
                       select cd).Skip(start).Take(limit);
            if (data.Count() > 0 && data != null)
            {
                foreach (var item in data.ToList())
                {
                    ketQua += @"
                    <div class='box wow fadeInDown box-list-product' data-wow-duration='2s' data-wow-delay='1s'>
                      <div class='image image-list-product' style='height: 100%;'>
                        <img src='../../../assets/img/SanPham/" + item.AnhSP + @"'alt='' />
                    </div>
                    <div class='box-content'>
                        <h3 class='list-product-name'>" + item.TenSP + @"</h3>
                        <h4>" + string.Format("{0:0,000}", item.GiaSP) + @"đ</h4>
                        <p>
                            " + item.MotaSP + @"
                        </p>
                        <a href='ChiTietSanPham.aspx?MaSP=" + item.MaSP + @"' class='list-product-price'>Read More
                      <ion-icon name='chevron-forward-outline'></ion-icon>
  
                          </a>
  
                      </div>
  
                  </div>
                  ";
                }
            }
            Response.Write(ketQua);
        }
        private void SanPhamAtoZ()
        {
            string ketQua = "";
            int limit = Convert.ToInt32(Request.Params["limit"]);
            int start = Convert.ToInt32(Request.Params["start"]);
            var data = (from cd in db.db_SanPhams
                       orderby cd.TenSP 
                       select cd).Skip(start).Take(limit);
            if (data.Count() > 0 && data != null)
            {
                foreach (var item in data.ToList())
                {
                    ketQua += @"
                    <div class='box wow fadeInDown box-list-product' data-wow-duration='2s' data-wow-delay='1s'>
                      <div class='image image-list-product' style='height: 100%;'>
                        <img src='../../../assets/img/SanPham/" + item.AnhSP + @"'alt='' />
                    </div>
                    <div class='box-content'>
                        <h3 class='list-product-name'>" + item.TenSP + @"</h3>
                        <h4>" + string.Format("{0:0,000}", item.GiaSP) + @"đ</h4>
                        <p>
                            " + item.MotaSP + @"
                        </p>
                        <a href='ChiTietSanPham.aspx?MaSP=" + item.MaSP + @"' class='list-product-price'>Read More
                      <ion-icon name='chevron-forward-outline'></ion-icon>
  
                          </a>
  
                      </div>
  
                  </div>
                  ";
                }
            }
            Response.Write(ketQua);
        }
        private void SanPhamZtoA()
        {
            string ketQua = "";
            int limit = Convert.ToInt32(Request.Params["limit"]);
            int start = Convert.ToInt32(Request.Params["start"]);
            var data = (from cd in db.db_SanPhams
                       orderby cd.TenSP descending
                       select cd).Skip(start).Take(limit);
            if (data.Count() > 0 && data != null)
            {
                foreach (var item in data.ToList())
                {
                    ketQua += @"
                    <div class='box wow fadeInDown box-list-product' data-wow-duration='2s' data-wow-delay='1s'>
                      <div class='image image-list-product' style='height: 100%;'>
                        <img src='../../../assets/img/SanPham/" + item.AnhSP + @"'alt='' />
                    </div>
                    <div class='box-content'>
                        <h3 class='list-product-name'>" + item.TenSP + @"</h3>
                        <h4>" + string.Format("{0:0,000}", item.GiaSP) + @"đ</h4>
                        <p>
                            " + item.MotaSP + @"
                        </p>
                        <a href='ChiTietSanPham.aspx?MaSP=" + item.MaSP + @"' class='list-product-price'>Read More
                      <ion-icon name='chevron-forward-outline'></ion-icon>
  
                          </a>
  
                      </div>
  
                  </div>
                  ";
                }
            }
            Response.Write(ketQua);
        }
    }
}