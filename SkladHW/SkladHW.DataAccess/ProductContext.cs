namespace SkladHW.DataAccess
{
    using SkladHW.Models;
    using System.Data.Entity;

    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("name=ProductContext")
        {
        }

        public virtual DbSet<Product> Products { get; set; }     
        public virtual DbSet<DeletedProduct> DeletedProducts { get; set; }     
        public virtual DbSet<UpdatedProduct> UpdatedProducts { get; set; }     
    }

    
}