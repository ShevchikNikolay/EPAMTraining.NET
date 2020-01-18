using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar
{
    public static class Plural
    {
        public static string Convert(string singular)
        {
            //TODO: to implement proper formation of plural.

            var result = $"{singular}s";

            return result;
        }
    }
}
