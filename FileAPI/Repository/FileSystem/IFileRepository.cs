using FileAPI.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileAPI.Repository.FileSystem
{
    public interface IFileRepository
    {
        Task<bool> Create(List<Product> products);
    }
}