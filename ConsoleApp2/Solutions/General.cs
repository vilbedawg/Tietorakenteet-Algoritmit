using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmit
{
    public class General
    {
        public bool IsPalindrome(string s)
        {
            for (int i = 0, j = s.Length - 1; i < j;)
            {
                var left = s[i];
                if (!Char.IsLetterOrDigit(left))
                {
                    i++;
                    continue;
                }

                var right = s[j];
                if (!Char.IsLetterOrDigit(right))
                {
                    j--;
                    continue;
                }

                if (Char.ToLower(left) != Char.ToLower(right))
                {
                    return false;
                }

                i++;
                j--;
            }

            return true;
        }

        public int MaxNumberOfBalloons(string text)
        {
            if (text.Length < 7) return 0;

            Dictionary<char, int> dic = new Dictionary<char, int>();
            string balloon = "balon";

            foreach(char c in text)
            {
                if(balloon.IndexOf(c) != -1)
                {
                    if (dic.ContainsKey(c))
                        dic[c]++;
                    else
                        dic.Add(c, 1);
                }
            }

            if (dic.Count < 5) return 0;

            dic['l'] = dic['l'] / 2;
            dic['o'] = dic['o'] / 2;
            int highest = dic['b'];
            highest = Math.Min(highest, dic['a']);
            highest = Math.Min(highest, dic['l']);
            highest = Math.Min(highest, dic['o']);
            highest = Math.Min(highest, dic['n']);
            return highest;
        }
        public string Convert(string s, int numRows)
        {
            if (numRows == 1) return s;

            var lst = new StringBuilder[numRows];

            for (int i = 0; i < numRows; i++)
            {
                lst[i] = new StringBuilder();
            }

            int index = 0;
            int increment = 1;

            foreach (var c in s)
            {
                lst[index].Append(c);
                index += increment;

                if (index == numRows - 1 || index == 0)
                {
                    increment *= -1;
                }
            }

            var sb = new StringBuilder();

            for (int i = 0; i < numRows; i++)
            {
                sb.Append(lst[i]);
            }

            return sb.ToString();
        }
    }
}
