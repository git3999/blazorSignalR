using blazorSignalR.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace blazorSignalR.Server.services
{
    public class QuotePump : IQuotePump
    {
        public event EventHandler<StockQuote> QuoteUpdate;

        private List<StockQuote> stockQuotes = new List<StockQuote>();

        public QuotePump()
        {
            this.Init();
        }

        private void Init()
        {
            this.stockQuotes.Add(new StockQuote() { Symbol = "MSFT", Price = 80, BasePrice = 80, Volume = 2000, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "AAPL", Price = 100, BasePrice = 100, Volume = 3000, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "TSLA", Price = 350, BasePrice = 350, Volume = 120, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "NVDA", Price = 420, BasePrice = 420, Volume = 400, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "GOOG", Price = 1640, BasePrice = 1640, Volume = 110, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "AMZN", Price = 3200, BasePrice = 3200, Volume = 99, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "710000", Price = 34.845, BasePrice = 34.845, Volume = 3990203, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "703712", Price = 28.73, BasePrice = 28.73, Volume = 4972549, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "823212", Price = 6.892, BasePrice = 6.892, Volume = 9374495, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "604700", Price = 44.54, BasePrice = 44.54, Volume = 1052172, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "ENAG99", Price = 8.816, BasePrice = 8.816, Volume = 8198277, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "A0WMPJ", Price = 8.87, BasePrice = 8.87, Volume = 1715021, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "555750", Price = 12.655, BasePrice = 12.655, Volume = 16028358, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "716460", Price = 90.18, BasePrice = 90.18, Volume = 6439388, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "581005", Price = 125.3, BasePrice = 125.3, Volume = 753801, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "BASF11", Price = 46.31, BasePrice = 46.31, Volume = 3644131, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "BAY001", Price = 40.005, BasePrice = 40.005, Volume = 6964005, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "843002", Price = 196.75, BasePrice = 196.75, Volume = 808543, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "555200", Price = 29.07, BasePrice = 29.07, Volume = 4172211, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "578560", Price = 31.24, BasePrice = 31.24, Volume = 12094230, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "520000", Price = 88.94, BasePrice = 88.94, Volume = 408959, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "606214", Price = 31.98, BasePrice = 31.98, Volume = 1767693, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "A0D9PT", Price = 130, BasePrice = 130, Volume = 254502, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "604843", Price = 78.84, BasePrice = 78.84, Volume = 800386, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "A2DSYC", Price = 173.65, BasePrice = 173.65, Volume = 1248213, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "578580", Price = 64.86, BasePrice = 64.86, Volume = 1189784, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "A1EWWW", Price = 224.1, BasePrice = 224.1, Volume = 747668, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "A1ML7J", Price = 52.4, BasePrice = 52.4, Volume = 14648193, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "766403", Price = 123.42, BasePrice = 123.42, Volume = 1124661, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "846900", Price = 11463.9, BasePrice = 11463.9, Volume = 100607290, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "623100", Price = 18.936, BasePrice = 18.936, Volume = 4419546, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "519000", Price = 54.39, BasePrice = 54.39, Volume = 1694979, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "840400", Price = 149.32, BasePrice = 149.32, Volume = 1288010, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "703000", Price = 61.58, BasePrice = 61.58, Volume = 178345, Time = DateTime.Now });
            this.stockQuotes.Add(new StockQuote() { Symbol = "543900", Price = 81.72, BasePrice = 81.72, Volume = 450792, Time = DateTime.Now });

        }

        public async Task RunAsync(CancellationToken stopToken)
        {
            int i = 0;

            Random rndPrice = new Random();
            Random rndVol = new Random();
            Random rndIdx = new Random();

            while (!stopToken.IsCancellationRequested)
            {
                i = (int)(rndIdx.NextDouble() * this.stockQuotes.Count);

                if (i < this.stockQuotes.Count)
                {
                    var quote = this.stockQuotes[i];

                    var p = quote.Price * (((rndPrice.NextDouble() - 0.48d) / 1000d) + 1d);
                    quote.Price = Math.Round(p, 2);
                    quote.Volume = (int)(rndVol.NextDouble() * 3000d / p);
                    quote.Time = DateTime.Now;

                    this.QuoteUpdate?.Invoke(this, quote);
                }

                await Task.Delay(50);
            }
        }
    }
}
