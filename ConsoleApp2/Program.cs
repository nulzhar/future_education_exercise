using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool caracterValido = false;
            char resposta = 'A';

            while (!caracterValido)
            {
                Console.WriteLine("É terceirizado? S para Sim ou N para Não");
                Char.TryParse(Console.ReadLine().ToUpper(), out char resultado);
                resposta = resultado;
                if (resposta.Equals('S') || resposta.Equals('N'))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Caracter inválido, tente novamente!");
                }
            }

            Funcionario funcionario1 = new Funcionario("Filipe", 200, 40);
            Funcionario funcionario2 = new FuncionarioTerceiro("Filipe", 200, 40, "Capgemini", 0.5);

            if (resposta.Equals('S'))
            {
                funcionario2.ImprimeDados();
            }
            else
            {
                funcionario1.ImprimeDados();
            }
        }


    }

    public class Funcionario
    {
        public string Nome { get; set; }
        private int _cargaHoraria;
        private double _valorHora;

        public Funcionario()
        {

        }

        public Funcionario(string nome, int cargaHoraria, double valorHora)
        {
            Nome = nome;
            _cargaHoraria = cargaHoraria;
            _valorHora = valorHora;
        }

        public virtual double CalculaSalario()
        {
            return _valorHora * _cargaHoraria;
        }

        public virtual void ImprimeDados()
        {
            Console.WriteLine("Nome: {0} - Salário: R${1}", Nome, CalculaSalario());
        }
    }

    public class FuncionarioTerceiro : Funcionario
    {
        public string EmpresaOrigem { get; set; }
        public double TaxaServico { get; set; }

        public FuncionarioTerceiro()
        {

        }

        public FuncionarioTerceiro(string nome, int cargaHoraria, double valorHora, string empresaOrigem, double taxaServico)
            : base(nome, cargaHoraria, valorHora)
        {
            EmpresaOrigem = empresaOrigem;
            TaxaServico = taxaServico;
        }

        public override double CalculaSalario()
        {
            return base.CalculaSalario() * TaxaServico;
        }

        public override void ImprimeDados()
        {
            Console.WriteLine("Nome: {0} - Empresa de Origem: {2} - Salário: R${1}", Nome, CalculaSalario(), EmpresaOrigem);
        }
    }
}
