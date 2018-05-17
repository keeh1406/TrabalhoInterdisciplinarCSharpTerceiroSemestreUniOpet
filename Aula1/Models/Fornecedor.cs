using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula1.Models
{
    public class Fornecedor
    {
        public long FornecedorId { get; set; }

        public string Name { get; set; }

        public long Telefone { get; set; }

        public long CNPJ { get; set; }
    }
}