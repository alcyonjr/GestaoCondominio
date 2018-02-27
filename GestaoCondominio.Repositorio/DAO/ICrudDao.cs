using System.Collections.Generic;

namespace GestaoCondominio.Repositorio.DAO
{
    public interface ICrudDao<T>
    {

        void Inserir(T entidade);
        void Alterar(T entidade);
        void Excluir(T entidade);
        T BuscarPorId(int id);
        IList<T> Consultar();

    }
}
