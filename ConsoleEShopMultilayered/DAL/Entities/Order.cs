using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShopMultilayered.DAL.Interfaces;
using ConsoleEShopMultilayered.DAL.Enums;
using System.Diagnostics.CodeAnalysis;
/// <summary>
/// Entities
/// </summary>
namespace ConsoleEShopMultilayered.DAL.Entities
{

    /// <summary>
    /// Class order
    /// </summary>
    public class Order : IOrder, IEquatable<Order>
    {

        /// <summary>
        /// Count of all orders
        /// </summary>
        private static int count = 0;
        /// <summary>
        /// Unique order id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Customer Login
        /// </summary>
        public string CustomerLogin { get;  set; }
        /// <summary>
        /// List of Goods from basket
        /// </summary>
        public List<Goods> Goods { get; set; }
        /// <summary>
        /// Customer Name
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Customer Phone Number
        /// </summary>
        public string CustomerPhoneNumber { get; set; }
        /// <summary>
        /// Delivery Address
        /// </summary>
        public string DeliveryAddress { get; set; }
        /// <summary>
        /// DateTime now
        /// </summary>
        public DateTime dateTimeOfOrder { get; set; }
        /// <summary>
        /// Order Status
        /// </summary>
        public OrderStatus orderStatus { get; set; }

        /// <summary>
        /// Order constructor
        /// </summary>
        /// <param name="customerLogin"> Customer Login</param>
        /// <param name="customerName"> Customer Name</param>
        /// <param name="customerPhoneNumber"> Customer Phone Number</param>
        /// <param name="deliveryAddress">Delivery Address</param>
        /// <param name="goods">List of Goods from basket</param>
        public Order(string customerLogin, string customerName,  string customerPhoneNumber, string deliveryAddress, List<Goods> goods)
        {
            CustomerLogin = customerLogin;
            CustomerName = customerName;
            CustomerPhoneNumber = customerPhoneNumber;
            DeliveryAddress = deliveryAddress;
            Goods = goods;
            dateTimeOfOrder = DateTime.Now;
            orderStatus = OrderStatus.NewOrder;
            Id = count;
            count++;
        }
        /// <summary>
        /// Comparison of two orders
        /// </summary>
        /// <param name="other">Other order</param>
        /// <returns>True if orders equals</returns>
        public bool Equals([AllowNull] Order other)
        {
            if (this.CustomerLogin == other.CustomerLogin && this.CustomerName == other.CustomerName
                && this.CustomerPhoneNumber == other.CustomerPhoneNumber && this.DeliveryAddress == other.DeliveryAddress
              && this.orderStatus == other.orderStatus)
                return true;
            return false;
        }
    }
}
