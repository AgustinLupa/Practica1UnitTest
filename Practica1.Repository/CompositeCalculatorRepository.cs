using Practica1.Database;
using Practica1.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.Repository
{
    public class CompositeCalculatorRepository
    {
        readonly ICompositeCalculatorServices Services;
        public CompositeCalculatorRepository()
        {
            Services = new CompositeCalculatorServices();
        }
        
        public double Calculate(ICompositeCalculator calculator)
        {
            if (calculator == null)
            {
                throw new ArgumentException(nameof(calculator), "El objeto calculador no puede ser nulo.");
            }

            if (calculator.Type_Sums_Wallet <= 0 || calculator.Type_Sums_Wallet > 2)
            {
                throw new ArgumentException("Elige un tipo de adicion valida para la wallet 1 por mes y 2 por año.");
            }

            if (calculator.Type_interest <= 0 || calculator.Type_interest > 2) 
            {
                throw new ArgumentException("Elige un tipo de interes valido, 1 para calcular por dia y 2 para calcular por mes.");
            }

            if (calculator.YearsOfInterest <= 0)
            {
                throw new ArgumentException("Los años de interés deben ser mayores que cero.");
            }

            if (calculator.ammount_initial <= 0)
            {
                throw new ArgumentException("La cantidad inicial debe ser mayor que cero.");
            }

            if (calculator.Interest <= 0)
            {
                throw new ArgumentException("La tasa de interés debe ser mayor que cero.");
            }

            if (calculator.Sums_Wallet <= 0)
            {
                throw new ArgumentException("Las sumas en la cartera deben ser mayores que cero.");
            }


            return Services.Calculate(calculator);
        }
    }
}
