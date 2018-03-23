using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace foreach_async_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            List<string> sList = new List<string>();
            sList.Add("Michael Jordan");
            sList.Add("Steve Jobs");
            sList.Add("Bill Gates");
            sList.Add("Justin Bieber");

            sList.ForEach(async s =>
            {

                Console.WriteLine(s);

                await p.RequestAsync(); 
            });

            Console.WriteLine("done.");
            Console.ReadKey();
        }

        private async Task RequestAsync()
        {
            HttpClient httpClient = new HttpClient();

            string result = await httpClient.GetStringAsync("http://www.baidu.com");

            Console.WriteLine(result);
        }
    }
}
