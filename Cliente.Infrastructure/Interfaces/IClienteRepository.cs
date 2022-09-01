using Cliente.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Infrastructure.Interfaces
{
    public interface IClienteRepository
    {
        public IEnumerable<ClienteModel> GetAll();

        public ClienteModel Get(int id);
        public void Add(ClienteModel model);
        public void Update(ClienteModel model);
        public void Delete(int id);
    }
}
