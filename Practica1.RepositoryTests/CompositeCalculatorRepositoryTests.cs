using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica1.Models.Interface;
using Practica1.Models;
using Practica1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.Repository.Tests
{
    [TestClass()]
    public class CompositeCalculatorRepositoryTests
    {
        [TestMethod()]
        public void CalculateWithValidations_ValidInput_ReturnsResult()
        {
            // Arrange
            var repository = new CompositeCalculatorRepository();
            ICompositeCalculator problem = new CompositeCalculator()
            {
                Type_interest = 1,
                Type_Sums_Wallet = 1,
                ammount_initial = 1000,
                Interest = 5,
                Sums_Wallet = 50,
                YearsOfInterest = 3
            };

            // Act
            var result = repository.Calculate(problem);

            // Assert
            Assert.IsNotNull(result);
            
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateWithValidations_NullCalculator_ThrowsException()
        {
            // Arrange
            var repository = new CompositeCalculatorRepository();

            // Act
            repository.Calculate(null);

            // Assert (Se espera que arroje una excepción)
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateWithValidations_NegativeInitialAmount_ThrowsException()
        {
            // Arrange
            var repository = new CompositeCalculatorRepository();
            ICompositeCalculator problem = new CompositeCalculator()
            {
                Type_interest = 1,
                Type_Sums_Wallet = 1,
                ammount_initial = -1000,
                Interest = 5,
                Sums_Wallet = 50,
                YearsOfInterest = 3
            };

            // Act
            repository.Calculate(problem);

            // Assert (Se espera que arroje una excepción)
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateWithValidations_ZeroInterest_ThrowsException()
        {
            // Arrange
            var repository = new CompositeCalculatorRepository();
            ICompositeCalculator problem = new CompositeCalculator()
            {
                Type_interest = 1,
                Type_Sums_Wallet = 1,
                ammount_initial = 1000,
                Interest = 0,
                Sums_Wallet = 50,
                YearsOfInterest = 3
            };

            // Act
            repository.Calculate(problem);

            // Assert (Se espera que arroje una excepción)
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateWithValidations_ZeroYearsOfInterest_ThrowsException()
        {
            // Arrange
            var repository = new CompositeCalculatorRepository();
            ICompositeCalculator problem = new CompositeCalculator()
            {
                Type_interest = 1,
                Type_Sums_Wallet = 1,
                ammount_initial = 1000,
                Interest = 5,
                Sums_Wallet = 50,
                YearsOfInterest = 0
            };

            // Act
            repository.Calculate(problem);

            // Assert (Se espera que arroje una excepción)
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateWithValidations_NegativeSumsWallet_ThrowsException()
        {
            // Arrange
            var repository = new CompositeCalculatorRepository();
            ICompositeCalculator problem = new CompositeCalculator()
            {
                Type_interest = 1,
                Type_Sums_Wallet = 1,
                ammount_initial = 1000,
                Interest = 5,
                Sums_Wallet = -50,
                YearsOfInterest = 3
            };

            // Act
            repository.Calculate(problem);

            // Assert (Se espera que arroje una excepción)
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateWithValidations_NegativeInterest_ThrowsException()
        {
            // Arrange
            var repository = new CompositeCalculatorRepository();
            ICompositeCalculator problem = new CompositeCalculator()
            {
                Type_interest = 1,
                Type_Sums_Wallet = 1,
                ammount_initial = 1000,
                Interest = -5,
                Sums_Wallet = 50,
                YearsOfInterest = 3
            };

            // Act
            repository.Calculate(problem);

            // Assert (Se espera que arroje una excepción)
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateWithValidations_InvalidTypeSumsWallet_ThrowsException()
        {
            // Arrange
            var repository = new CompositeCalculatorRepository();
            ICompositeCalculator problem = new CompositeCalculator()
            {
                Type_interest = 1,
                Type_Sums_Wallet = 0,  // Tipo de sumas en la cartera inválido
                ammount_initial = 1000,
                Interest = 5,
                Sums_Wallet = 50,
                YearsOfInterest = 3
            };

            // Act
            repository.Calculate(problem);

            // Assert (Se espera que arroje una excepción)
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateWithValidations_InvalidTypeInterest_ThrowsException()
        {
            // Arrange
            var repository = new CompositeCalculatorRepository();
            ICompositeCalculator problem = new CompositeCalculator()
            {
                Type_interest = 0,  // Tipo de interés inválido
                Type_Sums_Wallet = 1,
                ammount_initial = 1000,
                Interest = 5,
                Sums_Wallet = 50,
                YearsOfInterest = 3
            };

            // Act
            repository.Calculate(problem);

            // Assert (Se espera que arroje una excepción)
        }
    }
}