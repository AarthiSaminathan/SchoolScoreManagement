using System;
using System.Collections;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CSVLinqDemo;

namespace CsvDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            string fpath = "C:\\Users\\aarthi.s\\source\\repos\\CSVLinqDemo\\CSVLinqDemo\\worldcities.csv";
            using var streamReader = File.OpenText(fpath);
            using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            IEnumerable<Cities> users = csvReader.GetRecords<Cities>();

            //foreach (var item in users)
            //{
            //    Console.WriteLine(item);
            //}

            // 1.Select City:
            //var cityname = users.Select(s => s.city).ToList();
            //foreach (var c in cityname)
            //{
            //    Console.WriteLine(c);
            //}

            //2.Countrywise City count:
            //    var cityCount=users.GroupBy(x=>x.city);
            //     Console.WriteLine("Countrywise city count:");
            //    foreach(var item1 in cityCount)
            //    {
            //         foreach(var i in item1)
            //         {
            //              Console.WriteLine(i.country+"\t"+item1.Count());
            //         }

            //    }

            //3.Countrywise state count:
            //  var stateCount=users.GroupBy(s=>s.admin_name);
            // Console.WriteLine("CountryWise State count:");
            // foreach(var i in stateCount)
            // {
            //     foreach(var item in i)
            //     {
            //         Console.WriteLine(item.admin_name+"\t"+i.Count());
            //     }

            // }  
            // }
            //   var Populated=users.Select(p=>p.population);


            // foreach (var item in Populated)
            //     {
            //       double d=Double.parseDouble(i); 
            //     } 

            //4.Unique capitals:
            //     var uniqueCapital=users.Select(c=>c.capital).Distinct().ToList();
            //    foreach(var c in uniqueCapital)
            //    {
            //         Console.WriteLine(c);
            //    }

            //5.Duplicate Cities:

            var totalDupeItems = users.GroupBy(x => x.city).Count(grp => grp.Count() > 1);
            Console.WriteLine("Duplicate Cities:");
            Console.WriteLine(totalDupeItems);

            //6.Remove space in New york:
            //var reSpace = String.Join("", "New York".Split(" "));
            //Console.WriteLine("Remove Space in New York:");
            //Console.WriteLine(reSpace);

            //7.Cities in same latitude:
            // var sameLat=users.GroupBy(l=>l.lat);
            // foreach(var item in sameLat)
            // {
            //     //Console.WriteLine(item.Key,item.Count());
            //     foreach(var slat in item)
            //     {
            //         Console.WriteLine(slat.lat +"\t"+ slat.city);
            //     }
            // }

            //8.Cities in same langitude:
            //var sameLng = users.GroupBy(l => l.lng).Distinct();
            //foreach (var item in sameLng)
            //{
            //    //Console.WriteLine(item.Key,item.Count());
            //    foreach (var slng in item)
            //    {
            //        Console.WriteLine(slng.lng + "\t" + slng.city);
            //    }
            //}

            //7.Order cities by population:
            //var orderPopulation = users.OrderBy(p => p.population);
            //Console.WriteLine("Order Cities by Population:");
            //foreach (var op in orderPopulation)
            //{
            //    Console.WriteLine(op.city + "\t" + op.population);
            //}

            //8.Order city by alphabts:
            //var orderCity = users.OrderBy(c => c.city);
            //Console.WriteLine("Order city in A to Z :");
            //foreach (var c in orderCity)
            //{
            //    Console.WriteLine(c.city);
            //}

            //9.Sum of total population:
            //var totalPopulation = users.Sum(t => t.population);
            //Console.WriteLine("Total Population:{0}", totalPopulation);

            //10.Search my city:
            //var cityname = users.Select(s => s.city).ToList();
            //Console.WriteLine("Enter a city:");
            //string myCity = Console.ReadLine();
            //if (cityname.Contains(myCity))
            //{
            //    Console.WriteLine("My City is:{0}", myCity);
            //}
            //else
            //{
            //    Console.WriteLine("Not Found");
            //}

            //11.Pass country name get capital:
            //    var countryName = users.Select(c => c.country);
            //    Console.WriteLine("Enter a country:");
            //    string myCountry = Console.ReadLine();
            //    var searchCapital = users.OrderBy(x => x.country).ThenBy(x => x.capital).Distinct();

            //    foreach (var items in searchCapital)
            //    {

            //        Console.WriteLine("Counrty={0} Capital={1}", items.country, items.capital);
            //    }
            //}

            //var cityname = users.Select(s => s.city).ToList();
            //IEnumerable<string> final = cityname.Where(
            //                    city => city.Contains("ing")).Take(3);

            //Console.WriteLine("City that ending  with ING substring:");


            //foreach (string stname in final)
            //{
            //    Console.WriteLine(stname);
            //}

            //    var latitude = users.Select(s => s.lat).ToList();
            //    IEnumerable<string> fresult = latitude.Where(latt=>latt.Take(2).Any()).ToList();


            //    Console.WriteLine("Only three values of latitude:");


            //    foreach (string stname in fresult)
            //    {
            //        Console.WriteLine(stname);
            //    }

        }




    }

 }









