using Servicios_Modulos.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Datos.DAO
{
    public class ServiciosDAO : IDAO.IServicioDAO
    {
        public bool delete(Servicio servicio)
        {
            Boolean Resultado = false;
            String Sentencia = @"DELETE FROM servicios WHERE idservicios = " + servicio.Idservicios + ";";
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

        public IEnumerable<Servicio> getAll()
        {
            MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;
            String connString = "Server=127.0.0.1;Database=funerariabd;Uid=usuario;Pwd=contra;";
            mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connString);

            List<Servicio> items = new List<Servicio>();
            mySqlConnection.Open();
            queryStr = "SELECT * FROM servicios";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, mySqlConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Servicio item = new Servicio();
                item.Idservicios = (int)reader["idservicios"];
                item.Nombre = reader["Nombre"].ToString();
                item.Valorcuota = (int)reader["valorcuota"];
                item.Valorcontado =(int) reader["valorcontado"];
                item.Descripcion = reader["descripcion"].ToString();
                item.Prima =(int)reader["prima"];
                items.Add(item);
            }

            mySqlConnection.Close();

            return items;
        }

        public Servicio GetById(int id)
        {
            MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;
            String connString = "Server=127.0.0.1;Database=funerariabd;Uid=usuario;Pwd=contra;";
            mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connString);
            Servicio item = new Servicio();
            
            mySqlConnection.Open();
            queryStr = "SELECT * FROM servicios where idservicios="+id;
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, mySqlConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                item.Idservicios = (int)reader["idservicios"];
                item.Nombre = reader["Nombre"].ToString();
                item.Valorcuota = (int)reader["valorcuota"];
                item.Valorcontado = (int)reader["valorcontado"];
                item.Descripcion = reader["descripcion"].ToString();
                item.Prima = (int)reader["prima"];
                
            }

            mySqlConnection.Close();

            return item;
        }

        public bool Save(Servicio servicio)
        {
            Boolean Resultado = false;
            String Sentencia = @"INSERT INTO servicios(nombre,valorcontado,valorcuota,descripcion,prima) 
            VALUES(' " + servicio.Nombre + " '," + servicio.Valorcontado + ", " + servicio.Valorcuota + " ,'" + servicio.Descripcion + "'," + servicio.Prima + " ); ";
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

        public bool update(Servicio servicio)
        {
            Boolean Resultado = false;
            String Sentencia = @"UPDATE servicios SET nombre=' " + servicio.Nombre + " ' , valorcontado=" + servicio.Valorcontado + ", valorcuota=" + servicio.Valorcuota + ", descripcion='" + servicio.Descripcion + "' , prima=" + servicio.Prima + "" +
                               "WHERE idservicios = " + servicio.Idservicios + ";";
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
