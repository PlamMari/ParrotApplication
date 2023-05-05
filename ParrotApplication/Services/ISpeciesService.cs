using BeersApplication.Models;
using System.Collections.Generic;

namespace BeersApplication.Services
{
    public interface ISpeciesService
    {
        List<Species> Get();
        Species Get(int id);
    }
}
