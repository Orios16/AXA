using System.Data;
using AXA.Entities.Models;

namespace AXA.BL.Class
{
    public interface IPolizasBL
    {

        string InsertPolizasBL(PolizasModelsIn Entrada);

        DataTable GetPolizasBL(GetPolizasModels Entrada);

    }
}
