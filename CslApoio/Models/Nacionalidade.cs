using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CslApoio.Models
{
    public class Nacionalidade : Entity
    {
        public IEnumerable<Funcionario> Funcionarios { get; set; }

        public string Opcoes { get; set; }

    }
}
