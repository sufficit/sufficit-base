﻿using Sufficit.Exchange;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sufficit.Notification
{
    public class Contact
    {
        [Key]
        public Guid IDContact { get; set; }
        public Guid IDContext { get; set; }

        [MaxLength(11)]
        public int Priority { get; set; }

        public TChannel Channel { get; set; }

        [MaxLength(200)]
        public string Destination { get; set; } = default!;

        /// <summary>
        /// Informações extras
        /// </summary>
        [MaxLength(200)]
        public string? Extra { get; set; }

        /// <summary>
        /// Motivo para bloqueio
        /// </summary>
        [MaxLength(200)]
        public string? Cause { get; set; }
    }
}
