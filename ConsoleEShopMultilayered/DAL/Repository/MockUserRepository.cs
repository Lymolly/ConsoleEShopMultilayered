using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using ConsoleEShopMultilayered.DAL.Entities;
using ConsoleEShopMultilayered.DL;
using ConsoleEShopMultilayered.DAL.Enums;
using ConsoleEShopMultilayered.PL;
using ConsoleEShopMultilayered.BLL;
using System.Linq;
/// <summary>
/// Repository
/// </summary>
namespace ConsoleEShopMultilayered.DAL.Repository
{
    /// <summary>
    /// Class for Mock users data
    /// </summary>
    public static class MockUserRepository
    {
        /// <summary>
        /// Object of mock
        /// </summary>
        public static IUserRepository UserRepository;
        /// <summary>
        /// Constructor to initialization mock 
        /// </summary>
        static MockUserRepository()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(mq => mq.Add(It.IsAny<User>())).Callback((User user) =>
            {
                Data.users.Add(user);
            }).Verifiable();
            userRepositoryMock.Setup(mq => mq.ChangePersonalInformation(It.IsAny<User>(), It.IsAny<User>())).Callback((User user, User temp) =>
            {
                if (temp.Login != null) user.Login = temp.Login;
                if (temp.Password != null) user.Password = temp.Password;
            }).Verifiable();
            userRepositoryMock.Setup(mq => mq.GetAll()).Returns(Data.users);
            userRepositoryMock.Setup(mq => mq.Authorization(It.IsAny<string>(), It.IsAny<string>()))
                .Callback((string login, string password) =>
                {
                    User temp = Data.users.Where(a => (a.Login == login) && (a.Password == password)).FirstOrDefault();
                    if (temp.Status == UserType.Registered)
                    {
                        Registered.user = temp;
                        ViewHandler.menu = ViewRegistered.Menu;
                    }
                    else
                    {
                        Admin.user = temp;
                        ViewHandler.menu = ViewAdmin.Menu;
                    }
                }).Verifiable();
            UserRepository = userRepositoryMock.Object;
        }
    }
}
