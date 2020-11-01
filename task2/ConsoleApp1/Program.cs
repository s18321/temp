using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           // args[0] = new string("https://www.pja.edu.pl");
            var listOfEmails = new List<string>();
            try
            {
                using (var httpClient = new HttpClient())
                {

                    using (var response = await httpClient.GetAsync(args[0])) // using(){} - automatically manages resources - like finally in Java
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        var regex = new Regex("[a-z]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);

                        var matches = regex.Matches(content);  //Match only find one occurence and matches find more of them

                        foreach (var match in matches)
                        {
                            //Console.WriteLine(match.ToString());
                            if (!listOfEmails.Contains(match.ToString()))
                            {
                                listOfEmails.Add(match.ToString());
                            }
                        }

                        if (listOfEmails.Count == 0)
                        {
                            Console.WriteLine("No email addresses found");
                        }
                        foreach (var email in listOfEmails)
                        {
                            Console.WriteLine(email);
                        }


                    }
                 

                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Index out of range");
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                Console.WriteLine("Error while downloading the page");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("ArgumentNullException");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("ArgumentException");
            }
        }


        /*
        Console.WriteLine("Hello World!");
        var url = @"https://www.pja.edu.pl";
        using (var httpClient = new HttpClient()) // var assignes the variable as right
        {
            using (var response = await httpClient.GetAsync(url))
            {

                var content = await response.Content.ReadAsStringAsync();




                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);

                var matches = regex.Matches(content); //Match only find one occurence and matches find more of them

                Console.WriteLine("Hello World!");

                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                    Console.WriteLine("Hello World!");
                }

            }
        }*/
    }
}

