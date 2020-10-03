using Eventeris.BLL.Services;
using Eventeris.DAL.Entidade;
using Eventeris.DL.API.Request;
using Eventeris.DL.API.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Eventeris.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private EventoService _svc;

        public EventosController(EventoService svc)
        {
            _svc = svc;
        }

        [HttpGet]
        public ActionResult<List<EventoResponseModel>> Get()
        {
            return _svc.ListarEventos();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<EventoResponseModel> Get([FromRoute]int id)
        {
            return _svc.ObterEvento(id);
        }

        [HttpPost]
        public ActionResult<EventoResponseModel> Post(EventoCreateRequest model)
        {
            if (ModelState.IsValid)
            {
                return Ok(_svc.InserirEvento(model));
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("Iniciar")]
        public ActionResult<EventoResponseModel> Iniciar(int idEvento)
        {
            if (ModelState.IsValid)
            {
                return Ok(_svc.IniciarEvento(idEvento));
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("Cancelar")]
        public ActionResult<EventoResponseModel> Cancelar(int idEvento)
        {
            if (ModelState.IsValid)
            {
                return Ok(_svc.CancelarEvento(idEvento));
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("Concluir")]
        public ActionResult<EventoResponseModel> Concluir(int idEvento)
        {
            if (ModelState.IsValid)
            {
                return Ok(_svc.ConcluirEvento(idEvento));
            }

            return BadRequest(ModelState);
        }
    }
}
