namespace tabela_frequencia.classes;

public class TabelaFrequencia
{
    public void Imprimir(ResultadoCompleto res)
    {
        Console.WriteLine("=== Resumo Estatístico ===");
        Console.WriteLine($"Total de elementos (n): {res.TotalN}");
        Console.WriteLine($"Mínimo: {res.Min} | Máximo: {res.Max}");
        Console.WriteLine($"Amplitude Total (H): {res.H_Total}");
        Console.WriteLine($"Número de Classes (k): {res.K_Classes}");
        Console.WriteLine($"Amplitude da Classe (h): {res.h_Classe}\n");

        Console.WriteLine("Classes\t\tFi\tFr\tFa\tFra\tXm");
        Console.WriteLine("----------------------------------------------------------");

        foreach (var linha in res.Linhas)
        {
            Console.WriteLine($"{linha.Classe}\t{linha.Fi}\t{linha.Fr:F2}\t{linha.Fa}\t{linha.Fra:F2}\t{linha.Xm}");
        }
    }
}