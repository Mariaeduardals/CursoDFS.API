using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage;
using WebApplication.Dominio.Helpers;

namespace WebApplication.Dominio.Modelos
{
    public class Compra
    {
        public int Id { get; set; }
        public float Valor { get; set; }
        public DateTime Date { get; set; }
        public FormaPag FormaPagamento { get; set; }
        public StatusCompra Status { get; set; }
        public string Observacao { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        
        [JsonIgnore] 
        public Usuario Usuario { get; set; }
               
        public int UsuarioId { get; set; }
               
        [JsonInclude]
        public IList<Item> Items { get; set; }
        
    }

}