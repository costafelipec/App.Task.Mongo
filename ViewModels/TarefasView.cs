using System;

namespace task.ViewModels
{
    public class TarefasView
    {
        public string _id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataConclusao { get; set; }
        
    }
}