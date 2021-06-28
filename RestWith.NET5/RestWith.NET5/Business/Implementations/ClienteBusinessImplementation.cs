using RestWith.NET5.Model;
using RestWith.NET5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWith.NET5.Business.Implementations
{
    public class ClienteBusinessImplementation : IClienteBusiness
    {
        private readonly IClienteRepository _repository;

        public ClienteBusinessImplementation(IClienteRepository repository)
        {
            _repository = repository;
        }

        public Cliente Create(Cliente cliente)
        {
            return _repository.Create(cliente);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Cliente> FindAll()
        {
            return _repository.FindAll();
        }

        public Cliente FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Cliente Update(Cliente cliente)
        {
            return _repository.Update(cliente);
        }
    }
}
