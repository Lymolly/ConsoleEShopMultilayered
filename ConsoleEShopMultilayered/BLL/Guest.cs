using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShopMultilayered.DAL.Entities;
using ConsoleEShopMultilayered.DAL.Repository;
using ConsoleEShopMultilayered.DL;
using System.Linq;
/// <summary>
/// Business logic
/// </summary>
namespace ConsoleEShopMultilayered.BLL
{
    /// <summary>
    /// Class for guest
    /// </summary>
    public class Guest
    {
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
        /// Register new account for user
        /// </summary>
        /// <param name="user">New user</param>
        public static void Register(User user)
        {
            MockUserRepository.UserRepository.Add(user);
        }
        /// <summary>
        /// Log in to account
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        public static void LogIn(string login, string password)
        {
            
                Console.WriteLine("Loged in.");
            MockUserRepository.UserRepository.Authorization(login, password);
           
        }
        /// <summary>
        /// Check user login
        /// </summary>
        /// <param name="login">User login</param>
        /// <returns>False if this login exist in data already, else true</returns>
        public static bool CheckLogin(string login)
        {
            if (MockUserRepository.UserRepository.GetAll().Where(u => u.Login.Equals(login)).Select(u => u).Count() > 0 || login.Length == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Check correct login and password to LogIn
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        /// <returns>False if login or password wrong</returns>
        public static bool CheckForLogIn(string login, string password)
        {
            if (MockUserRepository.UserRepository.GetAll().Where(a => (a.Login == login) && (a.Password == password)).Count() < 1)
            {
                return false;
            }
            return true;
        }
    }
}
