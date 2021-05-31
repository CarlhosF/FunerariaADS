using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empleados_Modulo.CLS;
namespace Datos.IDAO
{
    public interface IPuestoDAO
    {
        IEnumerable<Puesto> getAll();
        bool Save(Puesto puesto);
        Puesto GetById(int id);
        bool update(Puesto puesto);
        bool delete(Puesto puesto);
    }
}
