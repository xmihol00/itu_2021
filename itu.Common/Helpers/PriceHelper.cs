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
            int mod = 3 - split[0].Length % 3;

            
            for (int i = 0; i < split[0].Length; i++)
            {
                if ((i + mod) % 3 == 0 && result != "")
                {
                    result = result + " " + split[0][i];
                }
                else
                {
                    result = result + split[0][i];
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
