using Eventeris.DAL.Entidade;
using Eventeris.DAL.Repositorio;
using Eventeris.DL.API.Request;
using Eventeris.DL.API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eventeris.BLL.Services
{
    public class CategoriaService
    {
        private IRepositorioComum<CategoriaEvento> _repositorio;

        public CategoriaService(IRepositorioComum<CategoriaEvento> repositorio)
        {
            _repositorio = repositorio;
        }

        public List<CategoriaResponseModel> ListarCategorias()
        {
            var listaRetorno = new List<CategoriaResponseModel>();  // cria uma lista vazia
            //var _repositorio = new RepositorioComum<CategoriaEvento>();

            var lista = _repositorio.Listar();

            if (lista != null && lista.Any())
            {
                foreach (CategoriaEvento item in lista)
                    listaRetorno.Add(new CategoriaResponseModel(item.IdCategoriaEvento, item.NomeCategoria));
            }

            return listaRetorno;
        }
    }
}

