using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringLibrary
{
    public class StringService : IStringService
    {
        public int WordCount(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new StringException("Строка не может быть пустой или состоять из пробелов.");

            return text.Split(new[] { ' ', '\t', '\n' },
                              StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public string Reverse(string text)
        {
            if (text == null)
                throw new StringException("Строка не может быть null.");

            return new string(text.Reverse().ToArray());
        }

        public bool IsPalindrome(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new StringException("Строка не может быть пустой.");

            var clean = new string(text.Where(char.IsLetterOrDigit).ToArray()).ToLower();
            var reversed = new string(clean.Reverse().ToArray());
            return clean == reversed;
        }
    }
}
