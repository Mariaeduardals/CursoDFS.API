using System;
using WebApplication.Dominio.Modelos;

namespace WebApplication.Resource
{
    public class ProdutoResource
    {
        public int Id { get; set; }   
        public string Nome { get; set; }
        public float Valor { get; set; }
        public string Observacao { get; set; }
        public int CompanhiaId { get; set; }
        public Companhia Companhia { get; set; }
        public int IdCompra { get; set; }
        public Compra Compra { get; set; }
    }
}