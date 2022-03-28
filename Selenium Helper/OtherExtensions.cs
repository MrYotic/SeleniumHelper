using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Helper;

public static class OtherExtensions
{
    public static string MultiReplace(this string str, params (string, string)[] args)
    {
        args.ToList().ForEach(z => {
            str = str.Replace(z.Item1, z.Item2);
        });
        return str;
    }
    public static string DictionaryReplace(this string str, Dictionary<string, string> args)
    {
        args.ToList().ForEach(z => {
            str = str.Replace(z.Key, z.Value);
        });
        return str;
    }
}
