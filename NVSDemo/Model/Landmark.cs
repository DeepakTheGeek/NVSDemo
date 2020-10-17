using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NVSDemo.Model
{
    public class Landmark
    {
        public int Id { get; set; }
        [Required]
        public string LandmarkName { get; set; }
        [Required]
        public string Address { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public bool IsActive { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
