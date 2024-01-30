using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.Models.Interface
{
    public interface ICompositeCalculatorServices
    {
        public double Calculate(ICompositeCalculator calculator);
    }
}
