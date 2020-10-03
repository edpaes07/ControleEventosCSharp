using System.Collections.Generic;
using System.Linq;
using Xunit;
using Eventeris.DAL.Repositorio;
using Eventeris.DL.API.Request;
using Eventeris.BLL.Services;
using Eventeris.DAL.Entidade;
using System;

namespace Eventeris.Tests.Unit
{
    public class ParticipanteServiceTests : BLLServiceTestBase
    {
        private ParticipanteService _service;

        public ParticipanteServiceTests()
        {
            var repo = new RepositorioParticipante(base.GetMockUser(),
            new RepositorioComum<Participacao>(base.GetMockUser()));
            _service = new ParticipanteService(repo);

        }

        [Fact]
        public void ListarParticipantes()
        {
            var result = _service.ListarParticipantes();

            Assert.True(result.Any());
        }

        [Fact]
        public void InserirParticipante_Vazio()
        {
            var result = _service.InserirParticipante(null);

            Assert.Null(result);
        }

        public static IEnumerable<object[]> PostParticipantesTheoryData()
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
        [MemberData(nameof(PostParticipantesTheoryData))]
        public void InserirParticipante_Vazio_Theory(ParticipanteCreateRequest model, bool equalsNull)
        {
            var result = _service.InserirParticipante(model);

            Assert.True((result == null) == equalsNull);
        }
    }
}