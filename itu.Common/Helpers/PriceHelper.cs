using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace itu.Common.Helpers
{
    public static class PriceHelper
    {
        public static string ToPrice(this double price)
        {
            if (price == 0.0)
            {
                return "";
            }
            
            string[] split = price.ToString().Split('.');
            string result = "";

            for (int i = split[0].Length - 1; i >= 0; i--)
            {
                if (i % 3 == 0 && result != "") // TODO
                {
                    result = split[0][i] + " " + result;
                }
                else
                {
                    result = split[0][i] + result;
                }
            }

            if (split.Length > 1 && split[1].Length > 3)
            {
                result += "." + split[1].Substring(0, 2);
            }
            else if (split.Length > 1)
            {
                result += "." + split[1];
            }

            return result;
        }
    }
}
