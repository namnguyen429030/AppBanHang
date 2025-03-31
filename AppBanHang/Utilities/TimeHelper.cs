using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanHang.Utilities
{
    public static class TimeHelper
    {
        public static int ToUnixTimestamp(DateTime dateTime)
        {
            return (int)dateTime.ToUniversalTime().Subtract(DateTime.UnixEpoch).TotalSeconds;
        }
    }
}
