using blazorSignalR.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace blazorSignalR.Server.services
{
    public interface IQuotePump
    {
        event EventHandler<StockQuote> QuoteUpdate;

        Task RunAsync(CancellationToken stopToken);
    }
}
