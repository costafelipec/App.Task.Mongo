using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using task.Data.Collections;

namespace task.Controllers
{
   [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Tarefas> _tarefaCollection;

        public TarefaController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _tarefaCollection = _mongoDB.DB.GetCollection<Tarefas>(typeof(Tarefas).Name.ToLower(), null);
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] Tarefas dto)
        {
            var tarefa = new Tarefas(dto.Nome, dto.Status, dto.DataCriacao, dto.DataConclusao);
            _tarefaCollection.InsertOne(tarefa);            
            return StatusCode(201, "Tarefa adicionada com sucesso!");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var tarefa = _tarefaCollection.Find(Builders<Tarefas>.Filter.Empty).ToList();            
            return Ok(tarefa);
        }
    }
}