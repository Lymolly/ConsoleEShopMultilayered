﻿using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShopMultilayered.BLL;
using ConsoleEShopMultilayered.DAL.Entities;
using System.Linq;
/// <summary>
/// Presentation
/// </summary>
namespace ConsoleEShopMultilayered.PL
{
    /// <summary>
    /// View for Registered
    /// </summary>
    class ViewRegistered
    {
        /// <summary>
        /// Menu for Registered
        /// </summary>
        public static void Menu()
        {
            if (Registered.user == null) return;
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enter the number:\n" +
                "1 - Show All Goods\n" +
                "2 - Find Good With Name\n" +
                "3 - Create a new Order\n" +
                "4 - Complete Order\n" +
                "5 - Deny Order\n" +
                "6 - List of Orders\n" +
                "7 - List of Completed orders\n" +
                "8 - Change status to Complete\n" +
                "9 - Change your profile\n" +
                "10 - LogOut\n");
            HandleMenu();
        }
        /// <summary>
        /// Handle of Registered menu
        /// </summary>
        public static void HandleMenu()
        {
            try
            {
                int key;
                key = Int32.Parse(Console.ReadLine());
                if ((key < 1) || (key > 10)) { Console.WriteLine("Wrong Input"); return; }
                List<Action> action = new List<Action>();
                action.Add(ShowAllProducts);
                action.Add(SearchGoodsByName);
                 action.Add(CreateNewOrder);
                action.Add(CheckoutOrder);
                action.Add(DenyOrder);
                 action.Add(ShowListOfOrders);
                action.Add(ShowListOfCompletedOrders);
                action.Add(ChangeStatusToComplete);
                action.Add(ChangeProfile);
                 action.Add(LogOut);
                action[key - 1].Invoke();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        ///  Show all goods from data
        /// </summary>
        public static void ShowAllProducts()
        {
            List<Goods> goods = Registered.ViewAllGoods();
            foreach (Goods g in goods)
            {
                Console.WriteLine("ID:" + g.Id);
                Console.WriteLine("Name:" + g.Name);
                Console.WriteLine("Description:" + g.Description);
                Console.WriteLine("Price:" + g.Price + "$");
            }
        }
        /// <summary>
        /// Show goods whith such name
        /// </summary>
        public static void SearchGoodsByName()
        {
            string name = "";
            Console.WriteLine("Input name of goods");
            name = Console.ReadLine();
            List<Goods> goods = Registered.SearchByName(name);
            if (goods.Count == 0)
            {
                Console.WriteLine("Nothing found");
            }
            else
            {
                foreach (Goods g in goods)
                {
                    Console.WriteLine("ID:" + g.Id);
                    Console.WriteLine("Name:" + g.Name);
                    Console.WriteLine("Description:" + g.Description);
                    Console.WriteLine("Price:" + g.Price + "$");
                }
            }

        }
        /// <summary>
        /// Add goods to user basket
        /// Input goods id 
        /// </summary>
        public static void CreateNewOrder()
        {
            Console.WriteLine("Input good id");
            while (true)
            {
                
                int id = Convert.ToInt32(Console.ReadLine());
                if (id == -1) break;
                if (Registered.ViewAllGoods().Where(g => g.Id == id).Select(g => g).Count() > 0)
                {
                    Registered.AddToBasket(Registered.ViewAllGoods().Where(g => g.Id == id).Select(g => g).FirstOrDefault());
                } else
                {
                    Console.WriteLine("Nothing found");
                }
                Console.WriteLine("If you want end add to basket input -1 or goods id");
            }
        }
        /// <summary>
        /// Create new order
        /// Input order information
        /// </summary>
        public static void CheckoutOrder()
        {
            Console.WriteLine("Input customer name: ");
            string customerName = Console.ReadLine();
            Console.WriteLine("Input customer phone: ");
            string customerPhoneNumber = Console.ReadLine();
            Console.WriteLine("Input delivery address: ");
            string deliveryAddress = Console.ReadLine();
            Registered.Checkout(customerName, customerPhoneNumber, deliveryAddress);
        }
        /// <summary>
        /// Deny order 
        /// Input order id
        /// </summary>
        public static void DenyOrder()
        {
            Console.WriteLine("Input order id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (Registered.DenyOrder(id))
            {
                Console.WriteLine("Order was denied.");
            }
            else Console.WriteLine("Wrong id.");
        }
        /// <summary>
        /// Show all user orders
        /// </summary>
        public static void ShowListOfOrders()
        {
            List<Order> orders = Registered.UserOrders();
            foreach (Order o in orders)
            {
                Console.WriteLine("Customer Name: " + o.CustomerName);
                Console.WriteLine("Customer PhoneNumber: " + o.CustomerPhoneNumber);
                Console.WriteLine("DeliveryAddress: " + o.DeliveryAddress);
                Console.WriteLine("Order Status: " + o.orderStatus);
                foreach (Goods g in o.Goods)
                {
                    Console.WriteLine("ID:" + g.Id);
                    Console.WriteLine("Name:" + g.Name);
                    Console.WriteLine("Description:" + g.Description);
                    Console.WriteLine("Price:" + g.Price + "$");
                }
            }
        }
        /// <summary>
        /// Show completed user orders
        /// </summary>
        public static void ShowListOfCompletedOrders()
        {
            List<Order> orders = Registered.UserCompleteOrders();
            foreach (Order o in orders)
            {
                Console.WriteLine("Customer Name: " + o.CustomerName);
                Console.WriteLine("Customer PhoneNumber: " + o.CustomerPhoneNumber);
                Console.WriteLine("DeliveryAddress: " + o.DeliveryAddress);
                Console.WriteLine("Order Status: " + o.orderStatus);
                foreach (Goods g in o.Goods)
                {
                    Console.WriteLine("ID:" + g.Id);
                    Console.WriteLine("Name:" + g.Name);
                    Console.WriteLine("Description:" + g.Description);
                    Console.WriteLine("Price:" + g.Price + "$");
                }
            }
        }
        /// <summary>
        /// Change order status to complete
        /// Input order id
        /// </summary>
        public static void ChangeStatusToComplete()
        {
            Console.WriteLine("Input order id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Registered.ChangeStatusToComplete(id);
        }
        /// <summary>
        /// Change user information
        /// Input new information
        /// </summary>
        public static void ChangeProfile()
        {
            User user = new User(null, null);
            bool flag = true;
            int key;
            while (flag)
            {
                Console.WriteLine("Choose what you want to change:");
                Console.WriteLine(
                    "1 - Login\n" +
                    "2 - Password\n" +
                    "3 - SaveChanges\n");
                key = Int32.Parse(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        user.Login = Change();
                        break;
                    case 2:
                        user.Password = Change();
                        break;  
                    case 3:
                        flag = false;
                        break;
                }
            }
            Registered.ChangeProfile(user);
        }
        /// <summary>
        /// Input new information
        /// </summary>
        /// <returns>New info</returns>
        private static string Change()
        {
            Console.WriteLine("Input new one:");
            string temp = Console.ReadLine();
            return temp;
        }
        /// <summary>
        /// Log out from account
        /// </summary>
        public static void LogOut()
        {
            Registered.LogOut();
        }
    }
}
