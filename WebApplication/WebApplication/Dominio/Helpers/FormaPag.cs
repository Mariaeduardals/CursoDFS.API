using System;
using System.ComponentModel;

namespace WebApplication.Dominio.Helpers
{
    public enum FormaPag : long
    {
     //int Id;   
    // string Descrição;
    
    [Description("Cartao")]
    Cartao=1,
    
    [Description("Dinheiro")]
    Dinheiro=2
    

    }
}