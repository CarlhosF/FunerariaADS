using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empleados_Modulo.CLS;
namespace Datos.IDAO
{
    public interface IEmpleadoDAO
    {
        IEnumerable<Empleados> getAll();
        bool Save(Empleados empleado);
        Empleados GetById(int id);
        bool update(Empleados empleado);
        bool delete(Empleados empleado);
    }
}
