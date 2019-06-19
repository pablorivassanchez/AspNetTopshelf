using System;
using System.Threading.Tasks;

namespace AspNetTopshelf.Jobs
{
    public interface IJob
    {
        Task RunAtTimeOf(DateTime now);
    }
}
