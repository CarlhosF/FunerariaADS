using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios_Modulos.CLS;
namespace Datos.IDAO
{
    public interface ITipoContratoDAO
    {
        IEnumerable<TipoContrato> getAll();
        bool Save(TipoContrato Tcontrato);
        TipoContrato GetById(int id);
        bool update(TipoContrato Tcontrato);
        bool delete(TipoContrato Tcontrato);
    }
}
