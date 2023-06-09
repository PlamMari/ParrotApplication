﻿using ParrotsApplication.Models;
using System.Collections.Generic;

namespace ParrotsApplication.Services
{
    public interface ISpeciesService
    {
        List<Species> Get();
        Species Get(int id);
    }
}
