using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using DinnerPartyRoa.Models;
using HtmlAgilityPack;

using MenuItem = DinnerPartyRoa.Models.MenuItem;

namespace DinnerPartyRoa.services
{
    public class Scrapper
    {
        ApplicationDbContext db = new ApplicationDbContext();
        string urlToLoad = "http://www.aroy.co.nz/";


        public byte[] Imageextraction(string realtiveUrl)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlToLoad);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/jpeg"));


                HttpResponseMessage response = client.GetAsync(realtiveUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsByteArrayAsync().Result;
                }

            }
            return null;

        }

        public List<MenuItem> GetList()
        {
            List<MenuItem> menulist = new List<MenuItem>();


            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.OptionFixNestedTags = true;


            HttpWebRequest request = WebRequest.Create(urlToLoad + "menu.html") as HttpWebRequest;
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
                        var imageNode = articleNode.SelectSingleNode("a/img");

                        var title = WebUtility.HtmlDecode(titleNode.InnerText.Trim());

                        if (!string.IsNullOrEmpty(title))
                        {
                            byte[] image = null;
                            if (imageNode != null)
                            {
                                image = Imageextraction(imageNode.GetAttributeValue("src", "wrong"));
                            }
                            MenuItem menuitem = new MenuItem()
                            {
                                Title = WebUtility.HtmlDecode(titleNode.InnerText.Trim()),
                                Image = image
                            };
                            menulist.Add(menuitem);
                        }
                    }
                }


            }
            return menulist;
        }

        private void SaveItems(List<MenuItem> items)
        {
            db.MenuItems.AddRange(items);
            db.SaveChanges();
        }



        public void GetAndSave()
        {
            List<MenuItem> list = GetList();
            SaveItems(list);
        }
    }
}
