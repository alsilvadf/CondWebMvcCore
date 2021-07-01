using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CondWebMvc.Models
{
    public class Morador
    {
        public int Id { get; set; }
       
        public string NomeMorador { get; set; }
       
        public int TelefoneMorador { get; set; }

       
        public string EmailMorador { get; set; }

      
        public int UnidadeId { get; set; }

        public Unidade Unidade { get; set; }

       

      

        public Morador()
        {

        }

        public Morador(int id, string nomeMorador, int telefoneMorador, string emailMorador, Unidade unidade)
        {
            Id = id;
            NomeMorador = nomeMorador;
            TelefoneMorador = telefoneMorador;
            EmailMorador = emailMorador;
            Unidade = unidade;
        
        }
        
        //public void AddUnidade(Unidade un)
        //{
        //    Unidades.Add(un);
        //}
    }
}
