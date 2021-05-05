using Stefanini.Domain.Entity;
using System;

namespace Stefanini.DemoApp.Domain.Entities
{
    public class Aluno : BaseEntity
    {
        public virtual string Nome { get; set; }
        public virtual string Documento { get; set; }
    }
}
