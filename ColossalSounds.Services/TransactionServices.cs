﻿using ColossalSounds.Data;
using ColossalSounds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ColossalSounds.Services
{
    public class TransactionServices
    {
        public int CreateTransaction(TransactionCreate model)
        {
            try
            {

                using (var ctx = new ApplicationDbContext())
                {
                    var entity = new Transaction();
                    //Goes through the list of inputted integers and 
                    //a. adds the name of the instrument/accessory associated to a list of integers (like a receipt prints out the names of items purchased
                    //b. adds the price of the item to the subtotal
                    //c. increases the product count of the transaction by 1. 
                    List<string> itemList = new List<string>();

                    if (model.AllInstruments != null)
                    {
                        foreach (int number in model.AllInstruments)
                        {
                            Instrument example = ctx.Instruments.Where(e => e.InstrumentId == number).Single();
                            itemList.Add(example.Name);
                            entity.SubTotal = entity.SubTotal + ctx.Instruments.Where(e => e.InstrumentId == number).Single().Price;
                            entity.ProductCount = entity.ProductCount + 1;
                        }
                    }
                    if (model.AllAccessories != null)
                    {
                        foreach (int number in model.AllAccessories)
                        {
                            Accessory accessory = ctx.Accessories.Where(e => e.AccessoryId == number).Single();
                            itemList.Add(accessory.Name);
                            entity.SubTotal = entity.SubTotal + ctx.Accessories.Where(e => e.AccessoryId == number).Single().Price;
                            entity.ProductCount = entity.ProductCount + 1;
                        }
                    }


                    entity.ItemsBought = itemList;
                    entity.CustomerId = model.CustomerId;
                    entity.DateOfTransaction = DateTime.Now;
                    ctx.Transactions.Add(entity);
                    return ctx.SaveChanges();
                }

            }
            catch
            {
                return 500;
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
                            ItemsBoughtString = string.Join(", ", e.ItemsBought),
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
                    .Single(e => e.TransactionId == id);

                return
                    new TransactionDetail
                    {
                        ItemsBoughtString = string.Join(", ", entity.ItemsBought),
                        TransactionId = entity.TransactionId,
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
                    .Single(e => e.TransactionId == model.Id);


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
                    .Single(e => e.TransactionId == id);

                ctx.Transactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
