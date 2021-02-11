using System;
using System.Net.Http;
using System.Net;

namespace MVVMTestc
{
    class Program
    {
        private const string data_url = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

        static void Main(string[] args)
        {
            var web_client = new WebClient();

            

            var client = new HttpClient();

            var items = new string[10];

            var last_item = items[^1]; // последний
            var pre_last_item = items[^2]; // предпоследний



            var response = client.GetAsync(data_url).Result;
            var csv_string = response.Content.ReadAsStringAsync().Result;

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
