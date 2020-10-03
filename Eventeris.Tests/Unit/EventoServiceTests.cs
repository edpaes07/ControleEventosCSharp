using System.Collections.Generic;
using System.Linq;
using Xunit;
using Eventeris.DAL.Repositorio;
using Eventeris.DL.API.Request;
using Eventeris.BLL.Services;
using Eventeris.DAL.Entidade;
using System;
using Eventeris.DAL.Interface;
using System.Net;

namespace Eventeris.Tests.Unit
{
    public class EventoServiceTests : BLLServiceTestBase
    {
        private EventoService _service;

        public EventoServiceTests()
        {
            var repo = new RepositorioEvento(base.GetMockUser(),
            new RepositorioComum<Evento>(base.GetMockUser()));
            _service = new EventoService(repo);

        }

        [Fact]
        public void ListarEventos()
        {
            var result = _service.ListarEventos();

            Assert.True(result.Any());
        }

        [Fact]
        public void InserirEvento_Vazio()
        {
            var result = _service.InserirEvento(null);

            Assert.Null(result);
        }

        public static IEnumerable<object[]> PostEventosTheoryData()
        {
            var allData = new List<object[]>
            {
            new object[] {
                null,
                true
                }
            }
            ;

            return allData;
        }

        [Theory]
        [MemberData(nameof(PostEventosTheoryData))]
        public void InserirEvento_Vazio_Theory(EventoCreateRequest model, bool equalsNull)
        {
            var result = _service.InserirEvento(model);

            Assert.True((result == null) == equalsNull);
        }
    }
}