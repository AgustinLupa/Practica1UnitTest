using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.Models.Interface
{
    public interface ICompositeCalculatorRepository
    {
        public double CalculateInterest(ICompositeCalculator calculator);
    }
}
