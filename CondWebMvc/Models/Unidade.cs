using System.ComponentModel.DataAnnotations;

namespace CondWebMvc.Models
{
    public class Unidade
    {
        public int Id { get; set; }

        [Display(Name = "Unidade")]
        public int NumUnidade { get; set; }

        [Display(Name = "Bloco")]
        public string BlocoUnidade { get; set; }

       
        public string NomeComBloco { get => $"{ this.Id} - {this.BlocoUnidade}"; }


        public Unidade()
        {

        }

        public Unidade(int id, int numUnidade, string blocoUnidade)
        {
            Id = id;
            NumUnidade = numUnidade;
            BlocoUnidade = blocoUnidade;
        }
    }
}
