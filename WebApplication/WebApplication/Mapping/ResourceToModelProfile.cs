using AutoMapper;
using WebApplication.Dominio.Modelos;
using WebApplication.Resource;

namespace WebApplication.Mapping
{
    
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<AuthUsuarioResource, Usuario>();
            CreateMap<SaveUsuarioResource, Usuario>();
            CreateMap<SaveCompanhiaResource, Companhia>();
            CreateMap<SaveCompraResource, Compra>();
            CreateMap<SaveProdutoResource, Produto>();
            CreateMap<SaveItemResource, Item>();
        }

    }
}