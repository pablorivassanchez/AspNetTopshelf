using AspNetTopshelf.Jobs;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetTopshelf
{
    public class HangfireJobScheduler
    {
        public static void ScheduleRecurringJobs()
        {
            RecurringJob.RemoveIfExists(nameof(DumbJob));
            RecurringJob.AddOrUpdate<DumbJob>(nameof(DumbJob),
            job=>job.Run(JobCancellationToken.Null),
            Cron.Daily(5,00),TimeZoneInfo.Local);
        }
    }
}
