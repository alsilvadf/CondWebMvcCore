using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondWebMvc.Models
{
    public class ControleVisitas
    {
        public int Id { get; set; }     
      
        public string NomeVisitante { get; set; }
        public string Documento { get; set; }
        public string Obs { get; set; }
       
        public int UnidadeId { get; set; }

        public Unidade Unidade { get; set; }


        public ControleVisitas()
        {

        }

        public ControleVisitas(int id, Unidade unidade, string nomeVisitante, string documento, string obs)
        {
            Id = id;          
            Unidade = unidade;
            NomeVisitante = nomeVisitante;
            Documento = documento;
            Obs = obs;
        }
    }
}
