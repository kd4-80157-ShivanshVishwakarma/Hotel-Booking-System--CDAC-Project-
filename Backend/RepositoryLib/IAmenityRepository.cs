using EntityModelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public interface IAmenityRepository
    {
        bool AddAmenity(Amenities amenity);
        bool DeleteAmenity(int AmenityId);
        bool UpdateAmenity(int AmenityId, Amenities amenity);
        IEnumerable<Amenities> GetAllAmenities();
    }
}
