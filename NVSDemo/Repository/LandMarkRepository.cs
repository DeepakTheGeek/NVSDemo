using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NVSDemo.Data;
using NVSDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace NVSDemo.Repository
{
    public class LandMarkRepository : ILandmarkRepository
    {
        private readonly NVSContext _context;

        public LandMarkRepository(NVSContext context)
        {
            _context = context;
        }
        public async Task<Landmark> SaveLandMark(Landmark landmark)
        {
            if (landmark.Id == 0)
            {
                _context.Landmarks.Add(landmark);
            }
            else
            {
                var landMarkFromRepo = await _context.Landmarks.FindAsync(landmark.Id);
                if (landMarkFromRepo == null) return null;

                landMarkFromRepo.IsActive = landmark.IsActive;
                landMarkFromRepo.Address = landmark.Address;
                landMarkFromRepo.LandmarkName = landmark.LandmarkName;
                landMarkFromRepo.Latitude = landmark.Latitude;
                landMarkFromRepo.Longitude = landmark.Longitude;
                landMarkFromRepo.ShortDescription = landmark.ShortDescription;
                landMarkFromRepo.Description = landmark.Description;
            }
            await _context.SaveChangesAsync();
            return landmark;
        }

        public async Task<bool> IsLandmarkExists(Landmark landmark)
        {
            return await _context.Landmarks
                .AnyAsync(l => 
                l.LandmarkName == landmark.LandmarkName 
                || l.Address == landmark.Address
                || (l.Latitude == landmark.Latitude && l.Longitude == landmark.Longitude));
        }

        public async Task<Landmark> GetLandMark(int landmarkId)
        {
            return await _context.Landmarks.SingleOrDefaultAsync(l => l.Id == landmarkId);
        }

        public async Task<List<Landmark>> GetLandMarks()
        {
            return await _context.Landmarks.ToListAsync();
        }
    }
}
