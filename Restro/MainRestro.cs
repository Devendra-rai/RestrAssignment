using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Restro.Interface.IRestro;
using Restro.Class;
using Restro.Class.KFC;

namespace Restro
{
    class MainRestro
    {
        IRestro KfcRestro = null;
        IRestro DominosRestro = null;
        public MainRestro(IRestro kfc, IRestro domino)
        {
            KfcRestro = kfc;
            DominosRestro = domino;
        }

        public void StartApplication()
        {
        start:
            IRestro iRestro = chooseRestro();
            while (true)
            {
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Customer");
                Console.WriteLine("3. Back to Restro choice");
                Console.WriteLine("Please Enter Your Choice");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        iRestro.ShowAdmin();
                        break;

                    case 2:
                        User user = new User();
                        user.ShowCustomer(iRestro);
                        break;

                    case 3:
                        goto start;

                    default:
                        Console.WriteLine("Wrong choice");
                        Environment.Exit(0);
                        break;
                }
            }
            Console.ReadKey();
        }

        public IRestro chooseRestro()
        {
            IRestro restro = null;
            int choice = 0;
            do
            {
                Console.WriteLine("1. Dominos");
                Console.WriteLine("2. KFC");
                Console.WriteLine("Enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        restro = DominosRestro;
                        
                        break;

                    case 2:
                        restro = KfcRestro;
                        break;

                    default:
                        break;
                }

            } while (choice > 2);

            return restro;
        }
      
        public static void Main(string[] args)
        {
            MainRestro mainRestro = new MainRestro(new KFC(), new Dominos());
            mainRestro.StartApplication();
        }
     }
    
}










































