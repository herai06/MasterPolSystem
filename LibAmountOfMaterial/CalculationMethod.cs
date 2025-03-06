namespace LibAmountOfMaterial
{
    public class CalculationMethod
    {
        private Dictionary<int, double> ProductCoefficients = new Dictionary<int, double>()
        {
            {1, 2.35},
            {2, 5.15},
            {3, 4.34},
            {4, 1.5}
        };
        private Dictionary<int, double> MaterialDefectRates = new Dictionary<int, double>()
        {
            {1, 0.1},
            {2, 0.95},
            {3, 0.28},
            {4, 0.55},
            {5, 0.34}
        };
        public int CalculateMaterial(int idProduct, int idMaterial, int productCount, double param1, double param2)
        {
            if (!ProductCoefficients.ContainsKey(idProduct) || !MaterialDefectRates.ContainsKey(idMaterial))
            {
                return -1;
            }
            if (param1 <= 0 || param2 <= 0)
            {
                return -1;
            }
            double materialPerUnit = param1 * param2 * ProductCoefficients[idProduct];
            double totalMaterial = materialPerUnit * productCount / (1 + MaterialDefectRates[idMaterial]);
            return (int)Math.Round(totalMaterial);
        }
    }
}
