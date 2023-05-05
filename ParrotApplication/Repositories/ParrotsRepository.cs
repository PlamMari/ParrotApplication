using BeersApplication.Data;
using BeersApplication.Exceptions;
using BeersApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeersApplication.Repositories
{
    public class ParrotsRepository : IParrotsRepository
    {
        private readonly ApplicationContext context;

        public ParrotsRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public Parrot Create(Parrot parrot)
        {
            var createdParrot = this.context.Parrots.Add(parrot);
            this.context.SaveChanges();
            return createdParrot.Entity;
        }
        public Parrot Delete(int id)
        {
            var parrotToDelete = this.Get(id);
            this.context.Parrots.Remove(parrotToDelete);
            this.context.SaveChanges();
            return parrotToDelete;
        }
        public List<Parrot> Get()
        {
            return this.context.Parrots
                .Include(parrot => parrot.Species)
                .Include(parrot => parrot.Videos)
                .ToList();
        }
        public Parrot Get(int id)
        {
            var parrot = this.Get().Where(b => b.Id == id).FirstOrDefault();
            return parrot ?? throw new EntityNotFoundException();
        }

        public List<Parrot> Get(ParrotQueryParameters filterParameters)
        {
            string name = !string.IsNullOrEmpty(filterParameters.Name) ? filterParameters.Name.ToLowerInvariant() : string.Empty;
            // load related data in order to work
            string species = !string.IsNullOrEmpty(filterParameters.Species) ? filterParameters.Species.ToLowerInvariant() : string.Empty;
            string sortCriteria = !string.IsNullOrEmpty(filterParameters.SortBy) ? filterParameters.SortBy.ToLowerInvariant() : string.Empty;
            string sortOrder = !string.IsNullOrEmpty(filterParameters.SortOrder) ? filterParameters.SortOrder.ToLowerInvariant() : string.Empty;

            IEnumerable<Parrot> result = this.Get();
            result = FilterByName(result, name);
            result = FilterBySpecies(result, species);
            result = SortBy(result, sortCriteria);
            result = Order(result, sortOrder);
            return result.ToList();
        }

        public Parrot Get(string name) {
            var parrot = this.context.Parrots.Where(b => b.Name == name).FirstOrDefault();
            return parrot ?? throw new EntityNotFoundException();
        }
        public Parrot Update(int id, Parrot parrot) {
            var parrotToUpdate = this.Get(id);
            parrotToUpdate.Name = parrot.Name;
            parrotToUpdate.Species = parrot.Species;
            parrotToUpdate.Size = parrot.Size;            
            parrotToUpdate.NoiseLevel= parrot.NoiseLevel;
            
            this.context.SaveChanges();
            return parrotToUpdate;
        }
        private static IEnumerable<Parrot> FilterByName(IEnumerable<Parrot> result, string name)
        {
            return result.Where(parrot => parrot.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        }
        public int CountParrots(ParrotQueryParameters filterParameters)
        {
            string name = !string.IsNullOrEmpty(filterParameters.Name) ? filterParameters.Name.ToLowerInvariant() : string.Empty;
            int count = this.context.Parrots.Count(predicate=> predicate.Name == name);
            return count;
        }

        private static IEnumerable<Parrot> FilterBySpecies(IEnumerable<Parrot> result, string species)
        {
            return result.Where(parrot => parrot.Species.Name.Contains(species, StringComparison.InvariantCultureIgnoreCase));
        }
        
        private static IEnumerable<Parrot> SortBy(IEnumerable<Parrot> result, string sortCriteria)
        {
            switch (sortCriteria)
            {
                case "name":
                    return result.OrderBy(parrot => parrot.Name);
                case "noiselevel":
                    return result.OrderBy(parrot => parrot.NoiseLevel);
                case "size":
                    return result.OrderBy(parrot => parrot.Size);
                case "species":
                    return result.OrderBy(parrot => parrot.Species.Name);
                default:
                    return result;
            }
        }
        private static IEnumerable<Parrot> Order(IEnumerable<Parrot> result, string sortOrder)
        {
            return (sortOrder == "desc") ? result.Reverse() : result;
        }        
    }
}
