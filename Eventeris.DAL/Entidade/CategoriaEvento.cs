using Eventeris.DAL;
using System;
using System.Collections.Generic;

namespace Eventeris.DAL.Entidade
{
    public partial class CategoriaEvento
    {
        public CategoriaEvento()
        {
            Evento = new HashSet<Evento>();
        }

        public int IdCategoriaEvento { get; set; }
        public string NomeCategoria { get; set; }

        public virtual ICollection<Evento> Evento { get; set; }
    }
}
