using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Relacionamento
{
    public class Grupo
    {
        public Guid ID { get; set; }
        public string Titulo { get; set; }

        public virtual int Contador { get; set; }
        public virtual IEnumerable<Contato> Membros { get; set; }
    }
}
