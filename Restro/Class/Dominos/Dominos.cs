using Restro.Interface.IRestro;
using Restro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restro.Class
{
    class Dominos : Restro, IRestro
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
            Item.Add(new ItemsListModel { ItemId = 1, ItemName = "Cheese Berger", ItemPrice = 100, ItemStatus = true });
            Item.Add(new ItemsListModel { ItemId = 2, ItemName = "Veg Pizza", ItemPrice = 80, ItemStatus = true });
            Item.Add(new ItemsListModel { ItemId = 3, ItemName = "NonVeg Pizza", ItemPrice = 200, ItemStatus = true });
            Item.Add(new ItemsListModel { ItemId = 4, ItemName = "Pizza mania", ItemPrice = 150, ItemStatus = true });
            Item.Add(new ItemsListModel { ItemId = 5, ItemName = "Extra Cheese Pizza", ItemPrice = 200, ItemStatus = true });
        }
    }
}
