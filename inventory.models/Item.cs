using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory.models
{
    internal class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime CreateAt { get; set; }

        public int AvailQuantity { get; set; }

        public Status Status { get; set; }
    }
}

namespace inventory.models
{
    public enum Status
    {
        Ok, Defective
    }
}