using RestWith.NET5.Model;
using RestWith.NET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

// Classe responsável por executar as ações 
namespace RestWith.NET5.Repository.Implementations
{
    public class ClienteRepositoryImplementation : IClienteRepository
    {
        private readonly MySQLContext _context;
        
        public ClienteRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public List<Cliente> FindAll()
        {
            return _context.Clientes.ToList();
        }

        public Cliente FindByID(long id)
        {
            return _context.Clientes.SingleOrDefault(p => p.Id == id);
        }

        public Cliente Create(Cliente cliente)
        {
            try
            {
                _context.Add(cliente);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return cliente;
        }

        public Cliente Update(Cliente cliente)
        {
            // Se a pessoa NÃO existir no banco de dados, retornamos NULO
            if (!Exists(cliente.Id)) return null;

            var result = _context.Clientes.SingleOrDefault(p => p.Id == cliente.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(cliente);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return cliente;
        }

        public void Delete(long id)
        {
            var result = _context.Clientes.SingleOrDefault(p => p.Id == id);

            if (result != null)
            {
                try
                {
                    _context.Clientes.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
   
        public bool Exists(long id)
        {
            return _context.Clientes.Any(p => p.Id == id);
        }
    }
}

