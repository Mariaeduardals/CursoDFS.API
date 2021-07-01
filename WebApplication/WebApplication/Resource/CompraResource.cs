using Microsoft.EntityFrameworkCore.Storage;
using WebApplication.Dominio.Helpers;
using WebApplication.Dominio.Modelos;

namespace WebApplication.Resource
{
    public class CompraResource
    {
        public int Id { get; set; }
        public float Valor { get; set; }
        public Database Date { get; set; }
        public FormaPag FormaPagamento { get; set; }
        public StatusCompra Status { get; set; }
        public string Observaco { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
   
    }
}