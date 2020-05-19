using System;
using System.Collections.Generic;
using System.Text;

namespace PKUMonitor.Entidades
{
    public abstract class BaseDTO
    {
        public string Id { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
