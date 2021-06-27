using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using ConsoleEShopMultilayered.DAL.Interfaces;
/// <summary>
/// Entities
/// </summary>
namespace ConsoleEShopMultilayered.DAL.Entities
{
    /// <summary>
    /// Class goods
    /// </summary>
    public class Goods : IGoods, IEquatable<Goods>
    {
        /// <summary>
        /// Count of all goods
        /// </summary>
        private static int Count = 0;
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
        /// <summary>
        /// Goods constructor
        /// </summary>
        /// <param name="name">Name of good</param>
        /// <param name="description">Goods description</param>
        /// <param name="price">Goods price</param>
        public Goods(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
            Id = Count;
            Count++;
        }
        /// <summary>
        /// Comparison of two goods
        /// </summary>
        /// <param name="other">Other good</param>
        /// <returns>True if goods equals</returns>
        public bool Equals([AllowNull] Goods other)
        {
            if (this.Name == other.Name && this.Price == other.Price && this.Description == other.Description)
                return true;
            return false;
        }
    }
}
