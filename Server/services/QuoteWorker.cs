using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace blazorSignalR.Server.services
{
    public class QuoteWorker : BackgroundService
    {
        private readonly ILogger<QuoteWorker> logger;
        private readonly IHubContext<QuoteHub, IQuoteHub> quoteHub;
        private readonly IQuotePump quotePump;

        public QuoteWorker(ILogger<QuoteWorker> logger, IHubContext<QuoteHub, IQuoteHub> quoteHub, IQuotePump pump)
        {
            this.logger = logger;
            this.quoteHub = quoteHub;
            this.quotePump = pump;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            this.quotePump.QuoteUpdate += QuotePump_QuoteUpdate;

            await this.quotePump.RunAsync(stoppingToken);

            this.quotePump.QuoteUpdate -= QuotePump_QuoteUpdate;
        }

        private async void QuotePump_QuoteUpdate(object sender, Shared.StockQuote quote)
        {
            await this.quoteHub.Clients.All.SendQuoteInfo(quote);
        }
    }
}
