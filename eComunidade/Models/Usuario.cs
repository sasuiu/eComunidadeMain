using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eComunidade.Models
{
    public class Usuario
    {
        public int Id { get; set; } 
        public string? Login { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Celular { get; set; }
        public string? Cep { get; set; }
    }
}
