using Microsoft.AspNetCore.Hosting;

namespace AspNetTopshelf
{
    public class MainService
    {
        private IWebHost _webHost;
        private readonly string _contentRoot;

        public MainService(string contentRoot)
        {
            _contentRoot = contentRoot;
        }

        public void Start()
        {
            _webHost = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(_contentRoot)
                .UseStartup<Startup>()
                .Build();

            _webHost.Start();
        }

        public void Stop()
        {
            _webHost?.Dispose();
        }
    }
}
