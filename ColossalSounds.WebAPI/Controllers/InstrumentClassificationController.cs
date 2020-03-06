using ColossalSounds.Models;
using ColossalSounds.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ColossalSounds.Data.InstrumentClassification;

namespace ColossalSounds.WebAPI.Controllers
{
    public class InstrumentClassificationController : ApiController
    {

        private InstrumentClassificationServices CreateClassificationService()
        {
            var classificationService = new InstrumentClassificationServices();
            return classificationService; 
        }

        //GET

         public IHttpActionResult GetAll()
        {
            InstrumentClassificationServices classificationService = CreateClassificationService();
            var classification = classificationService.GetInstClassifications();
            return Ok(classification);
        }
        
        public IHttpActionResult GetById(int id)
        {
            InstrumentClassificationServices classificationService = CreateClassificationService();
            var classification = classificationService.GetInstClassificationById(id);
            return Ok(classification);
        }

        //POST 

        public IHttpActionResult Post(InstrumentClassificationCreate classification)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateClassificationService();

            if (!service.CreateInstClassification(classification))
                return InternalServerError();

            return Ok();
        }

        //PUT (UPDATE)
        public IHttpActionResult Put(InstrumentClassificationEdit classification)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateClassificationService();

            if (!service.UpdateInstClassification(classification))
                return InternalServerError();

            return Ok();
        }

        //DELETE

        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateClassificationService();

            if (!service.DeleteInstClassification(id))
                return InternalServerError();

            return Ok();
        }

        //Enum Method Retrun Categories 

        [HttpGet]
        [Route("categorytypes/all")]
        public IHttpActionResult GetCategoryValues()
        {
            return Ok(DisplayEnum.GetValues<CategoryType>());
        }

        [HttpGet]
        [Route("instrumenttypes/all")]
        public IHttpActionResult GetInstrumentTypeNames()
        {
            return Ok(DisplayEnum.GetValues<InstrumentType>()); 
        }

        [HttpGet]
        [Route("instrumenttypes/")]
        public IHttpActionResult GetInstrumentByIndexNumber(int index)
        {
            if(DisplayEnum.GetValuesByIndex<InstrumentType>(index) == null)
            {
                return BadRequest("There is no instrument by that number");
            }
            return Ok(DisplayEnum.GetValuesByIndex<InstrumentType>(index));
        }
        
        [HttpGet]
        [Route("instrumentinputnumber/")]
        public IHttpActionResult Get(string instrument)
        {
            if (DisplayEnum.GetInputNumberByInstType<InstrumentType>(instrument) == null)
            {
                return BadRequest("There is no instrument by that name");
            }
            return Ok(DisplayEnum.GetInputNumberByInstType<InstrumentType>(instrument));
        }
    }

}
