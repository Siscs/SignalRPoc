using System;

namespace SignalRPoc.Models
{
    public class Indice
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public decimal Acumulado { get; set; }
        
    }

}
