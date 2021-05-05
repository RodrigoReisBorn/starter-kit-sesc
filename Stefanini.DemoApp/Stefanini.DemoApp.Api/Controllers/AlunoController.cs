using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Stefanini.Common;
using Stefanini.DemoApp.Application.Interfaces;
using Stefanini.DemoApp.Application.ViewModel;
using Stefanini.DemoApp.Domain.Entities;

namespace Stefanini.DemoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        private readonly IAlunoService _service;
        private readonly INotification _notification;

        public AlunoController(IAlunoService service,
                                   INotification notification)
        {
            this._service = service;
            this._notification = notification;
        }

        // GET: api/Aluno
        [HttpGet]
        public IEnumerable<AlunoViewModel> Get()
        {
            return this._service.GetAll();
        }

        // GET: api/Aluno/5
        [HttpGet("{id}", Name = "GetAluno")]
        public AlunoViewModel Get(int id)
        {
            return this._service.GetById(id);          
        }

        // POST: api/Aluno
        [HttpPost]
        public void Post([FromBody] AlunoViewModel aluno)
        {
            this._service.Insert(aluno);
        }

        // PUT: api/Aluno/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AlunoViewModel aluno)
        {
            this._service.Update(aluno);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._service.Delete(id);
        }
    }
}