using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FuckingPricesApp
{   // Класс нужен для сортировки называний изображений
    public class MyComparer : IComparer<string>
    {
        private readonly Regex regex = new Regex(@"(\d+)([a-z]?)");
        public int Compare(string x, string y)
        {
            Match m1 = regex.Match(x);
            Match m2 = regex.Match(y);
            string num1 = m1.Groups[1].Value;
            string num2 = m2.Groups[1].Value;
            if (num1.Length < num2.Length)
                return -1;
            if (num1.Length > num2.Length)
                return 1;
            int cmp = string.Compare(num1, num2);
            if (cmp != 0)
                return cmp;
            return string.Compare(m1.Groups[2].Value, m2.Groups[2].Value);
        }
    }
}
