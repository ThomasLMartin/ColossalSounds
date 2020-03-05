using ColossalSounds.Data;
using ColossalSounds.Models.InstrumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Services
{
    public class InstrumentService
    {
        private readonly int _instrumentId;

        public InstrumentService(int instrumentId)
        {
            _instrumentId = instrumentId;
        }
        public bool CreateInstrument(InstrumentCreate model)
        {
            var entity =
                new Instrument()
                {
                    InstrumentId = model.InstrumentId,
                    Description = model.Description,
                    Name = model.Name,
                    ModelName = model.ModelName,
                    Brand = model.Brand,
                    ExpLvl = model.ExpLvl,
                    Quantity = model.Quantity,
                    Price = model.Price,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Instruments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<InsturmentListItem> GetInstruemt()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Instruments
                        .Where(e => e.InstrumentId == _instrumentId)
                        .Select(
                            e =>
                                new InsturmentListItem
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

        public InstrumentDetail GetInstrumentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Instruments
                        .Single(e => e.InstrumentId == id && e.InstrumentId == _instrumentId);
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
                        .Single(e => e.InstrumentId == model.InstrumentId && e.InstrumentId == _instrumentId);

                entity.InstrumentId = model.InstrumentId;
                entity.Description = model.Description;
                entity.Name = model.Name;
                entity.ModelName = model.ModelName;
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
