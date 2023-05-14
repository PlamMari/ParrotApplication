﻿using System.Collections.Generic;

namespace ParrotsApplication.Models
{
    public class Species
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Parrot> Parrots { get; set; }
    }
}
