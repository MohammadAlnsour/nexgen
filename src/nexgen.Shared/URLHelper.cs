using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace nexgen.Shared
{
    public static class URLHelper
    {
        public static string ReplaceSpecialCharactersAndSpace(this string source, string replacement)
        {
            return Regex.Replace(source, @"([^\w]+)", replacement);
        }
    }
}
