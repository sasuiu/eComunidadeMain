using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eComunidade.Models.Enum;

namespace eComunidade.Models
{
    public class Ocorrencia
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        
        public string? Descricao { get; set;}

        public TipoOcorrencia Tipo {  get; set; }
    }
}
