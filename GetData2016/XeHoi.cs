﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GetData2016.Models;

namespace GetData2016
{
    public class XeHoi
    {
        public XeHoi()
        {
            
        }

        public void GetData()
        {
            string linkTpl = "https://itviec.com/companies/-?page={0}";

            for (int i = 1; i <= 55; i++)
            {
                IList<Company> lst = new List<Company>();

                string res = Functions.DownLoadUrl(string.Format(linkTpl, i));

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
                        string detailHtml = Functions.DownLoadUrl("https://itviec.com" + href.Value);

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
