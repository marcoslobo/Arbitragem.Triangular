using Binance.Net;
using Binance.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Arbitragem.Triangular
{
    internal class Program
    {
        public static System.Collections.ArrayList array = new System.Collections.ArrayList();
        private static List<BinanceStreamBalance> balances = null;
        private static BinanceClient binanceClient = new BinanceClient();
        private static BinanceSocketClient binanceSocketClient = new BinanceSocketClient();
        private static System.Data.DataSet dsSearch = new System.Data.DataSet();
        private static ExchangeBinance exchangeBinance = new ExchangeBinance();
        private static decimal initialValue = 0;
        private static string[] markets = null;
        static private object objLockOrders = new object();
        private static bool ok = true;
        private static decimal percValue = 0;

        /// <summary>
        /// Criação dos pares para triangular
        /// </summary>
        /// <returns></returns>
        public static string[] getArrayTriangularArbitrage()
        {
            StringBuilder sb = new StringBuilder();
            String market = null;

            market = "ETH";
            foreach (var item in ExchangeBinance.exchangeInfo["symbols"])
            {
                String pairs = market + "BTC:";
                bool add = false;
                if (item["symbol"].ToString().Substring(item["symbol"].ToString().Length - 3, 3) == market)
                {
                    pairs += item["symbol"].ToString() + ":";
                    String auxPair = item["symbol"].ToString().Replace(market, "");
                    foreach (var item2 in ExchangeBinance.exchangeInfo["symbols"])
                    {
                        if (item2["symbol"].ToString() == auxPair + "BTC")
                            if (item2["status"].ToString().Trim().ToUpper() == "TRADING")
                            {
                                add = true;
                                pairs += item2["symbol"].ToString() + ";";
                            }
                    }
                }
                if (add)
                    sb.Append(pairs);
            }

            market = "BNB";
            foreach (var item in ExchangeBinance.exchangeInfo["symbols"])
            {
                String pairs = market + "BTC:";
                bool add = false;
                if (item["symbol"].ToString().Substring(item["symbol"].ToString().Length - 3, 3) == market)
                {
                    pairs += item["symbol"].ToString() + ":";
                    String auxPair = item["symbol"].ToString().Replace(market, "");
                    foreach (var item2 in ExchangeBinance.exchangeInfo["symbols"])
                    {
                        if (item2["symbol"].ToString() == auxPair + "BTC")
                            if (item2["status"].ToString().Trim().ToUpper() == "TRADING")
                            {
                                add = true;
                                pairs += item2["symbol"].ToString() + ";";
                            }
                    }
                }
                if (add)
                    sb.Append(pairs);
            }

            market = "BTC";
            foreach (var item in ExchangeBinance.exchangeInfo["symbols"])
            {
                String pairs = "";
                bool add = false;
                if (item["symbol"].ToString().Substring(item["symbol"].ToString().Length - 3, 3) == market)
                {
                    pairs += item["symbol"].ToString() + ":";
                    String auxPair = item["symbol"].ToString().Replace(market, "");
                    foreach (var item2 in ExchangeBinance.exchangeInfo["symbols"])
                    {
                        if (item2["symbol"].ToString() == auxPair + "ETH")
                            if (item2["status"].ToString().Trim().ToUpper() == "TRADING")
                            {
                                add = true;
                                pairs += item2["symbol"].ToString() + ":";
                                pairs += "ETHBTC;";
                            }
                    }
                }
                if (add)
                    sb.Append(pairs);
            }

            market = "BTC";
            foreach (var item in ExchangeBinance.exchangeInfo["symbols"])
            {
                String pairs = "";
                bool add = false;
                if (item["symbol"].ToString().Substring(item["symbol"].ToString().Length - 3, 3) == market)
                {
                    pairs += item["symbol"].ToString() + ":";
                    String auxPair = item["symbol"].ToString().Replace(market, "");
                    foreach (var item2 in ExchangeBinance.exchangeInfo["symbols"])
                    {
                        if (item2["symbol"].ToString() == auxPair + "BNB")
                            if (item2["status"].ToString().Trim().ToUpper() == "TRADING")
                            {
                                add = true;
                                pairs += item2["symbol"].ToString() + ":";
                                pairs += "BNBBTC;";
                            }
                    }
                }
                if (add)
                    sb.Append(pairs);
            }

            market = "BTC";
            foreach (var item in ExchangeBinance.exchangeInfo["symbols"])
            {
                String pairs = "";
                bool add = false;
                if (item["symbol"].ToString().Substring(item["symbol"].ToString().Length - 3, 3) == market)
                {
                    pairs += item["symbol"].ToString() + ":";
                    String auxPair = item["symbol"].ToString().Replace(market, "");
                    foreach (var item2 in ExchangeBinance.exchangeInfo["symbols"])
                    {
                        if (item2["symbol"].ToString() == auxPair + "USDT")
                            if (item2["status"].ToString().Trim().ToUpper() == "TRADING")
                            {
                                add = true;
                                pairs += item2["symbol"].ToString() + ":";
                                pairs += "BTCUSDT;";
                            }
                    }
                }
                if (add)
                    sb.Append(pairs);
            }

            market = "BTC";
            foreach (var item in ExchangeBinance.exchangeInfo["symbols"])
            {
                String pairs = "";
                bool add = false;
                if (item["symbol"].ToString().Substring(item["symbol"].ToString().Length - 3, 3) == market)
                {
                    pairs += item["symbol"].ToString() + ":";
                    String auxPair = item["symbol"].ToString().Replace(market, "");
                    foreach (var item2 in ExchangeBinance.exchangeInfo["symbols"])
                    {
                        if (item2["symbol"].ToString() == auxPair + "PAX")
                            if (item2["status"].ToString().Trim().ToUpper() == "TRADING")
                            {
                                add = true;
                                pairs += item2["symbol"].ToString() + ":";
                                pairs += "BTCPAX;";
                            }
                    }
                }
                if (add)
                    sb.Append(pairs);
            }

            market = "BTC";
            foreach (var item in ExchangeBinance.exchangeInfo["symbols"])
            {
                String pairs = "";
                bool add = false;
                if (item["symbol"].ToString().Substring(item["symbol"].ToString().Length - 3, 3) == market)
                {
                    pairs += item["symbol"].ToString() + ":";
                    String auxPair = item["symbol"].ToString().Replace(market, "");
                    foreach (var item2 in ExchangeBinance.exchangeInfo["symbols"])
                    {
                        if (item2["symbol"].ToString() == auxPair + "USDC")
                            if (item2["status"].ToString().Trim().ToUpper() == "TRADING")
                            {
                                add = true;
                                pairs += item2["symbol"].ToString() + ":";
                                pairs += "BTCUSDC;";
                            }
                    }
                }
                if (add)
                    sb.Append(pairs);
            }

            market = "BTC";
            foreach (var item in ExchangeBinance.exchangeInfo["symbols"])
            {
                String pairs = "";
                bool add = false;
                if (item["symbol"].ToString().Substring(item["symbol"].ToString().Length - 3, 3) == market)
                {
                    pairs += item["symbol"].ToString() + ":";
                    String auxPair = item["symbol"].ToString().Replace(market, "");
                    foreach (var item2 in ExchangeBinance.exchangeInfo["symbols"])
                    {
                        if (item2["symbol"].ToString() == auxPair + "TUSD")
                            if (item2["status"].ToString().Trim().ToUpper() == "TRADING")
                            {
                                add = true;
                                pairs += item2["symbol"].ToString() + ":";
                                pairs += "TUSD;";
                            }
                    }
                }
                if (add)
                    sb.Append(pairs);
            }

            //sb.Clear();
            //sb.Append("XRPBTC:XRPUSDT:BTCUSDT;");
            //sb.Append("THETABTC:THETAETH:ETHBTC;");
            //sb.Append("LINKBTC:LINKETH:ETHBTC;");
            //sb.Append("FETBTC:FETETH:ETHBTC;");
            //sb.Append("XMRBTC:XMRETH:ETHBTC;");
            //sb.Append("ETHBTC:XMRETH:XMRBTC;");
            //sb.Append("NULSBTC:NULSETH:ETHBTC;");

            Random rnd = new Random();
            string[] MyRandomArray = sb.ToString().Split(';').OrderBy(x => rnd.Next()).ToArray();
            Console.Title = MyRandomArray.Length.ToString() + " PARES TOTAIS";
            return MyRandomArray;
        }

        private static decimal calcPerc(decimal more, decimal less)
        {
            return ((more * 100) / less) - 100;
        }

        private static void config()
        {
            String configJson = System.IO.File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}config.json");
            Newtonsoft.Json.Linq.JContainer jContainer = (Newtonsoft.Json.Linq.JContainer)JsonConvert.DeserializeObject(configJson);

            Key.key = Environment.GetEnvironmentVariable("binanceApiKey");
            Key.secret = Environment.GetEnvironmentVariable("binanceApiSecret");
            initialValue = decimal.Parse(jContainer["initialValue"].ToString(), System.Globalization.NumberStyles.Float);
            percValue = decimal.Parse(jContainer["percValue"].ToString(), System.Globalization.NumberStyles.Float);
        }

        private static decimal getBalance(string pair)
        {
            if (balances != null)
                foreach (var item in balances)
                    if (item.Asset.Trim().ToUpper() == pair.Trim().ToUpper())
                        return item.Free;

            return 0;
        }

        /// <summary>
        /// Load nos orders books dos pares via socket
        /// </summary>
        private static void initializeSockets()
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.Tables.Add("Symbol");
            ds.Tables["Symbol"].Columns.Add("Pair");

            ds.Tables["Symbol"].Clear();
            loadDataDetailSocket("btcusdt");
            loadDataDetailSocket("btcpax");
            loadDataDetailSocket("btctusd");
            loadDataDetailSocket("btcusdc");
            loadDataDetailSocket("ethbtc");
            loadDataDetailSocket("bnbbtc");
            loadDataDetailSocket("bnbeth");
            loadDataDetailSocket("ethbnb");

            ds.Tables["Symbol"].Rows.Add("btcusdt");
            ds.Tables["Symbol"].Rows.Add("btcpax");
            ds.Tables["Symbol"].Rows.Add("btctusd");
            ds.Tables["Symbol"].Rows.Add("btcusdc");
            ds.Tables["Symbol"].Rows.Add("ethbtc");
            ds.Tables["Symbol"].Rows.Add("bnbbtc");
            ds.Tables["Symbol"].Rows.Add("bnbeth");
            ds.Tables["Symbol"].Rows.Add("ethbnb");

            for (int i = 0; i < markets.Length; i++)
            {
                try
                {
                    if (markets[i] != "")
                    {
                        String[] pair = markets[i].ToLower().Split(':');
                        for (int z = 0; z < pair.Length; z++)
                        {
                            bool insert = true;
                            for (int x = 0; x < ds.Tables["Symbol"].Rows.Count; x++)
                                if (ds.Tables["Symbol"].Rows[x][0].ToString().ToLower().Trim() == pair[z].ToLower().Trim())
                                    insert = false;

                            if (insert)
                            {
                                ds.Tables["Symbol"].Rows.Add(pair[z]);
                                Thread t = new Thread(loadDataDetailSocket);
                                t.Start(pair[z]);
                                t.Join();
                                //System.Threading.Thread.Sleep(1000);
                            }
                        }
                    }
                }
                catch { }
            }
        }

        private static decimal lessPercent(decimal value, decimal perc)
        {
            return value - ((value * perc) / 100);
        }

        private static void loadDataDetailSocket(object obj)
        {
            try
            {
                ClassDetailOrder classDetailOrder = new ClassDetailOrder();
                classDetailOrder.symbol = obj.ToString().ToLower();
                array.Add(classDetailOrder);

                Console.WriteLine("loadDataDetail " + classDetailOrder.symbol);

                var successOrderBook = binanceSocketClient.SubscribeToPartialBookDepthStream(obj.ToString().ToLower(), 20, (data) =>
                {
                    try
                    {
                        for (int i = 0; i < array.Count; i++)
                            if ((array[i] as ClassDetailOrder).symbol.ToLower().Trim() == data.Symbol.ToLower().Trim())
                            {
                                classDetailOrder = new ClassDetailOrder();
                                classDetailOrder.symbol = obj.ToString().ToLower();
                                classDetailOrder.book = data;

                                array[i] = classDetailOrder;
                            }
                    }
                    catch (Exception ex)
                    {
                        Logger.log(ex.Message + ex.StackTrace);
                    }
                });

                while (!successOrderBook.Success)
                    System.Threading.Thread.Sleep(100);

                Logger.log("Succes | " + obj.ToString().ToLower() + " | " + successOrderBook.Success.ToString());
                if (successOrderBook.Error != null)
                    Logger.log("Error " + successOrderBook.Error.ToString());
                //if (successOrderBook.Data != null)
                //  Logger.log("Data " + successOrderBook.Data.ToString());
            }
            catch (Exception ex)
            {
                Logger.log(ex.Message + ex.StackTrace);
            }
        }

        private static void Main(string[] args)
        {
            config();
            binanceClient.SetApiCredentials(Key.key, Key.secret);

            var result = binanceClient.StartUserStream();

            while (!result.Success)
                System.Threading.Thread.Sleep(100);

            var userStream = binanceSocketClient.SubscribeToUserStream(result.Data, (data) =>
            {
                if (data != null)
                {
                    balances = data.Balances;
                }
            },
             (order) =>
             {
             }
            );

            while (!userStream.Success)
                System.Threading.Thread.Sleep(100);

            //Console.WriteLine(userStream.Success);
            //Console.WriteLine(userStream.Data);
            //Console.WriteLine(userStream.Error);

            //loadDataDetailSocket("bnbbtc");
            //loadDataDetailSocket("xrpbnb");
            //loadDataDetailSocket("xrpbtc");

            //for (int i = 0; i < 10; i++)
            //{
            //    System.Threading.Thread.Sleep(100);
            //    Console.WriteLine(i.ToString());
            //}

            //String log = exchangeBinance.order("buy", "BNBBTC", 0.05m, morePercent(exchangeBinance.getLastPrice("BNBBTC"),3));
            //while(getBalance("BNB") <= 0)
            //    System.Threading.Thread.Sleep(1);
            //decimal amount = getBalance("BNB");

            //var resultA = exchangeBinance.orderMarket("buy", "INSETH", amount);

            //while (getBalance("INS") <= 0)
            //    System.Threading.Thread.Sleep(1);
            //amount = getBalance("INS");

            //while (true)
            //    System.Threading.Thread.Sleep(1000);

            dsSearch.Tables.Add("Symbol");
            dsSearch.Tables["Symbol"].Columns.Add("Pair");

            dsSearch.Tables["Symbol"].Clear();

            triangularBinance();
            Console.ReadLine();
        }

        private static decimal morePercent(decimal value, decimal perc)
        {
            return ((value * perc) / 100) + value;
        }

        private static void triangularBinance()
        {
            markets = getArrayTriangularArbitrage();

            new Thread(initializeSockets).Start();

            try
            {
                for (int z = 0; z < markets.Length; z++)
                    if (markets[z].Trim() != "")
                        new Thread(triangularBinanceDetail).Start(markets[z]);
            }
            catch
            { System.Threading.Thread.Sleep(5000); }

            while (true)
                System.Threading.Thread.Sleep(120000);
        }

        /// <summary>
        /// Função principal de loop
        /// </summary>
        /// <param name="obj"></param>
        private static void triangularBinanceDetail(object obj)
        {
            Logger.log("START " + obj.ToString());
            String[] pairs = obj.ToString().Split(':');

            while (true)
            {
                try
                {
                    ArbTriangle ret = verifyOrderBook(pairs, initialValue);
                    bool insert = true;
                    for (int x = 0; x < dsSearch.Tables["Symbol"].Rows.Count; x++)
                        if (dsSearch.Tables["Symbol"].Rows[x][0].ToString().ToLower().Trim() == obj.ToString().ToLower().Trim())
                            insert = false;
                    if (insert)
                    {
                        dsSearch.Tables["Symbol"].Rows.Add(obj.ToString());
                        Console.Title = dsSearch.Tables[0].Rows.Count.ToString() + " PARES RASTREADOS";
                        Logger.trade(obj.ToString());
                    }
                    if (ret.perc > percValue)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine(" -- -- BAITING THE FISH!! -- -- ");
                        lock (objLockOrders)
                        {
                            string jason = "";
                            if (pairs[2] == "ETHBTC" || pairs[2] == "BNBBTC")
                            {
                                jason = exchangeBinance.orderMarket("buy", pairs[0], ret.amount1, false, true);
                                Console.WriteLine("                --------------------");
                                Console.WriteLine(jason.IndexOf("FILLED"));
                                Console.WriteLine("                --------------------");
                                Console.WriteLine("                --------------------");
                                Console.WriteLine("                --------------------");
                                Console.WriteLine(jason);
                                Console.WriteLine("                --------------------");
                                Console.WriteLine("                --------------------");

                                if (jason.IndexOf("FILLED") >= 0)
                                {
                                    Console.WriteLine("|| -- -- FIRST ACT COMPLETE!!! -- -- >>");
                                    jason = exchangeBinance.orderMarket("sell", pairs[1], ret.amount1, false, true);
                                    if (jason.IndexOf("FILLED") >= 0)
                                    {
                                        Console.WriteLine("|| -- -- SECOND ACT COMPLETE!!! -- -- >>");
                                        jason = exchangeBinance.orderMarket("sell", pairs[2], ret.amount2);
                                        if (jason.IndexOf("FILLED") >= 0)
                                        {
                                            String obs = pairs[2].Replace("BTC", "") + " | " + ret.perc + Environment.NewLine +
                                            "Buy " + pairs[0] + "  " + ret.amount1 + "  " + Environment.NewLine +
                                            " Change " + pairs[1] + "  " + ret.amount2 + " " + Environment.NewLine +
                                            " Sell " + pairs[2] + "  " + ret.amount2 + Environment.NewLine +
                                            " Initial " + initialValue + "  Final " + ret.finalvalue + " perc  " + Math.Round(ret.perc, 8) + Environment.NewLine;

                                            Logger.triangle(obs);
                                            Console.WriteLine("<< -- -- FISHING COMPLETE!!! -- -- ||");
                                        }
                                        else
                                        {
                                            Console.WriteLine("|| -- -- FINAL FISHING FAIL!!! -- -- >>");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("|| -- -- SECOND ACT FAIL!!! -- -- >>");
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("|| -- -- FIRST ACT FAIL!!! -- -- \\");
                                    break;
                                }
                            }
                            else if (pairs[2] == "BTCUSDT" || pairs[2] == "BTCPAX")
                            {
                                jason = exchangeBinance.orderMarket("buy", pairs[0], ret.amount1, false, true);
                                Console.WriteLine("                --------------------");
                                Console.WriteLine(jason.IndexOf("FILLED"));
                                Console.WriteLine("                --------------------");
                                Console.WriteLine("                --------------------");
                                Console.WriteLine("                --------------------");
                                Console.WriteLine(jason);
                                Console.WriteLine("                --------------------");
                                Console.WriteLine("                --------------------");
                                if (jason.IndexOf("FILLED") >= 0)
                                {
                                    Console.WriteLine("|| -- -- FIRST ACT COMPLETE!!! -- -- >>");
                                    Console.WriteLine(jason.IndexOf("FILLED"));
                                    jason = exchangeBinance.orderMarket("sell", pairs[1], ret.amount1, false, true);
                                    if (jason.IndexOf("FILLED") >= 0)
                                    {
                                        Console.WriteLine("|| -- -- SECOND ACT COMPLETE!!! -- -- >>");
                                        jason = exchangeBinance.orderMarket("sell", pairs[2], ret.amount2);
                                        if (jason.IndexOf("FILLED") >= 0)
                                        {
                                            String obs = pairs[2].Replace("BTC", "") + " | " + ret.perc + Environment.NewLine +
                                            "Buy " + pairs[0] + "  " + ret.amount1 + "  " + Environment.NewLine +
                                            " Change " + pairs[1] + "  " + ret.amount2 + " " + Environment.NewLine +
                                            " Sell " + pairs[2] + "  " + ret.amount2 + Environment.NewLine +
                                            " Initial " + initialValue + "  Final " + ret.finalvalue + " perc  " + Math.Round(ret.perc, 8) + Environment.NewLine;

                                            Logger.triangle(obs);
                                            Console.WriteLine("<< -- -- FISHING COMPLETE!!! -- -- ||");
                                        }
                                        else
                                        {
                                            Console.WriteLine("|| -- -- FINAL FISHING FAIL!!! -- -- >>");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("|| -- -- SECOND ACT FAIL!!! -- -- >>");
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("|| -- -- FIRST ACT FAIL!!! -- -- \\");
                                    break;
                                }
                            }
                            else
                            {
                                jason = exchangeBinance.orderMarket("buy", pairs[0], ret.amount1, false, true);
                                Console.WriteLine("                --------------------");
                                Console.WriteLine(jason.IndexOf("FILLED"));
                                Console.WriteLine("                --------------------");
                                Console.WriteLine("                --------------------");
                                Console.WriteLine("                --------------------");
                                Console.WriteLine(jason);
                                Console.WriteLine("                --------------------");
                                Console.WriteLine("                --------------------");
                                if (jason.IndexOf("FILLED") >= 0)
                                {
                                    Console.WriteLine("|| -- -- FIRST ACT COMPLETE!!! -- -- >>");
                                    Console.WriteLine(jason.IndexOf("FILLED"));
                                    jason = exchangeBinance.orderMarket("sell", pairs[1], ret.amount1, false, true);
                                    if (jason.IndexOf("FILLED") >= 0)
                                    {
                                        Console.WriteLine("|| -- -- SECOND ACT COMPLETE!!! -- -- >>");
                                        jason = exchangeBinance.orderMarket("sell", pairs[2], ret.amount2);
                                        if (jason.IndexOf("FILLED") >= 0)
                                        {
                                            String obs = pairs[2].Replace("BTC", "") + " | " + ret.perc + Environment.NewLine +
                                            "Buy " + pairs[0] + "  " + ret.amount1 + "  " + Environment.NewLine +
                                            " Change " + pairs[1] + "  " + ret.amount2 + " " + Environment.NewLine +
                                            " Sell " + pairs[2] + "  " + ret.amount2 + Environment.NewLine +
                                            " Initial " + initialValue + "  Final " + ret.finalvalue + " perc  " + Math.Round(ret.perc, 8) + Environment.NewLine;

                                            Logger.triangle(obs);
                                            Console.WriteLine("<< -- -- FISHING COMPLETE!!! -- -- ||");
                                        }
                                        else
                                        {
                                            Console.WriteLine("|| -- -- FINAL FISHING FAIL!!! -- -- >>");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("|| -- -- SECOND ACT FAIL!!! -- -- >>");
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("|| -- -- FIRST ACT FAIL!!! -- -- \\");
                                    break;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Threading.Thread.Sleep(1000);
                    //Logger.log(ex.Message + ex.StackTrace + "||" + obj.ToString());
                }
            }
        }

        /// <summary>
        /// Calculo com o Order book
        /// </summary>
        /// <param name="pairs"></param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        private static ArbTriangle verifyOrderBook(string[] pairs, decimal initialValue)
        {
            try
            {
                ArbTriangle arbTriangle = new ArbTriangle();

                arbTriangle.pair1 = pairs[0];
                arbTriangle.pair2 = pairs[1];
                arbTriangle.pair3 = pairs[2];

                if (pairs[2] == "ETHBTC" || pairs[2] == "BNBBTC")
                {
                    //EOSBTC BUY
                    //EOSETH SELL
                    //EOSBTC SELL

                    //BUY
                    arbTriangle.amount1 = Math.Round(exchangeBinance.getBook(pairs[0], initialValue, "asks", "buy"), 8);

                    //CHANGE
                    arbTriangle.amount2 = Math.Round(exchangeBinance.getBook(pairs[1], arbTriangle.amount1, "bids", "sell", false), 8);

                    //SELL
                    arbTriangle.finalvalue = Math.Round(exchangeBinance.getBook(pairs[2], arbTriangle.amount2, "bids", "sell", false), 8);

                    //Report
                    decimal perc = Math.Round((((arbTriangle.finalvalue * 100) / initialValue) - 100), 5);

                    arbTriangle.perc = perc;
                    //if (perc > -1)
                    //{
                    //    Console.WriteLine(Math.Round(perc, 2) + "% | " + pairs[0].ToString() + "(" + arbTriangle.amount1 + ") - " + pairs[1].ToString() + "(" + arbTriangle.amount2 + ") - " + pairs[2].ToString() + "(" + arbTriangle.finalvalue + ")");
                    //}
                    return arbTriangle;
                }
                else if (pairs[2] == "BTCUSDT" || pairs[2] == "BTCPAX" || pairs[2] == "BTCTUSD" || pairs[2] == "BTCUSDC")
                {
                    //XRPBTC BUY
                    //XRPUSDT SELL
                    //BTCUSDT BUY

                    //BUY
                    arbTriangle.amount1 = Math.Round(exchangeBinance.getBook(pairs[0], initialValue, "asks", "buy"), 8);

                    //CHANGE
                    arbTriangle.amount2 = Math.Round(exchangeBinance.getBook(pairs[1], arbTriangle.amount1, "bids", "sell", false), 8);

                    //SELL
                    arbTriangle.finalvalue = Math.Round(exchangeBinance.getBook(pairs[2], arbTriangle.amount2, "asks", "buy"), 8);

                    //Report
                    decimal perc = Math.Round((((arbTriangle.finalvalue * 100) / initialValue) - 100), 5);

                    arbTriangle.perc = perc;

                    //if (perc > -1)
                    //{
                    //    Console.WriteLine(Math.Round(perc, 2) + "% | " + pairs[0].ToString() + "(" + arbTriangle.amount1 + ") - " + pairs[1].ToString() + "(" + arbTriangle.amount2 + ") - " + pairs[2].ToString() + "(" + arbTriangle.finalvalue + ")");
                    //}
                    return arbTriangle;
                }
                else
                {
                    //ETHBTC BUY
                    //XRPETH BUY
                    //XRPBTC SELL

                    //BUY
                    arbTriangle.amount1 = Math.Round(exchangeBinance.getBook(pairs[0], initialValue, "asks", "buy"), 8);

                    //CHANGE
                    arbTriangle.amount2 = Math.Round(exchangeBinance.getBook(pairs[1], arbTriangle.amount1, "asks", "buy"), 8);

                    //SELL
                    arbTriangle.finalvalue = Math.Round(exchangeBinance.getBook(pairs[2], arbTriangle.amount2, "bids", "sell", false), 8);

                    //Report
                    decimal perc = Math.Round((((arbTriangle.finalvalue * 100) / initialValue) - 100), 5);

                    arbTriangle.perc = perc;

                    //if (perc > -1)
                    //{
                    //    Console.WriteLine(Math.Round(perc, 2) + "% | " + pairs[0].ToString() + "(" + arbTriangle.amount1 + ") - " + pairs[1].ToString() + "(" + arbTriangle.amount2 + ") - " + pairs[2].ToString() + "(" + arbTriangle.finalvalue + ")");
                    //}
                    return arbTriangle;
                }
            }
            catch
            {
                //Console.WriteLine("ERROR BOOK!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                throw new Exception("Erro book");
            }
        }

        /// <summary>
        /// Classe da trangulação
        /// </summary>
        public class ArbTriangle
        {
            public decimal amount1;
            public decimal amount2;
            public decimal finalvalue;
            public string pair1;
            public string pair2;
            public string pair3;
            public decimal perc;
        }

        public class ClassDetailOrder
        {
            public BinanceOrderBook book;
            public string symbol;
        }
    }
}