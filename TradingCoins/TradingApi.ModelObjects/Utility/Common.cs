﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingApi.ModelObjects.Utility
{
   public static class Common
   {
      public static long UnixTimeStampUtc()
      {
         Int32 unixTimeStamp;
         DateTime currentTime = DateTime.Now;
         DateTime dt = currentTime.ToUniversalTime();
         DateTime unixEpoch = new DateTime(1970, 1, 1);
         unixTimeStamp = (Int32)(dt.Subtract(unixEpoch)).TotalSeconds;
         return unixTimeStamp;
      }
      public static DateTime GetTimeStamp(long ts)
      {
         var unixEpoch = new DateTime(1970, 1, 1);
         return DateTime.SpecifyKind(unixEpoch.AddSeconds(ts), DateTimeKind.Utc);
      }
      public static double GetTimeStamp(DateTime dt)
      {
         var unixEpoch = new DateTime(1970, 1, 1);
         return dt.Subtract(unixEpoch).TotalSeconds;
      }
      public static System.Security.SecureString ToSecureString(string input)
      {
         var ret = new System.Security.SecureString();
         foreach (var cb in input)
            ret.AppendChar(cb);
         ret.MakeReadOnly();
         input = string.Empty;
         return ret;
      }
   }
}
