using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DinnerPartyRoa.Models;
using HtmlAgilityPack;
using Microsoft.Owin.Security.Provider;

namespace DinnerPartyRoa.services
{
   public class Scrapper
   {
       string urlToLoad = "http://www.aroy.co.nz/";

        public  void Aroy()
        {
            ApplicationDbContext db=new ApplicationDbContext();
    
            HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.OptionFixNestedTags = true;


            HttpWebRequest request = HttpWebRequest.Create(urlToLoad + "menu.html") as HttpWebRequest;
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
                        var imageUrl=Imageextraction(imageNode.GetAttributeValue("src","wrong"));


                        var pelement = new MenuItem() {Title = title};
                        var imagelement = new MenuItem() {Image = null};

                        db.MenuItems.Add(pelement);
                        db.MenuItems.Add(imagelement);
                        db.SaveChanges();
                    }
                }


            }

       


     
        }

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
    }
}
