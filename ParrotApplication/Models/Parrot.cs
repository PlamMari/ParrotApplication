using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ParrotsApplication.Models
{
    public class Parrot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }

        public double NoiseLevel { get; set; }

        public List<Video> Videos { get; set; } = new List<Video>();

        [JsonIgnore]
        public int SpeciesId { get; set; }

        public Species Species { get; set; }
                
    }
}
