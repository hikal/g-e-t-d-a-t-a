using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GetData2016
{
    public static class Functions
    {
        public static string DownLoadUrl(string url)
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
        public static void LoadAndSaveXml(string content)
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
    }
}
