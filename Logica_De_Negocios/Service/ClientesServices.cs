using Clientes_Modulo.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica_De_Negocios.Service
{
    public class ClientesServices : IService.IClientesServices
    {
        Datos.DAO.ClientesDAO _dao;
        public ClientesServices() 
        {
            _dao = new Datos.DAO.ClientesDAO();
        }
        public bool create(Clientes cliente)
        {
            return _dao.Save(cliente);
        }

        public bool delete(Clientes cliente)
        {
            return _dao.delete(cliente);
        }

        public IEnumerable<Clientes> getAll()
        {
            return _dao.getAll();
        }

        public Clientes getById(int id)
        {
            return _dao.GetById(id);
        }

        public bool update(Clientes cliente)
        {
            return _dao.update(cliente);
        }
    }
}
