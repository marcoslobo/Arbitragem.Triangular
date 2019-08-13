using Binance.Net;
using System;
using Xunit;

namespace Arbitragem.Triangular.Test
{
    public class UnitTest1
    {
        [Fact]
        public void ExecutaOrdem()
        {
            BinanceClient binanceClient = new BinanceClient();
            binanceClient.SetApiCredentials(Environment.GetEnvironmentVariable("binanceApiKey"), Environment.GetEnvironmentVariable("binanceApiSecret"));

            var result = binanceClient.PlaceOrder("BNBBTC", Binance.Net.Objects.OrderSide.Buy, Binance.Net.Objects.OrderType.Market, decimal.Parse("0.1"));
        }
    }
}