using ColossalSounds.Models;
using ColossalSounds.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ColossalSounds.Data.ProductRating;

namespace ColossalSounds.WebAPI.Controllers
{
    public class RatingController : ApiController
    {

        private RatingService CreateRatingService()
        {
            var ratingService = new RatingService();
            return ratingService;
        }

        public IHttpActionResult Get()
        {
            RatingService ratingService = CreateRatingService();
            var starRating = ratingService.GetRating();
            return Ok(starRating);
        }

        public IHttpActionResult Post(RatingCreate rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRatingService();

            if (!service.CreatingProductRating(rating))
                return InternalServerError();

            return Ok(); 
        }

        public IHttpActionResult Put(RatingEdit rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRatingService();

            if (!service.UpdateRating(rating))
                return InternalServerError();

            return Ok(); 
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateRatingService();
            if (!service.DeleteRating(id))
                return InternalServerError();
            return Ok();
        }

    }
}
