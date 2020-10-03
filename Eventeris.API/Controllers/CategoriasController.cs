using System;
using System.Collections.Generic;
using Eventeris.BLL.Services;
using Eventeris.DL.API.Response;
using Microsoft.AspNetCore.Mvc;

namespace Eventeris.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriasController : ControllerBase
	{
		private CategoriaService _svc;
		public CategoriasController(CategoriaService svc)
		{
			_svc = svc;
		}

		[HttpGet]
		public ActionResult<List<CategoriaResponseModel>> Get()
		{
			return _svc.ListarCategorias();
		}
	}
}