using BeersApplication.Models;
using System.Collections.Generic;

namespace BeersApplication.Services
{
    public interface IParrotsService
    {
        List<Parrot> Get();
        List<Parrot> Get(ParrotQueryParameters filterParameters);
        Parrot Get(int id);
        Parrot Create(Parrot parrot);
        Parrot Update(int id, Parrot parrot/*, User user*/);
        void Delete(int id/*, User user*/);
    }
}
