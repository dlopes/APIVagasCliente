using APIVendasCliente.Dao;
using APIVendasCliente.Models.Entities;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIVendasCliente.Repository
{
    public class EmpresaRepository
    {
        public Empresa Get(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var emp = session.Get<Empresa>(id);
            
                //NHibernateUtil.Initialize(emp.Nome);
                NHibernateUtil.Initialize(emp.Vagas);
                //NHibernateUtil.Initialize(emp.Vagas);

                return emp;
            }
        }

        public void Save(Empresa emp)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(emp);
                transaction.Commit();
            }
        }

        public void Update(Empresa emp)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(emp);
                transaction.Commit();
            }
        }

        public IList<Empresa> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var empresas = session.CreateCriteria<Empresa>().List<Empresa>();
                foreach (var emp in empresas)
                {
                    NHibernateUtil.Initialize(emp.Vagas);
                    //NHibernateUtil.Initialize(user.Adress.City);
                    //NHibernateUtil.Initialize(user.Adress.State);
                    //NHibernateUtil.Initialize(user.Adress.Country);
                }
                return empresas;
            }
        }

        public void Delete(Empresa emp)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.CreateQuery("delete from Empresa u where u.Id = (:id)")
                    .SetParameter("id", emp.Id)
                    .ExecuteUpdate();
                transaction.Commit();
            }
        }

        public int empresaCout(int id)
        {
            int count = 0;
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var criteria = session.CreateCriteria(typeof(Empresa))
                        .Add(Restrictions.Eq("Id", id))
                        .SetProjection(Projections.CountDistinct("Id"));
                count = (int)criteria.UniqueResult();
            }

            return count;
        }

        public int vagaCout(int id)
        {
            int count = 0;
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var criteria = session.CreateCriteria(typeof(Vaga))
                        .Add(Restrictions.Eq("EmpresaId", id))
                        .SetProjection(Projections.CountDistinct("Id"));
                count = (int)criteria.UniqueResult();
            }

            return count;
        }

    }
}