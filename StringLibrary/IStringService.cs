using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringLibrary
{
    public interface IStringService
    {
        int WordCount(string text);
        string Reverse(string text);
        bool IsPalindrome(string text);
    }
}