using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShopMultilayered.DAL.Entities;
/// <summary>
/// Repository
/// </summary>
namespace ConsoleEShopMultilayered.DAL.Repository
{
    /// <summary>
    /// Interface for MockUserRepository
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Add new user to data
        /// </summary>
        /// <param name="user">New User</param>
        void Add(User user);
        /// <summary>
        /// Change information about user
        /// </summary>
        /// <param name="user">User which you want to change</param>
        /// <param name="temp">New information</param>
        void ChangePersonalInformation(User user, User temp);
        /// <summary>
        /// Get all users from data
        /// </summary>
        /// <returns>List of all users</returns>
        List<User> GetAll();
        /// <summary>
        /// Log in to account
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        void Authorization(string login, string password);
    }
}
