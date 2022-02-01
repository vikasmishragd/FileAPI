using FileAPI.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileAPI.Repository.Database
{
    public class DBRepository : IDBRepository
    {
        private readonly RepositoryDbContext fileContext;

        public DBRepository(RepositoryDbContext fileContext)
        {
            this.fileContext = fileContext;
        }
        public async Task<bool> Create(List<Product> product)
        {
            await fileContext.AddRangeAsync(product);
            await fileContext.SaveChangesAsync();
            return true;
        }
    }
}
