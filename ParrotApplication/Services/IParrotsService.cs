using ParrotsApplication.Models;
using System.Collections.Generic;

namespace ParrotsApplication.Services
{
    public interface IParrotsService
    {
        List<Parrot> Get();
        List<Parrot> Get(ParrotQueryParameters filterParameters);
        Parrot Get(int id);
        Parrot Create(Parrot parrot);
        Parrot Update(int id, Parrot parrot);
        void Delete(int id);
    }
}
