using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using TradingApi.ModelObjects;
using TradingApi.ModelObjects.Bitfinex.Json;
using TradingApi.ModelObjects.Utility;
using System.Security;
using System.Threading.Tasks;

namespace TradingApi.Bitfinex
{
    /// <summary>
    /// The <see cref="BitfinexAsyncApi"/> class extends <see cref="BitfinexApi"/> by adding support for asynchronous calls.
    /// </summary>
    public class BitfinexAsyncApi
        : BitfinexApi
    {

        public BitfinexAsyncApi(string apiSecret, string apiKey)
            : base(apiSecret, apiKey)
        {
            apiSecret = string.Empty;
        }
        public BitfinexAsyncApi(SecureString apiSecret, string apiKey)
            : base(apiSecret, apiKey)
        {

        }
        #region Unauthenticated Calls
        public Task<BitfinexOrderBookGet> GetOrderBookAsync(BtcInfo.PairTypeEnum pairType)
        { return Task.Run(() => GetOrderBook(pairType)); }

        public Task<IList<BitfinexSymbolDetailsResponse>> GetSymbolsAsync()
        { return Task.Run(() => GetSymbols()); }
       
        public Task<BitfinexPublicTickerGet> GetPublicTickerAsync(BtcInfo.PairTypeEnum pairType)
        { return Task.Run(() => GetPublicTicker(pairType, BtcInfo.BitfinexUnauthenicatedCallsEnum.pubticker)); }

        public Task<IList<BitfinexSymbolStatsResponse>> GetPairStatsAsync(BtcInfo.PairTypeEnum pairType, BtcInfo.BitfinexUnauthenicatedCallsEnum callType)
        { return Task.Run(() => GetPairStats(pairType, BtcInfo.BitfinexUnauthenicatedCallsEnum.stats)); }
     

        public Task<IList<BitfinexTradesGet>> GetPairTradesAsync(BtcInfo.PairTypeEnum pairType, BtcInfo.BitfinexUnauthenicatedCallsEnum callType)
        { return Task.Run(() => GetPairTrades(pairType, BtcInfo.BitfinexUnauthenicatedCallsEnum.trades)); }
     

        /// <summary>
        /// symbol = ExchangeSymbolEnum
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public Task<IList<BitfinexLendsResponse>> GetLendsAsync(string symbol)
        { return Task.Run(() => GetLends(symbol)); }
      

        public Task<BitfinexLendbookResponse> GetLendbookAsync(string symbol)
        { return Task.Run(() => GetLendbook(symbol)); }
       
        #endregion

        #region Sending Crypto Orders

        public Task<BitfinexMultipleNewOrderResponse> SendMultipleOrdersAsync(BitfinexNewOrderPost[] orders)
        { return Task.Run(() => SendMultipleOrders(orders)); }
   
        public Task<BitfinexNewOrderResponse> SendOrderAsync(BitfinexNewOrderPost newOrder)
        { return Task.Run(() => SendOrder(newOrder)); }
        
        public Task<BitfinexNewOrderResponse> SendOrderAsync(string symbol, string amount, string price, string exchange, string side, string type, bool isHidden)
        { return Task.Run(() => SendOrder(symbol, amount, price, exchange, side, type, isHidden)); }
     
        public Task<BitfinexNewOrderResponse> SendSimpleLimitAsync(string symbol, string amount, string price, string side, bool isHidden = false)
        { return Task.Run(() => SendOrder(symbol, amount, price, DefaultOrderExchangeType, side, DefaultLimitType, isHidden)); }
     
        public Task<BitfinexNewOrderResponse> SendSimpleLimitBuyAsync(string symbol, string amount, string price, bool isHidden = false)
        { return Task.Run(() => SendOrder(symbol, amount, price, DefaultOrderExchangeType, Buy, DefaultLimitType, isHidden)); }
      

        public Task<BitfinexNewOrderResponse> SendSimpleLimitSellAsync(string symbol, string amount, string price, bool isHidden = false)
        { return Task.Run(() => SendOrder(symbol, amount, price, DefaultOrderExchangeType, Sell, DefaultLimitType, isHidden)); }
       
        #endregion

        #region Cancel Crypto Orders

        public Task<BitfinexOrderStatusResponse> CancelOrderAsync(int orderId)
        { return Task.Run(() => CancelOrder(orderId)); }
       

        public Task<BitfinexCancelReplaceOrderResponse> CancelReplaceOrderAsync(int cancelOrderId, BitfinexNewOrderPost newOrder)
        { return Task.Run(() => CancelReplaceOrder(cancelOrderId, newOrder)); }
      

        public Task<BitfinexCancelReplaceOrderResponse> CancelReplaceOrderAsync(BitfinexCancelReplacePost replaceOrder)
        { return Task.Run(() => CancelReplaceOrder(replaceOrder)); }
       
        public Task<string> CancelMultipleOrdersAsync(int[] intArr)
        { return Task.Run(() => CancelMultipleOrders(intArr)); }
       

        public Task<string> CancelAllActiveOrdersAsync()
        { return Task.Run(() => CancellAllActiveOrders()); }
     

        #endregion

        #region Trading Info
        public Task<IList<BitfinexMarginPositionResponse>> GetActiveOrdersAsync()
        { return Task.Run(() => GetActiveOrders()); }
  
        public Task<IList<BitfinexHistoryResponse>> GetHistoryAsync(string currency, string since, string until, int limit, string wallet)
        { return Task.Run(() => GetHistory(currency, since, until, limit, wallet)); }
       
        public Task<IList<BitfinexMyTradesResponse>> GetMyTradesAsync(string symbol, string timestamp, int limit)
        { return Task.Run(() => GetMyTrades(symbol, timestamp, limit)); }
      
        public Task<BitfinexOrderStatusResponse> GetOrderStatusAsync(int orderId)
        { return Task.Run(() => GetOrderStatus(orderId)); }
      
        #endregion

        #region Account Information

        public Task<IList<BitfinexBalanceResponse>> GetBalancesAsync()
        { return Task.Run(() => GetBalances()); }
        


        /// <summary>
        /// currency = upper case ExchangeSymbolEnum
        /// method = lower case ExchangeSymbolNameEnum
        /// wallet = BitfinexWalletEnum
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="method"></param>
        /// <param name="wallet"></param>
        /// <returns></returns>
        public Task<BitfinexDepositResponse> DepositAsync(string currency, string method, string wallet)
        { return Task.Run(() => Deposit(currency, method, wallet)); }
    
     
        public Task<BitfinexMarginInfoResponse> GetMarginInformationAsync()
        { return Task.Run(() => GetMarginInformation()); }
      

        public Task<IList<BitfinexMarginPositionResponse>> GetActivePositionsAsync()
        { return Task.Run(() => GetActivePositions()); }
       
        #endregion

        #region Lending and Borrowing Execution

        /// <summary>
        /// rate is the yearly rate. So if you want to borrow/lend at 10 basis points per day you would 
        /// pass in 36.5 as the rate (10 * 365). Also, lend = lend (aka offer swap), loan = borrow (aka receive swap)
        /// The newOffer's currency propery = ExchangeSymbolEnum uppercase.
        /// </summary>
        /// <param name="newOffer"></param>
        /// <returns></returns>
        public Task<BitfinexOfferStatusResponse> SendNewOfferAsync(BitfinexNewOfferPost newOffer)
        { return Task.Run(() => SendNewOffer(newOffer)); }
   

        /// <summary>
        /// rate is the yearly rate. So if you want to borrow/lend at 10 basis points per day you would 
        /// pass in 36.5 as the rate (10 * 365). Also, lend = lend (aka offer swap), loan = borrow (aka receive swap)
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="amount"></param>
        /// <param name="rate"></param>
        /// <param name="period"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public Task<BitfinexOfferStatusResponse> SendNewOfferAsync(string currency, string amount, string rate, int period, string direction)
        { return Task.Run(() => SendNewOffer(currency, amount, rate, period, direction)); }
     

        /// <summary>
        /// Note: bug with bitfinex Canceloffer - the object returned will still say offer is alive and not cancelled.
        /// If you execute a 'GetOfferStatus' after the cancel is alive will be true (aka the offer will show up as cancelled. 
        /// </summary>
        /// <param name="offerId"></param>
        /// <returns></returns>
        public Task<BitfinexOfferStatusResponse> CancelOfferAsync(int offerId)
        { return Task.Run(() => CancelOffer(offerId)); }
     

        public Task<BitfinexOfferStatusResponse> GetOfferStatusAsync(int offerId)
        { return Task.Run(() => GetOfferStatus(offerId)); }
    
        public Task<IList<BitfinexOfferStatusResponse>> GetActiveOffersAsync()
        { return Task.Run(() => GetActiveOffers()); }
      

        public Task<IList<BitfinexActiveCreditsResponse>> GetActiveCreditsAsync()
        { return Task.Run(() => GetActiveCredits()); }

        /// <summary>
        /// In the Total Return Swaps page you will see a horizontal header "Swaps used in margin position"
        /// This function returns information about what you have borrowed. If you want to close the 
        /// swap you must pass the id returned here to the "CloseSwap" function. 
        /// If you want to 'cash out' and claim the position you must pass the position id to the "ClaimPosition" function. 
        /// </summary>
        /// <returns></returns>
        public Task<IList<BitfinexActiveSwapsInMarginResponse>> GetActiveSwapsUsedInMarginPositionAsync()
        { return Task.Run(() => GetActiveSwapsUsedInMarginPosition()); }
    

        public Task<BitfinexActiveSwapsInMarginResponse> CloseSwapAsync(int swapId)
        { return Task.Run(() => CloseSwap(swapId)); }
      
        /// <summary>
        /// Ok... so from what I gather is:
        /// If you leverage usd for btc, and the price moved in your favor the trade
        /// you can physically claim the btc in your wallet as yours. You will notice the
        /// object return this function is the same as the GetActiveSwapUsedInMarginPosition
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public Task<BitfinexMarginPositionResponse> ClaimPositionAsync(int positionId)
        { return Task.Run(() => ClaimPosition(positionId)); }

        #endregion
    }
}
