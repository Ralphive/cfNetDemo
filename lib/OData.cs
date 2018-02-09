using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cfNetDemo.lib
{
    public class OData
    {
        public string odatametadata { get; set; }
        public Item[] value { get; set; }
        public string odatanextLink { get; set; }
    }

    public class Item
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public float QuantityOnStock { get; set; }
        public float QuantityOrderedFromVendors { get; set; }
        public float QuantityOrderedByCustomers { get; set; }
    }

}
