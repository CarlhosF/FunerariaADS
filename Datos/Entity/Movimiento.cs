using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovimientosModulo.CLS
{
    public class Movimiento
    {
        int _idMovimiento;
        int _idVendedor;
        int _idContrato;
        String _Concepto;
        float _Abono;
        DateTime _fecha = new DateTime();
        public int idMovimiento { get => _idMovimiento; set => _idMovimiento = value; }
        public int idVendedor { get => _idVendedor; set => _idVendedor = value; }
        public int idContrato { get => _idContrato; set => _idContrato = value; }
        public String Concepto { get => _Concepto; set => _Concepto = value; }
        public float Abono { get => _Abono; set => _Abono = value; }
        public DateTime fecha { get => _fecha; set => _fecha = value; }


    }
}
