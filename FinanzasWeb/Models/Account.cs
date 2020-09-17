using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinanzasWeb.Models
{
    public class Account
    {
        public int id { get; set; }
        public string Type { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio")] 
        public string Name { get; set; }
        public string Currency { get; set; }
        [Required(ErrorMessage = "El campo monto es obligatorio")] 
        public decimal Amount { get; set; }
    }
}
