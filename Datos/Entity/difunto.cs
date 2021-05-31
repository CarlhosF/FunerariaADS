using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasModulo.CLS
{
    public class difunto
    {
        int _iddifunto;
        int _idcontrato;
        String _nombres;
        String _apellidos;
        String _direccionDeToma;
        String _direccionDeEntrega;
        DateTime _fechanacimiento;
        DateTime _fechanMuerte;
        String _CausaMuerte;
        public int iddifunto { get => _iddifunto; set => _iddifunto = value; }
        public int idcontrato { get => _idcontrato; set => _idcontrato = value; }
        public string nombres { get => _nombres; set => _nombres = value; }
        public string apellidos { get => _apellidos; set => _apellidos = value; }
        public string direccionDeToma { get => _direccionDeToma; set => _direccionDeToma = value; }
        public string direccionDeEntrega { get => _direccionDeEntrega; set => _direccionDeEntrega = value; }
        public string CausaMuerte { get => _CausaMuerte; set => _CausaMuerte = value; }
        public DateTime fechanacimiento { get => _fechanacimiento; set => _fechanacimiento = value; }
        public DateTime fechanMuerte { get => _fechanMuerte; set => _fechanMuerte = value; }
    
    
    


    }
}
