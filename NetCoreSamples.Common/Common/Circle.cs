using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreSamples.Common.Common
{
    public class Circle : IComparable<Circle>
    {
        public Point Position { get; set; }
        public int Radius { get; set; }

        public int CompareTo(Circle other)
        {
            // A null value means that this object is greater.
            if (other == null)
                return 1;

            else
                return this.Radius.CompareTo(other.Radius);
        }

        //public bool Equals(Circle other)
        //{
        //    //if (other == null) return false;
        //    //Circle objAsPart = other as Circle;
        //    //if (objAsPart == null) return false;
        //    //else return Equals(objAsPart);

        //    throw new NotImplementedException();
        //}
    }
}
