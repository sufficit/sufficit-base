﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Relacionamento
{
    public class Atributo
    {
        public string Titulo { get; set; }
        public string Valor { get; set; }
        public string Descricao { get; set; }

        public Atributo() { }

        public Atributo(string Titulo, string Valor, string Descricao)
        {
            this.Titulo = Titulo;
            this.Valor = Valor;
            this.Descricao = Descricao;
        }
    }

}