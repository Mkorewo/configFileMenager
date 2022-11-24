﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configFile
{
    internal class DataRequestMenager
    {
        public string GetExchangeRates(string configFile)
        {
            string[] currencies = configFile.Split(',');
            string result = "";

            using (var httpClient = new HttpClient())
            {

                
                var request = new HttpRequestMessage(HttpMethod.Get, "http://api.nbp.pl/api/exchangerates/tables/A/last/1?format=json");
                var responseMessage = httpClient.SendAsync(request).Result;
                var responseContent = responseMessage.Content.ReadAsStringAsync().Result;

                RateInfoArray[] rateInfoArray = JsonConvert.DeserializeObject<RateInfoArray[]>(responseContent);
                foreach(var item in rateInfoArray.First().rates)
                {
                    for (int i = 0; i < currencies.Length; i++)
                    {
                        if (currencies[i] == item.code)
                        {
                            result += $"{item.currency}: {item.mid}\n";
                        }
                    }
                }

                return result;
            }
        }
    }
    class RateInfoArray
    {
        public string table { get; set; }
        public string no { get; set; }
        public string effectiveDate { get; set; }
        public Rates[] rates { get; set; }
    }
    class Rates
    {
        public string currency { get; set; }
        public string code { get; set; }
        public float mid { get; set; }
    }
}
