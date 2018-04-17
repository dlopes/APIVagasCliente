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
    public class VagasRepository
    {
        public Vaga Get(/*Guid id*/int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var vaga = session.Get<Vaga>(id);
                
                NHibernateUtil.Initialize(vaga.Requisitos);
  
                return vaga;
            }
        }

        public void Save(Vaga vaga)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(vaga);
                transaction.Commit();
            }
        }

        public void Update(Vaga vaga)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(vaga);
                transaction.Commit();
            }
        }

        public IList<Vaga> GetAll()
        {
            /*using (ISession session = NHibernateHelper.OpenSession())
            {
                var vagas = session.CreateCriteria<Vaga>().List<Vaga>();
                foreach (var vaga in vagas)
                {
                   NHibernateUtil.Initialize(vaga.Requisitos);

                }
                return vagas;
            }*/

            using (ISession session = NHibernateHelper.OpenSession())
            {
                var vagas = session.CreateCriteria<Vaga>()
                .Add(Restrictions.Eq("Ativa", true))
                .List<Vaga>();
                foreach (var vaga in vagas)
                {
                    NHibernateUtil.Initialize(vaga.Requisitos);

                }

                return vagas;
            }

        }

        public void Delete(Vaga vaga)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.CreateQuery("delete from Vaga u where u.Id = (:id)")
                    .SetParameter("id", vaga.Id)
                    .ExecuteUpdate();
                transaction.Commit();
            }
        }

        public int vagaCount(int id)
        {
            int count = 0;
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var criteria = session.CreateCriteria(typeof(Vaga))
                        .Add(Restrictions.Eq("Id", id))
                        .SetProjection(Projections.CountDistinct("Id"));
                count = (int)criteria.UniqueResult();
            }

            return count;
        }

        public IList<Requisito> GetRequisito(int idVag)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var requisitos = session.CreateCriteria<Requisito>()
                .Add(Restrictions.Eq("VagaId", idVag))
                .List<Requisito>();

                return requisitos;
            }
        }

    }
}