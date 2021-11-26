using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CslApoio.Models
{
    [DisplayName("Dependencias")]
    public class Dependencia : Entity
    {
        public IEnumerable<Funcionario> Funcionarios { get; set; }

        public string Opcoes { get; set; }
    }
}
