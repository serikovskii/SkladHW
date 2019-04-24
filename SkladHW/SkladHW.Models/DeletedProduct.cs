using System;

namespace SkladHW.Models
{
    public class DeletedProduct : Product
    {
        public Guid ProductId { get; set; }
        public DateTime DateDelete { get; set; }
        public DeletedProduct()
        {
            DateDelete = DateTime.Now;
        }
    }
}
