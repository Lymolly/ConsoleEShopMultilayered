using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShopMultilayered.DAL.Enums;
using ConsoleEShopMultilayered.DAL.Entities;
/// <summary>
/// Interfaces
/// </summary>
namespace ConsoleEShopMultilayered.DAL.Interfaces
{
    /// <summary>
    /// Interface for User
    /// </summary>
    interface IUser
    {
        /// <summary>
        /// Unique user id
        /// </summary>
        int Id { get; }
        /// <summary>
        /// User login
        /// </summary>
        string Login { get; set; }
        /// <summary>
        /// User password
        /// </summary>

        string Password { get; set; }
        /// <summary>
        /// User status - Administrator or Registered
        /// </summary>

        UserType Status { get; set; }
        /// <summary>
        /// User basket
        /// </summary>

        List<Goods> Basket { get; set; }
    }
}
