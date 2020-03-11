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

        public IHttpActionResult GetByPhoneNumber(string phoneNumber)
        {
            var service = CreateCustomerService(); 
          
            var customers = service.GetCustomerByPhoneNumber(phoneNumber);
            
            if (customers.Count() == 0)
            {
                return Ok("There are no customers with that phone number");
            }

            return Ok(); 

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

        public IHttpActionResult Put(CustomerEdit customer, string phoneNumber)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCustomerService();

            if (service.UpdateCustomerInfo(customer, phoneNumber) == false)
            {
                return Ok("There is no customer with that phone number. Double check to make sure you inputed the correct number.");
            }

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
