using System;
using System.Collections.Generic;

namespace Sufficit.Telefonia
{
    public class Enquete
    {
        public Enquete()
        {
            Opcoes = new List<Opcoes>();
        }

        public Guid ID { get; set; }
        public Guid IDContexto { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public List<Opcoes> Opcoes { get; set; }

        public class Resposta
        {
            public Guid IDEnquete { get; set; }
            public DateTime Cadastro { get; set; }
            public string Origem { get; set; } = string.Empty;
            public string Valor { get; set; } = string.Empty;
        }


    }

    public class Opcoes
    {
        public Guid IDEnquete { get; set; }
        public string Valor { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}
