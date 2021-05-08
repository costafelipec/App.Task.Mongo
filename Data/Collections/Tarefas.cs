using System;

namespace task.Data.Collections
{
    public class Tarefas
    {
        public Tarefas(string nome, bool status, DateTime dataCriacao, DateTime dataConclusao)
        {
            this.Nome = nome;
            this.Status = status;
            this.DataCriacao = dataCriacao;
            this.DataConclusao = dataConclusao;            
        }
        
        public string _id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataConclusao { get; set; }
    }
}