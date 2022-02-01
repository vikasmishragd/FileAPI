using FileAPI.Entity;
using System.Collections.Generic;

namespace FileAPI.Services
{
    public interface IDataTransformationService
    {
        List<Product> TransformCsvToObject(string fileName);
    }
}