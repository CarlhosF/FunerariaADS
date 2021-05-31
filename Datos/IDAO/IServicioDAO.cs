using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios_Modulos.CLS;

namespace Datos.IDAO
{
    public interface IServicioDAO
    {
        IEnumerable<Servicio> getAll();
        bool Save(Servicio servicio);
        Servicio GetById(int id);
        bool update(Servicio servicio);
        bool delete(Servicio servicio);
    }
}
