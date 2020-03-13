using ColossalSounds.Data;
using ColossalSounds.Models.AccessoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ColossalSounds.Data.InstrumentClassification;

namespace ColossalSounds.Services
{
    public class AccessoryService
    {
        private readonly Guid _accessoryId;

        public AccessoryService(Guid accessoryId)
        {
            _accessoryId = accessoryId;
        }
        public bool CreateAccessory(AccessoryCreate model)
        {
            var entity = new Accessory()
            {
                Name = model.Name,
                InstrumentAssociated = (InstrumentType)model.InstrumentAssociatedId,
                Brand = model.Brand,
                Quantity = model.Quantity,
                Price = model.Price,
                Description = model.Description
            };

            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Accessories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AccessoryListItem> GetAllAccessories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Accessories
                    .Select(
                        e => new AccessoryListItem
                        {
                            AccessoryId = e.AccessoryId,
                            Name = e.Name,
                            InstrumentAssociated = e.InstrumentAssociated,
                            Brand = e.Brand,
                            Quantity = e.Quantity,
                            Price = e.Price
                        }
                    );
                return query.ToArray();
            }
        }

        public AccessoryDetail GetAccessoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Accessories
                        .Single(e => e.AccessoryId == id);
                return
                    new AccessoryDetail
                    {
                        Name = entity.Name,
                        Brand = entity.Brand,
                        Quantity = entity.Quantity,
                        Price = entity.Price,
                        Description = entity.Description
                    };
            }
        }

            public bool UpdateAccessory(AccessoryEdit model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .Accessories
                        .Single(e => e.AccessoryId == model.AccessoryId);

                    entity.AccessoryId = model.AccessoryId;
                    entity.Name = model.Name;
                    entity.InstrumentAssociated = (InstrumentType)model.InstrumentAssociated;
                    entity.Brand = model.Brand;
                    entity.Quantity = model.Quantity;
                    entity.Price = model.Price;
                    entity.Description = model.Description;

                    return ctx.SaveChanges() == 1;
                }
            }

            public bool DeleteAccessory(int accessoryId)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity = ctx.Accessories.Single(e => e.AccessoryId == accessoryId);
                    ctx.Accessories.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
        }
    }
