using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShopMultilayered.DAL.Entities;
using ConsoleEShopMultilayered.DAL.Enums;
/// <summary>
/// Interfaces
/// </summary>
namespace ConsoleEShopMultilayered.DAL.Interfaces
{
    /// <summary>
    /// Interface for Order
    /// </summary>
    interface IOrder
    {
        /// <summary>
        /// Unique order id
        /// </summary>
        int Id { get; set; }
        /// <summary>
        /// Customer Login
        /// </summary>
        string CustomerLogin { get;  set; }
        /// <summary>
        /// List of Goods from basket
        /// </summary>
        List<Goods> Goods { get; set; }
        /// <summary>
        /// Customer Name
        /// </summary>
        string CustomerName { get; set; }
        /// <summary>
        /// Customer Phone Number
        /// </summary>
        string CustomerPhoneNumber { get; set; }
        /// <summary>
        /// Delivery Address
        /// </summary>
        string DeliveryAddress { get; set; }
        /// <summary>
        /// DateTime now
        /// </summary>
        DateTime dateTimeOfOrder { get; set; }
        /// <summary>
        /// Order Status
        /// </summary>
        OrderStatus orderStatus { get; set; }
    }
}
