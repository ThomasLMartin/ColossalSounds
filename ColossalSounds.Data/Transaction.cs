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

        
        [ForeignKey(nameof(Accessory))]
        public int? Id { get; set; }
        public virtual Accessory Accessory { get; set; }

      
        [ForeignKey(nameof(Instrument))]
        public int? InstrumentId { get; set; }
        public virtual Instrument Instrument { get; set; }

        
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        
        public DateTime DateOfTransaction { get; set; }


        public int ProductCount { get; set; }

        [DataType(DataType.Currency)]
        public decimal SubTotal 
        {
            get 
            {
                if (Instrument != null)
                {
                    return Instrument.Price * ProductCount;
                }
                else if (Accessory != null)
                {
                    return Accessory.Price * ProductCount;
                }
                else
                    return 0;
            }
            set { }
        }

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
