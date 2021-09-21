using Empleados_Modulo.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Xml;

namespace Datos.DAO
{
    public class EmpleadoDAO : IDAO.IEmpleadoDAO
    {
        XmlDocument xml = new XmlDocument();
        public bool delete(Empleados empleado)
        {
            Boolean Resultado = false;
            String Sentencia = @"DELETE FROM Empleados WHERE idEmpleados = " + empleado.idEmpleado + ";";
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

        public IEnumerable<Empleados> getAll()
        {
            MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;
            String connString = "Server=127.0.0.1;Database=funerariabd;Uid=usuario;Pwd=contra;";
            mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connString);

            List<Empleados> items = new List<Empleados>();
            mySqlConnection.Open();
            queryStr = "SELECT * FROM empleados";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, mySqlConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Empleados item = new Empleados();
                item.idEmpleado = (int)reader["idempleados"];
                item.Nombre = reader["Nombres"].ToString();
                item.Apellido = reader["Apellidos"].ToString();
                item.dt = DateTime.Parse(reader["fechanacimiento"].ToString());
                item.Telefono = reader["telefono"].ToString();
                item.Direccion = reader["direccion"].ToString();
                item.DUI = reader["DUI"].ToString();
                item.idpuesto = (int)reader["puesto"];
                item.fechaContratacion = DateTime.Parse(reader["fechacontratacion"].ToString());
                items.Add(item);
            }

            mySqlConnection.Close();

            return items;
        }

        public Empleados GetById(int id)
        {
            MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;
            String connString = "Server=127.0.0.1;Database=funerariabd;Uid=usuario;Pwd=contra;";
            mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connString);
            Empleados item = new Empleados();
            
            mySqlConnection.Open();
            queryStr = "SELECT * FROM empleados where idempleados="+id;
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, mySqlConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                item.idEmpleado = (int)reader["idempleados"];
                item.Nombre = reader["Nombres"].ToString();
                item.Apellido = reader["Apellidos"].ToString();
                item.dt = DateTime.Parse(reader["fechanacimiento"].ToString());
                item.Telefono = reader["telefono"].ToString();
                item.Direccion = reader["direccion"].ToString();
                item.DUI = reader["DUI"].ToString();
                item.idpuesto = (int)reader["puesto"];
                item.fechaContratacion = DateTime.Parse(reader["fechacontratacion"].ToString());
                
            }

            mySqlConnection.Close();

            return item;
        }

        public bool Save(Empleados empleado)
        {
            Boolean Resultado = false;

            String Sentencia = @"INSERT INTO Empleados(nombres,apellidos,fechanacimiento,telefono,direccion,DUI,fechacontratacion,puesto) VALUES('" + empleado.Nombre + "','" + empleado.Apellido + "','" + empleado.dt.ToString("yyyy/MM/dd") + "','" + empleado.Telefono + "','" + empleado.Direccion + "','" + empleado.DUI + "','" + empleado.fechaContratacion.ToString("yyyy/MM/dd") + " ', " + empleado.idpuesto + " );";
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
            catch
            {
                Resultado = false;
            }
            return Resultado;
        }

        public bool update(Empleados empleado)
        {
            Boolean Resultado = false;
            String Sentencia = @"UPDATE Empleados SET nombres='" + empleado.Nombre + "' , apellidos='" + empleado.Apellido + "', fechanacimiento=' " + empleado.dt.ToString("yyyy/MM/dd") + " ', telefono='" + empleado.Telefono + "', direccion='" + empleado.Direccion + "', DUI=' " + empleado.DUI + " ', fechacontratacion=' " + empleado.fechaContratacion.ToString("yyyy/MM/dd") + " ', puesto= " + empleado.idpuesto + "  WHERE idEmpleados = " + empleado.idEmpleado + ";";
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
