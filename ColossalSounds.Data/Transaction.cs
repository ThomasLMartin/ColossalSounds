using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Data
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public List<string> ItemsBought { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public DateTime DateOfTransaction { get; set; }


        public int ProductCount { get; set; }

        [DataType(DataType.Currency)]
        public decimal SubTotal { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total
        {
            get
            {
                var tax = SubTotal * 0.07m;
                return SubTotal + tax;
            }
            set { }
        }
    }
}
