using Stefanini.DemoApp.Domain.Entities;
using Stefanini.DemoApp.Domain.Repositories;
using Stefanini.Repository.EntityFramework;

namespace Stefanini.DemoApp.Infrastructure.Data.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApplicationContext context)
            : base(context)
        { }
    }
}
