using Clientes_Modulo.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Datos.DAO
{
    public class ClientesDAO : IDAO.IClienteDAO
    {
        public bool delete(Clientes cliente)
        {
            Boolean Resultado = false;
            String Sentencia = @"DELETE FROM clientes WHERE idclientes = " + cliente.Idclientes + ";";
            try
            {
                DataManager.CLS.OperacionBD Operacion = new DataManager.CLS.OperacionBD();
                if (Operacion.Eliminar(Sentencia) > 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch
            {
                Resultado = false;
            }
            return Resultado;
        }

        public IEnumerable<Clientes> getAll()
        {
            MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;
            String connString = "Server=127.0.0.1;Database=funerariabd;Uid=usuario;Pwd=contra;";
            mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connString);
            
            List<Clientes> items= new List<Clientes>();
            mySqlConnection.Open();
            queryStr = "SELECT * FROM clientes";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, mySqlConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Clientes item = new Clientes();
                item.Idclientes=(int)reader["idclientes"];
                item.Nombres=reader["Nombres"].ToString();
                item.Apellidos= reader["Apellidos"].ToString();
                item.Direccion = reader["Direccion"].ToString();
                item.Dui=reader["dui"].ToString();
                item.Fechanacimiento=DateTime.Parse(reader["fechanacimiento"].ToString());
                item.Telefono=reader["telefono"].ToString();
                item.Oficio=reader["oficio"].ToString();
                items.Add(item);
            }

            mySqlConnection.Close();

            return items;
        }

        public Clientes GetById(int id)
        {
            MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;
            String connString = "Server=127.0.0.1;Database=funerariabd;Uid=usuario;Pwd=contra;";
            mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connString);
            Clientes item = new Clientes();
           
            mySqlConnection.Open();
            queryStr = "SELECT * FROM clientes where idclientes="+id;
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, mySqlConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                item.Idclientes = (int)reader["idclientes"];
                item.Nombres = reader["Nombres"].ToString();
                item.Apellidos = reader["Apellidos"].ToString();
                item.Direccion = reader["Direccion"].ToString();
                item.Dui = reader["dui"].ToString();
                item.Fechanacimiento = DateTime.Parse(reader["fechanacimiento"].ToString());
                item.Telefono = reader["telefono"].ToString();
                item.Oficio = reader["oficio"].ToString();
                
            }

            mySqlConnection.Close();

            return item;
        }

        public bool Save(Clientes clientes)
        {
            Boolean Resultado = false;
            String Sentencia = @"INSERT INTO clientes(nombres,apellidos,dui,direccion,fechanacimiento,telefono,oficio) 
            VALUES(' " + clientes.Nombres + " ',' " + clientes.Apellidos + " ',' " + clientes.Dui + " ',' " + clientes.Direccion + " ',' " + clientes.Fechanacimiento.ToString("yyyy/MM/dd") + " ',' " + clientes.Telefono + " ',' " + clientes.Oficio + " '); ";
            Console.WriteLine(Sentencia);
            try
            {
                DataManager.CLS.OperacionBD Operacion = new DataManager.CLS.OperacionBD();
                if (Operacion.Insertar(Sentencia) > 0)
                {
                    Resultado = true;

                }
                else
                {
                    Resultado = false;
                }
            }
            catch
            {
                Resultado = false;
            }

            return Resultado;
        }

        public bool update(Clientes cliente)
        {
            Boolean Resultado = false;
            String Sentencia = @"UPDATE clientes SET nombres=' " + cliente.Nombres + " ' , apellidos=' " + cliente.Apellidos + " ' , dui=' " + cliente.Dui + " ' , direccion=' " + cliente.Direccion + " ' , fechanacimiento=' " + cliente.Fechanacimiento.ToString("yyyy/MM/dd") + " ' , telefono=' " + cliente.Telefono + " ' , oficio=' " + cliente.Oficio + " ' " +
                               "WHERE idclientes = " + cliente.Idclientes + ";";
            Console.WriteLine(Sentencia);
            try
            {
                DataManager.CLS.OperacionBD Operacion = new DataManager.CLS.OperacionBD();
                if (Operacion.Actualizar(Sentencia) > 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch
            {
                Resultado = false;
            }
            return Resultado;
        }
    }
}
