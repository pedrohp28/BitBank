using System.Text.RegularExpressions;
using System.Threading.Channels;
using BitBank.Contas;
using BitBank.Funcionarios;
using BitBank.Parceiros;
using BitBank.Sistemas;


namespace BitBank
{
    class MainClass
    {
        static void Main(string[] args)
        {
            void CriandoClientes()
            {
                //Criando o cliente Gabriela
                Cliente gabriela = new Cliente("Gabriela", "123.456.789-00");
                gabriela.Profissao = "Desenvolvedora";

                //Criando a conta da Gabriela
                ContaCorrente contaGabriela = new ContaCorrente(gabriela, 863, 863147);

                Console.WriteLine($"Titular: {contaGabriela.Titular.Nome}");
                Console.WriteLine($"Agencia: {contaGabriela.Agencia}");
                Console.WriteLine($"Conta: {contaGabriela.Conta}");
                Console.WriteLine($"Saldo: {contaGabriela.Saldo}");

                // Saca da conta da Gabriela um valor
                contaGabriela.Sacar(80);
                Console.WriteLine($"\nSaldo: {contaGabriela.Saldo}");

                //Deposito na conta da Gabriela um valor
                contaGabriela.Depositar(3000);
                Console.WriteLine($"\nSaldo: {contaGabriela.Saldo}");

                //Criando cliente Bruno
                Cliente bruno = new Cliente("Bruno", "987.654.321-88");

                //Criando conta do Bruno
                ContaCorrente contaBruno = new ContaCorrente(bruno, 987, 987256);
                contaBruno.Saldo = 300;

                Console.WriteLine($"\nTitular: {contaBruno.Titular.Nome}");
                Console.WriteLine($"Agencia: {contaBruno.Agencia}");
                Console.WriteLine($"Conta: {contaBruno.Conta}");
                Console.WriteLine($"Saldo: {contaBruno.Saldo}");

                //Transferencia da conta da Gabriela para a do Bruno
                contaGabriela.Transferir(1000, contaBruno);
                Console.WriteLine($"\nSaldo Gabriela: {contaGabriela.Saldo}");
                Console.WriteLine($"Saldo Bruno: {contaBruno.Saldo}");

                //Exibindo total de contas criadas
                Console.WriteLine($"Total de contas: {ContaCorrente.ContasCriadas}");
                Console.WriteLine("\n**********************************\n");
            }
            CriandoClientes();

            void CalcularBonificacao()
            {
                //Criando gerenciador de bonificações
                GerenciadorDeBonificacao gerenciador = new GerenciadorDeBonificacao();

                //Criando os funcionários
                Designer pedro = new Designer("Pedrp", "833.222.048-39");

                Diretor roberta = new Diretor("Roberta", "159.753.398-04");

                Auxiliar igor = new Auxiliar("Igor", "981.198.778-53");

                GerenteDeConta camila = new GerenteDeConta("Camila", "326.985.628-89");

                //Incluindo os funcionários na soma das bonificações
                gerenciador.Registrar(pedro);
                gerenciador.Registrar(roberta);
                gerenciador.Registrar(igor);
                gerenciador.Registrar(camila);

                //Mostrando o total de bonificação
                Console.WriteLine($"Total de bonificações do mês: {gerenciador.TotalBonificacao()}");
                Console.WriteLine("\n**********************************\n");
            }
            CalcularBonificacao();

            void UsarSistema()
            {
                //Criando sistema de autenticação
                SistemaInterno sistema = new SistemaInterno();

                //Criando diretor e definindo uma senha
                Diretor roberta = new Diretor("Roberta", "159.753.398-04");
                roberta.Senha = "123";

                //Autenticando a senha
                sistema.Logar(roberta, "123");
                sistema.Logar(roberta, "abc");

                //Criando gerente de conta e definindo uma senha
                GerenteDeConta camila = new GerenteDeConta("Camila", "326.985.628-89");
                camila.Senha = "abc";

                //Autenticando a senha
                sistema.Logar(camila, "123");
                sistema.Logar(camila, "abc");

                //Criando parceiro comercial e definindo uma senha
                ParceiroComercial parceiro = new ParceiroComercial();
                parceiro.Senha = "123abc";

                //Autenticando a senha
                sistema.Logar(parceiro, "123abc");
            }
            UsarSistema();
        }       
    }
}
