using EntityModelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public class AmenityRepository : IAmenityRepository
    {
        public ProjectDbContext dbContext;

        public AmenityRepository()
        {
            dbContext = new ProjectDbContext();
        }

        public bool AddAmenity(Amenities amenity)
        {
            dbContext.Amenitiess.Add(amenity);
            int count = dbContext.SaveChanges();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteAmenity(int AmenityId)
        {
            Amenities amenitiyToBeDeleted = dbContext.Amenitiess.Find(AmenityId);
            dbContext.Amenitiess.Remove(amenitiyToBeDeleted);
            int count = dbContext.SaveChanges();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Amenities> GetAllAmenities()
        {
            return dbContext.Amenitiess.ToList();
        }

        public bool UpdateAmenity(int AmenityId, Amenities updatedAmenity)
        {
            Amenities? amenityToBeUpdated = dbContext.Amenitiess.Find(AmenityId);
            amenityToBeUpdated.AmenityDesc = updatedAmenity.AmenityDesc;
            int count = dbContext.SaveChanges();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
