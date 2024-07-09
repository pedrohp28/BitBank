//using BitBank;

using System.Drawing;

namespace BitBank.Contas
{
    public class ContaCorrente
    {

        public Cliente Titular { get; set; }
        private int _agencia;
        public int Agencia
        {
            get { return _agencia; }
            set
            {
                if (value > 0)
                {
                    _agencia = value;
                }
            }
        }
        public int Conta { get; set; }
        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value > 0)
                {
                    _saldo = value;
                }
            }
        }
        public static int ContasCriadas { get; private set; }

        public ContaCorrente(Cliente titular, int agencia, int conta)
        {
            Titular = titular;
            Agencia = agencia;
            Conta = conta;
            ContasCriadas++;
        }

        public bool Sacar(double valor)
        {
            if (valor <= _saldo)
            {
                _saldo -= valor;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public bool Transferir(double valor, ContaCorrente conta)
        {
            if (valor <= _saldo)
            {
                _saldo -= valor;
                conta.Depositar(valor);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
