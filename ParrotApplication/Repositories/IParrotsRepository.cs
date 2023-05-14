using ParrotsApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParrotsApplication.Repositories
{
    public interface IParrotsRepository
    {
        List<Parrot> Get();
        Parrot Get(int id);
        List<Parrot> Get(ParrotQueryParameters filterParameters);
        Parrot Get(string name);
        Parrot Create(Parrot parrot);
        Parrot Update(int id, Parrot parrot);
        Parrot Delete(int id);
        int CountParrots(ParrotQueryParameters filterParameters);
    }
}
