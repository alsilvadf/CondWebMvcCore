using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondWebMvc.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string LoginUsuario { get; set; }
        public string SenhaUsuario { get; set; }

        public Usuario()
        {

        }

        public Usuario(int id, string nomeUsuario, string loginUsuario, string senhaUsuario)
        {
            Id = id;
            NomeUsuario = nomeUsuario;
            LoginUsuario = loginUsuario;
            SenhaUsuario = senhaUsuario;
        }
    }
}
