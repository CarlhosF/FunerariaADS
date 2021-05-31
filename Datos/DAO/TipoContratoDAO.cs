using Servicios_Modulos.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Datos.DAO
{
    public class TipoContratoDAO : IDAO.ITipoContratoDAO
    {
        public bool delete(TipoContrato Tcontrato)
        {
            Boolean Resultado = false;
            String Sentencia = @"DELETE FROM tipodecontrato WHERE idTipoDeContrato = " + Tcontrato.IdTipoDeContrato + ";";
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

        public IEnumerable<TipoContrato> getAll()
        {

            MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;
            String connString = "Server=127.0.0.1;Database=funerariabd;Uid=usuario;Pwd=contra;";
            mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connString);

            List<TipoContrato> items = new List<TipoContrato>();
            mySqlConnection.Open();
            queryStr = "SELECT * FROM tipodecontrato";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, mySqlConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TipoContrato item = new TipoContrato();
                item.IdTipoDeContrato = (int)reader["idtipocontrato"];
                item.Nombre = reader["Nombre"].ToString();
                item.Descripcion =reader["descripcion"].ToString();
                item.factor = (int)reader["factor"];
                item.tratamientos = (int)reader["tratamiento"];
                items.Add(item);
            }

            mySqlConnection.Close();

            return items;
        }

        public TipoContrato GetById(int id)
        {
            MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;
            String connString = "Server=127.0.0.1;Database=funerariabd;Uid=usuario;Pwd=contra;";
            mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connString);
            TipoContrato item = new TipoContrato();
            
            mySqlConnection.Open();
            queryStr = "SELECT * FROM tipodecontrato where idtipocontrato="+id;
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, mySqlConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               
                item.IdTipoDeContrato = (int)reader["idtipocontrato"];
                item.Nombre = reader["Nombre"].ToString();
                item.Descripcion = reader["descripcion"].ToString();
                item.factor = (int)reader["factor"];
                item.tratamientos = (int)reader["tratamiento"];
                
            }

            mySqlConnection.Close();

            return item;
        }

        public bool Save(TipoContrato Tcontrato)
        {
            Boolean Resultado = false;
            String Sentencia = @"INSERT INTO tipodecontrato(nombre,Descripcion,factor,tratamiento) 
            VALUES('" + Tcontrato.Nombre + "','" + Tcontrato.Descripcion + "', " + Tcontrato.factor + "," + Tcontrato.tratamientos + " ); ";
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

        public bool update(TipoContrato Tcontrato)
        {
            Boolean Resultado = false;
            String Sentencia = @"UPDATE tipodecontrato SET nombre=' " + Tcontrato.Nombre + " ' , Descripcion=' " + Tcontrato.Descripcion + " ' " + ",factor=" + Tcontrato.factor + "" +"tratamiento="+Tcontrato.tratamientos+""+
                               "WHERE idTipoDeContrato = " + Tcontrato.IdTipoDeContrato + ";";
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
