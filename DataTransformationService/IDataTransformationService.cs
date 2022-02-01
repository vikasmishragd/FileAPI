using FileAPI.Entity;
using System.Collections.Generic;

namespace DataTransformationService
{
    public interface IDataTransformationService
    {
        List<Product> TransformCsvToObject(string fileName);
    }
}