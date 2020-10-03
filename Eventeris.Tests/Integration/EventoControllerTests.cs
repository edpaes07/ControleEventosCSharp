using System;
using System.Collections.Generic;
using System.Text;
using Eventeris.DL.API.Request;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Eventeris.Tests.Integration
{
    public class EventoControllerTests : IClassFixture<WebApplicationFactory<Eventeris.API.Startup>>
	{
		private readonly WebApplicationFactory<Eventeris.API.Startup> _factory;

		public EventoControllerTests(WebApplicationFactory<Eventeris.API.Startup> factory)
		{
			_factory = factory;
		}

		[Fact]
		public async Task Get_Eventos()
		{
			var client = _factory.CreateClient();

			var response = await client.GetAsync("/api/Eventos");

			Assert.Equal(HttpStatusCode.OK, response.StatusCode);

			string responseString = await response.Content.ReadAsStringAsync();

			Assert.True(responseString.Length > 0);
		}

		[Fact]
		public async Task Put_Eventos_Iniciar()
		{
			var client = _factory.CreateClient();

			var response = await client.PutAsync("/api/Eventos/Inicar/?idEvento=1", new StringContent("", Encoding.UTF8, "application/json"));

			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}

		[Fact]
		public async Task Put_Eventos_Cancelar()
		{
			var client = _factory.CreateClient();

			var response = await client.PutAsync("/api/Eventos/Cancelar/?idEvento=1", new StringContent("", Encoding.UTF8, "application/json"));

			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}

		[Fact]
		public async Task Put_Eventos_Concluir()
		{
			var client = _factory.CreateClient();

			var response = await client.PutAsync("/api/Eventos/Concluir/?idEvento=1", new StringContent("", Encoding.UTF8, "application/json"));

			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}

		[Fact]
		public async Task Post_Eventos_Empty()
		{
			var client = _factory.CreateClient();

			var response = await client.PostAsync("/api/Eventos", new StringContent("", Encoding.UTF8, "application/json"));

			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}

		public static IEnumerable<object[]> PostEventosTheoryData()
		{
			var allData = new List<object[]>
			{
			new object[] {
				new EventoCreateRequest(),
				HttpStatusCode.BadRequest
				},
			new object[] {
				new EventoCreateRequest(){
					Nome = "Teste"
				},
				HttpStatusCode.BadRequest
				},
			new object[] {
				new EventoCreateRequest(){
					Nome = "Teste",
					IdCategoriaEvento = 1 }
				,
				HttpStatusCode.BadRequest
				},
			new object[] {
				new EventoCreateRequest(){
					Nome = "Teste",
					IdCategoriaEvento = 1,
					DataHoraInicio = DateTime.Now
				},
				HttpStatusCode.BadRequest
				}
			,
			new object[] {
				new EventoCreateRequest(){
					Nome = "Teste",
					IdCategoriaEvento = 1,
					DataHoraInicio = DateTime.Now,
					DataHoraFim = DateTime.Now
				},
				HttpStatusCode.BadRequest
				}
			,
			new object[] {
				new EventoCreateRequest(){
					Nome = "Teste",
					IdCategoriaEvento = 1,
					DataHoraInicio = DateTime.Now,
					DataHoraFim = DateTime.Now,
					Local = "Teste"
				},
				HttpStatusCode.BadRequest
				}
			,
			new object[] {
				new EventoCreateRequest(){
					Nome = "Teste",
					IdCategoriaEvento = 1,
					DataHoraInicio = DateTime.Now,
					DataHoraFim = DateTime.Now,
					Local = "Teste",
					Descricao = "Teste"
				},
				HttpStatusCode.OK
				},
			new object[] {
				new EventoCreateRequest(){
					Nome = "Teste",
					IdCategoriaEvento = 1,
					DataHoraInicio = DateTime.Now,
					DataHoraFim = DateTime.Now,
					Local = "Teste",
					Descricao = "Teste",
					LimiteVagas = 50
				},
				HttpStatusCode.OK
				}
			}
			;

			return allData;
		}

		[Theory]
		[MemberData(nameof(PostEventosTheoryData))]
		public async Task Post_Eventos_Theory(EventoCreateRequest model, HttpStatusCode statusCode)
		{
			var jsonString = JsonConvert.SerializeObject(model);

			// Wrap our JSON inside a StringContent which then can be used by the HttpClient class
			var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

			var client = _factory.CreateClient();

			var response = await client.PostAsync("/api/Eventos", httpContent);

			Assert.Equal(statusCode, response.StatusCode);
		}
	}
}
