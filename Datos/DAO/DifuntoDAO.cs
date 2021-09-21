using EntregasModulo.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Xml;
namespace Datos.DAO
{
    public class DifuntoDAO : IDAO.IDifuntoDAO
    {
        XmlDocument xml = new XmlDocument();
        public bool delete(difunto entrega)
        {
            Boolean Resultado = false;
            String Sentencia = @"DELETE FROM difuntos WHERE iddifuntos = " + entrega.iddifunto + ";";
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

        public IEnumerable<difunto> getAll()
        {
            MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;
            xml.Load("Conexion.xml");
            String Con = xml.InnerText;
            String connString = "Server=127.0.0.1;Database=funerariabd;Uid=usuario;Pwd=contra;";
            mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(Con);

            List<difunto> items = new List<difunto>();
            mySqlConnection.Open();
            queryStr = "SELECT * FROM difuntos";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, mySqlConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                difunto item = new difunto();
                item.iddifunto = (int)reader["iddifuntos"];
                item.idcontrato = (int)reader["contrato"];
                item.nombres = reader["nombre"].ToString();
                item.apellidos = reader["apellidos"].ToString();
                item.CausaMuerte = reader["CausadeMuerte"].ToString();
                item.fechanacimiento = DateTime.Parse(reader["fechadenacimiento"].ToString());
                item.fechanMuerte = DateTime.Parse(reader["fechademuerte"].ToString());
                item.direccionDeEntrega = reader["Direcciondeentrega"].ToString();
                item.direccionDeToma = reader["Direcciondetoma"].ToString();
                items.Add(item);
            }

            mySqlConnection.Close();

            return items;
        }

        public IEnumerable<difunto> getAllWithAcount(int id)
        {
            MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;
            String connString = "Server=127.0.0.1;Database=funerariabd;Uid=usuario;Pwd=contra;";
            mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connString);

            List<difunto> items = new List<difunto>();
            mySqlConnection.Open();
            queryStr = "SELECT * FROM difuntos where contrato="+id;
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, mySqlConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                difunto item = new difunto();
                item.iddifunto = (int)reader["iddifuntos"];
                item.idcontrato = (int)reader["contrato"];
                item.nombres = reader["nombre"].ToString();
                item.apellidos = reader["apellidos"].ToString();
                item.CausaMuerte = reader["CausadeMuerte"].ToString();
                item.fechanacimiento = DateTime.Parse(reader["fechadenacimiento"].ToString());
                item.fechanMuerte = DateTime.Parse(reader["fechademuerte"].ToString());
                item.direccionDeEntrega = reader["Direcciondeentrega"].ToString();
                item.direccionDeToma = reader["Direcciondetoma"].ToString();
                items.Add(item);
            }

            mySqlConnection.Close();

            return items;
        }

        public difunto GetById(int id)
        {
            MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;
            String connString = "Server=127.0.0.1;Database=funerariabd;Uid=usuario;Pwd=contra;";
            mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connString);
            difunto item = new difunto();
            
            mySqlConnection.Open();
            queryStr = "SELECT * FROM difuntos where iddifuntos=" + id;
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, mySqlConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                item.iddifunto = (int)reader["iddifuntos"];
                item.idcontrato = (int)reader["contrato"];
                item.nombres = reader["nombre"].ToString();
                item.apellidos = reader["apellidos"].ToString();
                item.CausaMuerte = reader["CausadeMuerte"].ToString();
                item.fechanacimiento = DateTime.Parse(reader["fechadenacimiento"].ToString());
                item.fechanMuerte = DateTime.Parse(reader["fechademuerte"].ToString());
                item.direccionDeEntrega = reader["Direcciondeentrega"].ToString();
                item.direccionDeToma = reader["Direcciondetoma"].ToString();
                
            }

            mySqlConnection.Close();

            return item;
        }

        public bool Save(difunto entrega)
        {
            Boolean Resultado = false;
            String Sentencia = @"INSERT INTO difuntos(nombre,apellidos,Direcciondetoma,Direcciondeentrega,CausadeMuerte,FechadeMuerte,FechadeNacimiento,contrato) 
            VALUES('" + entrega.nombres + " ','" + entrega.apellidos + "','" + entrega.direccionDeToma + "','" + entrega.direccionDeEntrega + "','" + entrega.CausaMuerte + "','" + entrega.fechanMuerte.ToString("yyyy/MM/dd") + "','" + entrega.fechanacimiento.ToString("yyyy/MM/dd") + "'," + entrega.idcontrato + "); ";
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

        public bool update(difunto entrega)
        {
            Boolean Resultado = false;
            String Sentencia = @"UPDATE difuntos SET nombre=' " + entrega.nombres + " ' , apellidos=' " + entrega.apellidos + " ' , Direcciondetoma=' " + entrega.direccionDeToma + " ' , Direcciondeentrega='" + entrega.direccionDeEntrega + "' , CausadeMuerte='" + entrega.CausaMuerte + "' , FechadeMuerte='" + entrega.fechanMuerte.ToString("yyyy/MM/dd") + "' , FechadeNacimiento='" + entrega.fechanacimiento.ToString("yyyy/MM/dd") + "',contrato=" + entrega.idcontrato +
                         " WHERE iddifuntos = " + entrega.iddifunto + ";";

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
