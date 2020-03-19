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

        public IEnumerable<InstrumentListItem> GetInstrument()
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
                                    ClassificationId = e.ClassificationId,
                                    AverageRating = e.AverageRating
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
                                    ClassificationId = e.ClassificationId,
                                    AverageRating = e.AverageRating,
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
                                    ClassificationId = e.ClassificationId,
                                    AverageRating = e.AverageRating,
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<InstrumentListItem> GetInstrumentByCategoryType(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Instruments
                        .Where(e => e.InstrumentClassification.TypeOfCategory == (CategoryType)id)
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
                                    AverageRating = e.AverageRating,
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<InstrumentListItem> GetInstrumentByInstrumentType(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Instruments
                        .Where(e => e.InstrumentClassification.TypeOfInstrument == (InstrumentType)id)
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
                                    AverageRating = e.AverageRating,
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<InstrumentListItem> GetInstrumentByExpLvl(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Instruments
                        .Where(e => e.ExpLvl == (ExperienceLevel)id)
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
                                    ClassificationId = e.ClassificationId,
                                    AverageRating = e.AverageRating,
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<InstrumentListItem> GetInstrumentByInstrumentTypeAndExpLvl(int Expid,int TypeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Instruments
                        .Where(e => e.InstrumentClassification.TypeOfInstrument == (InstrumentType)TypeId && e.ExpLvl == (ExperienceLevel)Expid)
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
                                    ClassificationId = e.ClassificationId,
                                    AverageRating = e.AverageRating
                                }
                        );
                return query.ToArray();
            }
        }

        public InstrumentListItem GetInstrumentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Instruments
                        .Single(e => e.InstrumentId == id);
                return
                    new InstrumentListItem
                    {
                        InstrumentId = entity.InstrumentId,
                        Description = entity.Description,
                        Name = entity.Name,
                        ModelName = entity.ModelName,
                        Brand = entity.Brand,
                        ExpLvl = entity.ExpLvl,
                        Quantity = entity.Quantity,
                        Price = entity.Price,
                        AverageRating = entity.AverageRating,
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
                bool updating = true;
                int counter = 0;
                while (updating)
                {
                    if (counter == 8)
                    {
                        updating = false;
                        break; 
                    }
                    if (model.Description != null && counter == 0)
                    {
                        entity.Description = model.Description;
                    }
                    else if (model.Name != null && counter == 1)
                    {
                        entity.Name = model.Name;
                    }
                    else if (model.ModelName != null && counter == 2)
                    {
                        entity.ModelName = model.ModelName;
                    }
                    else if (model.Brand != null && counter == 3)
                    {
                        entity.Brand = model.Brand;
                    }
                    else if (model.ExpLvl != 0 && counter == 4)
                    {
                        entity.ExpLvl = model.ExpLvl;
                    }
                    else if (model.Quantity != 0 && counter == 5)
                    {
                        entity.Quantity = model.Quantity;
                    }
                    else if (model.Price != 0 && counter == 6)
                    {
                        entity.Price = model.Price;
                    }
                    else if (model.ClassificationId != 0 && counter == 7)
                    {
                        entity.ClassificationId = model.ClassificationId;
                    }
                    counter++;
                }
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteInstrument(int instrumentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity =
                        ctx
                            .Instruments.Single(e => e.InstrumentId == instrumentId && e.OwnerId == _userId);
                    ctx.Instruments.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
                catch
                {
                    return false;
                }

            }
        }
    }
}
