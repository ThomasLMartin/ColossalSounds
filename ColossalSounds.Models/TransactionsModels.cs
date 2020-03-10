using ColossalSounds.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Models
{
    public class TransactionCreate
    {
        public int TransactionId { get; set; }

       public int? Id { get; set; } //accessory Id

       public int? InstrumentId { get; set; }
   
        public int CustomerId { get; set; }

        public DateTime DateOfTransaction { get; set; }

        public int ProductCount { get; set; }

        [DataType(DataType.Currency)]
        public decimal SubTotal { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

    }

    public class TransactionEdit
    {
        public int? Id { get; set; } //accessory Id

        public int? InstrumentId { get; set; }

        public int CustomerId { get; set; }

        public DateTime DateOfTransaction { get; set; }

        public int ProductCount { get; set; }

        //Price? --> adding a function to adjust price to a sale or match pricing
    }

    public class TransactionListItem
    
    {
        public int TransactionId { get; set; }

        public DateTime DateOfTransaction { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }
    }

    public class TransactionDetail

    {
        public int TransactionId { get; set; }

        public string Accessory { get; set; } 

        public string InstrumentName { get; set; }

        public string CustomerName { get; set; }

        public DateTime DateOfTransaction { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }
    }

}
