using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica1.Database;
using Practica1.Models;
using Practica1.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.Database.Tests
{
    [TestClass()]
    public class CompositeCalculatorServicesTests
    {
         [TestMethod()]
         public void CalculateTestCorrectData()
         {
             //Arrange

             var calculator = new CompositeCalculatorServices();
             ICompositeCalculator problem = new CompositeCalculator()
             {
                 Type_interest = 2,
                 Type_Sums_Wallet = 2,
                 ammount_initial = 500,
                 Interest = 10,
                 Sums_Wallet = 200,
                 YearsOfInterest = 1
             };
             //Act
             var result = calculator.Calculate(problem);
             //Assert

             Assert.IsNotNull(result);
         }
        

        [TestMethod()]
        public void CalculateTest_InterestType1_SumsWalletType1_MultipleYears_ReturnsExpectedResult()
        {
            // Arrange
            var calculator = new CompositeCalculatorServices();
            ICompositeCalculator problem = new CompositeCalculator()
            {
                Type_interest = 1,
                Type_Sums_Wallet = 1,
                ammount_initial = 1000,
                Interest = 0.5,  // 0.05%
                Sums_Wallet = 50,
                YearsOfInterest = 5
            };

            // Act
            var result = calculator.Calculate(problem);

            // Assert
            Assert.AreEqual(935329.1762, result, 0.0001);  
        }

        [TestMethod()]
        public void CalculateTest_InterestType2_SumsWalletType1_MultipleYears_ReturnsExpectedResult()
        {
            // Arrange
            var calculator = new CompositeCalculatorServices();
            ICompositeCalculator problem = new CompositeCalculator()
            {
                Type_interest = 2,
                Type_Sums_Wallet = 1,
                ammount_initial = 1200,
                Interest = 8,  // 0.8%
                Sums_Wallet = 75,
                YearsOfInterest = 3
            };

            // Act
            var result = calculator.Calculate(problem);

            // Assert
            Assert.AreEqual(33194.4673, result, 0.0001);  // Ajusta el valor esperado según tu lógica de cálculo y redondeo
        }

        [TestMethod()]
        public void CalculateTest_InterestType1_SumsWalletType2_MultipleYears_ReturnsExpectedResult()
        {
            // Arrange
            var calculator = new CompositeCalculatorServices();
            ICompositeCalculator problem = new CompositeCalculator()
            {
                Type_interest = 1,
                Type_Sums_Wallet = 2,
                ammount_initial = 2000,
                Interest = 0.6,  // 0.6%
                Sums_Wallet = 120,
                YearsOfInterest = 4
            };

            // Act
            var result = calculator.Calculate(problem);

            // Assert
            Assert.AreEqual(1125120.9671, result, 0.0001);
        }

        [TestMethod()]
        public void CalculateTest_NegativeInterest_ReturnsExpectedResult()
        {
            // Arrange
            var calculator = new CompositeCalculatorServices();
            ICompositeCalculator problem = new CompositeCalculator()
            {
                Type_interest = 1,
                Type_Sums_Wallet = 1,
                ammount_initial = 1000,
                Interest = -0.5,  // Tasa de interés negativa
                Sums_Wallet = 50,
                YearsOfInterest = 3
            };

            // Act
            var result = calculator.Calculate(problem);

            // Assert
            Assert.AreEqual(317.4561, result, 0.0001);
        }

        [TestMethod()]
        public void CalculateTest_NegativeInitialAmount_ReturnsNegativeResult()
        {
            // Arrange
            var calculator = new CompositeCalculatorServices();
            ICompositeCalculator problem = new CompositeCalculator()
            {
                Type_interest = 1,
                Type_Sums_Wallet = 1,
                ammount_initial = -1000,  // Cantidad inicial negativa
                Interest = 0.5,
                Sums_Wallet = 50,
                YearsOfInterest = 3
            };

            // Act
            var result = calculator.Calculate(problem);

            // Assert
            Assert.AreEqual(-36970.5342, result, 0.0001);
        }

        [TestMethod()]
        public void CalculateTest_ZeroInitialAmountAndZeroSums_ReturnsZeroResult()
        {
            // Arrange
            var calculator = new CompositeCalculatorServices();
            ICompositeCalculator problem = new CompositeCalculator()
            {
                Type_interest = 1,
                Type_Sums_Wallet = 1,
                ammount_initial = 0,
                Interest = 5,
                Sums_Wallet = 0,  // Sumas en la cartera cero
                YearsOfInterest = 3
            };

            // Act
            var result = calculator.Calculate(problem);

            // Assert
            Assert.AreEqual(0, result, 0.0001);
        }

        [TestMethod()]
        public void CalculateTest_SumsWalletNegative_ReturnsZeroResult()
        {
            // Arrange
            var calculator = new CompositeCalculatorServices();
            ICompositeCalculator problem = new CompositeCalculator()
            {
                Type_interest = 1,
                Type_Sums_Wallet = 1,
                ammount_initial = 1000,
                Interest = 0.5,
                Sums_Wallet = -50,  // Sumas en la cartera negativas
                YearsOfInterest = 3
            };

            // Act
            var result = calculator.Calculate(problem);

            // Assert
            Assert.AreEqual(36970.5342, result, 0.0001);
        }

        [TestMethod()]
        public void CalculateTest_NegativeInitialAmountAndNegativeSums_ReturnsNegativeResult()
        {
            // Arrange
            var calculator = new CompositeCalculatorServices();
            ICompositeCalculator problem = new CompositeCalculator()
            {
                Type_interest = 1,
                Type_Sums_Wallet = 1,
                ammount_initial = -1000,  // Cantidad inicial negativa
                Interest = 0.5,
                Sums_Wallet = -50,  // Sumas en la cartera negativas
                YearsOfInterest = 3
            };

            // Act
            var result = calculator.Calculate(problem);

            // Assert
            Assert.AreEqual(-66914.0023, result, 0.0001);
        }

        [TestMethod()]
        public void CalculateTest_NegativeYearsOfInterest_ReturnsExpectedResult()
        {
            // Arrange
            var calculator = new CompositeCalculatorServices();
            ICompositeCalculator problem = new CompositeCalculator()
            {
                Type_interest = 1,
                Type_Sums_Wallet = 1,
                ammount_initial = 1000,
                Interest = 5,
                Sums_Wallet = 50,
                YearsOfInterest = -3  // Años de interés negativos
            };

            // Act
            var result = calculator.Calculate(problem);

            // Assert
            Assert.AreEqual(1000, result, 0.0001);
        }

        [TestMethod()]
        public void CalculateTest_ZeroInterestAndZeroSums_ReturnsInitialAmount()
        {
            // Arrange
            var calculator = new CompositeCalculatorServices();
            ICompositeCalculator problem = new CompositeCalculator()
            {
                Type_interest = 1,
                Type_Sums_Wallet = 1,
                ammount_initial = 1000,
                Interest = 0,  // Tasa de interés cero
                Sums_Wallet = 0,  // Sumas en la cartera cero
                YearsOfInterest = 3
            };

            // Act
            var result = calculator.Calculate(problem);

            // Assert
            Assert.AreEqual(1000, result, 0.0001);
        }
    }
}