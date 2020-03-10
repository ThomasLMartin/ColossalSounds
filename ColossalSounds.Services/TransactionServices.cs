using ColossalSounds.Data;
using ColossalSounds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Services
{
    public class TransactionServices
    {
        public bool CreateTransaction(TransactionCreate model)
        {
            var entity = new Transaction()
            {
                TransactionId = model.TransactionId,
                Id = model.Id,
                InstrumentId = model.InstrumentId,
                CustomerId = model.CustomerId,
                DateOfTransaction = model.DateOfTransaction,
                ProductCount = model.ProductCount,
                SubTotal = model.SubTotal,
                Total = model.Total,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1; 
            }
        }

        public IEnumerable<TransactionListItem> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Transactions
                    .Select(
                        e =>
                        new TransactionListItem
                        {
                            TransactionId = e.TransactionId,
                            DateOfTransaction = e.DateOfTransaction,
                            Total = e.Total,
                        });
                return query.ToArray(); 
            }
        }

        public TransactionDetail GetTransactionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Transactions
                    .Single(e => e.Id == id);

                return
                    new TransactionDetail
                    {
                        TransactionId = entity.TransactionId,
                        Accessory = entity.Accessory.Name,
                        InstrumentName = entity.Instrument.Name,
                        CustomerName = entity.Customer.FullName,
                        DateOfTransaction = entity.DateOfTransaction,
                        Total = entity.Total,
                    };
            }
        }

        public bool UpdateTransaction(TransactionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Transactions
                    .Single(e => e.Id == model.Id);

                entity.Id = model.Id;
                entity.InstrumentId = model.InstrumentId;
                entity.CustomerId = model.CustomerId;
                entity.CustomerId = model.CustomerId;
                entity.DateOfTransaction = model.DateOfTransaction;
                entity.ProductCount = model.ProductCount;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTransaction(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Transactions
                    .Single(e => e.Id == id);

                ctx.Transactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
