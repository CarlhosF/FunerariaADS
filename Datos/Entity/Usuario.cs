using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosModulo.CLS
{
    public class Usuario
    {
        int _idusuario;
        String _usuario;
        String _clave;
        String _rol;
        int _idempleado;
        public string usuario 
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public string clave
        {
            get { return _clave; }
            set { _clave = value; }
        }
        public int idusuario 
        {
            get { return _idusuario; }
            set { _idusuario = value; }
        }
        public int idempleado
        {
            get { return _idempleado; }
            set { _idempleado = value; }
        }
        public String rol
        {
            get { return _rol; }
            set { _rol = value; }
        }

    }
}
