using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringLibrary.Tests
{
    public class StringServiceTests
    {
        private readonly StringService _svc = new StringService();

        [Fact]
        public void WordCount_Works()
        {
            Assert.Equal(3, _svc.WordCount("привет мир тест"));
        }

        [Fact]
        public void Reverse_Works()
        {
            Assert.Equal("cba", _svc.Reverse("abc"));
        }

        [Fact]
        public void IsPalindrome_Works()
        {
            Assert.True(_svc.IsPalindrome("А роза упала на лапу Азора"));
        }

        [Fact]
        public void WordCount_Empty_Throws()
        {
            var ex = Assert.Throws<StringException>(() => _svc.WordCount("   "));
            Assert.Contains("пустой", ex.Message);
        }

        [Fact]
        public void Reverse_Null_Throws()
        {
            Assert.Throws<StringException>(() => _svc.Reverse(null));
        }

        [Fact]
        public void TryCatchFinally_ContinuesWorking()
        {
            string log = "";
            try
            {
                _svc.WordCount("");
                log += "не должно выполниться;";
            }
            catch (StringException ex)
            {
                log += $"поймано: {ex.Message};";
            }
            finally
            {
                log += "finally выполнен;";
            }

            int result = _svc.WordCount("раз два три");
            log += $"слов после ошибки = {result}";

            Assert.Contains("поймано:", log);
            Assert.Contains("finally выполнен", log);
            Assert.Contains("= 3", log);
        }
    }
}