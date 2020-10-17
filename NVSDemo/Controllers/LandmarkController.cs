using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NVSDemo.Model;
using NVSDemo.Repository;

namespace NVSDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LandmarkController : ControllerBase
    {
        private readonly ILandmarkRepository _landMarkRepository;

        public LandmarkController(ILandmarkRepository landMarkRepository)
        {
            _landMarkRepository = landMarkRepository;
        }

        [HttpPost("SaveLandmark")]
        public async Task<ActionResult> SaveLandMark(Landmark landmark)
        {
            if (landmark.Id == 0)
            {
                if (await _landMarkRepository.IsLandmarkExists(landmark))
                    return BadRequest("This landmark already exists");
            }

            var savedLandmark = await _landMarkRepository.SaveLandMark(landmark);

            if (savedLandmark == null)
                return NotFound("Entered landmark does not exists");

            return Ok("Landmark Saved Successfully");
        }

        [HttpGet("GetLandMarks")]
        public async Task<ActionResult<Landmark>> GetLandMarks()
        {
            var landmarks = await _landMarkRepository.GetLandMarks();
            return Ok(landmarks);
        }
        [HttpGet("GetLandMarks/{id}")]
        public async Task<ActionResult<Landmark>> GetLandMarks(int id)
        {
            var landmark = await _landMarkRepository.GetLandMark(id);
            if (landmark == null) return NotFound("Requested landmark does not exists");
            return Ok(landmark);
        }
    }
}
