using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShopMultilayered.DAL.Entities;
using ConsoleEShopMultilayered.DAL.Repository;
using ConsoleEShopMultilayered.PL;
using System.Linq;
using ConsoleEShopMultilayered.DAL.Enums;

/// <summary>
/// Business logic
/// </summary>
namespace ConsoleEShopMultilayered.BLL
{
    /// <summary>
    /// Class for user with type Administrator
    /// </summary>
    public class Admin
    {
        /// <summary>
        /// User with type Administrator
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
        /// Get list of all orders in data
        /// </summary>
        /// <returns>List of all orders</returns>
        public static List<Order> ViewAllOrders()
        {
            return MockOrderRepository.OrderRepository.GetAll();
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
        /// Change order status by ID
        /// </summary>
        /// <param name="id">Order id which you want to change</param>
        /// <param name="orderStatus">Order status</param>
        public static void ChangeStatus(int id, OrderStatus orderStatus)
        {
            
                MockOrderRepository.OrderRepository.ChangeStatus(orderStatus, id);
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
                    MockOrderRepository.OrderRepository.ChangeStatus(OrderStatus.CanceledByAdministrator, id);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// get list of all users from data
        /// </summary>
        /// <returns>List of all users</returns>
        public static List<User> ShowAllUsers()
        {
            return MockUserRepository.UserRepository.GetAll();
        }
        /// <summary>
        /// Change user profile
        /// </summary>
        /// <param name="u">User which you want to change</param>
        /// <param name="temp">New information</param>
        public static void ChangeProfile(User u,  User temp)
        {
            MockUserRepository.UserRepository.ChangePersonalInformation(u, temp);
        }
        /// <summary>
        /// Add new goods to data
        /// </summary>
        /// <param name="goods">New good</param>
        public static void AddGoods(Goods goods)
        {
            MockGoodsRepository.GoodsRepository.Add(goods);
        }
        /// <summary>
        /// Change good information by id
        /// </summary>
        /// <param name="goods">New information</param>
        /// <param name="id">Goods id which you want to change</param>
        public static void ChangeGood(Goods goods, int id)
        {
            MockGoodsRepository.GoodsRepository.Change(goods, id);
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
