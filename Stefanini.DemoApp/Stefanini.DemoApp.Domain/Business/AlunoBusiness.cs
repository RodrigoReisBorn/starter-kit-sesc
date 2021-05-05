using FluentValidation;
using Stefanini.DemoApp.Domain.Entities;
using Stefanini.DemoApp.Domain.Repositories;
using Stefanini.Business;
using Stefanini.Common;
using Stefanini.DemoApp.Domain.Business.Interfaces;

namespace Stefanini.DemoApp.Domain.Business
{
    public class AlunoBusiness : CrudBusiness<Aluno>, IAlunoBusiness
    {
        public AlunoBusiness(IAlunoRepository repository,
            IValidator<Aluno> validator,
            INotification notification)
            : base(repository, validator, notification)
        { }
    }
}
