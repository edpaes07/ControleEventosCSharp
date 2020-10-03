using Eventeris.DAL.Contexto;
using Eventeris.DAL.Entidade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Eventeris.DAL.Repositorio
{
    public class RepositorioParticipante : RepositorioComum<Participacao>, IRepositorioParticipante, IDisposable
    {
        public RepositorioParticipante()
        {
            contexto = new EventerisContext();
        }

        private IRepositorioComum<Participacao> _repoParticipacao;

        public RepositorioParticipante(IPrincipal currentUser,
            IRepositorioComum<Participacao> repoParticipacao)
            : base(currentUser)
        {
            _repoParticipacao = repoParticipacao;
        }

        public List<Participacao> ListarParticipantes()
		{
			using (var contexto = new EventerisContext())
			{
				IQueryable<Participacao> query = contexto.Participacao;
				
				query = query.Include("Evento.Nome");

				return query.ToList();
			}
		}

        public Participacao obterParticipacao(int id)
        {
            var model = Obter(id);
            return model;
        }

        public Participacao atualizarPresenca(int idParticipante)
        {
            using (var contexto = new EventerisContext())
            {
                var model = Obter(idParticipante);

                var _repositorioEvento = new RepositorioEvento();

                var evento = _repositorioEvento.Obter(model.IdEvento);
                if (evento.IdEventoStatus == 2)
                {

                    model.FlagPresente = true;
                    Atualizar(model);
                    contexto.SaveChanges();
                }

                return model;
            }
        }

        public Participacao atualizarNota(int idParticipante, int nota, string cometario)
        {
            using (var contexto = new EventerisContext())
            {
                var model = Obter(idParticipante);

                var _repositorioEvento = new RepositorioEvento();

                var evento = _repositorioEvento.Obter(model.IdEvento);
                if (evento.IdEventoStatus == 3 && model.FlagPresente == true)
                {

                    model.Nota = nota;
                    model.Comentario = cometario;
                    Atualizar(model);
                    contexto.SaveChanges();
                }

                return model;
            }
        }
    }
}
