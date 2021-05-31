using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManager;


namespace Clientes_Modulo.CLS
{
    public class Clientes
    {
        int _idclientes;
        String _nombres;
        String _apellidos;
        String _dui;
        String _direccion;
        DateTime _fechanacimiento;
        String _telefono;
        String _oficio;

        public int Idclientes
        {
            get
            {
                return _idclientes;
            }

            set
            {
                _idclientes = value;
            }
        }

        public string Nombres
        {
            get
            {
                return _nombres;
            }

            set
            {
                _nombres = value;
            }
        }

        public string Apellidos
        {
            get
            {
                return _apellidos;
            }

            set
            {
                _apellidos = value;
            }
        }

        public string Dui
        {
            get
            {
                return _dui;
            }

            set
            {
                _dui = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                _direccion = value;
            }
        }

        public DateTime Fechanacimiento
        {
            get
            {
                return _fechanacimiento;
            }

            set
            {
                _fechanacimiento = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                _telefono = value;
            }
        }

        public string Oficio
        {
            get
            {
                return _oficio;
            }

            set
            {
                _oficio = value;
            }
        }

    }
}
