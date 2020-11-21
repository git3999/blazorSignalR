using System;
using System.Collections.Generic;
using System.Text;

namespace blazorSignalR.Shared
{
    public class StockQuote
    {
        public event EventHandler QuoteUpdated;

        public string Symbol { get; set; }
        public double Price { get; set; }
        public double BasePrice { get; set; }
        public double RecentPrice { get; private set; }
        public double Percent
        {
            get
            {
                return (BasePrice == 0) ? 0 : (Price / BasePrice * 100d) - 100d;
            }
        }

        public bool PriceRise { get; private set; }
        public int Volume { get; set; }
        public DateTime Time { get; set; }

        public void UpdateQuoteData(StockQuote newValues)
        {
            this.PriceRise = newValues.Price > this.RecentPrice;

            this.RecentPrice = this.Price;
            this.Price = newValues.Price;
            this.Volume = newValues.Volume;
            this.Time = newValues.Time;

            this.QuoteUpdated?.Invoke(this, new EventArgs());
        }
    }
}
