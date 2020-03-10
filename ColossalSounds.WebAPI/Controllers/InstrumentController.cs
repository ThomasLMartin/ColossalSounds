using ColossalSounds.Data;
using ColossalSounds.Models.InstrumentModel;
using ColossalSounds.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ColossalSounds.WebAPI.Controllers
{
    public class InstrumentController : ApiController
    {

        public IHttpActionResult Get()
        {
            InstrumentService instrumentService = CreateInstrumentService();
            var instrument = instrumentService.GetInstrument();
            return Ok(instrument);
        }

        public IHttpActionResult Post(InstrumentCreate instrument)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateInstrumentService();

            if (!service.CreateInstrument(instrument))
                return InternalServerError();

            return Ok(instrument);
        }
        
        public IHttpActionResult GetById(int id)
        {
            InstrumentService instrumentService = CreateInstrumentService();
            var instrument = instrumentService.GetInstrumentById(id);
            return Ok(instrument);
        }

        [Route("InstrumentFromCategoryType/")]
        public IHttpActionResult GetByCategoryType(int id)
        {
            InstrumentService instrumentService = CreateInstrumentService();
            var instruments = instrumentService.GetInstrumentByCategoryType(id);
            return Ok(instruments);   
        }

        [Route("InstrumentFromInstrumentType/")]
        public IHttpActionResult GetByInstrumentType(int id)
        {
            InstrumentService instrumentServices = CreateInstrumentService();
            var instruments = instrumentServices.GetInstrumentByInstrumentType(id);
            return Ok(instruments);
        }

        private InstrumentService CreateInstrumentService()
        {
            var instrumentId = Guid.Parse(User.Identity.GetUserId());
            var instrumentService = new InstrumentService(instrumentId);
            return instrumentService;
        }

        public IHttpActionResult Put(InstrumentEdit instrument)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateInstrumentService();

            if (!service.UpdateInstrument(instrument))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateInstrumentService();

            if (!service.DeleteInsturment(id))
                return InternalServerError();

            return Ok();
        }
    }
}
