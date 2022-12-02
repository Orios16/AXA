using System;

namespace AXA_WEB.Models
{
    public class ListPolizasModels
    {
        public int Identificacion { get; set; }

        public string Nombres { get; set; }

        public int Apellidos { get; set; }

        public DateTime Fechainicio { get; set; }

        public DateTime Fechafin { get; set; }

        public DateTime Fechavencimiento { get; set; }

        public string Placa { get; set; }

        public string Ciudad { get; set; }

    }
}
