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
    public class CustomerController : ApiController
    {
        private CustomerServices CreateCustomerService()
        {
            var customerService = new CustomerServices();
            return customerService;
        }

        public IHttpActionResult GetAll()
        {
            CustomerServices customerService = CreateCustomerService();
            var customer = customerService.GetCustomers();
            return Ok(customer);
        }

        public IHttpActionResult GetByPhoneNumber(int phoneNumber)
        {
            CustomerServices customerService = CreateCustomerService();
            var customer = customerService.GetCustomerByPhoneNumber(phoneNumber);
            return Ok(customer);
        }

        public IHttpActionResult Post(CustomerCreate customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCustomerService();

            if (!service.CreateCustomer(customer))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(CustomerEdit customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCustomerService();

            if (!service.UpdateCustomerInfo(customer))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCustomerService();

            if (!service.DeleteCustomer(id))
                return InternalServerError();

            return Ok();
        }

    }
}
