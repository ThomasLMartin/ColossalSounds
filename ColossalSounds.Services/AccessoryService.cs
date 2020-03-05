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
        public bool CreateAccessory(AccessoryCreate model)
        {
            var entity = new Accessory()
            {
                Name = model.Name,
                //InstrumentAssociated = model.InstrumentAssociated,
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
    }
}
