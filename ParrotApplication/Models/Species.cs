using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ParrotsApplication.Models
{
    public class Species
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Parrot> Parrots { get; set; }
    }
}
