using FileAPI.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileAPI.Repository.FileSystem
{
    public class FileRepository : IFileRepository
    {
        public async Task<bool> Create(List<Product> products)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(products, options);
            await Task.Run(() => WriteEverythingToFile(jsonString));
            return true;
        }

        private void WriteEverythingToFile(string jsonString)
        {
            var fileName = $"{DateTime.Now.DayOfYear}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Millisecond}output.json";

            DirectoryInfo di= null;
            var exists = Directory.Exists(CombinePath(Environment.CurrentDirectory, "Files"));
            if (!exists)
                di = Directory.CreateDirectory(CombinePath(Environment.CurrentDirectory, "Files"));
            else
                di = new DirectoryInfo(CombinePath(Environment.CurrentDirectory, "Files"));
            File.WriteAllText(CombinePath(di.FullName, fileName), jsonString);
        }

        private string CombinePath(string partOne, string partTwo)
        {
            return Path.Combine(partOne, partTwo);
        }
    }
}
