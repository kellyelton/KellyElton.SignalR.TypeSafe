namespace HubServer
{
    using System;
    using System.Threading;

    using Microsoft.AspNet.SignalR;
    using Microsoft.Owin.Hosting;

    using Owin;

    class Program
    {
        internal static IDisposable Host;
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Hub");
            Host = WebApplication.Start<Setup>("http://localhost:12345");
            Console.WriteLine("Hub Started");

            Console.WriteLine("Press the q key to quit.");

            var keepRunning = true;
            while (keepRunning)
            {
                if (Console.KeyAvailable) if (Console.ReadKey().Key == ConsoleKey.Q) keepRunning = false;
                Thread.Sleep(10);
            }
        }
    }
    public class Setup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapHubs(new HubConfiguration());
        }
    }
}
