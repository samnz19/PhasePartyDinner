using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DinnerPartyRoa.Models;
using HtmlAgilityPack;

namespace DinnerPartyRoa.services
{
    public class Scrapper
    {
        public void Aroy()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.OptionFixNestedTags = true;

            string urlToLoad = "http://www.aroy.co.nz/menu.html";
            HttpWebRequest request = HttpWebRequest.Create(urlToLoad) as HttpWebRequest;
            request.Method = "GET";
            /* Sart browser signature */
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-us,en;q=0.5");
            /* Sart browser signature */

            WebResponse response = request.GetResponse();

            htmlDoc.Load(response.GetResponseStream(), true);
            if (htmlDoc.DocumentNode != null)
            {
                var articleNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='menulist']");

                if (articleNodes != null && articleNodes.Any())
                {
                    foreach (var articleNode in articleNodes)
                    {
                        var titleNode = articleNode.SelectSingleNode("p");


                        db.MenuItems.Add(new MenuItem() { Title = WebUtility.HtmlDecode(titleNode.InnerText.Trim()) });

                    }
                }
            }
        }
    }
}
