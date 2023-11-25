using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using test_lab2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;
using MySql.Data.MySqlClient;

namespace Tests
{
    [TestClass()]
    public class TriangleCalculatorTests
    {
        [Test]
        public void CalculateTriangleTypeAndCoordinates_ValidTriangle_ShouldReturnCorrectTypeAndCoordinates()
        {
            // Arrange
            string sideA = "3";
            string sideB = "4";
            string sideC = "5";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("разносторонний", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((300, 50), result.Item2[0]); // меньше 100
            Assert.AreEqual((500, 0), result.Item2[1]);
            Assert.AreEqual((400, 100), result.Item2[2]);
        }

        [Test]
        public void CalculateTriangleTypeAndCoordinates_EquilateralTriangle_ShouldReturnCorrectTypeAndCoordinates()
        {
            // Arrange
            string sideA = "2";
            string sideB = "2";
            string sideC = "2";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("равносторонний", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((200, 50), result.Item2[0]);
            Assert.AreEqual((200, 0), result.Item2[1]);
            Assert.AreEqual((200, 100), result.Item2[2]);
        }

        [TestCase("1", "2", "3")]
        [TestCase("2", "1", "3")]
        [TestCase("3", "1", "2")]
        public void CalculateTriangleTypeAndCoordinates_NotATriangle_ShouldReturnCorrectTypeAndCoordinates(string a, string b, string c)
        {
            // Arrange


            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(a, b, c);

            // Assert
            Assert.AreEqual("не треугольник", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((-1, -1), result.Item2[0]);
            Assert.AreEqual((-1, -1), result.Item2[1]);
            Assert.AreEqual((-1, -1), result.Item2[2]);
        }

        [Test]
        public void CalculateTriangleTypeAndCoordinates_InvalidInput_ShouldReturnInvalidTypeAndCoordinates()
        {
            // Arrange
            string sideA = "a";
            string sideB = "2";
            string sideC = "3"; // аналогично

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("", result.Item1); // Invalid input
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((-2, -2), result.Item2[0]);
            Assert.AreEqual((-2, -2), result.Item2[1]);
            Assert.AreEqual((-2, -2), result.Item2[2]);
        }
        [Test]
        public void CalculateTriangleTypeAndCoordinates_InvalidInput_ShouldReturnInvalidTypeAndCoordinates1()
        {
            // Arrange
            string sideA = "2";
            string sideB = "a";
            string sideC = "3";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("", result.Item1); // Invalid input
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((-2, -2), result.Item2[0]);
            Assert.AreEqual((-2, -2), result.Item2[1]);
            Assert.AreEqual((-2, -2), result.Item2[2]);
        }
        [Test]
        public void CalculateTriangleTypeAndCoordinates_InvalidInput_ShouldReturnInvalidTypeAndCoordinates2()
        {
            // Arrange
            string sideA = "2";
            string sideB = "3";
            string sideC = "a";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("", result.Item1); // Invalid input
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((-2, -2), result.Item2[0]);
            Assert.AreEqual((-2, -2), result.Item2[1]);
            Assert.AreEqual((-2, -2), result.Item2[2]);
        }
        [Test]
        public void CalculateTriangleTypeAndCoordinates_ValidScaleneTriangle_ShouldReturnCorrectTypeAndCoordinates()
        {
            // Arrange
            string sideA = "3";
            string sideB = "4";
            string sideC = "5";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("разносторонний", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((300, 50), result.Item2[0]);
            Assert.AreEqual((500, 0), result.Item2[1]);
            Assert.AreEqual((400, 100), result.Item2[2]);
        }

        [Test]
        public void CalculateTriangleTypeAndCoordinates_ValidIsoscelesTriangle_ShouldReturnCorrectTypeAndCoordinates()
        {
            // Arrange
            string sideA = "5";
            string sideB = "5";
            string sideC = "6";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("равнобедренный", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((500, 50), result.Item2[0]);
            Assert.AreEqual((600, 0), result.Item2[1]);
            Assert.AreEqual((500, 100), result.Item2[2]);
        }

        [Test]
        public void CalculateTriangleTypeAndCoordinates_ValidEquilateralTriangle_ShouldReturnCorrectTypeAndCoordinates()
        {
            // Arrange
            string sideA = "4";
            string sideB = "4";
            string sideC = "4";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("равносторонний", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((400, 50), result.Item2[0]);
            Assert.AreEqual((400, 0), result.Item2[1]);
            Assert.AreEqual((400, 100), result.Item2[2]);
        }

        [Test]
        public void CalculateTriangleTypeAndCoordinates_NegativeSideLengths_ShouldReturnNotATriangle()
        {
            // Arrange
            string sideA = "-2";
            string sideB = "3";
            string sideC = "4";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("не треугольник", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((-1, -1), result.Item2[0]);
            Assert.AreEqual((-1, -1), result.Item2[1]);
            Assert.AreEqual((-1, -1), result.Item2[2]);
        }
        [Test]
        public void CalculateTriangleTypeAndCoordinates_NegativeSideLengths_ShouldReturnNotATriangle1()
        {
            // Arrange
            string sideA = "2";
            string sideB = "-3";
            string sideC = "4";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("не треугольник", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((-1, -1), result.Item2[0]);
            Assert.AreEqual((-1, -1), result.Item2[1]);
            Assert.AreEqual((-1, -1), result.Item2[2]);
        }
        [Test]
        public void CalculateTriangleTypeAndCoordinates_NegativeSideLengths_ShouldReturnNotATriangle2()
        {
            // Arrange
            string sideA = "2";
            string sideB = "3";
            string sideC = "-4";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("не треугольник", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((-1, -1), result.Item2[0]);
            Assert.AreEqual((-1, -1), result.Item2[1]);
            Assert.AreEqual((-1, -1), result.Item2[2]);
        }
        [Test]
        public void CalculateTriangleTypeAndCoordinates_SidesWithDecimalSeparator_ShouldReturnCorrectTypeAndCoordinates()
        {
            // Arrange
            string sideA = "2.5";
            string sideB = "3.5";
            string sideC = "4.5";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("разносторонний", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((250, 50), result.Item2[0]);
            Assert.AreEqual((450, 0), result.Item2[1]);
            Assert.AreEqual((350, 100), result.Item2[2]);
        }
        [Test]
        public void CalculateTriangleTypeAndCoordinates_OneSideAsEmptyString_ShouldReturnInvalidTypeAndCoordinates()
        {
            // Arrange
            string sideA = "2";
            string sideB = ""; // null
            string sideC = "4";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("", result.Item1); // Invalid input
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((-2, -2), result.Item2[0]);
            Assert.AreEqual((-2, -2), result.Item2[1]);
            Assert.AreEqual((-2, -2), result.Item2[2]);
        }
        [Test]
        public void CalculateTriangleTypeAndCoordinates_OneSideAsEmptyString_ShouldReturnInvalidTypeAndCoordinates1()
        {
            // Arrange
            string sideA = "";
            string sideB = "4";
            string sideC = "4";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("", result.Item1); // Invalid input
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((-2, -2), result.Item2[0]);
            Assert.AreEqual((-2, -2), result.Item2[1]);
            Assert.AreEqual((-2, -2), result.Item2[2]);
        }
        [Test]
        public void CalculateTriangleTypeAndCoordinates_OneSideAsEmptyString_ShouldReturnInvalidTypeAndCoordinates2()
        {
            // Arrange
            string sideA = "2";
            string sideB = "4";
            string sideC = "";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("", result.Item1); // Invalid input
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((-2, -2), result.Item2[0]);
            Assert.AreEqual((-2, -2), result.Item2[1]);
            Assert.AreEqual((-2, -2), result.Item2[2]);
        }
        [Test]
        public void CalculateTriangleTypeAndCoordinates_ZeroSide_ShouldReturnNotATriangle()
        {
            // Arrange
            string sideA = "0";
            string sideB = "3";
            string sideC = "4";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("не треугольник", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((-1, -1), result.Item2[0]);
            Assert.AreEqual((-1, -1), result.Item2[1]);
            Assert.AreEqual((-1, -1), result.Item2[2]);
        }
        [Test]
        public void CalculateTriangleTypeAndCoordinates_ZeroSide_ShouldReturnNotATriangle1()
        {
            // Arrange
            string sideA = "2";
            string sideB = "0";
            string sideC = "4";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("не треугольник", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((-1, -1), result.Item2[0]);
            Assert.AreEqual((-1, -1), result.Item2[1]);
            Assert.AreEqual((-1, -1), result.Item2[2]);
        }
        [Test]
        public void CalculateTriangleTypeAndCoordinates_ZeroSide_ShouldReturnNotATriangle2()
        {
            // Arrange
            string sideA = "2";
            string sideB = "3";
            string sideC = "0";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("не треугольник", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((-1, -1), result.Item2[0]);
            Assert.AreEqual((-1, -1), result.Item2[1]);
            Assert.AreEqual((-1, -1), result.Item2[2]);
        }
        [Test]
        public void CalculateTriangleTypeAndCoordinates_AllSidesGreaterThan100_ShouldReturnInvalidTypeAndCoordinates()
        {
            // Arrange
            string sideA = "150";
            string sideB = "120";
            string sideC = "110";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("недопустимые значения", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((-3, -3), result.Item2[0]);
            Assert.AreEqual((-3, -3), result.Item2[1]);
            Assert.AreEqual((-3, -3), result.Item2[2]);
        }

        // Тест, где одна сторона превышает 100, а остальные меньше
        [Test]
        public void CalculateTriangleTypeAndCoordinates_OneSideGreaterThan100_ShouldReturnInvalidTypeAndCoordinates()
        {
            // Arrange
            string sideA = "150";
            string sideB = "40";
            string sideC = "70";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("недопустимые значения", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((-3, -3), result.Item2[0]);
            Assert.AreEqual((-3, -3), result.Item2[1]);
            Assert.AreEqual((-3, -3), result.Item2[2]);
        }

        // Тест, где две стороны превышают 100, а третья - равна 100
        [Test]
        public void CalculateTriangleTypeAndCoordinates_TwoSidesGreaterThan100_OneEqual100_ShouldReturnInvalidTypeAndCoordinates()
        {
            // Arrange
            string sideA = "150";
            string sideB = "100";
            string sideC = "130";

            // Act
            var result = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("недопустимые значения", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((-3, -3), result.Item2[0]);
            Assert.AreEqual((-3, -3), result.Item2[1]);
            Assert.AreEqual((-3, -3), result.Item2[2]);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [TestCase("1", "1", "1", "равносторонний", "")] // if not exists
        [TestCase("1", "1", "1", "равносторонний", "")] // if exists
        public void ModelTriangle_CheckFuncionAdd(string sideA, string sideB, string sideC, string type, string error)
        {
            // Act
            var result = Triangle.add(sideA, sideB, sideC, type, error);

            // Assert
            Assert.That(result, Is.InstanceOf<MySqlDataReader>());
        }

        [TestCase("qwe", "qwe", "qwe", "", "")] // if enter uncorrect datas
        [TestCase("", "", "", "", "")] // if enter empty data
        public void ModelTriangle_CheckNegFuncionAdd(string sideA, string sideB, string sideC, string type, string error)
        {
            // Act
            var result = Triangle.add(sideA, sideB, sideC, type, error);

            // Assert
            Assert.That(null, Is.EqualTo(result));
        }

    }
}