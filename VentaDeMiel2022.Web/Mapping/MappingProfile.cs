using AutoMapper;
using VentaDeMiel2022.Entidades.Dtos;
using VentaDeMiel2022.Entidades.Entidades;
using VentaDeMiel2022.Web.Models.Envase;
using VentaDeMiel2022.Web.Models.Localidad;
using VentaDeMiel2022.Web.Models.Pais;
using VentaDeMiel2022.Web.Models.Provincia;
using VentaDeMiel2022.Web.Models.TipoEnvase;
using VentaDeMiel2022.Web.ViewModels.TipoEnvase;

namespace VentaDeMiel2022.Web.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            LoadPaisMapping();
            LoadProvinciaMapping();
            LoadLocalidadMapping();
            LoadTipoEnvaseMapping();
            LoadEnvaseMapping();
        }

       

        private void LoadLocalidadMapping()
        {
            CreateMap<Localidad, LocalidadEditVm>().ReverseMap();
       
            CreateMap<LocalidadListDto, LocalidadListVm>();

           
        }

        private void LoadProvinciaMapping()
        {
            CreateMap<Provincia, ProvinciaEditVm>().ReverseMap();
            CreateMap<ProvinciaListDto, ProvinciaListVm>();
            CreateMap<ProvinciaListDto, Provincia>();


        }

        private void LoadPaisMapping()
        {
           
            CreateMap<Pais, PaisEditVm>().ReverseMap();
            CreateMap<Pais, PaisListVm>();

        }

        private void LoadTipoEnvaseMapping()
        {

            CreateMap<TipoEnvase, TipoEnvaseEditVm>().ReverseMap();
            CreateMap<TipoEnvase, TipoEnvaseListVm>();
            CreateMap<TipoEnvase, TipoEnvaseListDto>();


        }
        private void LoadEnvaseMapping()
        {
            CreateMap<EnvaseListDto, EnvaseListVm>();
            CreateMap<Envase, EnvaseEditVm>().ReverseMap();
            CreateMap<Envase, EnvaseListVm>()
                .ForMember(dest => dest.TipoEnvase, opt => opt.MapFrom(src => src.TipoEnvase.Descripcion));
        }

    }
}