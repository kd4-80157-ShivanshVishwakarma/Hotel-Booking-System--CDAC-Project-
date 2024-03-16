using EntityModelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public class HotelReviewRepository : IHotelReviewRepository
    {
        public ProjectDbContext _DbContext;

        public HotelReviewRepository()
        {
            _DbContext = new ProjectDbContext();
        }

        public bool AddHotelReview(HotelReview hotelReview)
        {

            var hId = _DbContext.Bookings
                .Where(h => h.UserId == hotelReview.UserId)
                .Select(h => h.HotelId)
                .FirstOrDefault();

            hotelReview.HotelId = hId;

            _DbContext.HotelReviews.Add(hotelReview);
            int count = _DbContext.SaveChanges();
            return count > 0 ? true : false;
        }


        public bool DeleteHotelReviewById(int hotelReviewId)
        {
            HotelReview hr = GetHotelReviewById(hotelReviewId);
            _DbContext.HotelReviews.Remove(hr);
            int count = _DbContext.SaveChanges();
            return count > 0 ? true : false;
        }

        public HotelReview GetHotelReviewById(int hotelReviewId)
        {
            HotelReview? hr = _DbContext.HotelReviews.Find(hotelReviewId);
            return hr;
        }

        //updating HotelReview
        public bool ModifyHotelReview(HotelReview hotelReview, int hotelReviewId)
        {
            HotelReview? hr = _DbContext.HotelReviews.Find(hotelReviewId);
            hr.HotelRating = hotelReview.HotelRating;
            hr.HotelComment = hotelReview.HotelComment;
            hr.HotelId = hotelReview.HotelId;
            hr.UserId = hotelReview.UserId;
            int count = _DbContext.SaveChanges();
            return count > 0 ? true : false;
        }

        public List<HotelReview> GetAllReviewByHotelId(int hotelId)
        {
            IEnumerable<HotelReview> listHotelReviews = _DbContext.HotelReviews.ToList();

            return listHotelReviews.Where(r => r.HotelId == hotelId).ToList();
        }

        public List<HotelReview> GetAllReviewByUserId(int userId)
        {
            return _DbContext.HotelReviews.ToList().Where(r => r.UserId == userId).ToList();
        }
    }
}
