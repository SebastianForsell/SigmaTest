using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> test = new List<string> { "joder", "caca", "dsgdsgdsgs", "abc", "det", "zet", "abcde" };

            var test2 = test.OrderBy(s => s.Length).ThenBy(s => s).ToList();

            Console.ReadKey();
        }
    }
}
