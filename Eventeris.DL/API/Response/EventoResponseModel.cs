using System;
using System.Collections.Generic;
using System.Text;

namespace Eventeris.DL.API.Response
{
	public class EventoResponseModel
	{

        public EventoResponseModel(int idEvento, int idEventoStatus, int idCategoriaEvento, string nome, DateTime dataHoraInicio, DateTime dataHoraFim, string local, string descricao, int limiteVagas)
		{
			IdEvento = idEvento;
			IdEventoStatus = idEventoStatus;
			IdCategoriaEvento = idCategoriaEvento;
			Nome = nome;
			DataHoraInicio = dataHoraInicio;
			DataHoraFim = dataHoraFim;
			Local = local;
			Descricao = descricao;
			LimiteVagas = limiteVagas;
		}

		public int IdEvento { get; set; }

		public int IdEventoStatus { get; set; }

		public int IdCategoriaEvento { get; set; }

		public string Nome { get; set; }

		public DateTime DataHoraInicio { get; set; }

		public DateTime DataHoraFim { get; set; }

		public string Local { get; set; }

		public string Descricao { get; set; }

		public int LimiteVagas { get; set; }

		public virtual ICollection<CategoriaResponseModel> Evento { get; set; }
	}
}
