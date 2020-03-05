using ColossalSounds.Models;
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
    public class ReviewController : ApiController
    {
        private Review_Service CreateReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var reviewService = new Review_Service(userId);
            return reviewService;
        }
        public IHttpActionResult GetReviews()
        {
            var reviewService = CreateReviewService();
            var reviewList = reviewService.GetAllReviews();
            return Ok(reviewList);
        }
        public IHttpActionResult GetByInstrumentId(int id)
        {
            var service = CreateReviewService();
            var reviews = service.GetByInstrumentId(id);
            return Ok(reviews);
        }
        public IHttpActionResult GetByAccessoryId(int id)
        {
            var service = CreateReviewService();
            var reviews = service.GetByAccessoryId(id);
            return Ok(reviews);
        }
        public IHttpActionResult PostReview(ReviewCreate model)
        {
            if(model.AccessoryId == null && model.InstrumentId == null)
            {
                return BadRequest();
            }
            if(model.AccessoryId != null && model.InstrumentId != null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var service = CreateReviewService();
            if (!service.CreateReview(model))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult PutReview(ReviewEdit model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var service = CreateReviewService();
            if (!service.UpdateReview(model))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult DeleteReview(int id)
        {
            var service = CreateReviewService();
            if (!service.DeleteReview(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}