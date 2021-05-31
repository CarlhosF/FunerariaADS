using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicios_Modulos.CLS
{
    public class Servicio
    {
        int _idservicios;
        String _nombre;
        float _valorcontado;
        float _valorcuota;
        String _descripcion;
        float _prima;

        public int Idservicios { get => _idservicios; set => _idservicios = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public float Valorcontado { get => _valorcontado; set => _valorcontado = value; }
        public float Valorcuota { get => _valorcuota; set => _valorcuota = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public float Prima { get => _prima; set => _prima = value; }

    }
}
