using System;
using System.Collections.Generic;
using System.Linq;

namespace FindBook.Core.Models.Enum
{

    public enum OrderStatu
    {

        Await,
        AwaitPayment,
        Prepare,
        Shipped,
        Delivered,
        ReturnRequestReceived,
        Returned,
        Canceled
    }


}