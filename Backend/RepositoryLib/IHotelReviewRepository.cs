using EntityModelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public interface IHotelReviewRepository
    {
        bool AddHotelReview(HotelReview hotelReview);

        bool ModifyHotelReview(HotelReview hotelReview, int hotelReviewId);

        bool DeleteHotelReviewById(int hotelReviewId);

        List<HotelReview> GetAllReviewByHotelId(int hotelId);

        List<HotelReview> GetAllReviewByUserId(int userId);
    }
}
