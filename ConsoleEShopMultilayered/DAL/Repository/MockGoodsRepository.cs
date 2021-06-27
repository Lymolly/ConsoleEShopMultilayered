using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using ConsoleEShopMultilayered.DL;
using ConsoleEShopMultilayered.DAL.Entities;
using System.Linq;
/// <summary>
/// Repository
/// </summary>
namespace ConsoleEShopMultilayered.DAL.Repository
{
    /// <summary>
    /// Class for Mock goods data
    /// </summary>
    public static class MockGoodsRepository
    {
        /// <summary>
        /// Object of mock
        /// </summary>
        public static IGoodsRepository GoodsRepository;
        /// <summary>
        /// Constructor to initialization mock 
        /// </summary>
        static MockGoodsRepository()
        {
            Mock<IGoodsRepository> goodsRepositoryMock = new Mock<IGoodsRepository>();
            goodsRepositoryMock.Setup(mq => mq.Change(It.IsAny<Goods>(), It.IsAny<int>()))
                .Callback((Goods goods, int id) =>
                {
                    Goods g = Data.goods.Where(g => g.Id.Equals(id)).Select(g => g).FirstOrDefault();
                    if (goods.Description != null) g.Description = goods.Description;
                    if (goods.Name != null) g.Name = goods.Name;
                    if (goods.Price > 0) g.Price = goods.Price;
                }).Verifiable();
            goodsRepositoryMock.Setup(mq => mq.GetAll()).Returns(Data.goods);
            goodsRepositoryMock.Setup(mq => mq.GetGoodsByName(It.IsAny<string>()))
                .Returns<string>(name =>
                {
                    var goods = Data.goods.Where(g => g.Name.Equals(name)).Select(g => g).ToList();
                    return goods;
                });
            goodsRepositoryMock.Setup(mq => mq.Add(It.IsAny<Goods>())).Callback((Goods goods) => Data.goods.Add(goods)).Verifiable();
            GoodsRepository = goodsRepositoryMock.Object;
        }
    }
}
