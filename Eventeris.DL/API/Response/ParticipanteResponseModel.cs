using System;
using System.Collections.Generic;
using System.Text;

namespace Eventeris.DL.API.Response
{
    public class ParticipanteResponseModel
    {
        public ParticipanteResponseModel(int idPar, int idEv, string nome, bool presenca,
            int? nota, string coment)
        {
            IdPar = idPar;
            IdEv = idEv;
            Nome = nome;
            Presenca = presenca;
            Nota = nota;
            Coment = coment;
        }

        public int IdPar { get; set; }
        public int IdEv { get; set; }
        public string Nome { get; set; }
        public bool Presenca { get; set; }
        public int? Nota { get; set; }
        public string Coment { get; set; }
    }
}