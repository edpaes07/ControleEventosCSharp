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
    public class ParticipanteControllerTests : IClassFixture<WebApplicationFactory<Eventeris.API.Startup>>
    {
        private readonly WebApplicationFactory<Eventeris.API.Startup> _factory;

        public ParticipanteControllerTests(WebApplicationFactory<Eventeris.API.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_Participantes()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/Participantes");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            string responseString = await response.Content.ReadAsStringAsync();

            Assert.True(responseString.Length > 0);
        }

        [Fact]
        public async Task Put_Participantes_Presenca()
        {
            var client = _factory.CreateClient();

            var response = await client.PutAsync("/api/Participantes/Presenca?idParticipante=3", new StringContent("", Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Put_Participantes_Nota()
        {
            var client = _factory.CreateClient();

            var response = await client.PutAsync("/api/Participantes/Nota?idParticipante=3", new StringContent("", Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Post_Participantes_Empty()
        {
            var client = _factory.CreateClient();

            var response = await client.PostAsync("/api/Participantes", new StringContent("", Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        public static IEnumerable<object[]> PostParticipantesTheoryData()
        {
            var allData = new List<object[]>
            {
            new object[] {
                new ParticipanteCreateRequest(),
                HttpStatusCode.BadRequest
                },
            new object[] {
                new ParticipanteCreateRequest(){
                    IdEvento = 1
                },
                HttpStatusCode.BadRequest
                },
            new object[] {
                new ParticipanteCreateRequest(){
                    IdEvento = 1,
                    LoginParticipante = "Teste" }
                ,
                HttpStatusCode.OK
                }/*,
            new object[] {
                new ParticipanteCreateRequest(){
                    IdEvento = 1,
                    LoginParticipante = "Teste",
                    FlagPresente = true
                },
                HttpStatusCode.BadRequest
                }
            ,
            new object[] {
                new ParticipanteCreateRequest(){
                    IdEvento = 1,
                    LoginParticipante = "Teste",
                    FlagPresente = true,
                    Nota = 10
                },
                HttpStatusCode.BadRequest
                }
            ,
            new object[] {
                new ParticipanteCreateRequest(){
                    IdEvento = 1,
                    LoginParticipante = "Teste",
                    FlagPresente = true,
                    Nota = 10,
                    Comentario = "Teste"
                },
                HttpStatusCode.OK
                }*/
            };
            return allData;
        }

        [Theory]
        [MemberData(nameof(PostParticipantesTheoryData))]
        public async Task Post_Participantes_Theory(ParticipanteCreateRequest model, HttpStatusCode statusCode)
        {
            var jsonString = JsonConvert.SerializeObject(model);

            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var client = _factory.CreateClient();

            var response = await client.PostAsync("/api/Participantes", httpContent);

            Assert.Equal(statusCode, response.StatusCode);
        }
    }
}
