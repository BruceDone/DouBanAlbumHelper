using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DouBanDownLoad
{
    public static class ToolKit
    {

        /// <summary>
        /// Check if it is the Douban URL 
        /// </summary>
        /// <param name="txt">string to be inputed </param>
        /// <returns></returns>
        public static bool CheckUrl(string txt)
        {
            return Regex.IsMatch(txt, "^http://www[.]douban[.]com/photos/album/[0-9]+/$");
        }

        public static bool CheckIsNumber(string txt)
        {
            return Regex.IsMatch(txt, "^\\d+$");
        }
    }

    public enum ImgType
    {
        Big = 1,
        Medium = 2,
        Small = 3
    }
}
