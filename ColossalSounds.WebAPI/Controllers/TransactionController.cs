using ColossalSounds.Models;
using ColossalSounds.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ColossalSounds.WebAPI.Controllers
{
    public class TransactionController : ApiController
    {
        private TransactionServices CreateTransactionService()
        {
            var transactionService = new TransactionServices();
            return transactionService;
        }

        public IHttpActionResult GetAll()
        {
            TransactionServices transactionService = CreateTransactionService();

            var transaction = transactionService.GetTransactions();

            return Ok(transaction);
        }

        public IHttpActionResult GetById(int id)
        {
            TransactionServices transactionService = CreateTransactionService();

            var transaction = transactionService.GetTransactionById(id);
            
            return Ok(transaction);

        }

        public IHttpActionResult Post(TransactionCreate transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTransactionService();

            if (service.CreateTransaction(transaction) == 1)
            {
            return Ok();

            }
                return InternalServerError();

        }

        public IHttpActionResult Put(TransactionEdit transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTransactionService();

            if (!service.UpdateTransaction(transaction))
                return InternalServerError();

            return Ok(); 
        }

        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTransactionService();

            if (!service.DeleteTransaction(id))
                return InternalServerError();

            return Ok(); 
        }
    }
}
