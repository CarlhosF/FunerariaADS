using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosModulo.CLS;
using MySql.Data.MySqlClient;
namespace Datos.DAO
{
    public class UsurioDAO : IDAO.IUsuarioDAO
    {
        public bool delete(Usuario usuario)
        {
            Boolean Resultado = false;
            String Sentencia = @"DELETE FROM usuarios WHERE idusuarios = " + usuario.idusuario + ";";
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

        public IEnumerable<Usuario> getAll()
        {
            MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;
            String connString = "Server=127.0.0.1;Database=funerariabd;Uid=usuario;Pwd=contra;";
            mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connString);

            List<Usuario> items = new List<Usuario>();
            mySqlConnection.Open();
            queryStr = "SELECT * FROM usuarios";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, mySqlConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Usuario item = new Usuario();
                item.idusuario = (int)reader["idusuarios"];
                item.usuario = reader["usuario"].ToString();
                item.clave = reader["clave"].ToString();
                item.rol = reader["rol"].ToString();
                item.idempleado = (int)reader["idempleados"];
               
                items.Add(item);
            }

            mySqlConnection.Close();

            return items;
        }

        public Usuario GetById(int id)
        {
            MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;
            String connString = "Server=127.0.0.1;Database=funerariabd;Uid=usuario;Pwd=contra;";
            mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connString);
            Usuario item = new Usuario();
            
            mySqlConnection.Open();
            queryStr = "SELECT * FROM usuarios where idusuarios="+id;
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, mySqlConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                item.idusuario = (int)reader["idusuarios"];
                item.usuario = reader["usuario"].ToString();
                item.clave = reader["clave"].ToString();
                item.rol = reader["rol"].ToString();
                item.idempleado = (int)reader["idempleados"];

                
            }

            mySqlConnection.Close();

            return item;
        }

        public bool Save(Usuario usuario)
        {
            Boolean Resultado = false;
            String Sentencia = @"INSERT INTO usuarios(usuario,clave,rol,idempleados) 
            VALUES('" + usuario.usuario + "','" + usuario.clave + "','" + usuario.rol + "','" + usuario.idempleado + "'); ";
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

        public bool update(Usuario usuario)
        {
            Boolean Resultado = false;
            String Sentencia = @"UPDATE usuarios SET  usuario='" + usuario.usuario + "',clave='" + usuario.clave + "', rol='" + usuario.rol + "', idempleados= " + usuario.idempleado + "  " +
                               "WHERE idusuarios = " + usuario.idusuario + ";";
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
