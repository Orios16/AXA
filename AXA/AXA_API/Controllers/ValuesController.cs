using AXA.BL.Class;
using System.Web.Http;
using AXA.Entities.Models;

namespace AXA_API.Controllers
{

    /// <summary>
    /// API de SOAT
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api")]

    public class ValuesController : ApiController
    {

        private readonly PolizasBL _PolizasBL;

        /// <summary>
        /// Variable General para el llamado a la interfaz.
        /// </summary>
        public ValuesController()
        {
            _PolizasBL = new PolizasBL();
        }


        /// <summary>
        /// Grabar Polizas 
        /// </summary>        
        [HttpPost]
        [Route("InsertarPolizas")]
        public IHttpActionResult InsertPolizasBL(PolizasModelsIn Entrada)
        {
            var result = _PolizasBL.InsertPolizasBL(Entrada);
            return Json(result);
        }


        /// <summary>
        /// Consulta PLACA 
        /// </summary>        
        [HttpGet]
        [Route("ConsultaPlaca")]
        public IHttpActionResult GetPolizasBL(GetPolizasModels Entrada)
        {
            var result = _PolizasBL.GetPolizasBL(Entrada);
            return Json(result);
        }



    }
}
