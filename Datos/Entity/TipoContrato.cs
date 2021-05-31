using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Servicios_Modulos.CLS
{
    public class TipoContrato
    {
        int _idTipoDeContrato;
        String _nombre;
        String _Descripcion;
        float _factor;
        int _tratamientos;
        public int IdTipoDeContrato { get => _idTipoDeContrato; set => _idTipoDeContrato = value; }
        public float factor { get => _factor; set => _factor = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public int tratamientos { get => _tratamientos; set => _tratamientos = value; }
        
    }
}
