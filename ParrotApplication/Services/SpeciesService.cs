using System.Collections.Generic;

using BeersApplication.Models;
using BeersApplication.Repositories;

namespace BeersApplication.Services
{
    public class SpeciesService : ISpeciesService
    {
        private readonly ISpeciesRepository repository;
        public SpeciesService(ISpeciesRepository repository) {
            this.repository = repository;
        }
        public List<Species> Get()
        {
            return this.repository.Get();
        }
        public Species Get(int id)
        {
            return this.repository.Get(id);
        }
        
    }
}
