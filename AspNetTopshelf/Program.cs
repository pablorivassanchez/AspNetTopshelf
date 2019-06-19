using System;
using System.IO;
using Topshelf;

namespace AspNetTopshelf
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<MainService>(s =>
                {
                    s.ConstructUsing(n => new MainService(Directory.GetCurrentDirectory()));
                    s.WhenStarted(service => service.Start());
                    s.WhenStopped(service => service.Stop());
                });

                x.RunAsLocalSystem();
            });
        }
    }
}
