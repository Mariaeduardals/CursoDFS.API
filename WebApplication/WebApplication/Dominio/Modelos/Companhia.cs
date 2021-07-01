using System;
using System.Collections;
using System.Collections.Generic;

namespace WebApplication.Dominio.Modelos
{
    public class Companhia
    {
        
        public int Id { get; set; }  
        public string NomeFantasia {get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public IList<Produto> Produtos  { get; set; } 

    }
}