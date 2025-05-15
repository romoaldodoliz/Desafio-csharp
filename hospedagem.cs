using System;
using System.Collections.Generic;

// Classe Pessoa
public class Pessoa
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }

    public Pessoa(string nome, string sobrenome)
    {
        Nome = nome;
        Sobrenome = sobrenome;
    }
}

// Classe Suite
public class Suite
{
    public string TipoSuite { get; set; }
    public int Capacidade { get; set; }
    public decimal ValorDiaria { get; set; }

    public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
    {
        TipoSuite = tipoSuite;
        Capacidade = capacidade;
        ValorDiaria = valorDiaria;
    }
}

// Classe Reserva
public class Reserva
{
    public List<Pessoa> Hospedes { get; private set; }
    public Suite Suite { get; private set; }
    public int DiasReservados { get; set; }

    public Reserva()
    {
        Hospedes = new List<Pessoa>();
    }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
        if (Suite == null)
        {
            throw new Exception("Suite não cadastrada. Cadastre uma suite antes de adicionar hóspedes.");
        }

        if (hospedes.Count > Suite.Capacidade)
        {
            throw new Exception($"A suíte selecionada tem capacidade para {Suite.Capacidade} hóspedes.");
        }

        Hospedes = hospedes;
    }

    public void CadastrarSuite(Suite suite)
    {
        Suite = suite;
    }

    public int ObterQuantidadeHospedes()
    {
        return Hospedes.Count;
    }

    public decimal CalcularValorDiaria()
    {
        if (Suite == null || DiasReservados <= 0)
        {
            throw new Exception("Dados incompletos para cálculo da diária.");
        }

        decimal valorTotal = DiasReservados * Suite.ValorDiaria;

        // Aplicar desconto de 10% para reservas com 10 ou mais dias
        if (DiasReservados >= 10)
        {
            valorTotal *= 0.9m; // 10% de desconto
        }

        return valorTotal;
    }
}

// Programa principal
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Sistema de Hospedagem\n");

        // Criar algumas pessoas
        var pessoa1 = new Pessoa("João", "Silva");
        var pessoa2 = new Pessoa("Maria", "Santos");
        var pessoa3 = new Pessoa("Pedro", "Oliveira");

        // Criar uma suíte
        var suitePremium = new Suite("Premium", 2, 250.00m);
        var suiteLuxo = new Suite("Luxo", 4, 400.00m);

        // Criar reserva
        var reserva = new Reserva();

        try
        {
            // Cadastrar suíte
            reserva.CadastrarSuite(suitePremium);

            // Cadastrar hóspedes
            reserva.CadastrarHospedes(new List<Pessoa> { pessoa1, pessoa2 });

            // Definir dias reservados
            reserva.DiasReservados = 5;

            // Exibir informações
            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Suíte: {reserva.Suite.TipoSuite}");
            Console.WriteLine($"Valor total da diária: R$ {reserva.CalcularValorDiaria():F2}");

            // Tentativa com mais hóspedes que a capacidade (deve lançar exceção)
            // reserva.CadastrarHospedes(new List<Pessoa> { pessoa1, pessoa2, pessoa3 });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}