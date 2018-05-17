using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aula1.Models
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