using System;
using System.Collections.Generic;

// Classe abstrata base para todos os celulares
public abstract class Celular
{
    public string Marca { get; protected set; }
    public string Modelo { get; protected set; }
    public double TamanhoTela { get; protected set; } // em polegadas
    public int CapacidadeBateria { get; protected set; } // em mAh
    
    public abstract void Ligar();
    public abstract void Desligar();
    public abstract void FazerLigacao(string numero);
    public abstract void EnviarMensagem(string numero, string mensagem);
    
    public virtual void MostrarEspecificacoes()
    {
        Console.WriteLine($"\n📱 {Marca} {Modelo}");
        Console.WriteLine($"🔍 Tela: {TamanhoTela}\"");
        Console.WriteLine($"🔋 Bateria: {CapacidadeBateria}mAh");
    }
}

// Implementação concreta para iPhone
public class IPhone : Celular
{
    public IPhone(string modelo, double tamanhoTela, int capacidadeBateria)
    {
        Marca = "Apple";
        Modelo = modelo;
        TamanhoTela = tamanhoTela;
        CapacidadeBateria = capacidadeBateria;
    }
    
    public override void Ligar()
    {
        Console.WriteLine($"{Marca} {Modelo}: Ligando com Face ID...");
    }
    
    public override void Desligar()
    {
        Console.WriteLine($"{Marca} {Modelo}: Desligando dispositivo iOS...");
    }
    
    public override void FazerLigacao(string numero)
    {
        Console.WriteLine($"{Marca} {Modelo}: Chamando {numero} via FaceTime...");
    }
    
    public override void EnviarMensagem(string numero, string mensagem)
    {
        Console.WriteLine($"{Marca} {Modelo}: Enviando iMessage para {numero}: {mensagem}");
    }
    
    public override void MostrarEspecificacoes()
    {
        base.MostrarEspecificacoes();
        Console.WriteLine("🛠️ Sistema Operacional: iOS");
    }
}

// Implementação concreta para Samsung
public class Samsung : Celular
{
    public Samsung(string modelo, double tamanhoTela, int capacidadeBateria)
    {
        Marca = "Samsung";
        Modelo = modelo;
        TamanhoTela = tamanhoTela;
        CapacidadeBateria = capacidadeBateria;
    }
    
    public override void Ligar()
    {
        Console.WriteLine($"{Marca} {Modelo}: Ligando com leitor de digital...");
    }
    
    public override void Desligar()
    {
        Console.WriteLine($"{Marca} {Modelo}: Desligando dispositivo Android...");
    }
    
    public override void FazerLigacao(string numero)
    {
        Console.WriteLine($"{Marca} {Modelo}: Chamando {numero}...");
    }
    
    public override void EnviarMensagem(string numero, string mensagem)
    {
        Console.WriteLine($"{Marca} {Modelo}: Enviando mensagem via Samsung Messages para {numero}: {mensagem}");
    }
    
    public override void MostrarEspecificacoes()
    {
        base.MostrarEspecificacoes();
        Console.WriteLine("🛠️ Sistema Operacional: Android");
    }
}

// Implementação concreta para Xiaomi
public class Xiaomi : Celular
{
    public bool TemInfravermelho { get; private set; }
    
    public Xiaomi(string modelo, double tamanhoTela, int capacidadeBateria, bool temInfravermelho)
        : base()
    {
        Marca = "Xiaomi";
        Modelo = modelo;
        TamanhoTela = tamanhoTela;
        CapacidadeBateria = capacidadeBateria;
        TemInfravermelho = temInfravermelho;
    }
    
    public override void Ligar()
    {
        Console.WriteLine($"{Marca} {Modelo}: Ligando com MIUI...");
    }
    
    public override void Desligar()
    {
        Console.WriteLine($"{Marca} {Modelo}: Desligando dispositivo MIUI...");
    }
    
    public override void FazerLigacao(string numero)
    {
        Console.WriteLine($"{Marca} {Modelo}: Chamando {numero}...");
    }
    
    public override void EnviarMensagem(string numero, string mensagem)
    {
        Console.WriteLine($"{Marca} {Modelo}: Enviando mensagem para {numero}: {mensagem}");
    }
    
    public override void MostrarEspecificacoes()
    {
        base.MostrarEspecificacoes();
        Console.WriteLine("🛠️ Sistema Operacional: MIUI (Android)");
        Console.WriteLine($"📡 Infravermelho: {(TemInfravermelho ? "Sim" : "Não")}");
    }
}

// Programa principal
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("📲 Sistema de Modelagem de Celulares\n");
        
        // Criando diferentes modelos de celulares
        var celulares = new List<Celular>
        {
            new IPhone("13 Pro", 6.1, 3095),
            new Samsung("Galaxy S22", 6.1, 3700),
            new Xiaomi("Redmi Note 11", 6.43, 5000, true),
            new IPhone("SE (2022)", 4.7, 2018),
            new Samsung("Galaxy Z Flip4", 6.7, 3700)
        };
        
        // Demonstrando polimorfismo
        foreach (var celular in celulares)
        {
            celular.MostrarEspecificacoes();
            celular.Ligar();
            celular.FazerLigacao("+258 84 123 4567");
            celular.EnviarMensagem("+258 84 123 4567", "Olá do meu novo celular!");
            celular.Desligar();
            Console.WriteLine(new string('-', 40));
        }
    }
}