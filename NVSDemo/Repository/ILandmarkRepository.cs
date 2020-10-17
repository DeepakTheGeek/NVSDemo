using NVSDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVSDemo.Repository
{
    public interface ILandmarkRepository
    {
        public Task<Landmark> SaveLandMark(Landmark landmark);
        public Task<Landmark> GetLandMark(int landmarkId);
        public Task<List<Landmark>> GetLandMarks();
        public Task<bool> IsLandmarkExists(Landmark landmark);


    }
}
