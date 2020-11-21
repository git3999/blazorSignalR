using blazorSignalR.Shared;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorSignalR.Server.services
{
    public static class UserHandler
    {
        public static HashSet<string> ConnectedIds = new HashSet<string>();
    }

    public class QuoteHub : Hub<IQuoteHub>
    {
        public override async Task OnConnectedAsync()
        {
            UserHandler.ConnectedIds.Add(Context.ConnectionId);

            var msg = $"{Context.ConnectionId} joined the hub (Instance:{this.GetHashCode()})  clients-cnt:{UserHandler.ConnectedIds.Count}";
            await Clients.All.QuoteHubMessage(msg).ConfigureAwait(false);

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);

            var msg = $"{Context.ConnectionId} left the hub (Instance:{this.GetHashCode()})  clients-cnt:{UserHandler.ConnectedIds.Count}";
            await Clients.All.QuoteHubMessage(msg);
            await base.OnDisconnectedAsync(exception);
        }

        public Task QuoteHubMessage(string msg)
        {
            return Clients.All.QuoteHubMessage(msg);
        }

        public Task SendQuote(StockQuote quote)
        {
            return Clients.All.SendQuoteInfo(quote);
        }
    }
}
