using System;
using System.Collections;
using System.Collections.Generic;

namespace WebApplication.Dominio.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        
        public IList<Compra> Compra { get; set; }
    }
}