using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetTopshelf.Jobs
{
    public class DumbJob : IJob
    {
        private readonly ILogger<DumbJob> _logger;

        public DumbJob(ILogger<DumbJob> logger)
        {
            _logger = logger;
        }

        public async Task Run(IJobCancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            await RunAtTimeOf(DateTime.Now);
        }

        public async Task RunAtTimeOf(DateTime now)
        {
            _logger.LogInformation("My DumbJob Starts...");

            _logger.LogInformation("My DumbJob Completed.");

            await Task.Factory.StartNew(() => Thread.Sleep(10));
        }
    }
}
