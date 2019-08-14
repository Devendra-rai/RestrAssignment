using Restro.Interface.IRestro;
using Restro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restro.Class.KFC
{
    class KFC : Restro , IRestro
    {
        public override void SetTables()
        {
            Table.Add(new TableModel { TableNumber = 1, Status = true });
            Table.Add(new TableModel { TableNumber = 2, Status = true });
            Table.Add(new TableModel { TableNumber = 3, Status = true });
            Table.Add(new TableModel { TableNumber = 4, Status = true });


        }
        public override void SetItems()
        {
            Item.Add(new ItemsListModel { ItemId = 1, ItemName = "Chicken Berger", ItemPrice = 50, ItemStatus = true });
            Item.Add(new ItemsListModel { ItemId = 2, ItemName = "Chicken fries", ItemPrice = 40, ItemStatus = false });
            Item.Add(new ItemsListModel { ItemId = 3, ItemName = "Chicken Rice", ItemPrice = 30, ItemStatus = true });
            Item.Add(new ItemsListModel { ItemId = 4, ItemName = "Beverage", ItemPrice = 40, ItemStatus = true });
            Item.Add(new ItemsListModel { ItemId = 5, ItemName = "chicken Bucket", ItemPrice = 100, ItemStatus = true });
      
        }
    }
}
