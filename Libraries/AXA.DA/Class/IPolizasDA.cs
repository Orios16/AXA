using System.Data;
using AXA.Entities.Models;

namespace AXA.DA.Class
{
    public interface IPolizasDA
    {

        string InsertPolizasDA(PolizasModelsIn Entrada, FechasModels Fechas);

        DataTable GetPolizasDA(GetPolizasModels Entrada);

    }
}
