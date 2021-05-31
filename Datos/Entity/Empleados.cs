using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManager;
namespace Empleados_Modulo.CLS
{
    public class Empleados
    {
        int _idEmpleado;
        string _Nombre;
        string _Apellido;
        DateTime _dt = new DateTime().ToUniversalTime();
        string _telefono;
        string _direccion;
        string _DUI;
        string _fechaNacimiento;
        DateTime _fechaContratacion = new DateTime().ToUniversalTime();
        int _idpuesto;
        Puesto _puesto;
        public DateTime dt 
        {
            get 
            {
                return _dt;
            }
            set 
            {
                _dt = value;
            }
        }
        public DateTime fechaContratacion
        {
            get
            {
                return _fechaContratacion;
            }
            set
            {
                _fechaContratacion = value;
            }
        }
        public int idEmpleado 
        {
            get 
            {
                return _idEmpleado;
            }
            set 
            {
                _idEmpleado = value;
            }
        
        }
        public int idpuesto
        {
            get
            {
                return _idpuesto;
            }
            set
            {
                _idpuesto = value;
            }

        }
        public Puesto puesto
        {
            get
            {
                return _puesto;
            }
            set
            {
                _puesto = value;
            }

        }
        public string Nombre 
        {
            get 
            {
                return _Nombre;
            }
            set 
            {
                _Nombre = value;
            }
        }
        public string DUI
        {
            get
            {
                return _DUI;
            }
            set
            {
                _DUI = value;
            }
        }
        public string Apellido 
        {
            get 
            {
                return _Apellido;
            }
            set 
            {
                _Apellido = value;
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


    }
}
