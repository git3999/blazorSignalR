using blazorSignalR.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorSignalR.Server.services
{
    public interface IQuoteHub
    {
        Task SendQuoteInfo(StockQuote quote);

        Task QuoteHubMessage(string msg);
    }
}
