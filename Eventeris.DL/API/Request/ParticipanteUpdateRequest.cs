using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eventeris.DL.API.Request
{
	public class ParticipanteUpdateRequest
	{
		[Required]
		public bool FlagPresente { get; set; }

		[Required]
		public int? Nota { get; set; }

		[Required]
		[StringLength(1000)]
		public string Comentario { get; set; }
}
}
