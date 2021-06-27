using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShopMultilayered.DAL.Entities;
using ConsoleEShopMultilayered.DAL.Repository;
using ConsoleEShopMultilayered.DAL.Enums;
using System.Linq;
using ConsoleEShopMultilayered.PL;
/// <summary>
/// Business logic
/// </summary>
namespace ConsoleEShopMultilayered.BLL
{
    /// <summary>
    /// Class for user with type Registered
    /// </summary>
    public class Registered
    {
        /// <summary>
        /// User with type Registered
        /// </summary>
        public static User user;
        /// <summary>
        /// Get list of all goods in data
        /// </summary>
        /// <returns>List of all goods</returns>
        public static List<Goods> ViewAllGoods()
        {
            return MockGoodsRepository.GoodsRepository.GetAll();
        }
        /// <summary>
        /// Get list of goods which have such name
        /// </summary>
        /// <param name="name">Name of goods</param>
        /// <returns>List of goods with such name</returns>
        public static List<Goods> SearchByName(string name)
        {
            return MockGoodsRepository.GoodsRepository.GetGoodsByName(name);
        }
        /// <summary>
        /// Add goods to basket to create new order
        /// </summary>
        /// <param name="goods">Good what you want to buy</param>
        public static void AddToBasket(Goods goods)
        {
            user.Basket.Add(goods);
        }
        /// <summary>
        /// Create new order
        /// </summary>
        /// <param name="customerName">Name of customer</param>
        /// <param name="customerPhoneNumber">Customer Phone</param>
        /// <param name="deliveryAddress">Delivery adress</param>
        public static void Checkout(string customerName, string customerPhoneNumber, string deliveryAddress)
        {
            if (user.Basket.Count == 0) throw new ArgumentException("Basket is empty");
            Order order = new Order(user.Login, customerName, customerPhoneNumber, deliveryAddress, user.Basket);
            MockOrderRepository.OrderRepository.Checkout(order);
            user.Basket = new List<Goods>();
        }
        /// <summary>
        /// Deny order by ID
        /// </summary>
        /// <param name="id">Id of order which you want to deny</param>
        /// <returns>True if order was deny, or false if its immposible</returns>
        public static bool DenyOrder(int id)
        {
            if (MockOrderRepository.OrderRepository.GetAll().Where(o => o.Id == id).Select(o => o).Count() > 0)
            {
                if (MockOrderRepository.OrderRepository.GetAll().Where(o => o.Id == id).Select(o => o.orderStatus).FirstOrDefault() != OrderStatus.Completed)
                {
                    MockOrderRepository.OrderRepository.ChangeStatus(OrderStatus.CanceledByUser, id);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Get all orders for this user
        /// </summary>
        /// <returns>List of orders</returns>
        public static List<Order> UserOrders()
        {
            return MockOrderRepository.OrderRepository.GetUserOders(user.Login);
        }
        /// <summary>
        /// Get completed orders for this user
        /// </summary>
        /// <returns>List of orders</returns>
        public static List<Order> UserCompleteOrders()
        {
            return MockOrderRepository.OrderRepository.GetUserCompleteOders(user.Login);
        }
        /// <summary>
        /// Change order status by ID
        /// </summary>
        /// <param name="id">Order id which you want to change</param>
        public static void ChangeStatusToComplete(int id)
        {
            if (MockOrderRepository.OrderRepository.GetAll().Where(o => o.Id == id).Select(o => o).Count() > 0)
                MockOrderRepository.OrderRepository.ChangeStatus(OrderStatus.Completed, id);
        }
        /// <summary>
        /// Change this user profile
        /// </summary>
        /// <param name="temp">New information</param>
        public static void ChangeProfile(User temp)
        {
            MockUserRepository.UserRepository.ChangePersonalInformation(user, temp);
        }
        /// <summary>
        /// Log out
        /// </summary>
        public static void LogOut()
        {
            user = null;
            ViewHandler.menu = ViewGuest.Menu;
        }
    }
}
