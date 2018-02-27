using GestaoCondominio.Repositorio.Infra;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestaoCondominio.Repositorio.DAO
{
    public class RepositorioCrudDao<T> : ICrudDao<T> where T : class
    {
        public void Inserir(T entidade)
        {
            using (ISession session = FluentSessionFactory.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entidade);
                        transacao.Commit();
                    } catch (Exception)
                    {
                        if (!transacao.WasCommitted)
                            transacao.Rollback();

                        throw;
                    }
                    
                }
            }
        }

        public void Alterar(T entidade)
        {
            using (ISession session = FluentSessionFactory.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entidade);
                        transacao.Commit();
                    }
                    catch (Exception)
                    {
                        if (!transacao.WasCommitted)
                            transacao.Rollback();

                        throw;
                    }

                }
            }
        }

        public T BuscarPorId(int id)
        {
            using(ISession session = FluentSessionFactory.AbrirSession())
            {
                return session.Get<T>(id);
            }
        }

        public IList<T> Consultar()
        {
            using (ISession session = FluentSessionFactory.AbrirSession())
            {
                return session.Query<T>().ToList();
            }
        }

        public void Excluir(T entidade)
        {
            using (ISession session = FluentSessionFactory.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entidade);
                        transacao.Commit();
                    }
                    catch (Exception)
                    {
                        if (!transacao.WasCommitted)
                            transacao.Rollback();

                        throw;
                    }
                }
            }
        }       
    }
}
