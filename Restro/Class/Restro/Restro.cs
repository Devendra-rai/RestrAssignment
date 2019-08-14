using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restro.Interface.IRestro;
using Restro.Models;
using ConsoleTables;
using Restro.Event;

namespace Restro
{
    public class Restro : IRestro
    {

        public string RestroName { get; set; }
        public string BranchName { get; set; }
        public int TotalBill { get; set; }
        public int TableNumber { get; private set; }

        public  List<ItemsListModel> Item = new List<ItemsListModel>();
        public  List<CustomerListModel> Customer = new List<CustomerListModel>();
        public  List<OrderedItemsModel> OrderedItems = new List<OrderedItemsModel>();
        public  List<TableModel> Table = new List<TableModel>();

        public User user = new User();

        private MessageEvent eventValue;
        public Restro()
        {
            Customer = new List<CustomerListModel>(); 
            SetItems();
            SetTables();
            eventValue = new MessageEvent();
        }

        public void ShowCustomerList(List<CustomerListModel> Customers)
        {
            int count = 1;
            ConsoleTable table = new ConsoleTable("sr.No", "customer Name", "total Cost ", " Rating Given" );

            foreach (var customerInfo in Customers)
            {
                table.AddRow(count++, customerInfo.CustomerName, customerInfo.CustomerBill,customerInfo.CustomerRatingToRestro);
            }
            table.Write(Format.Alternative);
        }

        public void ShowAdmin()
        {
            int choiceInt = 0;
            do
            {
                int choice = GetAndShowAdminChoice();

                switch (choice)
                {
                    case 1:
                        ItemIterate(Item);
                        break;

                    case 2:
                        StatusOfItem(Item);
                        break;

                    case 3:
                        TableAvailable(Table);
                        break;

                    case 4:
                        ShowCustomerList(Customer);
                        break;

                    case 5:
                        Console.WriteLine("Enter the table number you want to make Empty");
                        int tableNumber = Convert.ToInt32(Console.ReadLine());
                        Table[tableNumber - 1].Status = true;
                        break;

                    case 6:
                        break;

                    default:
                        Console.WriteLine("wrong Choice");
                        break;

                }
                if (choice != 6)
                {
                    Console.WriteLine("Do you want to Continue");
                    Console.WriteLine("1 .Yes");
                    Console.WriteLine("0. No");
                    
                    choiceInt = Convert.ToInt32(Console.ReadLine());
                }
                else
                    choiceInt = 1;

            } while (choiceInt == 1);

        }

        public virtual void SetTables()
        {

        }
        public virtual void SetItems()
        {
        
        }
        public void TableAvailable(List<TableModel> Tables)
        {
            Console.WriteLine("Available Tables");
            Console.WriteLine();
            ConsoleTable conTable = new ConsoleTable("Tables", "Status");
            foreach (var table in Tables)
            {
                if (table.Status)
                {
                    conTable.AddRow(table.TableNumber, table.Status);
                }

                //else
                //    continue;
            }
            conTable.Write(Format.Alternative);
        }

        public void Order(string name)
        {
            int choice;
            TotalBill = 0;
            List<OrderedItemsModel> OrderedItemList = new List<OrderedItemsModel>();

            do
            {
                StatusOfItem(Item);
                Console.WriteLine("Enter item id to order food");
                int itemOrdered = Convert.ToInt32(Console.ReadLine());
                ItemsListModel itemList = Item.Where(x => x.ItemId == itemOrdered && x.ItemStatus).FirstOrDefault();
                 if(itemList.ItemStatus)
                 {
                    Console.WriteLine("Enter quantity of ordered food");
                    int quantity = Convert.ToInt32(Console.ReadLine());

                    OrderedItemList.Add(new OrderedItemsModel { ItemName = itemList.ItemName , OrderId = itemList.ItemId, Quantity = quantity, ItemPrice = itemList.ItemPrice });

                    TotalBill += Item[itemOrdered - 1].ItemPrice * quantity;
                }
                else
                {
                    Console.WriteLine("Wrong Input");
                }
                Console.WriteLine("1. Yes");
                Console.WriteLine("0. No");
                Console.WriteLine($"Do you Want To Continue...(1/0)");
                choice = int.Parse(Console.ReadLine());
            } while (choice == 1);
           
            GenerateBill(OrderedItemList, name);
        }

