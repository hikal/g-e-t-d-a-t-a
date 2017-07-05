using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using GetData2016.Models;
using System.Web;

namespace GetData2016
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //var doc = new XmlDocument();
            //doc.Load("ItViec.xml");
            //lvlMes.Text = doc.SelectNodes("/root/content").Count.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string linkTpl = "https://itviec.com/companies/-?page={0}";

            for (int i = 1; i <= 55; i++)
            {
                string res = DownLoadUrl(string.Format(linkTpl, i));

                var contentReg = new Regex(@"<div class='first-group'>[\s\S]+(?=<div id='show-more-wrapper'>)");
                string content = contentReg.Match(res).Value;
                if (!string.IsNullOrEmpty(content))
                {
                    LoadAndSaveXml(content);
                }
            }
            lvlMes.Text = "DONE";
        }

        private void LoadAndSaveXml(string content)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load("ItViec.xml");

                XmlNode root = doc.DocumentElement;

                var contentElm = doc.CreateElement("content");
                var cdata = doc.CreateCDataSection("cdata");
                cdata.InnerText = content;

                contentElm.AppendChild(cdata);

                if (root != null)
                {
                    root.AppendChild(contentElm);
                    doc.Save("ItViec.xml");
                }
            }
            catch (Exception)
            {
                lvlMes.Text = "Has an error on xml file";
                throw;
            }
        }
        private void SaveDb(IList<Company> lstCompanies)
        {
            try
            {
                var context = new ITViecEntities();
                foreach (var lstCompany in lstCompanies)
                {
                    context.Companies.Add(lstCompany);
                }
                
                context.SaveChanges();
            }
            catch (Exception ee)
            {
                lvlMes.Text = "Error on save DB";
                throw;
            }
        }
        private string DownLoadUrl(string url)
        {
            string res = string.Empty;

            try
            {
                using (var web = new WebClient())
                {
                    res = web.DownloadString(url);
                }
            }
            catch (Exception)
            {

            }
            return res;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string linkTpl = "https://itviec.com/companies/-?page={0}";

            for (int i = 1; i <= 55; i++)
            {
                IList<Company> lst = new List<Company>();

                string res = DownLoadUrl(string.Format(linkTpl, i));

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
                        string detailHtml = DownLoadUrl("https://itviec.com" + href.Value);
                        
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
                        if(string.IsNullOrEmpty(comName)) comName = regName1.Match(detailHtml).Value;
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
                            Country = country , Desc = desc, Location = location, Slogan = slogan
                            , Name = comName, WebLink = webLink
                        });
                        /*
                        *********** end
                        */
                    }  
                }
                SaveDb(lst);
            }
            lvlMes.Text = "DONE";
        }

        private void btnGetXeHoiChoTot_Click(object sender, EventArgs e)
        {
            var cls = new XeHoi();
            int from;
            int.TryParse(txtFromPage.Text, out from);
            int to;
            int.TryParse(txtToPage.Text, out to);

         //   cls.ChoTotXeHoiGetDataXe(from, to);
            cls.BxhGetData(from, to);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
