using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CslApoio.Models
{
    [DisplayName("Status do Terceiro")]
    public class StatusTerceiro : Entity
    {
        public IEnumerable<Funcionario> Funcionario { get; set; }

        public string Opcoes { get; set; }
    }
}
