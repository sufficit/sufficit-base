using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.Telefonia
{
    public class WebCallBack
    {
        public Guid IDContexto { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string Destino { get; set; } = string.Empty;

        public List<Discagem> Discagens { get; set; } = new List<Discagem>();

        public int Codigo { get; set; }
    }
}
