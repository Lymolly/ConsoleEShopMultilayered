using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Enums
/// </summary>
namespace ConsoleEShopMultilayered.DAL.Enums
{
    /// <summary>
    /// Order status
    /// </summary>
    public enum OrderStatus
    {
        NewOrder,
        CanceledByAdministrator,
        PaymentReceived,
        Sent,
        Received,
        Completed,
        CanceledByUser
    }
}
