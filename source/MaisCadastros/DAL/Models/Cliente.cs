﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Cliente
    {
        public long ClienteId { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        public string Endereco { get; set; }

        public long Telefone { get; set; }

        public string Email { get; set; }

        public long CPF { get; set; }

    }
}