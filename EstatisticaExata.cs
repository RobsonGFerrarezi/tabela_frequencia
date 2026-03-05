using System.Linq;

public class EstatisticaExata
{
    public void CalcularEImprimir(double[] dados)
    {
        int n = dados.Length;
        double media = dados.Average();

        double mediana;
        if (n % 2 == 0) {
            mediana = (dados[(n / 2) - 1] + dados[n / 2]) / 2.0;
        } else {
            mediana = dados[n / 2];
        }

        var grupos = dados.GroupBy(v => v);
        int maxRepeticoes = grupos.Max(g => g.Count());
        var modas = grupos.Where(g => g.Count() == maxRepeticoes).Select(g => g.Key).ToArray();
        string modaTexto = string.Join(", ", modas);

        double variancia = dados.Select(x => Math.Pow(x - media, 2)).Sum() / (n - 1);
        double desvioPadrao = Math.Sqrt(variancia);

        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine($"Média Estimada: {media:F2}");
        Console.WriteLine($"Mediana: {mediana:F2}");
        Console.WriteLine($"Moda: {modaTexto}");
        Console.WriteLine($"Variância: {variancia:F2}");
        Console.WriteLine($"Desvio Padrão: {desvioPadrao:F2}");
    }
}