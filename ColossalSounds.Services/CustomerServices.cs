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
                    CustomerId = model.CustomerId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    State = model.State,
                    Zipcode = model.Zipcode,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    FullAddress = model.FullAddress,
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

        public CustomerContactDetail GetCustomerByPhoneNumber(double phoneNumber)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.PhoneNumber == phoneNumber);

                    return
                    new CustomerContactDetail
                    {
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        FullAddress = entity.FullAddress,
                        PhoneNumber = entity.PhoneNumber,
                        Email = entity.Email,
                    };
            }
        }

        public bool UpdateCustomerInfo(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.PhoneNumber == model.PhoneNumber);

                if (model.FirstName != null)
                {
                    entity.FirstName = model.FirstName;
                }
                else if (model.LastName != null)
                {
                    entity.LastName = model.LastName;
                }
                else if (model.StreetAddress != null)
                {
                    entity.StreetAddress = model.StreetAddress;
                }
                else if (model.City != null)
                {
                    entity.City = model.City;
                }
                else if (model.State != null)
                {
                    entity.State = model.State;
                }
                else if (model.Zipcode != null)
                {
                    entity.Zipcode = model.Zipcode;
                }
                else if (model.PhoneNumber != 0)
                {
                    entity.PhoneNumber = model.PhoneNumber;
                }
                else if (model.Email != null)
                {
                    entity.Email = model.Email;
                }
                return ctx.SaveChanges() == 1;
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
