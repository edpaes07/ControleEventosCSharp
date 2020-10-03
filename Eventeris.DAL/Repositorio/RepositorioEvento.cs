using Eventeris.DAL.Contexto;
using Eventeris.DAL.Entidade;
using Eventeris.DAL.Interface;
using Eventeris.DAL.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Eventeris.DAL.Repositorio
{
    public class RepositorioEvento : RepositorioComum<Evento>, IRepositorioEvento, IDisposable
    {

        public RepositorioEvento()
        {
            contexto = new EventerisContext();
        }

        private IRepositorioComum<Evento> _repoEvento;

        public RepositorioEvento(IPrincipal currentUser,
            IRepositorioComum<Evento> repoEvento)
            : base(currentUser)
        {
            _repoEvento = repoEvento;
        }

        public Evento iniciarEvento(int idEvento)
        {
            var model = Obter(idEvento);
            if (model.DataHoraInicio.Date == DateTime.Now.Date)
            {
                model.IdEventoStatus = 2;
                Atualizar(model);
                contexto.SaveChanges();
            }
            return model;
        }
        
        public Evento cancelarEvento(int idEvento)
        {
            var model = Obter(idEvento);
            if (model.IdEventoStatus == 1
                && model.DataHoraInicio.Date > DateTime.Now.Date)
            {
                model.IdEventoStatus = 4;
                Atualizar(model);
                contexto.SaveChanges();
            }
            return model;
        }

        public Evento concluirEvento(int idEvento)
        {
            var model = Obter(idEvento);
            if (model.IdEventoStatus == 2 
                && model.DataHoraInicio.Date <= DateTime.Now.Date)
            {
                model.IdEventoStatus = 3;
                Atualizar(model);
                contexto.SaveChanges();
            }
            return model;
        }

        public Evento obterEvento(int id)
        {
            var model = Obter(id);
            return model;
        }

        public Evento InserirEvento(Evento model)
        {
            throw new NotImplementedException();
        }

        public Evento Iniciar(Evento model)
        {
            throw new NotImplementedException();
        }

        public Evento Cancelar(Evento model)
        {
            throw new NotImplementedException();
        }

        public Evento Concluir(Evento model)
        {
            throw new NotImplementedException();
        }
    }
}
