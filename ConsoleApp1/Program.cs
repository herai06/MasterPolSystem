using LibAmountOfMaterial;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculationMethod calculator = new CalculationMethod();

            int productId = 1;
            int materialId = 1;
            int productCount = 100;
            double param1 = 2.5;
            double param2 = 3.0;

            int requiredMaterial = calculator.CalculateMaterial(productId, materialId, productCount, param1, param2);

            Console.WriteLine($"Необходимое количество материала: {requiredMaterial}");
        }
    }
}
