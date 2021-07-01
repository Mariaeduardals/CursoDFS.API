using AutoMapper;
using WebApplication.Dominio.Modelos;
using WebApplication.Resource;

namespace WebApplication.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        
        public  ModelToResourceProfile()
        {
           
            CreateMap<Usuario, UsuarioResource>();
            CreateMap<Companhia, CompanhiaResource>();
            CreateMap<Compra, CompraResource>();
            CreateMap<Produto, ProdutoResource>();
            CreateMap<Item, ItemResource>();
        }
    }
}