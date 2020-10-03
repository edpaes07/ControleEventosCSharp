using Eventeris.BLL.Services;
using Eventeris.DL.API.Request;
using Eventeris.DL.API.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventeris.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class ParticipantesController : ControllerBase
	{
		private ParticipanteService _svc;

		public ParticipantesController(ParticipanteService svc)
		{
			_svc = svc;
		}

		[HttpGet]
		public ActionResult<List<ParticipanteResponseModel>> Get()
		{
			return _svc.ListarParticipantes();
		}

		[HttpGet]
		[Route("{id}")]
		public ActionResult<ParticipanteResponseModel> Get([FromRoute] int id)
		{
			return _svc.ObterParticipante(id);
		}

		[HttpPost]
		public ActionResult<ParticipanteResponseModel> Post(ParticipanteCreateRequest model)
		{
			if (ModelState.IsValid)
			{
				return Ok(_svc.InserirParticipante(model));
			}

			return BadRequest(ModelState);
		}
		

		[HttpPut]
		[Route("Presenca")]
		public ActionResult<ParticipanteResponseModel> Presenca(int idParticipante)
		{
			if (ModelState.IsValid)
			{
				return Ok(_svc.AtualizarPresenca(idParticipante));
			}
			return BadRequest(ModelState);
		}

		[HttpPut]
		[Route("Nota")]
		public ActionResult<ParticipanteResponseModel> Nota(int idParticipante, int nota, string comentario)
		{
			if (ModelState.IsValid)
			{
				return Ok(_svc.AtualizarNota(idParticipante, nota, comentario));
			}
			return BadRequest(ModelState);
		}
	}
}

