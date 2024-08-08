using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prices
{
    internal class Program
    {
        public static double CorrectedPriceWithNDS;
        public static double CorrectedPriceWithoutNDS;
        private static double _procNDS;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите процент");
            _procNDS = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите рекомендованную цену с НДС");
            double inputPrice = double.Parse(Console.ReadLine());

            CalcPrices(inputPrice, _procNDS, out CorrectedPriceWithNDS, out CorrectedPriceWithoutNDS);
            Console.WriteLine($"{CorrectedPriceWithNDS} с НДС, {CorrectedPriceWithoutNDS} без НДС");
            
            Console.ReadKey();
        }

        private static void CalcPrices(double inputPrice, double procNDS, out double CorrectedPriceWithNDS, out double CorrectedPriceWithoutNDS)
        {
            CorrectedPriceWithoutNDS = inputPrice / (1 + procNDS / 100);

            double priceWithoutNDS = Math.Round(CorrectedPriceWithoutNDS, 1, MidpointRounding.ToEven);
            double priceWithNDS = priceWithoutNDS * (1 + procNDS / 100);

            CorrectedPriceWithNDS = priceWithNDS;
            CorrectedPriceWithoutNDS = priceWithoutNDS;
        }
    }
}
