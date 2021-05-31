using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntregasModulo.CLS;
namespace Datos.IDAO
{
    interface IDifuntoDAO
    {
        IEnumerable<difunto> getAll();
        IEnumerable<difunto> getAllWithAcount(int id);
        bool Save(difunto entrega);
        difunto GetById(int id);
        bool update(difunto entrega);
        bool delete(difunto entrega);
    }
}
