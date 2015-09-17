using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace DouBanDownLoad
{
    public class DownLoadHelper
    {

        private WebClient wc = new WebClient();
        public void DownLoadFile(string url, string localfilename)
        {
            try
            {
                wc.DownloadFile(url, localfilename);
            }
            catch (Exception ex)
            {

            }

        }

        /// <summary>
        /// Get the total page count with the htmlweb 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public int GetThePageCount(string url)
        {
            string mycount = "0";
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(url);
            var count = doc.DocumentNode.SelectSingleNode("//span[@class='thispage']");

            if (count != null)
            {
                mycount = count.Attributes["data-total-page"].Value;
            }
            //Check if this is the real count number 
            if (string.IsNullOrWhiteSpace(mycount) || !ToolKit.CheckIsNumber(mycount))
            {
                mycount = "0";
            }
            return Convert.ToInt32(mycount);
        }

    }
}
