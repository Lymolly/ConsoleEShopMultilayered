using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShopMultilayered.DAL.Entities;
using ConsoleEShopMultilayered.DAL.Enums;
using ConsoleEShopMultilayered.DAL.Repository;
/// <summary>
/// Database
/// </summary>
namespace ConsoleEShopMultilayered.DL
{
    /// <summary>
    /// Class Data
    /// </summary>
    public static class Data
    {
        /// <summary>
        /// All goods
        /// </summary>
        public static List<Goods> goods = new List<Goods>() 
        {
            new Goods("product", "good", 10m)
        };
        /// <summary>
        /// All users
        /// </summary>
        public static List<User> users = new List<User>()
        {
            new User("login", "12345", UserType.Administrator)
        };
        /// <summary>
        /// All orders
        /// </summary>
        public static List<Order> orders = new List<Order>();
        /// <summary>
        /// Refresh the data
        /// </summary>
        public static void Clean()
        {
            Data.users.Clear();
            Data.users.Add(new User("login", "12345", UserType.Administrator));
            Data.goods.Clear();
            Data.goods.Add(new Goods("product", "good", 10m));
            Data.orders.Clear();
        }
    }
}
