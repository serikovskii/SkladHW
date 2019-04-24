using System;

namespace SkladHW.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string NameProduct { get; set; }
        public int PriceProduct { get; set; }

        public Product()
        {
            Id = Guid.NewGuid();
        }
    }
}
