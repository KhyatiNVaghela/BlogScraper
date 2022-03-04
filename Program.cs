using CsvHelper;
using HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Globalization;


using System;

namespace Getter
{


   /// <summary>
   /// This is row class
   /// </summary>
    public class Row
    {
        public string Title { get; set; }
    }
    class Program
    {
        /// <summary>
        /// This is the main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://en.wikipedia.org/wiki/Greece");

            var HeaderNames = doc.DocumentNode.SelectNodes("//span[@class='toctext']");

            var titles = new List<Row>();
            foreach (var item in HeaderNames)
            {
                titles.Add(new Row { Title = item.InnerText });
            }
            using (var writer = new StreamWriter("C:/GitHub/BlogScraper/example.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(titles);
            }
        }
    }
}

