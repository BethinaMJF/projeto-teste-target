using Projeto_Teste;
using System;
using System.Text.Json;

static void Menu()
{
    Console.Clear();
    Console.WriteLine("Escolha uma questão (2 a 5):");
    string opcao = Console.ReadLine();

    if (opcao == "2") Questao2();
    else if (opcao == "3") Questao3();
    else if (opcao == "4") Questao4();
    else if (opcao == "5") Questao5();
    else Console.WriteLine("Opção inválida"); Menu();
}

static void EsperarVoltarMenu()
{
    Console.Write("Pressione 'v' para voltar ao menu: ");
    string input = Console.ReadLine()?.Trim().ToLower() ?? "";
    if (input == "v")
        Menu();
    else
        EsperarVoltarMenu();
}


Menu();

static void Questao2()
{
    Console.Write("Informe um número: ");
    int numero = int.Parse(Console.ReadLine());

    int a = 0, b = 1;
    bool pertence = false;

    while (a <= numero)
    {
        if (a == numero)
        {
            pertence = true;
            break;
        }

        int proximo = a + b;
        a = b;
        b = proximo;
    }

    Console.WriteLine(pertence ? $"{numero} pertence à sequência de Fibonacci." : $"{numero} não pertence à sequência de Fibonacci.");
    EsperarVoltarMenu();

}

static void Questao3()
{
    var json = File.ReadAllText("dados.json");
    var faturamentos = JsonSerializer.Deserialize<Faturamento[]>(json);

    var diasComFaturamento = faturamentos.Where(f => f.valor > 0).ToArray(); // Ignora dias de faturamento 0
    double menor = diasComFaturamento.Min(f => f.valor);
    double maior = diasComFaturamento.Max(f => f.valor);
    double media = diasComFaturamento.Average(f => f.valor);
    int diasAcimaMedia = diasComFaturamento.Count(f => f.valor > media);

    Console.WriteLine($"Menor faturamento: {menor}");
    Console.WriteLine($"Maior faturamento: {maior}");
    Console.WriteLine($"Número de dias acima da média: {diasAcimaMedia}");
    EsperarVoltarMenu();

}

static void Questao4()
{
    static double CalcularPercentual(double valorEstado, double total)
    {
        return Math.Round(valorEstado / total * 100, 2);
    }

    double sp = 67836.43;
    double rj = 36678.66;
    double mg = 29229.88;
    double es = 27165.48;
    double outros = 19849.53;
    double total = sp + rj + mg + es + outros;
    
    Console.WriteLine($"SP: {CalcularPercentual(sp, total)}%");
    Console.WriteLine($"RJ: {CalcularPercentual(rj, total)}%");
    Console.WriteLine($"MG: {CalcularPercentual(mg, total)}%");
    Console.WriteLine($"ES: {CalcularPercentual(es, total)}%");
    Console.WriteLine($"Outros: {CalcularPercentual(outros, total)}%");
    EsperarVoltarMenu();
}

static void Questao5()
{
    Console.WriteLine("Digite uma palavra para inverter:");
    string palavra = Console.ReadLine();

    char[] letras = palavra.ToCharArray();
    string inversao = "";

    for (int i = (letras.Length - 1); i >= 0; i--)
    {
        inversao += letras[i];
    }
    Console.WriteLine($"Resultado: {inversao}");
    EsperarVoltarMenu();
}