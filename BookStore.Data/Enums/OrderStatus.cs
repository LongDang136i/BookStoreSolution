using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.Enums
{
    public enum OrderStatus
    {
        InProgress,
        Confirmed,
        Shipping,
        Success,
        Canceled
    }
}