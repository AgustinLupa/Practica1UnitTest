using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.Models.Interface
{
    public interface ICompositeCalculator
    {
        public short Type_interest { get; set; }
        public double ammount_initial { get; set; }
        public short Type_Sums_Wallet { get; set; }
        public double Interest { get; set; }
        public double Sums_Wallet { get; set; }
        public int YearsOfInterest { get; set; }
    }
}
