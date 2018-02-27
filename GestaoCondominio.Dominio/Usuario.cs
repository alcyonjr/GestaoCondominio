using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCondominio.Dominio
{
    public class Usuario
    {
        public virtual int id { get; set; }
        public virtual String login { get; set; }
        public virtual String senha { get; set; }       
    }
}
