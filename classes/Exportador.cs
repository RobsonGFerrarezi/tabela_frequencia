namespace tabela_frequencia.classes;

using System;
using System.IO;
using System.Text;
using ClosedXML.Excel;

public class Exportador
{
    public void Exportar(ResultadoCompleto res, int tipoSaida)
    {
        if (tipoSaida == 1) ExportarExcel(res);
        else if (tipoSaida == 2) ExportarTexto(res);
        else Console.WriteLine("Tipo de saída inválido.");
    }

    private void ExportarTexto(ResultadoCompleto res)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("=== Resumo Estatístico ===");
        sb.AppendLine($"Total n: {res.TotalN} | Mín: {res.Min} | Máx: {res.Max}");
        sb.AppendLine($"Amplitude Total: {res.H_Total} | Classes: {res.K_Classes} | h: {res.h_Classe}");
        sb.AppendLine("\nClasses\t\tFi\tFr\tFa\tFra\tXm");
        foreach (var l in res.Linhas)
            sb.AppendLine($"{l.Classe}\t{l.Fi}\t{l.Fr:F2}\t{l.Fa}\t{l.Fra:F2}\t{l.Xm}");
        
        sb.AppendLine("\n--- Estatísticas Exatas ---");
        sb.AppendLine($"Média: {res.Media:F2} | Mediana: {res.Mediana:F2} | Moda: {res.Moda}");
        sb.AppendLine($"Variância: {res.Variancia:F2} | Desvio Padrão: {res.DesvioPadrao:F2}");

        File.WriteAllText("resultado.txt", sb.ToString());
        Console.WriteLine("\n[OK] Resultado salvo em 'resultado.txt'");
    }

    private void ExportarExcel(ResultadoCompleto res)
    {
        using (var wb = new XLWorkbook())
        {
            var ws = wb.Worksheets.Add("Estatística");
            
            // Cabeçalhos da Tabela
            string[] headers = { "Classe", "Fi", "Fr", "Fa", "Fra", "Xm" };
            for (int i = 0; i < headers.Length; i++) ws.Cell(1, i + 1).Value = headers[i];

            // Dados da Tabela
            for (int i = 0; i < res.Linhas.Count; i++)
            {
                ws.Cell(i + 2, 1).Value = res.Linhas[i].Classe;
                ws.Cell(i + 2, 2).Value = res.Linhas[i].Fi;
                ws.Cell(i + 2, 3).Value = res.Linhas[i].Fr;
                ws.Cell(i + 2, 4).Value = res.Linhas[i].Fa;
                ws.Cell(i + 2, 5).Value = res.Linhas[i].Fra;
                ws.Cell(i + 2, 6).Value = res.Linhas[i].Xm;
            }

            // Estatísticas abaixo da tabela
            int row = res.Linhas.Count + 4;
            ws.Cell(row, 1).Value = "Média:";   ws.Cell(row, 2).Value = res.Media;
            ws.Cell(row+1, 1).Value = "Mediana:";      ws.Cell(row+1, 2).Value = res.Mediana;
            ws.Cell(row+2, 1).Value = "Moda:";         ws.Cell(row+2, 2).Value = res.Moda;
            ws.Cell(row+3, 1).Value = "Desvio Padrão:"; ws.Cell(row+3, 2).Value = res.DesvioPadrao;

            ws.Columns().AdjustToContents(); // Auto-ajuste de largura
            wb.SaveAs("resultado.xlsx");
        }
        Console.WriteLine("\n[OK] Resultado salvo em 'resultado.xlsx'");
    }
}