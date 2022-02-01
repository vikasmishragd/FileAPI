using FileAPI.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileAPI.Repository.Database
{
    public interface IDBRepository
    {
        Task<bool> Create(List<Product> product);
    }
}