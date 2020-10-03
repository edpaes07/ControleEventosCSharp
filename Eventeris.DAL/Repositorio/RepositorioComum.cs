using Eventeris.DAL.Contexto;
using Eventeris.DAL.Entidade;
using Eventeris.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace Eventeris.DAL.Repositorio
{
    public class RepositorioComum<T> : IRepositorioComum<T>, IDisposable
        where T : class, new()
    {

        protected IPrincipal _user;
        public RepositorioComum(IPrincipal currentUser)
        {
            _user = currentUser;
        }

        protected EventerisContext contexto;

        public RepositorioComum()
        {
            contexto = new EventerisContext();
        }

        public void Dispose()
        {
            if (contexto != null)
            {
                contexto.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public T Adicionar(T entity)
        {
            contexto.ChangeTracker.AutoDetectChangesEnabled = false;
            contexto.Set<T>().Add(entity);
            contexto.SaveChanges();
            return entity;
        }

        public T Atualizar(T entity)
        {
            contexto.ChangeTracker.AutoDetectChangesEnabled = false;
            contexto.Entry(entity).State = EntityState.Modified;
            contexto.SaveChanges();

            return entity;
        }

        public List<T> Listar()
        {
            return contexto.Set<T>().ToList();
        }

        public T Encontrar(int id) => contexto.Set<T>().Find(id);

        public void Salvar()
        {
            contexto.SaveChanges();
        }

        public T Obter(int id)
        {
            return contexto.Set<T>().Find(id);
        }
    }
}
