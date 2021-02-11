using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVVMTestc
{
    class Program
    {
        private const string data_url = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";


        private static async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(data_url, HttpCompletionOption.ResponseHeadersRead);
            return await response.Content.ReadAsStreamAsync();
        }

        private static IEnumerable<string> GetDataLines()
        {
            using var data_stream = GetDataStream().Result;
            using var data_reader = new StreamReader(data_stream);

            while (!data_reader.EndOfStream)
            {
                var line = data_reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;
                yield return line.Replace("Korea,","Korea -");
            }
        }

        private static DateTime[] GetDates() => GetDataLines()
            .First()
            .Split(',')
            .Skip(4)
            .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
            .ToArray();



        private static IEnumerable<(string Country, string Province, int[] Infected)> GetData()
        {
            var lines = GetDataLines().Skip(1).Select(line => line.Split(','));

            foreach (var row in lines)
            {
                var province = row[0].Trim();
                var country_name = row[1].Trim(' ', '"');
                var counts = row.Skip(4).Select(int.Parse).ToArray();
               
                yield return (country_name, province, counts);


                Console.WriteLine("Method GetData... " + country_name);

               
            }
        }


        static void Main(string[] args)
        {
            //var web_client = new WebClient();
            //var client = new HttpClient();
            //var items = new string[10];
            //var last_item = items[^1]; // последний
            //var pre_last_item = items[^2]; // предпоследний

            ////var response = client.GetAsync(data_url).Result;
            ////var csv_string = response.Content.ReadAsStringAsync().Result;

            //foreach(var data_line in GetDataLines())
            //{
            //    Console.WriteLine(data_line);
            ////}

            //var dates = GetDates();
            //Console.WriteLine(string.Join("\r\n", dates));

            //Console.WriteLine();

            var russia_data = GetData().First(v => v.Country.Equals("Kyrgyzstan", StringComparison.OrdinalIgnoreCase));


            Console.WriteLine(string.Join("\r\n", GetDates().Zip(russia_data.Infected, (date, count) => $"{date:dd:MM} - {count}")));

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
