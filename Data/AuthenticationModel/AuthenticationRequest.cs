using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImoStatemiddleware.Data.AuthenticationModel
{
    [Table("Auth_ClientServerAccessRight")]
    public class AuthenticationRequest
    {
        [Key]
        public int RowID { get; set; }
        public string Appkey { get; set; }
        public string AppID { get; set; }
        public string ClientIP { get; set; }
    }
}
