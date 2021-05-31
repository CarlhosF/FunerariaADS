using Empleados_Modulo.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Datos.DAO
{
    public class PuestoDAO : IDAO.IPuestoDAO
    {
        public bool delete(Puesto puesto)
        {
            Boolean Resultado = false;
            String Sentencia = @"DELETE FROM puestos WHERE idpuestos = " + puesto.idpuesto + ";";
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

        public IEnumerable<Puesto> getAll()
        {
            MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;
            String connString = "Server=127.0.0.1;Database=funerariabd;Uid=usuario;Pwd=contra;";
            mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connString);

            List<Puesto> items = new List<Puesto>();
            mySqlConnection.Open();
            queryStr = "SELECT * FROM puestos";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, mySqlConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Puesto item = new Puesto();
                item.idpuesto = (int)reader["idpuesto"];
                item.Nombre = reader["Nombre"].ToString();
                item.Descripcion = reader["descripcion"].ToString();
                items.Add(item);
            }

            mySqlConnection.Close();

            return items;
        }

        public Puesto GetById(int id)
        {
            MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;
            String connString = "Server=127.0.0.1;Database=funerariabd;Uid=usuario;Pwd=contra;";
            mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connString);
            Puesto item = new Puesto();
            mySqlConnection.Open();
            queryStr = "SELECT * FROM puestos where idpuestos="+id;
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, mySqlConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                item.idpuesto = (int)reader["idpuesto"];
                item.Nombre = reader["Nombre"].ToString();
                item.Descripcion = reader["descripcion"].ToString();
                
            }

            mySqlConnection.Close();

            return item;
        }

        public bool Save(Puesto puesto)
        {
            Boolean Resultado = false;

            String Sentencia = @"INSERT INTO puestos(nombre,descripcion) VALUES(' " + puesto.Nombre + " ',' " + puesto.Descripcion + "');";
            Console.Write(Sentencia);

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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Resultado = false;
            }
            return Resultado;
        }

        public bool update(Puesto puesto)
        {
            Boolean Resultado = false;
            String Sentencia = @"UPDATE puestos SET nombre=' " + puesto.Nombre + " ' , descripcion=' " + puesto.Descripcion + "' WHERE idpuestos = " + puesto.idpuesto + ";";
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
