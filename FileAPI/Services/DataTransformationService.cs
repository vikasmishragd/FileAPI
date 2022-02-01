using FileAPI.Entity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileAPI.Services
{
    public class DataTransformationService : IDataTransformationService
    {
        public List<Product> TransformCsvToObject(string fileName)
        {
            var items = new ConcurrentBag<Product>();
            using var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None, 64 * 1024, FileOptions.SequentialScan);
            using var reader = new StreamReader(fs);
            Parallel.ForEach(ReadCsv(reader), eachLine =>
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
                        Color = eachLine[9]
                    });
                }
                catch (Exception ex)
                {
                    //log this as this row was not added for some reason
                }
            });

            return items.ToList();
        }

        private static IEnumerable<string[]> ReadCsv(StreamReader reader)
        {
            string line = reader.ReadLine();
            while ((line = reader.ReadLine()) != null)
            {
                yield return line.Split(',');
            }
        }
    }
}
