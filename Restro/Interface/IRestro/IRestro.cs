using Restro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restro.Interface.IRestro
{
    public interface IRestro
    {
        int GetAndShowAdminChoice();

        void ShowAdmin();

        void SetTables();

        void SetItems();

        void Order(string name);

        void BookTable();

        void TableAvailable(List<TableModel> table);

        void ItemIterate(List<ItemsListModel> value);

        void StatusOfItem(List<ItemsListModel> value);

        void ShowCustomerList(List<CustomerListModel> customers);

        void GenerateBill(List<OrderedItemsModel> orderedItem, String name);

    }
}
