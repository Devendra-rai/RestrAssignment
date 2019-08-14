using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restro
{
    public class OrderedItemsModel
    {
        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public int ItemPrice { get; set; }

        public string ItemName { get; set; }

    }
}
