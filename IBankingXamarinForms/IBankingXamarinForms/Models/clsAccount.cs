using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBankingXamarinForms.Models
{
    public class ClsAccount
    {
      

            [JsonProperty("idCuenta")]
            public int IdCuenta { get; set; }

            [JsonProperty("cedula")]
            public Int64 Cedula { get; set; }

            [JsonProperty("tipoCuenta")]
            public string TipoCuenta { get; set; }

            [JsonProperty("balance")]
            public double Balance { get; set; }

            [JsonProperty("fechaActualizacion")]
            public DateTime FechaActualizacion { get; set; }

            [JsonProperty("fechaCreacion")]
            public DateTime FechaCreacion { get; set; }
     
    }
}
