using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace aspnetcore_test
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebHost webHost = WebHost
                .CreateDefaultBuilder(args)
                .Build();

            webHost.Run();

            Console.WriteLine("Hello World!");
        }
    }
}
