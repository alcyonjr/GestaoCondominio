using System;

namespace GestaoCondominio.Dominio
{
    public class Usuario
    {
        public virtual int id { get; set; }
        public virtual String login { get; set; }
        public virtual String senha { get; set; }       
    }
}
