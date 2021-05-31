using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clientes_Modulo.CLS;
namespace Logica_De_Negocios.IService
{
    public interface IClientesServices
    {
        IEnumerable<Clientes> getAll();

        bool create(Clientes cliente);

        Clientes getById(int id);

        bool update(Clientes cliente);

        bool delete(Clientes cliente);
    }
}
