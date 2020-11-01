using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //var url = @"https://www.pja.edu.pl"; for testing purposes
            using (var httpClient = new HttpClient()) // var assignes the variable as right
            {
                using (var response = await httpClient.GetAsync(args[0]))
                {

                    var content = await response.Content.ReadAsStringAsync();




                    var regex = new Regex("[a-z]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);

                    var matches = regex.Matches(content); //Match only find one occurence and matches find more of them



                    foreach (var match in matches)
                    {
                        Console.WriteLine(match.ToString());
                    }

                }
            }
        }
    }
}
