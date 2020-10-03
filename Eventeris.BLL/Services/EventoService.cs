using Eventeris.DAL.Entidade;
using Eventeris.DAL.Repositorio;
using Eventeris.DL.API.Request;
using Eventeris.DL.API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eventeris.BLL.Services
{
    public class EventoService : RepositorioComum<Evento>
    {
        private RepositorioEvento _repositorio;

        public EventoService(RepositorioEvento repositorio)
        {
            _repositorio = repositorio;
        }

        public List<EventoResponseModel> ListarEventos()
        {
            var listaRetorno = new List<EventoResponseModel>();  // cria uma lista vazia
            var repositorio = new RepositorioComum<Evento>();

            var lista = repositorio.Listar();

            if (lista != null && lista.Any())
            {
                foreach (Evento item in lista)
                    listaRetorno.Add(new EventoResponseModel(item.IdEvento, item.IdEventoStatus, item.IdCategoriaEvento, item.Nome,
                        item.DataHoraInicio, item.DataHoraFim, item.Local, item.Descricao, item.LimiteVagas));
            }

            return listaRetorno;
        }

        public EventoResponseModel ObterEvento(int idEvento)
        {
            var item = _repositorio.obterEvento(idEvento);
            EventoResponseModel evento;
            evento = new EventoResponseModel(item.IdEvento, item.IdEventoStatus, item.IdCategoriaEvento, item.Nome,
                        item.DataHoraInicio, item.DataHoraFim, item.Local, item.Descricao, item.LimiteVagas);

            return evento;

        }

        public Evento InserirEvento(EventoCreateRequest model)
        {
            if (model == null)
                return null;

            Evento evento = new Evento()
            {
                Nome = model.Nome,
                IdEventoStatus = 1,
                IdCategoriaEvento = model.IdCategoriaEvento,
                DataHoraInicio = model.DataHoraInicio,
                DataHoraFim = model.DataHoraFim,
                Local = model.Local,
                Descricao = model.Descricao,
                LimiteVagas = model.LimiteVagas,
            };

            evento = _repositorio.Adicionar(evento);

            return evento;
        }

        public Evento IniciarEvento(int idEvento)
        {
            var evento = _repositorio.iniciarEvento(idEvento);
            return evento;
        }

        public Evento CancelarEvento(int idEvento)
        {
            var evento = _repositorio.cancelarEvento(idEvento);
            return evento;
        }

        public Evento ConcluirEvento(int idEvento)
        {
            var evento = _repositorio.concluirEvento(idEvento);
            return evento;
        }

        
    }
}
