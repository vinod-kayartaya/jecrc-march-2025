using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    interface IShape
    {

        public string ShapeName { get; }

        public void PrintArea();
    }
}
