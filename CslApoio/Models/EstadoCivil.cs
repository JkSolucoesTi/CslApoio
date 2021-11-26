using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CslApoio.Models
{
    [DisplayName("Estado Civil")]
    public class EstadoCivil : Entity
    {
        public IEnumerable<Funcionario> Funcionarios { get; set; }
        [DisplayName("Opções")]
        public string Opcoes { get; set; }
    }
}
