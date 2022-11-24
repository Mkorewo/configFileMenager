using System;
using System.IO;

namespace configFile
{

    class Program
    {
        static void Main(string[] args)
        {
            DataRequestMenager dataRequestMenager = new DataRequestMenager();
            string configFile = System.IO.File.ReadAllText(Path.GetDirectoryName(typeof(Program).Assembly.Location) + "\\currencyConfigFile.txt");
            string path = Path.GetDirectoryName(typeof(Program).Assembly.Location) + "\\currencyResult.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(dataRequestMenager.GetExchangeRates(configFile));
            }

        }
    }
}