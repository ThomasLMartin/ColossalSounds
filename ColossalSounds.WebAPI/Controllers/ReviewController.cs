using ColossalSounds.Data;
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
        [HttpGet]
        public IHttpActionResult GetReviews()
        {
            var reviewService = CreateReviewService();
            var reviewList = reviewService.GetAllReviews();
            return Ok(reviewList);
        }
        public IHttpActionResult GetById(int id)
        {
            var service = CreateReviewService();
            var review = service.GetReviewById(id);
            if (review.Id == 0)
            {
                return NotFound();
            }
            return Ok(review);
        }
        [HttpGet]
        [Route("reviewfrominstrumentid/")]
        public IHttpActionResult GetByInstrumentId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var service = CreateReviewService();
                var reviews = service.GetByInstrumentId(id);
                if (reviews.Count() == 0)
                {
                    return Ok("There are no Reviews for this product");
                }
                var list = new List<ReviewListItem>();
                foreach (Review review in reviews)
                {
                    var item = new ReviewListItem();
                    item.Title = review.Title;
                    item.Content = review.Content;
                    item.DateCreated = review.DateCreated;
                    item.DateModified = review.DateModified;
                    list.Add(item);
                }
                return Ok(list);
            }
        }
        [HttpGet]
        [Route("reviewfromaccessoryid/")]
        public IHttpActionResult GetByAccessoryId(int id)
        {
            var service = CreateReviewService();
            var reviews = service.GetByAccessoryId(id);
            if (reviews.Count() == 0)
            {
                return Ok("There are no Reviews for this product");
            }
            var list = new List<ReviewListItem>();
            foreach (Review review in reviews)
            {
                var item = new ReviewListItem();
                item.Title = review.Title;
                item.Content = review.Content;
                item.DateCreated = review.DateCreated;
                item.DateModified = review.DateModified;
                list.Add(item);
            }
            return Ok(list);
        }
        [HttpPost]
        public IHttpActionResult PostReview(ReviewCreate model)
        {
            if (model.AccessoryId == null && model.InstrumentId == null)
            {
                return BadRequest();
            }
            if (model.AccessoryId != null && model.InstrumentId != null)
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
        [HttpPut]
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
        [HttpDelete]
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