using System.IO;
using System.Linq;

public class LeitorDados
{
    public double[]? LerArquivo(string caminhoArquivo)
    {
        if (!File.Exists(caminhoArquivo))
        {
            Console.WriteLine($"Erro: O arquivo '{caminhoArquivo}' não foi encontrado na pasta do projeto.");
            return null; 
        }

        string textoBruto = File.ReadAllText(caminhoArquivo);

        double[] dados = textoBruto
            .Split(new [] {',', ' ', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();

        return dados;
    }
}