using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
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




            // when a method is decorated with 'async'
            // the compiler will transform the code

            // create state machine & initialize it:

            //var sm = new HttpLengthSM
            //{
            //    m_builder = AsyncTaskMethodBuilder<int>.Create(),   //Task<int>
            //    uri = uri,
            //};

            //sm.m_builder.Start(ref sm);  // start running state machine
            //return sm.m_builder.Task;   // return its task to the caller
        }

        private struct HttpLengthSM : IAsyncStateMachine
        {
            public string uri, text;      // parameters & local variables
            public AsyncTaskMethodBuilder<int> m_builder;  // Task<int>
            public int m_state;      // location
            private TaskAwaiter<string> m_awaiter;   // compiler temporary

            public void MoveNext()
            {
                throw new NotImplementedException();
            }

            public void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                throw new NotImplementedException();
            }
        }
    }
}
