using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondWebMvc.Models.ViewModels
{
    public class MoradorFormViewModels
    {
        public Morador Morador { get; set; }
        public ICollection<Unidade> Unidades { get; set; }
    }
}
