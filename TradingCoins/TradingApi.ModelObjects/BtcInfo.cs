﻿using System.Collections.Generic;

namespace TradingApi.ModelObjects
{
   public static class BtcInfo
   {
      static BtcInfo()
      {
         SymbolMapHelper = new Dictionary<ExchangeSymbolEnum, ExchangeSymbolNameEnum>();
         SymbolMapHelper.Add(ExchangeSymbolEnum.btc,ExchangeSymbolNameEnum.bitcoin);
         SymbolMapHelper.Add(ExchangeSymbolEnum.ltc, ExchangeSymbolNameEnum.litecoin);
         SymbolMapHelper.Add(ExchangeSymbolEnum.drk, ExchangeSymbolNameEnum.darkcoin);
         SymbolMapHelper.Add(ExchangeSymbolEnum.eth, ExchangeSymbolNameEnum.etherium);
         SymbolMapHelper.Add(ExchangeSymbolEnum.zec, ExchangeSymbolNameEnum.zerocash);
      }

      public static Dictionary<ExchangeSymbolEnum, ExchangeSymbolNameEnum> SymbolMapHelper;
      
      public enum PairTypeEnum
      {
         ltcbtc = 0,
         btcusd = 1,
         ltcusd = 2,
         ethusd = 3,
         ethbtc = 4,
         zecusd = 5,
         zecbtc = 6
      }

      public enum ExchangeSymbolEnum
      {
         ltc = 0,
         btc = 1,
         usd = 2,
         drk = 3,
         eth = 4,
         zec = 5
      }

      public enum ExchangeSymbolNameEnum
      {
         bitcoin = 0,
         litecoin = 1,
         darkcoin = 2,
         etherium = 3,
         zerocash = 4
      }

      public enum ExchangeEnum
      {
         BITFINEX = 0
      }

      public enum BitfinexUnauthenicatedCallsEnum
      {
         pubticker = 0,
         stats = 1,
         trades = 2,
      }

      public enum BitfinexWalletEnum
      {
         trading = 0,
         exchange = 1,
         deposit = 2
      }

      public enum OfferDirectionEnum
      {
         lend = 0,
         loan = 1
      }

   }
}
