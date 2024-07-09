using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBank.Funcionarios
{
    public class Designer : Funcionario
    {
        public Designer(string nome, string cPF) : base(nome, cPF, 3000)
        {
            Console.WriteLine("Criando Designer");
        }

        public override double GetBonificacao()
        {
            return Salario * 0.17;
        }

        public override void AumentarSalario()
        {
            Salario *= 1.11;
        }
    }
}
