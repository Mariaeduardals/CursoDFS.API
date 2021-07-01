using System;
using System.ComponentModel;

namespace WebApplication.Dominio.Helpers
{
    public enum StatusCompra : long
    {
    
    // int Id;   
     //string Descrição;
    
    [Description("Paga")]
    Paga=1,
    
    [Description("Aberta")]
    Aberta=2
    
    }
}