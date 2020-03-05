using ColossalSounds.Data;
using ColossalSounds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Services
{
    public class Review_Service
    {
        public Guid _userId;
        public Review_Service(Guid id)
        {
            _userId = id;
        }
        public bool CreateReview(ReviewCreate model)
        {
            var review = new Review()
            {
                AuthorId = _userId,
                Title = model.Title,
                Content = model.Content,
                DateCreated = DateTime.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(review);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReviewListItem> GetAllReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var list = ctx.Reviews.Where(e => e.AuthorId == _userId).Select(e =>
                new ReviewListItem
                {
                    DateCreated = e.DateCreated,
                    Title = e.Title,
                    DateModified = e.DateModified
                });
                return list.ToArray();
            }
        }
        public Review GetByInstrumentId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Reviews.Single(e => e.InstrumentId == id);
                return entity;
            }
        }
        public Review GetByAccessoryId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Reviews.Single(e => e.AccessoryId == id);
                return entity;
            }
        }
        public bool UpdateReview(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Reviews.Single(e => e.Id == model.Id && e.AuthorId == _userId);
                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.DateModified = DateTime.Now;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteReview(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Reviews.Single(e => e.Id == id && e.AuthorId == _userId);
                ctx.Reviews.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
