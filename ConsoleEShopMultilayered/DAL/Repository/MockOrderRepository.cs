using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using ConsoleEShopMultilayered.DAL.Entities;
using ConsoleEShopMultilayered.DL;
using ConsoleEShopMultilayered.DAL.Enums;
using System.Linq;
/// <summary>
/// Repository
/// </summary>
namespace ConsoleEShopMultilayered.DAL.Repository
{
    /// <summary>
    /// Class for Mock order data
    /// </summary>
    public static class MockOrderRepository
    {
        /// <summary>
        /// Object of mock
        /// </summary>
        public static IOrderRepository OrderRepository;
        /// <summary>
        /// Constructor to initialization mock 
        /// </summary>
        static MockOrderRepository()
        {
            Mock<IOrderRepository> orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(mq => mq.Checkout(It.IsAny<Order>())).Callback((Order order) => Data.orders.Add(order)).Verifiable();
            orderRepositoryMock.Setup(mq => mq.ChangeStatus(It.IsAny<OrderStatus>(), It.IsAny<int>()))
                .Callback((OrderStatus status, int id) => 
                {
                    Order order = Data.orders.Where(o => o.Id == id).Select(o => o).FirstOrDefault();
                    order.orderStatus = status;
                }).Verifiable();
            orderRepositoryMock.Setup(mq => mq.GetAll()).Returns(Data.orders);
            orderRepositoryMock.Setup(mq => mq.GetUserOders(It.IsAny<string>()))
                .Returns<string>(login =>
                {
                    return Data.orders.Where(o => o.CustomerLogin == login).Select(o => o).ToList();
                });
            orderRepositoryMock.Setup(mq => mq.GetUserCompleteOders(It.IsAny<string>()))
                .Returns<string>(login =>
                {
                    return Data.orders.Where(o => (o.CustomerLogin == login && o.orderStatus == OrderStatus.Completed)).Select(o => o).ToList();
                });

            OrderRepository = orderRepositoryMock.Object;
        }
    }
}
