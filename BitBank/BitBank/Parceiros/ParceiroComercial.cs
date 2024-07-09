using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitBank.Sistemas;

namespace BitBank.Parceiros
{
    public class ParceiroComercial : IAutenticavel
    {
        public string Senha { get; set; }

        public ParceiroComercial()
        {
            Console.WriteLine("Criando parceiro comercial");
        }

        public bool Autenticar(string senha)
        {
            return Senha == senha;
        }
    }
}
