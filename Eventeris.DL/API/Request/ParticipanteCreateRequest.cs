using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eventeris.DL.API.Request
{
    public class ParticipanteCreateRequest
    {
        [Required]
        public int IdEvento { get; set; }

        [Required]
        [StringLength(250)]
        public string LoginParticipante { get; set; }
    }
}
