
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using GetData2016.Models;
using GetData2016.Models.XeHoi;
using Newtonsoft.Json;

namespace GetData2016
{
    public class XeHoi
    {
        private string _bxhDomain = "http://banxehoi.com";
        private const string _bxhKeyText = "ban-xe-hoi";

        private string _choTotDomain = "http://chotot.vn";
        public XeHoi()
        {
            
        }

        #region banxehoi.com

        public void BxhGetData(int fromPage, int toPage)
        {
            // page 1: https://banxehoi.com/ban-xe
            // page 2: https://banxehoi.com/ban-xe/p2          

            string urlFormat1 = "https://banxehoi.com/ban-xe";
            string urlFormat2 = "https://banxehoi.com/ban-xe/p{0}";

            for (int i = fromPage; i <= toPage; i++)
            {
                if (i == 1)
                {
                    BxhFetchUrl(string.Format(urlFormat1));
                }
                else
                {
                    BxhFetchUrl(string.Format(urlFormat2, i));
                }
            }
        }

        private void BxhFetchUrl(string url)
        {
            var results = Functions.DownLoadUrl(url, Encoding.UTF8);
            var linkPat = new Regex(@"(?<=class=""opensanslistauto"" href="")[\s\S]+?(?=(""))");
            var links = linkPat.Matches(results);

            foreach (Match link in links)
            {
                /*
                *********** go to detail page company
                */
                string webLink = _bxhDomain + link.Value;
                string detailHtml = Functions.DownLoadUrl(webLink, Encoding.UTF8);

                #region thong tin xe coban
                string title = string.Empty, price = string.Empty, desc = string.Empty
                    , maTin = string.Empty, ngayDang= string.Empty, namSanXuat = string.Empty
                    , tinhTrang = string.Empty, xuatXu = string.Empty, hopSo = string.Empty
                    , soCua = string.Empty, soChoNgoi = string.Empty, nhienLieu = string.Empty
                    , mauXe = string.Empty, hangXe = string.Empty, dongXe = string.Empty;

                var titlePat = new Regex(@"(?<=<h1>)[\s\S]+?(?=(<\/h1>))");
                title = HttpUtility.HtmlDecode(titlePat.Match(detailHtml).Value);

                var descPat = new Regex(@"(?<=<div class=""desc"">)[\s\S]+?(?=(<\/div>))");
                desc = descPat.Match(detailHtml).Value;

                //< input type = "hidden" id = "txtPrice1" value = "3899000000" />
                var pricePat = new Regex(@"(?<=<input type=""hidden"" id=""txtPrice1"" value="")[\s\S]+?(?=("" \/>))");
                price = pricePat.Match(detailHtml).Value;
                //< input type = "hidden" id = "txtProductionYear" value = "2017" />
                var namSanXuatPat = new Regex(@"(?<=<input type=""hidden"" id=""txtProductionYear"" value="")[\s\S]+?(?=("" \/>))");
                namSanXuat = namSanXuatPat.Match(detailHtml).Value;
                //< input type = "hidden" id = "txtSecondHand" value = "Mới" />
                var tinhTrangPat = new Regex(@"(?<=<input type=""hidden"" id=""txtSecondHand"" value="")[\s\S]+?(?=("" \/>))");
                tinhTrang = tinhTrangPat.Match(detailHtml).Value;

                var ngayDangPat = new Regex(@"(?<=<span class=""lastuptime"">)[\s\S]+?(?=(<\/span>))");
                ngayDang = ngayDangPat.Match(detailHtml).Value;
                var maTinPat = new Regex(@"(?<=<span class=""code"">)[\s\S]+?(?=(<\/span>))");
                maTin = maTinPat.Match(detailHtml).Value;

                var htmlXuatXuPat = new Regex(@"<label class=""madein"">Xuất xứ<\/label>(\s+)<span>:[\s\S]+?<\/span>");
                string htmlXuatXu = htmlXuatXuPat.Match(detailHtml).Value;
                var xuatXuPat = new Regex(@"(?<=<span>:)[\s\S]+?(?=(<\/span>))");
                xuatXu = xuatXuPat.Match(htmlXuatXu).Value;

                var htmlHopSoPat = new Regex(@"<label class=""tranmission"">Hộp số<\/label>(\s+)<span>:[\s\S]+?<\/span>");
                string htmlHopSo = htmlHopSoPat.Match(detailHtml).Value;
                var hopSoPat = new Regex(@"(?<=<span>:)[\s\S]+?(?=(<\/span>))");
                hopSo = hopSoPat.Match(htmlHopSo).Value;

                var htmlsoCuaPat = new Regex(@"Số cửa<\/label>(\s+)<span>[\s\S]+?<\/span>");
                string htmlsoCua = htmlsoCuaPat.Match(detailHtml).Value;
                var soCuaPat = new Regex(@"(?<=<span>)[\s\S]+?(?=(<\/span>))");
                soCua = soCuaPat.Match(htmlsoCua).Value;

                var htmlSoChoNgoiPat = new Regex(@"Số chỗ<\/label>(\s+)<span>[\s\S]+?<\/span>");
                string htmlsoChoNgoi = htmlSoChoNgoiPat.Match(detailHtml).Value;
                var soChoNgoiPat = new Regex(@"(?<=<span>)[\s\S]+?(?=(<\/span>))");
                soChoNgoi = soChoNgoiPat.Match(htmlsoChoNgoi).Value;

                var htmlNhienLieuPat = new Regex(@"Nhiên liệu<\/label>(\s+)<span>[\s\S]+?<\/span>");
                string htmlNhienLieu = htmlNhienLieuPat.Match(detailHtml).Value;
                var nhienLieuPat = new Regex(@"(?<=<span>)[\s\S]+?(?=(<\/span>))");
                nhienLieu = nhienLieuPat.Match(htmlNhienLieu).Value;

                var htmlMauXePat = new Regex(@"Màu xe<\/label>(\s+)<span>[\s\S]+?<\/span>");
                string htmlMauXe = htmlMauXePat.Match(detailHtml).Value;
                var mauxePat = new Regex(@"(?<=<span>)[\s\S]+?(?=(<\/span>))");
                mauXe = mauxePat.Match(htmlMauXe).Value;

                //var hangXePat = new Regex(@"(?<=<input type=""hidden"" id=""txtSecondHand"" value="")[\s\S]+?(?=(""<\""/>))");
                //hangXe = hangXePat.Match(detailHtml).Value;
                //var dongXePat = new Regex(@"(?<=<input type=""hidden"" id=""txtSecondHand"" value="")[\s\S]+?(?=(""<\""/>))");
                //dongXe = dongXePat.Match(detailHtml).Value;
                #endregion

                #region thong so kt chung chung
                // data return extra </div>, should be add <div> at begin
                var thongSoCoBanPat = new Regex(@"
                        (?<=<div class=""titlebox"">Thông số cơ bản<\/div>)[\s\S]+?(?=(<div class=""techinfo mgb15"">))");
                string thongSoCoBan = "<div>" + thongSoCoBanPat.Match(detailHtml).Value;
                
                // data return extra </div>, should be add <div> at begin
                var thongSoKtPat = new Regex(@"
                                (?<=<div class=""titlebox"">Thông số kỹ thuật<\/div>)[\s\S]+?(?=(<div class=""extendinfo mgb15"">))");
                string thongSoKt = "<div>" + thongSoKtPat.Match(detailHtml).Value;
                
                // data return extra </div></div>, should be add <div><div> at begin
                var tienNghiPat = new Regex(@"
                                        (?<=<div class=""titlebox"">Tiện nghi<\/div>)[\s\S]+?(?=(<div class=""contact"">))");
                string tienNghi = "<div><div>"+ tienNghiPat.Match(detailHtml).Value;
                #endregion

                #region thong tin ng ban
                // < input id = "mailto" value = "nguyenlong.dang91@gmail.com" type = "hidden" >
                var emailPat = new Regex(@"(?<=<input id=""mailto"" value="")[\s\S]+?(?=("" type=""hidden"" \/>))");
                string email = emailPat.Match(detailHtml).Value;
                var fullNamePat = new Regex(@"(?<=<div class=""fullname"">)[\s\S]+?(?=(<\/div>))");
                string fullName = fullNamePat.Match(detailHtml).Value;
                if (fullName.IndexOf("</a>") != -1)
                {
                    // showroom
                    var patSmall = new Regex(@"(?<=>)[\s\S]+?(?=(</a>))");
                    fullName = patSmall.Match(fullName).Value;
                }
                var addressPat = new Regex(@"(?<=<div class=""address"">)[\s\S]+?(?=(<\/div>))");
                string address = addressPat.Match(detailHtml).Value;
                var phonePat = new Regex(@"(?<=<div class=""mobile"">)[\s\S]+?(?=(<\/div>))");
                string phone = phonePat.Match(detailHtml).Value;
                #endregion
            }
        }
        #endregion

        #region chotot xe
        public void ChoTotXeHoiGetDataXe(int fromPage, int toPage)
        {
            // page 1: https://gateway.chotot.com/v1/public/ad-listing?region=&cg=2010&sp=0&limit=20&o=0&st=s,k
            // page 2: https://gateway.chotot.com/v1/public/ad-listing?region=&cg=2010&page=2&sp=0&limit=20&o=20&st=s,k           

            string urlFormat1 = "https://gateway.chotot.com/v1/public/ad-listing?region=&cg=2010&sp=0&limit=20&o=0&st=s,k";
            string urlFormat2 = "https://gateway.chotot.com/v1/public/ad-listing?region=&cg=2010&page={0}&sp=0&limit=20&o=0&st=s,k";

            for (int i = fromPage; i <= toPage; i++)
            {
                if (i == 1)
                {
                    ChoTotXeHoiFetchUrl(string.Format(urlFormat1));
                }
                else
                {
                    ChoTotXeHoiFetchUrl(string.Format(urlFormat2, i));
                }
            }
        }

        private void ChoTotXeHoiFetchUrl(string url)
        {
            var results =
               Functions.DownLoadUrl(url, Encoding.UTF8);
            var json = JsonConvert.DeserializeObject<ChoTotCars>(results);
            if (json != null)
            {
                var ads = json.ads;
                foreach (var ad in ads)
                {
                    string name = HttpUtility.HtmlEncode(ad.account_name);
                    string id = ad.account_id;
                }
                // insert to db
            }
        }
        #endregion        

        public void GetData()
        {
            string linkTpl = "https://itviec.com/companies/-?page={0}";

            for (int i = 1; i <= 55; i++)
            {
                IList<Company> lst = new List<Company>();

                string res = Functions.DownLoadUrl(string.Format(linkTpl, i), Encoding.Default);

                var contentReg = new Regex(@"<div class='first-group'>[\s\S]+(?=<div id='show-more-wrapper'>)");
                string content = contentReg.Match(res).Value;
                if (!string.IsNullOrEmpty(content))
                {
                    // get title html 
                    var titleReg = new Regex(@"<div class='title'>[\s\S]+?<\/div>");
                    MatchCollection matTitle = titleReg.Matches(content);

                    foreach (Match titleHtml in matTitle)
                    {
                        // get detail link
                        var hrefReg = new Regex(@"(?<=href="")[\s\S]+?(?=(""))");

                        var href = hrefReg.Match(titleHtml.Value);

                        /*
                        *********** go to detail page company
                        */
                        string detailHtml = Functions.DownLoadUrl("https://itviec.com" + href.Value, Encoding.Default);

                        string comName = string.Empty, slogan = string.Empty, desc = string.Empty
                            , webLink = string.Empty, location = string.Empty, country = string.Empty;

                        var regName = new Regex(@"(?<=<h1 class='title'>)[\s\S]+?(?=(<\/h1>))");
                        // other html format of title
                        var regName1 = new Regex(@"(?<=<h1 class='title-when-blank'>)[\s\S]+?(?=(<\/h1>))");

                        var regSlogan = new Regex(@"(?<=<h2>)[\s\S]+?(?=(<\/h2>))");
                        var regDesc = new Regex(@"(?<=<div class='about-us paragraph'>)[\s\S]+?(?=(<\/div>))");
                        var regHrefWebLink = new Regex(@"(?<=<div class='link'>)[\s\S]+?(?=(<\/div>))");
                        var regLocation = new Regex(@"(?<=<div class='map-address'>)[\s\S]+?(?=(<\/div>))");

                        var regNameAndInfo = new Regex(@"(?<=<div class='name-and-info'>)[\s\S]+?(?=(<\/div>))");
                        var regCountry = new Regex(@"(?<=<\/i>[\s\S]<\/span>)[\s\S]+?(?=<\/span>)");

                        comName = regName.Match(detailHtml).Value;
                        if (string.IsNullOrEmpty(comName)) comName = regName1.Match(detailHtml).Value;
                        slogan = regSlogan.Match(detailHtml).Value;
                        desc = regDesc.Match(detailHtml).Value;
                        location = regLocation.Match(detailHtml).Value;

                        // get link
                        string webLinkHtml = regHrefWebLink.Match(detailHtml).Value;
                        webLink = hrefReg.Match(webLinkHtml).Value;
                        // end get link

                        string countryHtml = regNameAndInfo.Match(detailHtml).Value;
                        country = regCountry.Match(countryHtml).Value;

                        lst.Add(new Company
                        {
                            Country = country,
                            Desc = desc,
                            Location = location,
                            Slogan = slogan
                            ,
                            Name = comName,
                            WebLink = webLink
                        });
                        /*
                        *********** end
                        */
                    }
                }
              //  SaveDb(lst);
            }
         //   lvlMes.Text = "DONE";
        }
    }
}
