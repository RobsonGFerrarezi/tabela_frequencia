namespace tabela_frequencia.classes;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ClosedXML.Excel; 

public class LeitorDados
{
    public double[]? LerArquivo(string caminhoArquivo)
    {
        if (!File.Exists(caminhoArquivo))
        {
            Console.WriteLine($"Erro: O arquivo '{caminhoArquivo}' não foi encontrado.");
            return null;
        }

        string extensao = Path.GetExtension(caminhoArquivo).ToLower();

        try
        {
            switch (extensao)
            {
                case ".txt":
                case ".csv":
                    return LerTextoGeral(caminhoArquivo);
                case ".json":
                    return LerJson(caminhoArquivo);
                case ".xlsx":
                    return LerExcel(caminhoArquivo);
                default:
                    Console.WriteLine($"Erro: O formato '{extensao}' não é suportado pelo sistema.");
                    return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao tentar processar o arquivo: {ex.Message}");
            return null;
        }
    }

    private double[] LerTextoGeral(string caminho)
    {
        string textoBruto = File.ReadAllText(caminho);
        return textoBruto
            .Split(new[] { ',', ';', ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();
    }

    private double[] LerJson(string caminho)
    {
        string jsonBruto = File.ReadAllText(caminho);
        
        return JsonSerializer.Deserialize<double[]>(jsonBruto) ?? new double[0];
    }

    private double[] LerExcel(string caminho)
    {
        var listaDeNumeros = new List<double>();

        using (var workbook = new XLWorkbook(caminho))
        {
            var primeiraAba = workbook.Worksheet(1); 

            foreach (var celula in primeiraAba.CellsUsed())
            {
                if (celula.TryGetValue(out double valor))
                {
                    listaDeNumeros.Add(valor);
                }
            }
        }

        return listaDeNumeros.ToArray();
    }
}