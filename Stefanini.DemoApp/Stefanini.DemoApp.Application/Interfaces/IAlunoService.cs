using Stefanini.Application;
using Stefanini.DemoApp.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stefanini.DemoApp.Application.Interfaces
{
    public interface IAlunoService : IBaseService
    {
        void Delete(int id);
        IEnumerable<AlunoViewModel> GetAll();
        AlunoViewModel GetById(int id);
        void Insert(AlunoViewModel entity);
        void Update(AlunoViewModel entity);
    }
}
