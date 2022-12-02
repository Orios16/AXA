using System;
using System.Data;
using AXA.DA.Class;
using AXA.Entities.Models;

namespace AXA.BL.Class
{
    public class PolizasBL : IPolizasBL
    {


        public string InsertPolizasBL(PolizasModelsIn Entrada)
        {

            IPolizasDA _PolizasDA = new PolizasDA();

            var EntradaInsertPolizas = new GetPolizasModels
            {
                Placa = Entrada.Placa
            };
            var ResultPlaca = _PolizasDA.GetPolizasDA(EntradaInsertPolizas);

            var Fechas = new FechasModels
            {
                Fechainicio = DateTime.Now,
                Fechafin = DateTime.Now.AddDays(-1),
                Fechavencimiento = DateTime.Now.AddDays(+365)
            };

            if (ResultPlaca.Rows[0]["CODMENSAJE"].ToString() == "0")
            {
                var result = _PolizasDA.InsertPolizasDA(Entrada, Fechas);
                return result;
            }
            else
            {

                DateTime FecFin = (DateTime)ResultPlaca.Rows[0]["Fechavencimiento"];
                DateTime FecIni = DateTime.Now;
                string FecIni2 = string.Format("{0:dd, MM, yyyy}", FecIni);
                string FecFin2 = string.Format("{0:dd, MM, yyyy}", FecFin);

                int ResultFechas = DateTime.Compare(Convert.ToDateTime(FecIni2), Convert.ToDateTime(FecFin2));
                if (ResultFechas <= 0)
                {
                    var result = _PolizasDA.InsertPolizasDA(Entrada, Fechas);
                    return result;
                }
                else
                {
                    return "la fecha de vencimiento de la póliza actual, supero la fecha actual";
                }

            }
        }

        public DataTable GetPolizasBL(GetPolizasModels Entrada)
        {
            IPolizasDA _PolizasDA = new PolizasDA();
            var result = _PolizasDA.GetPolizasDA(Entrada);
            return result;
        }


    }
}
