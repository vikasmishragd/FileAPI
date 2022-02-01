using FileAPI.Entity;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DataTransformationService
{
    public class DataTransformationService : IDataTransformationService
    {
        public List<Product> TransformCsvToObject(string fileName)
        {
            List<Product> items = new List<Product>();

            foreach (var eachLine in ReadCsv(fileName))
            {
                try
                {
                    items.Add(new Product
                    {
                        Key = eachLine[0],
                        ArtikelCode = eachLine[1],
                        ColorCode = eachLine[2],
                        Description = eachLine[3],
                        Price = eachLine[4],
                        DiscountPrice = eachLine[5],
                        DeliveredIn = eachLine[6],
                        Q1 = eachLine[7],
                        Size = eachLine[8],
                        Color = (Colors)Enum.Parse(typeof(Colors), eachLine[9])
                    });
                }
                catch (Exception ex)
                {
                    //log this as this row was not added for some reason
                }

            }

            return items;
            //await repository.Create(items);

            //var options = new JsonSerializerOptions { WriteIndented = true };
            //string jsonString = JsonSerializer.Serialize(items, options);

            //await Task.Run(() => WriteEverythingToFile(jsonString));

            //return true;
        }

        private static IEnumerable<string[]> ReadCsv(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 64 * 1024, FileOptions.SequentialScan))
            using (var reader = new StreamReader(fs))
            {
                string line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line.Split(',');
                }
            }
        }
    }
}
