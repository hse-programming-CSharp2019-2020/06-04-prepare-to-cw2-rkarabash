using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
    public class Item : IComparable<Item>
    {
        public Item(double weight)
        {
            if (weight >= 0)
                Weight = weight;
            else
                throw new ArgumentException("Масса не может быть отрицательной!");
        }

        public double Weight { get; set; }
        public int CompareTo(Item other)
        {
            if (this.Weight > other.Weight)
                return 1;
            else if (this.Weight == other.Weight)
                return 0;
            else
                return -1;
        }
        public override string ToString()
        {
            return $"Weight: {Weight}";
        }
        public static explicit operator double(Item item)
        {
            return item.Weight;
        }

    }
}
