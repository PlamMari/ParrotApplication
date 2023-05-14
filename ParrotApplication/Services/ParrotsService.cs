using ParrotsApplication.Exceptions;
using ParrotsApplication.Models;
using ParrotsApplication.Repositories;
using System;
using System.Collections.Generic;

namespace ParrotsApplication.Services
{
    public class ParrotsService : IParrotsService
    {
        private const string Modify_parrot_error_message = "Only admins can update or delete a parrot.";
        private readonly IParrotsRepository repository;
       

        public ParrotsService(IParrotsRepository repository)
        {
            this.repository = repository;
        }

        public Parrot Create(Parrot parrot)        {
            
            ParrotQueryParameters parrotQueryParameters = new ParrotQueryParameters();
            parrotQueryParameters.Name = parrot.Name;            
            bool duplicateExists = this.repository.CountParrots(parrotQueryParameters)>0;            
            if (duplicateExists)
            {
                throw new DuplicateEntityException();
            }
            var createdParrot = this.repository.Create(parrot);
            return createdParrot;
        }

        public void Delete(int id/*, User user*/) {
           /* if (!user.IsAdmin)
            {
                throw new UnauthorizedAccessException(Modify_parrot_error_message);
            }*/
            this.repository.Delete(id);
        }

        public List<Parrot> Get()
        {
            return this.repository.Get();
        }

        public List<Parrot> Get(ParrotQueryParameters filterParameters)
        {
            return this.repository.Get(filterParameters);
        }

        public Parrot Get(int id)
        {
            return this.repository.Get(id);
        }

        public Parrot Update(int id, Parrot parrot/*, User user*/)
        {
            /*if (!user.IsAdmin)
            {
                throw new UnauthorizedAccessException(Modify_parrot_error_message);
            }*/
            this.repository.Get(parrot.Id);
            var updatedParrot = this.repository.Update(id, parrot);
            return updatedParrot;
        }
    }
}
