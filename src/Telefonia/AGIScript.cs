using System.ComponentModel.DataAnnotations;

namespace Sufficit.Telefonia
{
    public class AGIScript
    {
        [StringLength(36)]
        [Required]
        public string id { get; set; }

        [StringLength(36)]
        [Required]
        public string idcontexto { get; set; }

        [StringLength(250)]
        [Required]
        public string descricao { get; set; }

        [Required]
        public bool ativo { get; set; }

        [StringLength(200)]
        [Required]
        public string destino { get; set; }

        [Required]
        public string dstid { get; set; }

        [Required]
        public string dstclasse { get; set; }

        #region PROPRIEDADES ANULAVEIS OU OPICIONAIS

        public string idusuario { get; set; }
        public string idoutros { get; set; }
        public string idcomercial { get; set; }
        public string idsuporte { get; set; }
        public string idfinanceiro { get; set; }
        public string idcancelamento { get; set; }

        #endregion

        [Required]
        public string sistema { get; set; }
        [Required]
        public string sistemaid { get; set; }
        [Required]
        public string sistemasenha { get; set; }
        [Required]
        public string sistemaficha { get; set; }
        [Required]
        public string sistemaendereco { get; set; }

        [StringLength(6)]
        public int? sistemaporta { get; set; }
        [Required]
        public string sistemadb { get; set; }
        [Required]
        public string sistemaboleto { get; set; }
        [Required]
        public string audio { get; set; }
        [Required]
        public string voz { get; set; }
        [Required]
        public string idioma { get; set; }
    }
}
