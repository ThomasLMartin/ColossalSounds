using ColossalSounds.Models.AccessoryModels;
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
    public class AccessoryController : ApiController
    {
        private AccessoryService CreateAccessoryService()
        {
            var accessoryId = Guid.Parse(User.Identity.GetUserId());
            var accessoryService = new AccessoryService(accessoryId);
            return accessoryService;
        }

        public IHttpActionResult Get()
        {
            AccessoryService accessoryService = CreateAccessoryService();
            var accessory = accessoryService.GetAllAccessories();
            return Ok(accessory);
        }

        public IHttpActionResult Post(AccessoryCreate accessory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAccessoryService();

            if (!service.CreateAccessory(accessory))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(AccessoryEdit accessory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAccessoryService();

            if (!service.UpdateAccessory(accessory))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateAccessoryService();

            if (!service.DeleteAccessory(id))
                return InternalServerError();

            return Ok();
        }
    }
}
