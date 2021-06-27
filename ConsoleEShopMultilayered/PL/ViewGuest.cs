using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShopMultilayered.BLL;
using ConsoleEShopMultilayered.DAL.Entities;
using ConsoleEShopMultilayered.DAL.Enums;
using System.Linq;
/// <summary>
/// Presentation
/// </summary>
namespace ConsoleEShopMultilayered.PL
{
    /// <summary>
    /// View for Guest
    /// </summary>
    class ViewGuest
    {
        /// <summary>
        /// Menu for Guest
        /// </summary>
        public static void Menu()
        {
            Console.Write("Enter the number:\n" +
                "1 - Show All Goods\n" +
                "2 - Find Good With Name\n" +
                "3 - Register\n" +
                "4 - Log In \n");
            HandleMenu();
        }
        /// <summary>
        /// Handle of Guest menu
        /// </summary>
        public static void HandleMenu()
        {
            try
            {
                int key;
                key = Int32.Parse(Console.ReadLine());
                if ((key < 1) || (key > 4)) { Console.WriteLine("Wrong Input"); return; }
                List<Action> action = new List<Action>();
                action.Add(ShowAllGoods);
                action.Add(SearchGoodsByName);
                action.Add(Register);
                action.Add(LogIn);
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
        /// Show all goods from data
        /// </summary>
        public static void ShowAllGoods()
        {
            List<Goods> goods = Guest.ViewAllGoods();
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
            List<Goods> goods = Guest.SearchByName(name);
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
        /// Register new account
        /// </summary>
         public static void Register()
         {
            Console.WriteLine("Input your Login");
            string login = Console.ReadLine();
            while (true)
            {
                if (!Guest.CheckLogin(login))
                {
                    Console.WriteLine("This Login is already taken");
                    Console.WriteLine("Input your Login");
                    login = Console.ReadLine();
                }
                else break;
            }
            Console.WriteLine("Input your Password");
            string password = Console.ReadLine();
            while (true)
            {
                if (password.Length <= 5)
                {
                    Console.WriteLine("Password length must be more than 5");
                    Console.WriteLine("Input your Password");
                    password = Console.ReadLine();
                }
                else break;
            }
            User user = new User(login, password, UserType.Registered);
            Guest.Register(user);
        }
       
         
        /// <summary>
        /// Log in to account
        /// Input login and password
        /// </summary>
         public static void LogIn()
         {
            string login = "";
            string password = "";
            Console.WriteLine("Input your Login:");
            login = Console.ReadLine();
            Console.WriteLine("Input your Password:");
            password = Console.ReadLine();
            if (!Guest.CheckForLogIn(login, password))
            {
                Console.WriteLine("Wrong login or password.");
            } else
            {
                Guest.LogIn(login, password);
            }
         }

         
    }
}
