using Eventeris.DL.API.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eventeris.DL.API.Request
{
	public class EventoCreateRequest
	{
		[Required]
		[StringLength(250)]
		public string Nome { get; set; }

		[Required]
		public int IdEventoStatus { get; private set; }

		[Required]
		public int IdCategoriaEvento { get; set; }

		[Required]
		public DateTime DataHoraInicio { get; set; }

		[Required]
		public DateTime DataHoraFim { get; set; }

		[Required]
		[StringLength(250)]
		public string Local { get; set; }

		[Required]
		[StringLength(1000)]
		public string Descricao { get; set; }

		[Required]
		public int LimiteVagas { get; set; }
	}
}