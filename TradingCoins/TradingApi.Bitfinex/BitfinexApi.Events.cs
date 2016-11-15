using System;
using System.Collections.Generic;
using TradingApi.ModelObjects;
using TradingApi.ModelObjects.Bitfinex.Json;

namespace TradingApi.Bitfinex
{
    public  partial class BitfinexApi
    {
       private void InitializeEvents()
       {
          ErrorMessage += OnErrorMessage;
          OrderBookMsg += OnOrderBookMsg;
          BalanceResponseMsg += OnBalanceResponseMsg;
          MultipleOrderFeedMsg += OnMultipleOrderFeedMsg;
          OrderFeedMsg += OnOrderFeedMsg;
          CancelOrderMsg += OnCancelOrderMsg;
          CancelReplaceFeedMsg += OnCancelReplaceFeedMsg;
          CancelMultipleOrdersMsg += OnCancelMultipleOrdersMsg;
          CancelAllActiveOrdersMsg += OnCancelAllActiveOrdersMsg;
          ActiveOffersMsg += OnActiveOffersMsg;
          HistoryMsg += OnHistoryMsg;
          MyTradesMsg += OnMyTradesMsg;
          MarginInformationMsg += OnMarginInformationMsg;
          ActivePositionssMsg += OnActivePositionssMsg;
          OrderStatusMsg += OnOrderStatusMsg;
          NewOfferStatusMsg += OnNewOfferStatusMsg;
          CancelOfferMsg += OnCancelOfferMsg;
          OfferStatusMsg += OnOfferStatusMsg;
          ActiveCreditsMsg  += OnActiveCreditsMsg;
          ActiveSwapsUsedInMarginMsg += OnActiveSwapsUsedInMarginMsg;
          CloseSwapMsg += OnCloseSwapMsg;
          ClaimPositionMsg += OnClaimPositionMsg;
          LendbookResponseMsg += OnLendbookResponseMsg;
          LendsResponseMsg += OnLendsResponseMsg;
      }

       public event ErrorMessageHandler ErrorMessage;
       public delegate void ErrorMessageHandler(string errorMessage);

       public event OrderBookMsgHandler OrderBookMsg;
       public delegate void OrderBookMsgHandler(BitfinexOrderBookGet marketData);

       public event BalanceResponseMsgHandler BalanceResponseMsg;
       public delegate void BalanceResponseMsgHandler(IList<BitfinexBalanceResponse> balanceResponse);

       public event MultipleOrderFeedMsgHandler MultipleOrderFeedMsg;
       public delegate void MultipleOrderFeedMsgHandler(BitfinexMultipleNewOrderResponse ordersResponse);

       public event OrderFeedMsgHandler OrderFeedMsg;
       public delegate void OrderFeedMsgHandler(BitfinexNewOrderResponse orderResponse);

       public event CancelOrderMsgHandler CancelOrderMsg;
       public delegate void CancelOrderMsgHandler(BitfinexOrderStatusResponse cancelResponse);

       public event CancelReplaceFeedMsgHandler CancelReplaceFeedMsg;
       public delegate void CancelReplaceFeedMsgHandler(BitfinexCancelReplaceOrderResponse cancelReplaceReponse);

       public event CancelMultipleOrdersMsgHandler CancelMultipleOrdersMsg;
       public delegate void CancelMultipleOrdersMsgHandler(string msg);

       public event CancelAllActiveOrdersMsgHandler CancelAllActiveOrdersMsg;
       public delegate void CancelAllActiveOrdersMsgHandler(string msg);

       public event ActiveOrdersMsgHandler ActiveOrdersMsg;
       public delegate void ActiveOrdersMsgHandler(IList<BitfinexMarginPositionResponse> activePositionResponse);

       public event HistoryMsgHandler HistoryMsg;
       public delegate void HistoryMsgHandler(IList<BitfinexHistoryResponse> historyResponse);

       public event MyTradesMsgHandler MyTradesMsg;
       public delegate void MyTradesMsgHandler(IList<BitfinexMyTradesResponse> myTradesResponse);

       public event MarginInformationMsgHandler MarginInformationMsg;
       public delegate void MarginInformationMsgHandler(BitfinexMarginInfoResponse marginInfoResponse);

       public event ActivePositionsMsgHandler ActivePositionssMsg;
       public delegate void ActivePositionsMsgHandler(IList<BitfinexMarginPositionResponse> activePositionResponse);

       public event OrderOrderStatusMsgHandler OrderStatusMsg;
       public delegate void OrderOrderStatusMsgHandler(BitfinexOrderStatusResponse orderStatusResponse);

