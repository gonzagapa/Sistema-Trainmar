using AutoMapper;
using TareasMVC.Entidades;
using TareasMVC.Models;
using TareasMVC.Models.Renec;

namespace TareasMVC.Servicios
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<Tarea, TareaDTO>()
            //    .ForMember(dto => dto.PasosTotal, ent => ent.MapFrom(x => x.Pasos.Count()))
            //    .ForMember(dto => dto.PasosRealizados, ent =>
            //            ent.MapFrom(x => x.Pasos.Where(p => p.Realizado).Count()));
            CreateMap<TerminalViewModel, Terminal>();
            //De un modelo a una entidad de mi base de datos
            CreateMap<EvaluacionViewModel, Evaluacion>();

            CreateMap<RENECViewModel, RENEC>();
            CreateMap<RENEC, RENECViewModel>();
        }
    }
}
