using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
    public class Box : Item
    {
        public Box(double a, double b, double c, double weight) : base(weight)
        {
            if (a > 0 && b > 0 && c > 0)
            {
                A = a;
                B = b;
                C = c;
            }
            else
                throw new ArgumentException("Измерения должны быть больше 0!");
        }

        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public double GetLongestSide() => Math.Max(Math.Max(A, B), C);
        public override string ToString() => base.ToString() + $" A: {A} B: {B} C: {C} Longest: {GetLongestSide()}";

    }
}
