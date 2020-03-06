﻿using ColossalSounds.Data;
using ColossalSounds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Services
{
    public class InstrumentClassificationServices
    {

        public bool CreateInstClassification(InstrumentClassificationCreate model)
        {
            var entity =
                new InstrumentClassification()
                {
                    Id = model.Id,
                    TypeOfCategory = model.TypeOfCategory,
                    TypeOfInstrument = model.TypeOfInstrument,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Classifications.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<InstrumentClassificationListItem> GetInstClassifications()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Classifications
                        .Select(
                        e =>
                        new InstrumentClassificationListItem
                        {
                            Id = e.Id,
                            TypeOfCategory = e.TypeOfCategory,
                            TypeOfInstrument = e.TypeOfInstrument,
                        });

                return query.ToArray();
            }
        }

        public InstrumentClassificationDetail GetInstClassificationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Classifications
                        .Single(e => e.Id == id);
                return
                    new InstrumentClassificationDetail
                    {
                        TypeOfCategory = entity.TypeOfCategory,
                        TypeOfInstrument = entity.TypeOfInstrument,
                    };
            }
        }

        public bool UpdateInstClassification(InstrumentClassificationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Classifications
                    .Single(e => e.Id == model.Id);

                entity.TypeOfCategory = model.TypeOfCategory;
                entity.TypeOfInstrument = model.TypeOfInstrument;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteInstClassification(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Classifications
                    .Single(e => e.Id == id);

                ctx.Classifications.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
    //Printing enum Value and Index 

    public static class DisplayEnum
    {
        public static List<EnumContents> GetValues<T>()
        {
            List<EnumContents> contents = new List<EnumContents>();

            foreach (var itemType in Enum.GetValues(typeof(T)))
            {

                contents.Add(new EnumContents()
                {
                    enumName = Enum.GetName(typeof(T), itemType),
                    enumNumber = (int)itemType
                });
            }
            return contents;
        }

        public static List<EnumContents> GetValuesByIndex<T>(int indexNumber)
        {
            List<EnumContents> contents = new List<EnumContents>();


            for (int enumIndex = 1; enumIndex < Enum.GetValues(typeof(T)).Length; enumIndex++)
            {
                if (enumIndex == indexNumber)
                {
                    foreach (var itemType in Enum.GetValues(typeof(T)))
                      
                        if(itemType.GetHashCode() == indexNumber)
                        contents.Add(new EnumContents()
                        {
                            enumName = Enum.GetName(typeof(T), itemType),
                            enumNumber = (int)itemType,
                        });

                    return contents;
                }
            }
            return null;
        }

    }

}
