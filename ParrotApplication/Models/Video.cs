using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeersApplication.Models
{
    public class Video
    {
        public int Id { get; set; }
        public int ParrotId { get; set; }
        public Parrot Parrot { get; set; }
        public string Value { get; set; }
    }
}
