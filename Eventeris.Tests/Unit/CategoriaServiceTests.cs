using Eventeris.BLL.Services;
using Eventeris.DAL.Entidade;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Eventeris.DAL.Repositorio;

namespace Eventeris.Tests.Unit
{
    public class CategoriaServiceTests : BLLServiceTestBase
    {
        private CategoriaService _service;

        [Fact]
        public void Deve_ListarCategoriasExistentes()
        {
            Mock<IRepositorioComum<CategoriaEvento>> mockRepo = new Mock<IRepositorioComum<CategoriaEvento>>();

            mockRepo.Setup(x => x.Listar())
            .Returns(new List<CategoriaEvento>() { new CategoriaEvento { NomeCategoria = "Nome", IdCategoriaEvento = 1 } });

            _service = new CategoriaService(mockRepo.Object);


            var result = _service.ListarCategorias();

            Assert.True(result.Any());
        }

        [Fact]
        public void Deve_RetornarListaVazia()
        {
            Mock<IRepositorioComum<CategoriaEvento>> mockRepo = new Mock<IRepositorioComum<CategoriaEvento>>();

            mockRepo.Setup(x => x.Listar())
            .Returns(new List<CategoriaEvento>());

            _service = new CategoriaService(mockRepo.Object);

            var result = _service.ListarCategorias();

            Assert.True(result != null);
            Assert.True(!result.Any());
        }

        [Fact]
        public void Deve_RetornarListaVazia2()
        {
            Mock<IRepositorioComum<CategoriaEvento>> mockRepo = new Mock<IRepositorioComum<CategoriaEvento>>();

            List<CategoriaEvento> listaNull = null;

            mockRepo.Setup(x => x.Listar()).Returns(listaNull);

            _service = new CategoriaService(mockRepo.Object);

            var result = _service.ListarCategorias();

            Assert.True(result != null);
            Assert.True(!result.Any());
        }
    }
}