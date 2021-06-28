using RestWith.NET5.Model;
using System.Collections.Generic;

namespace RestWith.NET5.Repository
{
    public interface IClienteRepository
    {
        Cliente Create(Cliente cliente);
        Cliente FindByID(long id);
        List<Cliente> FindAll();
        Cliente Update(Cliente cliente);
        void Delete(long id);
        bool Exists(long id);
    }
}
