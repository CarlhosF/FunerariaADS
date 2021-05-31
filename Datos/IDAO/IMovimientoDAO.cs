using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovimientosModulo.CLS;
namespace Datos.IDAO
{
    public interface IMovimientoDAO
    {
        IEnumerable<Movimiento> getAll();
        IEnumerable<Movimiento> getAllWithAcount(int id);
        bool Save(Movimiento movimiento);
        Movimiento GetById(int id);
        bool update(Movimiento movimiento);
        bool delete(Movimiento movimiento);
    }
}