       public event NewOfferStatusMsgHandler NewOfferStatusMsg;
       public delegate void NewOfferStatusMsgHandler(BitfinexOfferStatusResponse newOfferRespone);

       public event CancelOfferMsgHandler CancelOfferMsg;
       public delegate void CancelOfferMsgHandler(BitfinexOfferStatusResponse cancelOfferResponse);

       public event OfferStatusMsgHandler OfferStatusMsg;
       public delegate void OfferStatusMsgHandler(BitfinexOfferStatusResponse offerStatusResponse);

       public event ActiveOffersMsgHandler ActiveOffersMsg;
       public delegate void ActiveOffersMsgHandler(IList<BitfinexOfferStatusResponse> activeOfferResponse);

       public event ActiveCreditsMsgHandler ActiveCreditsMsg;
       public delegate void ActiveCreditsMsgHandler(IList<BitfinexActiveCreditsResponse> activeCreditsResponse);

       public event ActiveSwapsUsedInMarginMsgHandler ActiveSwapsUsedInMarginMsg;
       public delegate void ActiveSwapsUsedInMarginMsgHandler(IList<BitfinexActiveSwapsInMarginResponse> activeSwapsInMarginResponse);

       public event CloseSwapMsgHandler CloseSwapMsg;
       public delegate void CloseSwapMsgHandler(BitfinexActiveSwapsInMarginResponse closeSwapResponse);

       public event ClaimPositionMsgHandler ClaimPositionMsg;
       public delegate void ClaimPositionMsgHandler(BitfinexMarginPositionResponse claimPosResponse);

       public event LendbookResponseMsgHandler LendbookResponseMsg;
       public delegate void LendbookResponseMsgHandler(BitfinexLendbookResponse lendbookResponse);

       public event LendsResponseMsgHandler LendsResponseMsg;
       public delegate void LendsResponseMsgHandler(IList<BitfinexLendsResponse> lendsResponse);

       protected virtual void OnLendsResponseMsg(IList<BitfinexLendsResponse> lendsResponse) { }

       protected virtual void OnLendbookResponseMsg(BitfinexLendbookResponse lendbookResponse) { }

       protected virtual void OnClaimPositionMsg(BitfinexMarginPositionResponse claimPosResponse) { }

       protected virtual void OnCloseSwapMsg(BitfinexActiveSwapsInMarginResponse closeSwapResponse) { }

       protected virtual void OnActiveSwapsUsedInMarginMsg(IList<BitfinexActiveSwapsInMarginResponse> activeSwapsInMarginResponse) { }

       protected virtual void OnActiveCreditsMsg(IList<BitfinexActiveCreditsResponse> activeCreditsResponse) { }

       protected virtual void OnOfferStatusMsg(BitfinexOfferStatusResponse offerStatusResponse) { }

       protected virtual void OnCancelOfferMsg(BitfinexOfferStatusResponse cancelOfferResponse) { }

       protected virtual void OnNewOfferStatusMsg(BitfinexOfferStatusResponse newOfferRespone) { }

       protected virtual void OnOrderStatusMsg(BitfinexOrderStatusResponse orderStatusResponse) { }

       protected virtual void OnActivePositionssMsg(IList<BitfinexMarginPositionResponse> activePositionResponse) { }

       protected virtual void OnMarginInformationMsg(BitfinexMarginInfoResponse marginInfoResponse) { }

       protected virtual void OnMyTradesMsg(IList<BitfinexMyTradesResponse> myTradesResponse) { }

       protected virtual void OnHistoryMsg(IList<BitfinexHistoryResponse> historyResponse) { }

       protected virtual void OnActiveOffersMsg(IList<BitfinexOfferStatusResponse> activeOfferResponse) { }

       protected virtual void OnCancelAllActiveOrdersMsg(string msg) { }

       protected virtual void OnCancelMultipleOrdersMsg(string msg) { }

       protected virtual void OnCancelReplaceFeedMsg(BitfinexCancelReplaceOrderResponse cancelReplaceReponse) { }

       protected virtual void OnCancelOrderMsg(BitfinexOrderStatusResponse cancelResponse) { }

       protected virtual void OnOrderFeedMsg(BitfinexNewOrderResponse orderResponse) { }

       protected virtual void OnMultipleOrderFeedMsg(BitfinexMultipleNewOrderResponse ordersResponse) { }

       protected virtual void OnBalanceResponseMsg(IList<BitfinexBalanceResponse> balanceResponse) { }

       protected virtual void OnOrderBookMsg(BitfinexOrderBookGet marketData) { }

       protected virtual void OnErrorMessage(string errorMessage) { } 



    }
}
