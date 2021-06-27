using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Interfaces
/// </summary>
namespace ConsoleEShopMultilayered.DAL.Interfaces
{
    /// <summary>
    /// Interface of Goods
    /// </summary>
    interface IGoods
    {
        /// <summary>
        /// Unique good id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of goods
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Goods price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Goods description
        /// </summary>
        public string Description { get; set; }
    }
}
