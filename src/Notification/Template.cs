using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sufficit.Notification
{
    public class Template
    {
        [Key]
        [MaxLength(50)]
        public string Title { get; set; } = default!;

        [Column(TypeName = "longtext")]
        public string Body { get; set; } = default!;
    }    
}
