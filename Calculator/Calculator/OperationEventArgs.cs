using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class OperationEventArgs : EventArgs
    {
        public double? Number1 { get; set; }
        
        public double? Number2 { get; set; }
        
        public string op { get; set; }
    }
}
