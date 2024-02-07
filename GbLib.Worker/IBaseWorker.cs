using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Worker
{
    public interface IBaseWorker
    {
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
