using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileAPI.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string ArtikelCode { get; set; }
        public string ColorCode { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string DiscountPrice { get; set; }
        public string DeliveredIn { get; set; }
        public string Q1 { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }

    public enum Colors
    {
        grijs,
        groen,
        wit,
        zwart,
        bruin,
        beige,
        rood,
        blauw
    }
}
