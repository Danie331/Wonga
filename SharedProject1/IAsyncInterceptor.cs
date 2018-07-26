using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IAsyncInterceptor
    {
        void InterceptMessageAsync(Action<string> messagedReceivedAction);
    }
}
