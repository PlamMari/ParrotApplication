using ParrotsApplication.Data;
using ParrotsApplication.Exceptions;
using ParrotsApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParrotsApplication.Repositories
{
    public class SpeciesRepository : ISpeciesRepository
    {
        private readonly ApplicationContext context;
        public SpeciesRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public List<Species> Get()
        {
            var species = this.context.Species
                .Include(spec => spec.Parrots).ToList();
            return species;
        }
        public Species Get(int id) {
            var species = this.context.Species.Where(species =>species.Id == id).FirstOrDefault();
            return species ?? throw new EntityNotFoundException();
        }
    }
}
