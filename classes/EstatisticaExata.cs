namespace tabela_frequencia.classes;

public class EstatisticaExata
{
    public void Imprimir(ResultadoCompleto res)
    {
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine($"Média: {res.Media:F2}");
        Console.WriteLine($"Mediana: {res.Mediana:F2}");
        Console.WriteLine($"Moda: {res.Moda}");
        Console.WriteLine($"Variância: {res.Variancia:F2}");
        Console.WriteLine($"Desvio Padrão: {res.DesvioPadrao:F2}");
    }
}