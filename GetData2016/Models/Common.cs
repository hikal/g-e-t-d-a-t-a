using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace GetData2016.Models
{
    public class Common
    {
        public XmlDocument GetAttributeDoc()
        {
            var doc = new XmlDocument();
            doc.Load("~/Data/AttributesMapped.xml");
            return doc;
        }

        public XmlNode GetAttribute(string site, string attName)
        {
            var doc = GetAttributeDoc();
            var node = doc.SelectSingleNode("/root/site[@id='" + site + "']/att[@'"+attName+"']");
            return node;
        }
        public int GetAttributeId(string site, string attName, string keyText)
        {
            var doc = GetAttributeDoc();
            var node = doc.SelectSingleNode("/root/site[@id='" + site + "']/att[@'" + attName + "']/item[@'"+ keyText + "']");
            int i = 0;
            if (node != null)
            {
                int.TryParse(node.Attributes?["id"].Value, out i);
            }
            return i;
        }
        public static string RemoveDiacritics(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            var regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            temp = Regex.Replace(temp, "\\W+", " ");
            return
                regex.Replace(temp.Replace('đ', 'd').Replace('Đ', 'D'), String.Empty)
                    .Replace('\u0111', 'd')
                    .Replace('\u0110', 'D')
                    .ToLower();
        }

        private static string BuildUrlDisplay(string noDiacritics)
        {
            if (!string.IsNullOrEmpty(noDiacritics))
                return Regex.Replace(noDiacritics, "\\W+", "-").Trim('-');
            return string.Empty;
        }
        /// <summary>
        /// create url with format: test-data-user
        /// </summary>
        /// <param name="input">unicode text</param>
        /// <returns>text with no unicode</returns>
        public static string CreateTextUrl(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return BuildUrlDisplay(RemoveDiacritics(input));
            }
            return string.Empty;
        }
    }
}
