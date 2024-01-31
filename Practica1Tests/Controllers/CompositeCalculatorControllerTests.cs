using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Practica1.Controllers;
using Practica1.Models;
using Practica1.Models.Interface;
using Practica1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.Controllers.Tests
{
    [TestClass()]
    public class CompositeCalculatorControllerTests
    {
        [TestMethod]
        public void Post_ValidInput_ReturnsCreatedResult()
        {
            // Arrange
            var substituteService = Substitute.For<ICompositeCalculatorServices>();
            var controller = new CompositeCalculatorController(substituteService);
            CompositeCalculator compositeCalculator = new CompositeCalculator()
            {
                Type_interest = 2,
                Type_Sums_Wallet = 2,
                ammount_initial = 500,
                Interest = 10,
                Sums_Wallet = 200,
                YearsOfInterest = 1
            };
            
            // Act
            var result = controller.Post(compositeCalculator);
            substituteService.Calculate(compositeCalculator).Returns(1926.1356);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(200, (result as OkObjectResult).StatusCode);
            
        }

        [TestMethod]
        public void Post_InvalidInput_ReturnsBadRequest()
        {
            // Arrange                     

            var substituteService = Substitute.For<ICompositeCalculatorServices>();
            var controller = new CompositeCalculatorController(substituteService);
            var compositeCalculator = new CompositeCalculator();

            // Act
            substituteService.When(x => x.Calculate(Arg.Any<ICompositeCalculator>()))
                    .Do(x => throw new ArgumentException("Simulación de excepción"));
            var result = controller.Post(compositeCalculator);
            
            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.AreEqual(400, (result as BadRequestObjectResult).StatusCode);
            
        }
        
    }
}