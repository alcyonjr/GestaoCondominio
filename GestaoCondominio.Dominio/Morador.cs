using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCondominio.Dominio
{
    public class Morador
    {
        public virtual int id { get; set; }
        public virtual String nome { get; set; }
        public virtual DateTime dataNascimento { get; set; }
        public virtual int telefone { get; set; }
        public virtual int cpf { get; set; }
        public virtual String email { get; set; }
        public virtual Boolean responsavel { get; set; }

        public virtual Apartamento apartamento { get; set; }

    }
}
