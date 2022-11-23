using System;
using System.IO;

namespace configFile
{

    class Program
    {
        static void Main(string[] args)
        {
            DataRequestMenager dataRequestMenager = new DataRequestMenager();
            string path = Path.GetDirectoryName(typeof(Program).Assembly.Location)+"\\currencyConfigFile.txt";

            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(dataRequestMenager.GetExchangeRates());   
            }

        }
    }
}