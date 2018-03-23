using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace async_control_flow
{
    class Program
    {
        static void Main(string[] args)
        {

            FirstAsyncFunction();

        }



        private static void FirstAsyncFunction()
        {
            int id1 = Environment.CurrentManagedThreadId;

            Task<int> task = HttpLengthAsync("http://www.baidu.com");

            Debugger.Break();

            int id3 = Environment.CurrentManagedThreadId;

            Console.ReadLine();

            Debugger.Break();

            var length = task.Result;
        }

        private static async Task<int> HttpLengthAsync(string uri)
        {
            int id2 = Environment.CurrentManagedThreadId;

            Task<string> task = new HttpClient().GetStringAsync(uri);

            string text = await task;

            Debugger.Break();

            int id3 = Environment.CurrentManagedThreadId;

            return text.Length;
        }
    }
}
