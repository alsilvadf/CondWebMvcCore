using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondWebMvc.Models.ViewModels
{
    public class VisitaFormViewModels
    {
        public ControleVisitas Visita { get; set; }

        public ICollection<Unidade> Unidades { get; set; }

        public ICollection<Morador> Moradores { get; set; }
    }
}
