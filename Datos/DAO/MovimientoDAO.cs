using MovimientosModulo.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Datos.DAO
{
    public class MovimientoDAO : IDAO.IMovimientoDAO
    {
        public bool delete(Movimiento movimiento)
        {
            Boolean Resultado = false;
            String Sentencia = @"DELETE FROM movimientos WHERE idmovimientos = " + movimiento.idMovimiento + ";";
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

        public IEnumerable<Movimiento> getAll()
        {
            MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;
            String connString = "Server=127.0.0.1;Database=funerariabd;Uid=usuario;Pwd=contra;";
            mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connString);

            List<Movimiento> items = new List<Movimiento>();
            mySqlConnection.Open();
            queryStr = "SELECT * FROM movimientos";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, mySqlConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Movimiento item = new Movimiento();
                item.idMovimiento = (int)reader["idmovimientos"];
                item.idContrato =(int)reader["idContrato"];
                item.idVendedor = (int)reader["idEmpleado"];
                item.Concepto = reader["Concepto"].ToString();
                item.Abono = float.Parse(reader["abono"].ToString());
                item.fecha = DateTime.Parse(reader["fecha"].ToString());
            
                items.Add(item);
            }

            mySqlConnection.Close();

            return items;
        }

        public IEnumerable<Movimiento> getAllWithAcount(int id)
        {

            MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;
            String connString = "Server=127.0.0.1;Database=funerariabd;Uid=usuario;Pwd=contra;";
            mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connString);

            List<Movimiento> items = new List<Movimiento>();
            mySqlConnection.Open();
            queryStr = "SELECT * FROM movimientos where idContrato="+id;
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, mySqlConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Movimiento item = new Movimiento();
                item.idMovimiento = (int)reader["idmovimientos"];
                item.idContrato = (int)reader["idContrato"];
                item.idVendedor = (int)reader["idEmpleado"];
                item.Concepto = reader["Concepto"].ToString();
                item.Abono = float.Parse(reader["abono"].ToString());
                item.fecha = DateTime.Parse(reader["fecha"].ToString());

                items.Add(item);
            }

            mySqlConnection.Close();

            return items;
        }

        public Movimiento GetById(int id)
        {
            MySql.Data.MySqlClient.MySqlConnection mySqlConnection;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;
            String connString = "Server=127.0.0.1;Database=funerariabd;Uid=usuario;Pwd=contra;";
            mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connString);
            Movimiento item = new Movimiento();
            
            mySqlConnection.Open();
            queryStr = "SELECT * FROM movimientos where idmovimientos=" + id;
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, mySqlConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                item.idMovimiento = (int)reader["idmovimientos"];
                item.idContrato = (int)reader["idContrato"];
                item.idVendedor = (int)reader["idEmpleado"];
                item.Concepto = reader["Concepto"].ToString();
                item.Abono = float.Parse(reader["abono"].ToString());
                item.fecha = DateTime.Parse(reader["fecha"].ToString());

                
            }

            mySqlConnection.Close();

            return item;
        }

        public bool Save(Movimiento movimiento)
        {
            Boolean Resultado = false;
            String Sentencia = @"INSERT INTO movimientos (Fecha,idContrato,Concepto,Abono,idEmpleado)
            VALUES ('" + movimiento.fecha.ToString("yyyy/MM/dd") + "'," + movimiento.idContrato + ",'" + movimiento.Concepto + "'," + movimiento.Abono + "," + movimiento.idVendedor + "); ";
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

        public bool update(Movimiento movimiento)
        {
            throw new NotImplementedException();
        }
    }
}
