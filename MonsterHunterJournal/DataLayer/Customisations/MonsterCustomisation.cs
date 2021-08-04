using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public partial class Monster
    {
        public override string ToString()
        {
            return $"{Name} of type {Type} of element {PrimaryElement}";
        }
    }
}
