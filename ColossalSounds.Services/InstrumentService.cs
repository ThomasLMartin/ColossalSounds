using ColossalSounds.Data;
using ColossalSounds.Models;
using ColossalSounds.Models.InstrumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ColossalSounds.Data.InstrumentClassification;

namespace ColossalSounds.Services
{
    public class InstrumentService
    {
        public Guid _userId;
        public InstrumentService(Guid id)
        {
            _userId = id;
        }
        public bool CreateInstrument(InstrumentCreate model)
        {
            var entity =
                new Instrument()
                {
                    Description = model.Description,
                    Name = model.Name,
                    ModelName = model.ModelName,
                    Brand = model.Brand,
                    ExpLvl = model.ExpLvl,
                    Quantity = model.Quantity,
                    Price = model.Price,
                    OwnerId = _userId,
                    ClassificationId = model.ClassificationId,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Instruments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<InstrumentListItem> GetInstruemt()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Instruments
                        .Select(
                            e =>
                                new InstrumentListItem
                                {
                                    InstrumentId = e.InstrumentId,
                                    Description = e.Description,
                                    Name = e.Name,
                                    ModelName = e.ModelName,
                                    Brand = e.Brand,
                                    ExpLvl = e.ExpLvl,
                                    Quantity = e.Quantity,
                                    Price = e.Price,
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<InstrumentListItem> GetInstrumentyByBrand(string Brand)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Instruments
                        .Where(e => e.Brand.ToLower() == Brand.ToLower())
                        .Select(
                            e =>
                                new InstrumentListItem
                                {
                                    InstrumentId = e.InstrumentId,
                                    Description = e.Description,
                                    Name = e.Name,
                                    ModelName = e.ModelName,
                                    Brand = e.Brand,
                                    ExpLvl = e.ExpLvl,
                                    Quantity = e.Quantity,
                                    Price = e.Price,
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<InstrumentListItem> GetInstrumentyByModelName(string modelName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Instruments
                        .Where(e => e.ModelName.ToLower() == modelName.ToLower())
                        .Select(
                            e =>
                                new InstrumentListItem
                                {
                                    InstrumentId = e.InstrumentId,
                                    Description = e.Description,
                                    Name = e.Name,
                                    ModelName = e.ModelName,
                                    Brand = e.Brand,
                                    ExpLvl = e.ExpLvl,
                                    Quantity = e.Quantity,
                                    Price = e.Price,
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<Instrument> GetInstrumentByCategoryType(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Instruments
                        .Where(e => e.InstrumentClassification.TypeOfCategory == (CategoryType)id)
                        .Select(
                            e =>
                                new Instrument
                                {                                
                                    ClassificationId = e.ClassificationId,
                                    InstrumentId = e.InstrumentId,
                                    Description = e.Description,
                                    Name = e.Name,
                                    ModelName = e.ModelName,
                                    Brand = e.Brand,
                                    ExpLvl = e.ExpLvl,
                                    Quantity = e.Quantity,
                                    Price = e.Price,
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<Instrument> GetInstrumentByInstrumentType(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Instruments
                        .Where(e => e.InstrumentClassification.TypeOfInstrument == (InstrumentType)id)
                        .Select(
                            e =>
                                new Instrument
                                {
                                    ClassificationId = e.ClassificationId,
                                    InstrumentId = e.InstrumentId,
                                    Description = e.Description,
                                    Name = e.Name,
                                    ModelName = e.ModelName,
                                    Brand = e.Brand,
                                    ExpLvl = e.ExpLvl,
                                    Quantity = e.Quantity,
                                    Price = e.Price,
                                }
                        );
                return query.ToArray();
            }
        }

        public InstrumentDetail GetInstrumentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Instruments
                        .Single(e => e.InstrumentId == id);
                return
                    new InstrumentDetail
                    {
                        InstrumentId = entity.InstrumentId,
                        Description = entity.Description,
                        Name = entity.Name,
                        ModelName = entity.ModelName,
                        Brand = entity.Brand,
                        ExpLvl = entity.ExpLvl,
                        Quantity = entity.Quantity,
                        Price = entity.Price,
                    };
            }
        }

        public bool UpdateInstrument(InstrumentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Instruments
                        .Single(e => e.InstrumentId == model.InstrumentId && e.OwnerId == _userId);

                entity.InstrumentId = model.InstrumentId;
                entity.Description = model.Description;
                entity.Name = model.Name;
                entity.ModelName = model.ModelName;
                entity.Brand = model.Brand;
                entity.ExpLvl = model.ExpLvl;
                entity.Quantity = model.Quantity;
                entity.Price = model.Price;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteInsturment(int instrumentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Instruments.Single(e => e.InstrumentId == instrumentId && e.OwnerId == _userId);

                ctx.Instruments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
