using ColossalSounds.Data;
using ColossalSounds.Models.AccessoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Services
{
    public class AccessoryService
    {
        private readonly List<Accessory> _accessories = new List<Accessory>();
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
                InstrumentAssociated = model.InstrumentAssociated,
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
                var query = ctx.Accessories.Where(e => e.Id == _accessoryId)
                    .Select(e => new AccessoryListItem
                    {
                        Id = e.Id,
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

        public bool UpdateAccessory(AccessoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Accessories.Single(e => e.Id == _accessoryId);
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.InstrumentAssociated = model.InstrumentAssociated;
                entity.Brand = model.Brand;
                entity.Quantity = model.Quantity;
                entity.Price = model.Price;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAccessory(int accessId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Accessories.Single(e => e.Id == _accessoryId);
                ctx.Accessories.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
