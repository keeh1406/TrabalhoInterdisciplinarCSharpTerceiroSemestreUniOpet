﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Venda
    {
        public long VendaId { get; set; }

        public string DescricaoVenda { get; set; }

        public int QuantidadeProduto { get; set; }

        public decimal Valor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataVenda { get; set; }

        public long ProdutoId { get; set; }
        public long ClienteId { get; set; }
        public Produto Produto { get; set; }
        public Cliente Cliente { get; set; }
    }
}