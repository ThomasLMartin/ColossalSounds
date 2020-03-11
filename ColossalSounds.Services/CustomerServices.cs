using ColossalSounds.Data;
using ColossalSounds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Services
{
    public class CustomerServices
    {
        //public Guid _userId;

        //public CustomerServices(Guid id)
        //{
        //    _userId = id; 
        //}

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    State = model.State,
                    Zipcode = model.Zipcode,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerContactDetail> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Customers
                    .Select(
                        e =>
                        new CustomerContactDetail
                        {
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            FullAddress = e.FullAddress,
                            PhoneNumber = e.PhoneNumber,
                            Email = e.Email,
                        });
                return query.ToArray();
            }
        }

        public IEnumerable<CustomerContactDetail> GetCustomerByPhoneNumber(string phoneNumber)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var query =
                        ctx
                        .Customers
                        .Where(e => e.PhoneNumber == phoneNumber);

                    List<CustomerContactDetail> listCCD = new List<CustomerContactDetail>();

                    foreach (Customer c in query)
                    {
                        CustomerContactDetail customerToReturn = new CustomerContactDetail();

                        customerToReturn.FirstName = c.FirstName;
                        customerToReturn.LastName = c.LastName;
                        customerToReturn.FullAddress = c.FullAddress;
                        customerToReturn.PhoneNumber = c.PhoneNumber;
                        customerToReturn.Email = c.Email;

                        listCCD.Add(customerToReturn);
                    }
                    return listCCD; 
                }
                catch
                {
                    var query = new List<CustomerContactDetail>();
                      return query; 
                }
            }
        }

        public bool UpdateCustomerInfo(CustomerEdit model, string phoneNumber)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity =
                        ctx
                        .Customers
                        .Single(e => e.PhoneNumber == phoneNumber);
                    bool updating = true;
                    int counter = 0;
                    while (updating)
                    {
                        if (counter == 8)
                        {
                            updating = false;
                            break;
                        }

                        if (model.FirstName != null && counter == 0)
                        {
                            entity.FirstName = model.FirstName;
                        }
                        else if (model.LastName != null && counter == 1)
                        {
                            entity.LastName = model.LastName;
                        }
                        else if (model.StreetAddress != null && counter == 2)
                        {
                            entity.StreetAddress = model.StreetAddress;
                        }
                        else if (model.City != null && counter == 3)
                        {
                            entity.City = model.City;
                        }
                        else if (model.State != null && counter == 4)
                        {
                            entity.State = model.State;
                        }
                        else if (model.Zipcode != null && counter == 5)
                        {
                            entity.Zipcode = model.Zipcode;
                        }
                        else if (model.PhoneNumber != null && counter == 6)
                        {
                            entity.PhoneNumber = model.PhoneNumber;
                        }
                        else if (model.Email != null && counter == 7)
                        {
                            entity.Email = model.Email;
                        }
                        counter++;
                    }
                    return ctx.SaveChanges() == 1;
                }
                catch
                {
                    var entity =
                        ctx
                        .Customers
                        .Where(e => e.PhoneNumber == null);
                    return false;

                }
            }
        }

        public bool DeleteCustomer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.CustomerId == id);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
