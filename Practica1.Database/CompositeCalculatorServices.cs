using Practica1.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.Database
{
    public class CompositeCalculatorServices : ICompositeCalculatorServices
    {
        public double Calculate(ICompositeCalculator calculator)
        {
            //1 = dia, 2 = mes
            if (calculator.Type_interest == 1)
            {
                //1= mes, 2=año
                if (calculator.Type_Sums_Wallet == 1)
                {
                    double result = calculator.ammount_initial;

                    for (int o = 0; o <= calculator.YearsOfInterest - 1; o++)
                    {
                        for (int i = 0; i < 264; i++)
                        {
                            result += result * (calculator.Interest / 100);
                            if (i != 0 && i % 30 == 0)
                                result += calculator.Sums_Wallet;
                        }                       
                    }
                    return Math.Round(result, 4);
                }
                else
                {
                    double result = calculator.ammount_initial;

                    for (int o = 0; o <= calculator.YearsOfInterest-1; o++)
                    {
                        for (int i = 0; i < 264; i++)
                        {
                            result += result * (calculator.Interest / 100);                            
                                
                        }
                        result += calculator.Sums_Wallet;
                    }
                    return Math.Round(result, 4);
                }
            }
            else
            {
                if (calculator.Type_Sums_Wallet == 1)
                {
                    double result = calculator.ammount_initial;

                    for (int o = 0; o <= calculator.YearsOfInterest-1; o++)
                    {
                        for (int i = 0; i < 12; i++)
                        {
                            result += result * (calculator.Interest / 100);                            
                            result += calculator.Sums_Wallet;
                        }
                    }
                    return Math.Round(result, 4);
                }
                else
                {
                    double result = calculator.ammount_initial;

                    for (int o = 0; o <= calculator.YearsOfInterest-1; o++)
                    {
                        for (int i = 0; i < 12; i++)
                        {
                            result += result * (calculator.Interest / 100);

                        }
                        result += calculator.Sums_Wallet;
                    }
                    return Math.Round(result, 4);
                }
            }
        }
    }
}
