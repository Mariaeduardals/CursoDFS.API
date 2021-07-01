using System;
using System.Text.Json.Serialization;

namespace WebApplication.Dominio.Modelos
{
    public class Produto
    {
        public int Id { get; set; }   
        public string Nome { get; set; }
        public float Valor { get; set; }
        public string Observacao { get; set; }
        public int CompanhiaId { get; set; }
        
        [JsonIgnore]
        public Companhia Companhia { get; set; }
        
    }
}