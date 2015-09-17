using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace DouBanDownLoad
{
    public class ImgInfo
    {
        public string Downloadurl { get; set; }
        /// <summary>
        /// absoulte path 
        /// </summary>
        public string ImgName { get; set; }


        public string Localpath { get; set; }

        /// <summary>
        /// Get List Page Info
        /// </summary>
        /// <param name="htmlinfo"></param>
        /// <returns></returns>
        public List<ImgInfo> GetListByContent(string urlinfo)
        {
            List<ImgInfo> list = new List<ImgInfo>();

            if (string.IsNullOrEmpty(urlinfo))
            {
                throw new Exception("plesae input url info!!!");
            }
            HtmlWeb web = new HtmlWeb();
            list = Regex.Matches(web.Load(urlinfo).DocumentNode.InnerHtml, @"(?is)<div class=""photo_wrap"">\s*.*?<img src=""(?<imgurl>.*?)"">")
                  .OfType<Match>()
                  .Select(p => new ImgInfo { ImgName = DoPath(p.Groups["imgurl"].Value.ToString()), Downloadurl = p.Groups["imgurl"].Value.ToString() })
                  .ToList<ImgInfo>();
            //将缩小图转成大图
            //list.ForEach(x =>
            //{
            //    if (x.Downloadurl.Contains("thumb"))
            //    {
            //        x.Downloadurl = x.Downloadurl.Replace("thumb", "public");
            //    }
            //});
            return list;

        }


        /// <summary>
        /// Get the img list with the xpath 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="imgtype"></param>
        /// <returns></returns>
        public List<ImgInfo> GetListByXpath(string url, ImgType imgtype)
        {
            HtmlWeb web = new HtmlWeb();
            List<ImgInfo> list = new List<ImgInfo>();
            list = web.Load(url)
                .DocumentNode
                .SelectNodes("//a[@class='photolst_photo']/img")
                .Select(p => new ImgInfo { ImgName = DoPath(p.Attributes["src"].Value), Downloadurl = p.Attributes["src"].Value })
                .ToList<ImgInfo>();
            if (imgtype == ImgType.Medium)
            {
                list.ForEach(x =>
                {
                    if (x.Downloadurl.Contains("thumb"))
                    {
                        x.Downloadurl = x.Downloadurl.Replace("thumb", "photo");
                    }
                });
            }


            return list;
        }

        private string DoPath(string nameinfo)
        {
            return Localpath + "\\" + Regex.Match(nameinfo, @"public/(.*?jpg)").Groups[1].Value.ToString();
        }
    }
}
