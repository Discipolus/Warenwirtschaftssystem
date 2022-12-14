using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Konstrukte
{
    public class MaßeTemplate : IEditableObject
    {
        #region Propertys
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        #endregion

        #region Konstruktoren
        public MaßeTemplate(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public MaßeTemplate() : this(0, 0, 0){}
        public MaßeTemplate(double[] maße) : this(maße[0], maße[1], maße[2]){}
        #endregion

        public override string ToString()
        {
            return "(" + X + "|" + Y + "|" + Z + ")";
        }
        public double[] ToArray()
        {
            return new double[3] { X, Y, Z };
        }
        
    }
}
