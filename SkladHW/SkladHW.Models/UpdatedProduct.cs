using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkladHW.Models
{
    public class UpdatedProduct : Product
    {
        public string OldNameProduct { get; set; }
        public int? OldPriceProduct { get; set; }
        public DateTime DateUpdate { get; set; }

        public UpdatedProduct()
        {
            DateUpdate = DateTime.Now;
        }
    }
}
