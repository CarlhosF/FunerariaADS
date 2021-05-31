using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clientes_Modulo.CLS;
namespace Datos.IDAO
{
    public interface IClienteDAO
    {
        IEnumerable<Clientes> getAll();
        bool Save(Clientes clientes);
        Clientes GetById(int id);
        bool update(Clientes cliente);
        bool delete(Clientes cliente);

    }
}