        public void BookTable()
        {
            
            bookTable:

            TableAvailable(Table);

            Console.WriteLine("Please Enter table you want to Book");
            TableNumber = Convert.ToInt32(Console.ReadLine());

            TableModel tableSelect = Table.Where(x => x.TableNumber == TableNumber).FirstOrDefault();
            if (tableSelect.Status)
            {
                tableSelect.Status = false;
                Console.WriteLine("Table Booked");
            }
                
            else
            {
                Console.WriteLine("table is Occupied");
                goto bookTable;
            }
          
            Console.WriteLine("Available Items");
            Console.WriteLine();
        }

        public void ItemIterate(List<ItemsListModel> Value)
        {
            ConsoleTable conTable = new ConsoleTable("Item Id", "Item Name", " Item Price");
            foreach (var item in Value)
            {
                conTable.AddRow(item.ItemId, item.ItemName, item.ItemPrice);

            }
            conTable.Write(Format.Alternative);
        }

        public void StatusOfItem(List<ItemsListModel> Value)
        {
            ConsoleTable conTable = new ConsoleTable("Item Id", "Item Name", " Item Price");
            foreach (var item in Value)
            {
                if (item.ItemStatus)
                {
                    conTable.AddRow(item.ItemId, item.ItemName, item.ItemPrice);
                }
                else
                    continue;
            }
            conTable.Write(Format.Alternative);
        }

        public void GenerateBill(List<OrderedItemsModel> OrderedItems, String Name)
        {
            int s_no = 1;
            Console.WriteLine("----------------------------------------------------------|");
            Console.WriteLine($"-------------------------WelCome-------------------------|");
            Console.WriteLine("----------------------------------------------------------|");
            Console.WriteLine($"Customer Name : { Name}");
            Console.WriteLine();
            Console.WriteLine("sr.no\tItem Name\tprice\t*\tquantity");
            Console.WriteLine();
            foreach (var orderedItem in OrderedItems)
            {
                Console.WriteLine($"{s_no}\t{orderedItem.ItemName}\t\t{orderedItem.ItemPrice}\t*\t{orderedItem.Quantity}");
                s_no++;
            }
            Console.WriteLine("-----------------------------------------------------------|");
            Console.WriteLine($"Total bill : {TotalBill}");
            Console.WriteLine("-----------------------------------------------------------|");

            Console.WriteLine();
            Console.WriteLine("\t********Thank You Visit Again*************");
            Console.WriteLine("-----------------------------------------------------------|");
            Console.WriteLine();
            Console.WriteLine(eventValue.SendMessageAction(Name,TotalBill));
            Console.WriteLine();
            float rating = RatingByCustomer();
            Console.WriteLine();
            Customer.Add(new CustomerListModel { CustomerName = Name, CustomerBill = TotalBill ,CustomerRatingToRestro = rating });

          

        }

        public float RatingByCustomer()
        {
            Console.WriteLine();
            Console.WriteLine("Enter Rating for Restaurant in numbers( 1 - 5) ");
            return float.Parse(Console.ReadLine());
        }

        public int GetAndShowAdminChoice()
        {
            Console.WriteLine("1. Show All Items");
            Console.WriteLine("2. show Available Items");
            Console.WriteLine("3. Show Available tables");
            Console.WriteLine("4. Show Customer visited List");
            Console.WriteLine("5. Make table Empty");
            Console.WriteLine("6. Back to Main Menu");
            Console.WriteLine("Enter your choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
    }
}
