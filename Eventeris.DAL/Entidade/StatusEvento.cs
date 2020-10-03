using System;
using System.Collections.Generic;

namespace Eventeris.DAL.Entidade
{
    public partial class StatusEvento
    {
        public StatusEvento()
        {
            Evento = new HashSet<Evento>();
        }

        public int IdEventoStatus { get; set; }
        public string NomeStatus { get; set; }

        public virtual ICollection<Evento> Evento { get; set; }
    }
}
