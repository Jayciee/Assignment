using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer
{
    public partial class Size
    {
        public Size()
        {
            Monsters = new HashSet<Monster>();
        }

        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public decimal SizeFloor { get; set; }
        public decimal SizeCeiling { get; set; }

        public virtual ICollection<Monster> Monsters { get; set; }
    }
}
