using Eventeris.DAL.Contexto;
using Eventeris.DAL.Entidade;
using Eventeris.DAL.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventeris.DAL.Interface
{
    public interface IRepositorioEvento : IRepositorioComum<Evento>
    {

        Evento InserirEvento(Evento model);
        Evento Iniciar(Evento model);
        public Evento Cancelar(Evento model);
        public Evento Concluir(Evento model);
    }
}
