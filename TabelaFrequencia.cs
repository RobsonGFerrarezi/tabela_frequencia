using System.Linq;

public class TabelaFrequencia
{
    public void GerarEImprimir(double[] dados)
    {
        int n = dados.Length;
        double min = dados[0];
        double max = dados[n-1];
        double amplitudeTotal = max - min;

        int k = (int)Math.Round(Math.Sqrt(n));
        double h = Math.Ceiling(amplitudeTotal / k);

        Console.WriteLine("=== Resumo Estatístico ===");
        Console.WriteLine($"Total de elementos (n): {n}");
        Console.WriteLine($"Mínimo: {min} | Máximo: {max}");
        Console.WriteLine($"Amplitude Total (H): {amplitudeTotal}");
        Console.WriteLine($"Número de Classes (k): {k}");
        Console.WriteLine($"Amplitude da Classe (h): {h}\n");

        Console.WriteLine("Classes\t\tFi\tFr\tFa\tFra\tXm");
        Console.WriteLine("----------------------------------------------------------");

        double limiteInferior = min;
        int frequenciaAcumulada = 0;
        double somaMedia = 0;

        for(int i = 0; i < k; i++)
        {
            double limiteSuperior = limiteInferior + h;

            int fi = dados.Count(x => x >= limiteInferior && (i == k - 1 ? x <= limiteSuperior : x < limiteSuperior));
            
            frequenciaAcumulada += fi;

            double fr = (double) fi / n;
            double fra = (double) frequenciaAcumulada / n;
            double xm = (limiteInferior + limiteSuperior) / 2.0;

            somaMedia += xm * fi;

            Console.WriteLine($"{limiteInferior} |- {limiteSuperior}\t{fi}\t{fr:F2}\t{frequenciaAcumulada}\t{fra:F2}\t{xm}");
            limiteInferior = limiteSuperior;
        }
    }
}