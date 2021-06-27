using NUnit.Framework;
using ConsoleEShopMultilayered.DL;
using ConsoleEShopMultilayered.BLL;
using ConsoleEShopMultilayered.DAL.Entities;
using ConsoleEShopMultilayered.DAL.Repository;
using ConsoleEShopMultilayered.DAL.Enums;
using System;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ViewAllGoods_Guest_ListOfGoods()
        {
            MockGoodsRepository.GoodsRepository.Add(new Goods("Name2", "Descr2", 16m));
            Goods[] expected = new Goods[] { new Goods("product", "good", 10m), new Goods("Name2", "Descr2", 16m) };
            Goods[] actual = Guest.ViewAllGoods().ToArray();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "View goods work incorrectry.");
        }
        [Test]
        public void ViewAllGoods_Registered_ListOfGoods()
        {
            MockGoodsRepository.GoodsRepository.Add(new Goods("Name2", "Descr2", 16m));
            Goods[] expected = new Goods[] { new Goods("product", "good", 10m), new Goods("Name2", "Descr2", 16m) };
            Goods[] actual = Registered.ViewAllGoods().ToArray();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "View goods work incorrectry.");
        }
        [Test]
        public void ViewAllGoods_Admin_ListOfGoods()
        {
            MockGoodsRepository.GoodsRepository.Add(new Goods("Name2", "Descr2", 16m));
            Goods[] expected = new Goods[] { new Goods("product", "good", 10m), new Goods("Name2", "Descr2", 16m) };
            Goods[] actual = Admin.ViewAllGoods().ToArray();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "View goods work incorrectry.");
        }
        [Test]
          public void SearchByName_Guest_ListOfGoods()
          {
              MockGoodsRepository.GoodsRepository.Add(new Goods("Name2", "Descr2", 16m));
              MockGoodsRepository.GoodsRepository.Add(new Goods("Name2", "Descr3", 18m));
              Goods[] expected = new Goods[] { new Goods("Name2", "Descr2", 16m), new Goods("Name2", "Descr3", 18m) };
              Goods[] actual = Guest.SearchByName("Name2").ToArray();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "SearchByName work incorrectry.");
          }
        [Test]
        public void SearchByName_Registered_ListOfGoods()
        {
            MockGoodsRepository.GoodsRepository.Add(new Goods("Name2", "Descr2", 16m));
            MockGoodsRepository.GoodsRepository.Add(new Goods("Name2", "Descr3", 18m));
            Goods[] expected = new Goods[] { new Goods("Name2", "Descr2", 16m), new Goods("Name2", "Descr3", 18m) };
            Goods[] actual = Registered.SearchByName("Name2").ToArray();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "SearchByName work incorrectry.");
        }
        [Test]
        public void SearchByName_Admin_ListOfGoods()
        {
            MockGoodsRepository.GoodsRepository.Add(new Goods("Name2", "Descr2", 16m));
            MockGoodsRepository.GoodsRepository.Add(new Goods("Name2", "Descr3", 18m));
            Goods[] expected = new Goods[] { new Goods("Name2", "Descr2", 16m), new Goods("Name2", "Descr3", 18m) };
            Goods[] actual = Admin.SearchByName("Name2").ToArray();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "SearchByName work incorrectry.");
        }
         [Test]
        public void Registration_AddUser_UserAdded()
        {
           
            Guest.Register(new User("Loginnn", "password"));
            User[] expected = new User[] { new User("login", "12345", UserType.Administrator), new User("Loginnn", "password", UserType.Registered) };
            User[] actual = MockUserRepository.UserRepository.GetAll().ToArray();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "Registration user work incorrectly");


        }
          [Test]
         public void CreateNewOrderUser_Goods_AddToBasket()
         {
            User user = new User("log", "123456");
             Goods goods = new Goods("goods", "desc", 10m);
            Registered.user = user;
            Registered.AddToBasket(goods);
             Goods[] expected = new Goods[] { new Goods("goods", "desc", 10m) };
             Goods[] actual = Registered.user.Basket.ToArray();
            Data.Clean();
             Assert.AreEqual(expected, actual, message: "CreateNewOrder work incorrectly");
         }
        [Test]
        public void CreateNewOrderAdmin_Goods_AddToBasket()
        {
            User user = new User("log", "123456");
            Goods goods = new Goods("goods", "desc", 10m);
            Admin.user = user;
            Admin.AddToBasket(goods);
            Goods[] expected = new Goods[] { new Goods("goods", "desc", 10m) };
            Goods[] actual = Admin.user.Basket.ToArray();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "CreateNewOrder work incorrectly");
        }
        [Test]
        public void CheckoutByUser_Basket_NewOrder()
        {
            User user = new User("log", "123456");
            Registered.user = user;
            Registered.AddToBasket(new Goods("goods", "desc", 10m));
            Registered.Checkout("name","34234","sdsas");
            Order[] expected = new Order[] { new Order("log", "name", "34234", "sdsas", (new Goods[] { new Goods("goods", "desc", 10m) }).ToList()) };
            Order[] actual = MockOrderRepository.OrderRepository.GetAll().ToArray();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "Checkout work incorrectly");
        }
        [Test]
        public void CheckoutByAdmin_Basket_NewOrder()
        {
            User user = new User("log", "123456");
            Admin.user = user;
            Admin.AddToBasket(new Goods("goods", "desc", 10m));
            Admin.Checkout("name", "34234", "sdsas");
            Order[] expected = new Order[] { new Order("log", "name", "34234", "sdsas", (new Goods[] { new Goods("goods", "desc", 10m) }).ToList()) };
            Order[] actual = MockOrderRepository.OrderRepository.GetAll().ToArray();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "Checkout work incorrectly");
        }
        [Test]
        public void DenyOrderUser_NewOrder_DenyOrder()
        {
            User user = new User("log", "123456");
            Registered.user = user;
            Registered.AddToBasket(new Goods("goods", "desc", 10m));
            Registered.Checkout("name", "34234", "sdsas");
            Order order = MockOrderRepository.OrderRepository.GetAll().FirstOrDefault();
            Registered.DenyOrder(order.Id);
            Order order1 = new Order("log", "name", "34234", "sdsas", (new Goods[] { new Goods("goods", "desc", 10m) }).ToList());
            order1.orderStatus = OrderStatus.CanceledByUser;
            Order[] expected = new Order[] { order1 };
            Order[] actual = MockOrderRepository.OrderRepository.GetAll().ToArray();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "DenyOrder work incorrectly");
        }
        [Test]
        public void DenyOrderAdmin_NewOrder_DenyOrder()
        {
            User user = new User("log", "123456");
            Admin.user = user;
            Admin.AddToBasket(new Goods("goods", "desc", 10m));
            Admin.Checkout("name", "34234", "sdsas");
            Order order = MockOrderRepository.OrderRepository.GetAll().FirstOrDefault();
            Admin.DenyOrder(order.Id);
            Order order1 = new Order("log", "name", "34234", "sdsas", (new Goods[] { new Goods("goods", "desc", 10m) }).ToList());
            order1.orderStatus = OrderStatus.CanceledByAdministrator;
            Order[] expected = new Order[] { order1 };
            Order[] actual = MockOrderRepository.OrderRepository.GetAll().ToArray();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "DenyOrder work incorrectly");
        }
        [Test]
        public void ChangeStatusToComplete_Order_ChangeStatusOrder()
        {
            User user = new User("log", "123456");
            Registered.user = user;
            Registered.AddToBasket(new Goods("goods", "desc", 10m));
            Registered.Checkout("name", "34234", "sdsas");
            Order order = MockOrderRepository.OrderRepository.GetAll().FirstOrDefault();
            Registered.ChangeStatusToComplete(order.Id);
            Order order1 = new Order("log", "name", "34234", "sdsas", (new Goods[] { new Goods("goods", "desc", 10m) }).ToList());
            order1.orderStatus = OrderStatus.Completed;
            Order[] expected = new Order[] { order1 };
            Order[] actual = MockOrderRepository.OrderRepository.GetAll().ToArray();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "ChangeStatusToComplete work incorrectly");
        }
        [Test]
        public void ChangeStatusAdmin_Order_ChangeStatusOrder()
        {
            User user = new User("log", "123456");
            Admin.user = user;
            Admin.AddToBasket(new Goods("goods", "desc", 10m));
            Admin.Checkout("name", "34234", "sdsas");
            Order order = MockOrderRepository.OrderRepository.GetAll().FirstOrDefault();
            Admin.ChangeStatus(order.Id, OrderStatus.Sent);
            Order order1 = new Order("log", "name", "34234", "sdsas", (new Goods[] { new Goods("goods", "desc", 10m) }).ToList());
            order1.orderStatus = OrderStatus.Sent;
            Order[] expected = new Order[] { order1 };
            Order[] actual = MockOrderRepository.OrderRepository.GetAll().ToArray();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "ChangeStatus work incorrectly");
        }
        [Test]
          public void CheckoutByUser_EmptyBasket_Exception()
          {
            User user = new User("log", "123456");
            Registered.user = user;
            Data.Clean();
            Assert.Throws<ArgumentException>(() => Registered.Checkout("Name", "322324", "adress12"));
          }
        [Test]
        public void CheckoutByAdmin_EmptyBasket_Exception()
        {
            User user = new User("log", "123456");
            Admin.user = user;
            Data.Clean();
            Assert.Throws<ArgumentException>(() => Admin.Checkout("Name", "322324", "adress12"));
        }

        [Test]
          public void ChangePersonalInformation_ChangeLogin_ChangedByUser()
          {
            User user = new User("log", "123456");
            Registered.user = user;
            Registered.ChangeProfile(new User("logg", "123456"));
            User expected = new User("logg", "123456");
            Data.Clean();
            Assert.AreEqual(expected, Registered.user, message: "Change login work incorrectly");
          }
        [Test]
        public void ChangePersonalInformation_ChangePassword_ChangedByUser()
        {
            User user = new User("log", "123456");
            Registered.user = user;
            Registered.ChangeProfile(new User("log", "2345678"));
            User expected = new User("log", "2345678");
            Data.Clean();
            Assert.AreEqual(expected, Registered.user, message: "Change password work incorrectly");
        }
        [Test]
        public void ChangePersonalInformation_ChangeLogin_ChangedByAdmin()
        {
            User user = new User("log", "123456");
            MockUserRepository.UserRepository.Add(user);
            User userA = new User("loggg", "123456");
            Admin.user = userA;
            Admin.ChangeProfile(user,new User("logg", "123456"));
            User expected = new User("logg", "123456");
            User actual = MockUserRepository.UserRepository.GetAll().Where(u => u.Id == user.Id).Select(u => u).FirstOrDefault();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "Change login work incorrectly");
        }
        [Test]
        public void ChangePersonalInformation_ChangePassword_ChangedByAdmin()
        {
            User user = new User("log", "123456");
            MockUserRepository.UserRepository.Add(user);
            User userA = new User("loggg", "123456");
            Admin.user = userA;
            Admin.ChangeProfile(user, new User("log", "1234566"));
            User expected = new User("log", "1234566");
            User actual = MockUserRepository.UserRepository.GetAll().Where(u => u.Id == user.Id).Select(u => u).FirstOrDefault();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "Change password work incorrectly");
        }
        [Test]
        public void AddGoods_NewGoods_AddToData()
        {
            User user = new User("log", "123456");
            Admin.user = user;
            Goods goods = new Goods("Name2", "Descr2", 16m);
            Admin.AddGoods(goods);
            Goods[] expected = new Goods[] { new Goods("product", "good", 10m), new Goods("Name2", "Descr2", 16m) };
            Goods[] actual = Guest.ViewAllGoods().ToArray();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "AddGoods work incorrectly");
        }
        [Test]
        public void ChangeGood_GoodsName_ChangeInfo()
        {
            User user = new User("log", "123456");
            Admin.user = user;
            Goods goods = new Goods("Name2", "Descr2", 16m);
            Admin.AddGoods(goods);
            Goods goods1 = new Goods("Name5", "Descr2", 16m);
            Admin.ChangeGood(goods1, goods.Id);
            Goods[] expected = new Goods[] { new Goods("product", "good", 10m), new Goods("Name5", "Descr2", 16m) };
            Goods[] actual = Guest.ViewAllGoods().ToArray();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "ChangeGood work incorrectly");
        }
        [Test]
        public void ChangeGood_GoodsDescription_ChangeInfo()
        {
            User user = new User("log", "123456");
            Admin.user = user;
            Goods goods = new Goods("Name2", "Descr2", 16m);
            Admin.AddGoods(goods);
            Goods goods1 = new Goods("Name2", "Descr5", 16m);
            Admin.ChangeGood(goods1, goods.Id);
            Goods[] expected = new Goods[] { new Goods("product", "good", 10m), new Goods("Name2", "Descr5", 16m) };
            Goods[] actual = Guest.ViewAllGoods().ToArray();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "ChangeGood work incorrectly");
        }
        [Test]
        public void ChangeGood_GoodsPrice_ChangeInfo()
        {
            User user = new User("log", "123456");
            Admin.user = user;
            Goods goods = new Goods("Name2", "Descr2", 16m);
            Admin.AddGoods(goods);
            Goods goods1 = new Goods("Name2", "Descr2", 19m);
            Admin.ChangeGood(goods1, goods.Id);
            Goods[] expected = new Goods[] { new Goods("product", "good", 10m), new Goods("Name2", "Descr2", 19m) };
            Goods[] actual = Guest.ViewAllGoods().ToArray();
            Data.Clean();
            Assert.AreEqual(expected, actual, message: "ChangeGood work incorrectly");
        }
      
    }
}