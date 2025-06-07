using DataAccess.DAO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    /*
     * Clase u objeto que se encarga de la comunicación con la base de datos.
     * Solo ejecuta Store Procedures
     * 
     * Esta clse implementa el Patron del Singleton para asegurar
     * la existencia de una unica instancia de este objeto
     */
    public class SqlDao
    {
        //Paso 1: Crear una instancia privada de la misma clase
        private static SqlDao _instance;
        
        private string _connectionString;

        //Paso 2: Redefinir el constructor default y convertirlo en privado
        private SqlDao()
        {
            _connectionString = @"Data Source=srv-sqldatabase-aaguero.database.windows.net;Initial Catalog=cenfocinemas-db;Persist Security Info=True;User ID=sysman;Password=Cenfotec123!;Trust Server Certificate=True";
        }

        //Paso 3: Definir el metodo que expone la instancia

        public static SqlDao GetInstance()
        {
            //Si la instancia es nula, crear una nueva instancia
            if (_instance == null)
            {
                _instance = new SqlDao();
            }
            //Retornar la instancia
            return _instance;
        }

        //Metodo para la ejecución de Store Procedures sin retorno
        public void ExecuteProcedure(SqlOperation sqlOperation)
        {
            //Conectarse a la base de datos
            //Ejecutar el Store Procedure
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                })

                {
                    //Set de los parametros
                    foreach (var param in sqlOperation.Parameters)
                    {
                        command.Parameters.Add(param);
                    }
                    //Ejectura el SP
                    conn.Open();
                    command.ExecuteNonQuery();
                }

            }
        }

        //Metodo para la ejecución de Store Procedures con retorno
        public List<Dictionary<string, object>> ExecuteProcedureWithReturn(SqlOperation operation)
        {
            //Conectarse a la base de datos
            //Ejecutar el Store Procedure
            //Capturar el resultado
            //Convertir el resultado en DTOs

            var list = new List<Dictionary<string, object>>();

            return list;
        }
    }
}
