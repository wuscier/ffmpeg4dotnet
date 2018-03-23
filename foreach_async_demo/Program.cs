using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace foreach_async_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"main thread id: {Thread.CurrentThread.ManagedThreadId}");

            Program p = new Program();

            List<string> sList = new List<string>();
            sList.Add("Michael Jordan");
            sList.Add("Steve Jobs");
            sList.Add("Bill Gates");
            sList.Add("Justin Bieber");

            sList.ForEach(async s =>
            {

                Console.WriteLine(s);

                Console.WriteLine($"ForEach before RequestAsync() thread id is:{Thread.CurrentThread.ManagedThreadId}");

                await p.RequestAsync();

                Console.WriteLine($"ForEach after RequestAsync() thread id is:{Thread.CurrentThread.ManagedThreadId}");


                // Console.WriteLine(s);
                // code after await won't execute until the task awaited completes
            });

            Console.WriteLine("done.");
            Console.ReadKey();
        }

        private async Task RequestAsync()
        {
            HttpClient httpClient = new HttpClient();

            Console.WriteLine($"RequestAsync() before GetStringAsync() thread id is:{Thread.CurrentThread.ManagedThreadId}");

            string result = await httpClient.GetStringAsync("http://www.baidu.com");

            Console.WriteLine($"RequestAsync() after GetStringAsync() thread id is:{Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine(result);
        }
    }
}
