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
    public class ParticipanteService
    {
		private RepositorioParticipante _repositorio;

		public ParticipanteService(RepositorioParticipante repositorio)
		{
			_repositorio = repositorio;
		}
		public List<ParticipanteResponseModel> ListarParticipantes()
        {
			var listaRetorno = new List<ParticipanteResponseModel>();  // cria uma lista vazia
			var repositorio = new RepositorioComum<Participacao>();

			var lista = repositorio.Listar();

			if (lista != null && lista.Any())
			{
				foreach (Participacao item in lista)
					listaRetorno.Add(new ParticipanteResponseModel(item.IdParticipacao, item.IdEvento, 
						item.LoginParticipante, item.FlagPresente, item.Nota, item.Comentario));
			}

			return listaRetorno;
		}

		public ParticipanteResponseModel ObterParticipante(int id)
        {
			var item = _repositorio.obterParticipacao(id);
			ParticipanteResponseModel participante;

			participante = new ParticipanteResponseModel(item.IdParticipacao, item.IdEvento,
						item.LoginParticipante, item.FlagPresente, item.Nota, item.Comentario);

			return participante;
        }

		public Participacao InserirParticipante(ParticipanteCreateRequest model)
		{
			if (model == null)
				return null;

			Participacao participante = new Participacao()
			{

				IdEvento = model.IdEvento,
				LoginParticipante = model.LoginParticipante,
				Nota = 0,
				FlagPresente = false,
				Comentario = " "
			};

			participante = _repositorio.Adicionar(participante);

			return participante;
		}


		public Participacao AtualizarPresenca(int idParticipante)
		{
			var participante = _repositorio.atualizarPresenca(idParticipante);

			participante = _repositorio.Atualizar(participante);

			return participante;
		}

		public Participacao AtualizarNota(int idParicipante, int nota, string cometario)
		{
			var participante = _repositorio.atualizarNota(idParicipante, nota, cometario);

			participante = _repositorio.Atualizar(participante);

			return participante;
		}
	}
}