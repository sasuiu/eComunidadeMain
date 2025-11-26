using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eComunidade.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public string? Local { get; set; }
        public DateTime Data { get; set; } //ja pega data e hora, ai nao precisa botar dois separados
        public int QtdeVoluntarios {  get; set; }
        public int QtdeVagas { get; set; }
        public TimeSpan? Duracao { get; set; } // melhor para para durações do que um datetime
        public int PontuacaoVoluntario { get; set; }

        //calcular as vagas restantes
        public int QtdeVagasRestantes => QtdeVagas - QtdeVoluntarios;

        public string DataFormatada => Data.ToString("HH:mm");

        public Evento() { }

        public Evento(string titulo, string descricao, string local, DateTime data, int qtdeVagas)
        {
            Titulo = titulo;
            Descricao = descricao;
            Local = local;
            Data = data;
            QtdeVagas = qtdeVagas;
            QtdeVoluntarios = 0;
            PontuacaoVoluntario = 0;
        }
    }
}
  
