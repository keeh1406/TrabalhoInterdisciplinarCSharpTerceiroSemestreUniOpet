using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aula1.Models
{
    public class Produto
    {
        public long ProdutoId { get; set; }

        public string Name { get; set; }

        public string DescricaoProduto { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataValidade { get; set; }

        public string MarcaId { get; set; }
        public Marca marca { get; set; }

        public string SetorId { get; set; }
        public Setor setor { get; set; }

        public long? FornecedorId { get; set; }
        public Fornecedor fornecedor { get; set; }

        public long? LojaId { get; set; }
        public Loja Loja { get; set; }
        
        public virtual ICollection<Venda> Vendas { get; set; }
    }
}