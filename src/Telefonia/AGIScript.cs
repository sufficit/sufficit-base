using System.ComponentModel.DataAnnotations;

namespace Sufficit.Telefonia
{
    public class AGIScript
    {
        [StringLength(36)]
        [Required]
        public string id { get; set; } = default!;

        [StringLength(36)]
        [Required]
        public string idcontexto { get; set; } = string.Empty;

        [StringLength(250)]
        [Required]
        public string descricao { get; set; } = string.Empty;

        [Required]
        public bool ativo { get; set; }

        [StringLength(200)]
        [Required]
        public string destino { get; set; } = string.Empty;

        [Required]
        public string dstid { get; set; } = string.Empty;

        [Required]
        public string dstclasse { get; set; } = string.Empty;

        #region PROPRIEDADES ANULAVEIS OU OPICIONAIS

        public string idusuario { get; set; } = string.Empty;
        public string idoutros { get; set; } = string.Empty;
        public string idcomercial { get; set; } = string.Empty;
        public string idsuporte { get; set; } = string.Empty;
        public string idfinanceiro { get; set; } = string.Empty;
        public string idcancelamento { get; set; } = string.Empty;

        #endregion

        [Required]
        public string sistema { get; set; } = string.Empty;
        [Required]
        public string sistemaid { get; set; } = string.Empty;
        [Required]
        public string sistemasenha { get; set; } = string.Empty;
        [Required]
        public string sistemaficha { get; set; } = string.Empty;
        [Required]
        public string sistemaendereco { get; set; } = string.Empty;

        [StringLength(6)]
        public int? sistemaporta { get; set; }
        [Required]
        public string sistemadb { get; set; } = string.Empty;
        [Required]
        public string sistemaboleto { get; set; } = string.Empty;
        [Required]
        public string audio { get; set; } = string.Empty;
        [Required]
        public string voz { get; set; } = string.Empty;
        [Required]
        public string idioma { get; set; } = string.Empty;
    }
}
