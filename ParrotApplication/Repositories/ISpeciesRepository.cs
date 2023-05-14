using ParrotsApplication.Models;
using System.Collections.Generic;

namespace ParrotsApplication.Repositories
{
    public interface ISpeciesRepository
    {
        List<Species> Get();
        Species Get(int id);
    }
}
