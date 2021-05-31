using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosModulo.CLS;
namespace Datos.IDAO
{
    public interface IUsuarioDAO
    {   
        IEnumerable<Usuario> getAll();
        bool Save(Usuario usuario);
        Usuario GetById(int id);
        bool update(Usuario usuario);
        bool delete(Usuario usuario);
    }
}
