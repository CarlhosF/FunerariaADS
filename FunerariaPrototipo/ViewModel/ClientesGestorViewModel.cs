using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica_De_Negocios.Service;
namespace FunerariaPrototipo.ViewModel
{
    public class ClientesGestorViewModel
    {
        ClientesServices clienteservice;
        public ClientesGestorViewModel() 
        {
            clienteservice = new ClientesServices();
        }
        public DataTable GetAll() 
        {
            return CLSConvert.ToDataTable<Clientes_Modulo.CLS.Clientes>((List<Clientes_Modulo.CLS.Clientes>)clienteservice.getAll());
        }
    }
}
