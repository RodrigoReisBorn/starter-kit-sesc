using AutoMapper;
using Stefanini.DemoApp.Application.ViewModel;
using Stefanini.DemoApp.Domain.Entities;

namespace Stefanini.DemoApp.Application
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Aluno, AlunoViewModel>();
        }
    }
}
