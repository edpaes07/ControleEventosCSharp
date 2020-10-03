using Eventeris.DAL;
using System;
using System.Collections.Generic;

namespace Eventeris.DAL.Entidade
{
    public partial class Evento
    {
        public Evento()
        {
            Participacao = new HashSet<Participacao>();
        }

        public int IdEvento { get; set; }
        public int IdEventoStatus { get; set; }
        public int IdCategoriaEvento { get; set; }
        public string Nome { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public string Local { get; set; }
        public string Descricao { get; set; }
        public int LimiteVagas { get; set; }

        public virtual CategoriaEvento IdCategoriaEventoNavigation { get; set; }
        public virtual StatusEvento IdEventoStatusNavigation { get; set; }
        public virtual ICollection<Participacao> Participacao { get; set; }
    }
}
