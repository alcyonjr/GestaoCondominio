using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCondominio.Repositorio.DAO
{
    public interface ICrudDao<T>
    {

        void Inserir(T entidade);
        void Alterar(T entidade);
        void Excluir(T entidade);
        T BuscarPorId(int id);
        IList<T> consultar();

    }
}
