using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBankingXamarinForms.Models
{
    public class ClsUser
    {
        [JsonProperty("idUsuario")]
        public int IDUsuario { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("contraseña")]
        public string Password { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("cedula")]
        public Int64 IdCard { get; set; }

        [JsonProperty("tipoCuenta")]
        public string AccountType { get; set; }

        [JsonProperty("fecha")]
        public DateTime Date_Time { get; set; }

        [JsonProperty("fecha_Creacion")]
        public DateTime FechaCreacion { get; set; }
     
    }
}
