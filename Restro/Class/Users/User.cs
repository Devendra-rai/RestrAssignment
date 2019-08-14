using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restro.Interface.IRestro;
using Restro.Models;

namespace Restro
{
    public class User
    {
       
        public string UserName { get; set; }

        public void UserInfo()
        {
            Console.WriteLine("Enter user Name");
            UserName = Console.ReadLine();
        }

        public void ShowCustomer(IRestro restro)
        {
            UserInfo();
        
            restro.BookTable();

            restro.Order(UserName);

        }
    }
}
