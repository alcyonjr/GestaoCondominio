using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCondominio.Dominio
{
    public class Apartamento
    {
        public virtual int id { get; set; }
        public virtual String nome { get; set; }
        public virtual int numero { get; set; }
        public virtual String bloco { get; set; }
        public virtual IList<Morador> moradores { get; set; }

    }
}
