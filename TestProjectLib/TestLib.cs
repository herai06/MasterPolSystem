using LibAmountOfMaterial;
using System;

namespace TestProjectLib
{
    [TestClass]
    public class TestLib
    {
        [TestMethod]
        public void ProductIdNotExists()
        {
            CalculationMethod calculator = new CalculationMethod();
            int idProduct = 5;
            int idMaterial = 1;
            int productCount = 10;
            double param1 = 1;
            double param2 = 1;
            int result = calculator.CalculateMaterial(idProduct, idMaterial, productCount, param1, param2);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void MaterialIdNotExists()
        {
            CalculationMethod calculator = new CalculationMethod();
            int idProduct = 1;
            int idMaterial = 6;
            int productCount = 10;
            double param1 = 1;
            double param2 = 1;

            int result = calculator.CalculateMaterial(idProduct, idMaterial, productCount, param1, param2);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void Param1_NotZero()
        {
            CalculationMethod calculator = new CalculationMethod();
            int idProduct = 1;
            int idMaterial = 1;
            int productCount = 10;
            double param1 = 0;
            double param2 = 1;

            int result = calculator.CalculateMaterial(idProduct, idMaterial, productCount, param1, param2);
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void Param2_NotZero()
        {
            CalculationMethod calculator = new CalculationMethod();
            int idProduct = 1;
            int idMaterial = 1;
            int productCount = 10;
            double param1 = 1;
            double param2 = 0;

            int result = calculator.CalculateMaterial(idProduct, idMaterial, productCount, param1, param2);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void ReturnTypeAnswer_Int()
        {
            CalculationMethod calculator = new CalculationMethod();
            int idProduct = 1;
            int idMaterial = 1;
            int productCount = 10;
            double param1 = 5.1;
            double param2 = 1.5;

            Assert.IsInstanceOfType(calculator.CalculateMaterial(idProduct, idMaterial, productCount, param1, param2), typeof(int));
        }


        [TestMethod]
        public void ReturnTypeAnswer_NotDouble()
        {
            CalculationMethod calculator = new CalculationMethod();
            int idProduct = 1;
            int idMaterial = 1;
            int productCount = 10;
            double param1 = 5.7;
            double param2 = 1.2;

            Assert.IsNotInstanceOfType(calculator.CalculateMaterial(idProduct, idMaterial, productCount, param1, param2), typeof(double));
        }

        

        [TestMethod]
        public void CoefficientsAreCorrect()
        {
            CalculationMethod calculator = new CalculationMethod();
            int idProduct = 1;
            int idMaterial = 1;
            int productCount = 10;
            double param1 = 1;
            double param2 = 1;

            int result = calculator.CalculateMaterial(idProduct, idMaterial, productCount, param1, param2);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void RoundingTest()
        {
            CalculationMethod calculator = new CalculationMethod();
            int idProduct = 1;
            int idMaterial = 1;
            int productCount = 1;
            double param1 = 0.5;
            double param2 = 0.5;

            double expectedMaterialPerUnit = param1 * param2 * 2.35;
            double expectedTotalMaterial = expectedMaterialPerUnit / (1 + 0.1);
            int expected = (int)Math.Round(expectedTotalMaterial);

            int result = calculator.CalculateMaterial(idProduct, idMaterial, productCount, param1, param2);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ProductCountZero_ReturnsZero()
        {
            CalculationMethod calculator = new CalculationMethod();
            int idProduct = 1;
            int idMaterial = 1;
            int productCount = 0;
            double param1 = 1;
            double param2 = 1;

            int result = calculator.CalculateMaterial(idProduct, idMaterial, productCount, param1, param2);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MaxProductCount_ReturnsCorrectResult()
        {
            CalculationMethod calculator = new CalculationMethod();
            int idProduct = 1;
            int idMaterial = 1;
            int productCount = int.MaxValue;
            double param1 = 1;
            double param2 = 1;

            double expectedMaterialPerUnit = param1 * param2 * 2.35;
            double expectedTotalMaterial = expectedMaterialPerUnit * productCount / (1 + 0.1);
            int expected = (int)Math.Round(expectedTotalMaterial);

            int result = calculator.CalculateMaterial(idProduct, idMaterial, productCount, param1, param2);
            Assert.AreEqual(expected, result);
        }
        
        [TestMethod]
        public void MaxParams_ReturnsCorrectResult()
        {
            CalculationMethod calculator = new CalculationMethod();
            int idProduct = 1;
            int idMaterial = 1;
            int productCount = 10;
            double param1 = double.MaxValue;
            double param2 = double.MaxValue;

            double expectedMaterialPerUnit = param1 * param2 * 2.35;
            double expectedTotalMaterial = expectedMaterialPerUnit * productCount / (1 + 0.1);
            int expected = (int)Math.Round(expectedTotalMaterial);

            int result = calculator.CalculateMaterial(idProduct, idMaterial, productCount, param1, param2);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MinParams_ReturnsCorrectResult()
        {
            CalculationMethod calculator = new CalculationMethod();
            int idProduct = 1;
            int idMaterial = 1;
            int productCount = 10;
            double param1 = double.Epsilon;
            double param2 = double.Epsilon;

            double expectedMaterialPerUnit = param1 * param2 * 2.35;
            double expectedTotalMaterial = expectedMaterialPerUnit * productCount / (1 + 0.1);
            int expected = (int)Math.Round(expectedTotalMaterial);

            int result = calculator.CalculateMaterial(idProduct, idMaterial, productCount, param1, param2);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ProductNegativeVakue_ThrowsException()
        {
            CalculationMethod calculator = new CalculationMethod();
            int idProduct = -1;
            int idMaterial = 1;
            int productCount = 10;
            double param1 = 1;
            double param2 = 1;

            Assert.ThrowsException<DivideByZeroException>(() => calculator.CalculateMaterial(idProduct, idMaterial, productCount, param1, param2));
        }

        [TestMethod]
        public void MaterialNotExists_ThrowsException()
        {
            CalculationMethod calculator = new CalculationMethod();
            int idProduct = 5;
            int idMaterial = 1;
            int productCount = 10;
            double param1 = 1;
            double param2 = 1;

            Assert.ThrowsException<DivideByZeroException > (() => calculator.CalculateMaterial(idProduct, idMaterial, productCount, param1, param2));
        }

        [TestMethod]
        public void Param1IsZero_ThrowsCalculationException()
        {
            CalculationMethod calculator = new CalculationMethod();
            int idProduct = 1;
            int idMaterial = 1;
            int productCount = 10;
            double param1 = 0;
            double param2 = 1;

            Assert.ThrowsException<DivideByZeroException>(() => calculator.CalculateMaterial(idProduct, idMaterial, productCount, param1, param2));
        }

        [TestMethod]
        public void AllZeroValues_ThrowsCalculationException()
        {
            CalculationMethod calculator = new CalculationMethod();
            int idProduct = 0;
            int idMaterial = 0;
            int productCount = 0;
            double param1 = 0;
            double param2 = 0;

            Assert.ThrowsException<DivideByZeroException>(() => calculator.CalculateMaterial(idProduct, idMaterial, productCount, param1, param2));
        }

    }
}