using System;
using System.Data;
using AXA.Entities.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace AXA.DA.Class
{
    public class PolizasDA : IPolizasDA
    {

        public string InsertPolizasDA(PolizasModelsIn Entrada, FechasModels Fechas)
        {

            try
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AXA"].ToString()))
                {
                    connection.Open();
                    SqlCommand com = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "InsertPolizas"
                    };

                    com.Parameters.Add("@Identificacion", SqlDbType.Int).Value = Entrada.Identificacion;
                    com.Parameters.Add("@Nombres", SqlDbType.NVarChar).Value = Entrada.Nombres.ToUpper().Trim();
                    com.Parameters.Add("@Apellidos", SqlDbType.NVarChar).Value = Entrada.Apellidos.ToUpper().Trim();
                    com.Parameters.Add("@Fechainicio", SqlDbType.Date).Value = Fechas.Fechainicio;
                    com.Parameters.Add("@Fechafin", SqlDbType.Date).Value = Fechas.Fechafin;
                    com.Parameters.Add("@Fechavencimiento", SqlDbType.Date).Value = Fechas.Fechavencimiento;
                    com.Parameters.Add("@Placa", SqlDbType.NVarChar).Value = Entrada.Placa.ToUpper().Trim();
                    com.Parameters.Add("@Ciudad", SqlDbType.NVarChar).Value = Entrada.Ciudad.ToUpper().Trim();

                    var returnParameter = com.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    com.ExecuteNonQuery();

                    var result = returnParameter.Value;

                    if (Convert.ToInt32(result) == 0)
                        return "La ciudad no existe";

                }

            }
            catch (Exception exception)
            {
                var exceptionMessage = "Error en metodo(AXA.DA.Class-InsertPolizasDA) = " + exception.Message;
                throw new Exception(exceptionMessage);
            }
            return " Los datos han sido guardados correctamente ";
        }

        public DataTable GetPolizasDA(GetPolizasModels Entrada)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AXA"].ToString()))
                {
                    connection.Open();
                    SqlCommand com = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "GetPolizas"
                    };

                    com.Parameters.Add("@Placa", SqlDbType.NVarChar).Value = Entrada.Placa.ToUpper().Trim();

                    leer = com.ExecuteReader();
                    tabla.Load(leer);
                    if (tabla.Rows.Count == 0)
                    {
                        var tablaSal = new DataTable();
                        tablaSal.Columns.Add("CODMENSAJE");
                        tablaSal.Columns.Add("MENSAJE");
                        DataRow ldrSal = tablaSal.NewRow();
                        ldrSal["CODMENSAJE"] = "0";
                        ldrSal["MENSAJE"] = string.Format("No existe informacion de esa placa");
                        tablaSal.Rows.Add(ldrSal);
                        return tablaSal;
                    }

                    tabla.Columns.Add("CODMENSAJE", typeof(string), "1");

                }
            }
            catch (Exception exception)
            {
                var exceptionMessage = "Error en metodo(AXA.DA.Class-GetPolizasDA) = " + exception.Message;
                throw new Exception(exceptionMessage);
            }
            return tabla;
        }






    }
}
