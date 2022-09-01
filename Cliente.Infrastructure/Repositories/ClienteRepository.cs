using Cliente.Domain.Model;
using Cliente.Infrastructure.Interfaces;
using System.Linq;

namespace Cliente.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private static List<ClienteModel> dbCliente = new List<ClienteModel>();

        public IEnumerable<ClienteModel> GetAll()
        {
            return dbCliente;
        }

        public ClienteModel Get(int id)
        {
            return dbCliente.FirstOrDefault(x => x.Id == id);
        }

        public void Add(ClienteModel model)
        {
            dbCliente.Add(model);
        }

        public void Update(ClienteModel model)
        {
            var cliente = dbCliente.FirstOrDefault(x => x.Id == model.Id);
            if (cliente != null)
            {
                dbCliente.Remove(cliente);
                dbCliente.Add(model);
            }
        }

        public void Delete(int id)
        {
            var cliente = dbCliente.FirstOrDefault(x => x.Id == id);
            if (cliente != null)
            {
                dbCliente.Remove(cliente);
            }
        }
    }
}
