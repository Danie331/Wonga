using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IAsyncDispatcher
    {
        Task DispatchMessageAsync(string message);
    }
}
