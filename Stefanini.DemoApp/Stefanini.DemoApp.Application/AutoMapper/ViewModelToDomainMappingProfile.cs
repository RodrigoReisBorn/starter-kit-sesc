using AutoMapper;
using Stefanini.DemoApp.Application.ViewModel;
using Stefanini.DemoApp.Domain.Entities;

namespace Stefanini.DemoApp.Application
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AlunoViewModel, Aluno>();
        }
    }
}
