namespace tabela_frequencia.classes;

using System;
using System.Collections.Generic;
using System.Linq;

public class MotorEstatistico
{
    public ResultadoCompleto Processar(double[] dados)
    {
        int n = dados.Length;
        double min = dados[0];
        double max = dados[n - 1];
        double h_total = max - min;
        int k = (int)Math.Round(Math.Sqrt(n));
        double h_classe = Math.Ceiling(h_total / k);

        var resultado = new ResultadoCompleto
        {
            TotalN = n,
            Min = min,
            Max = max,
            H_Total = h_total,
            K_Classes = k,
            h_Classe = h_classe
        };

        // Construção da Tabela de Frequências
        double limiteInferior = min;
        int fa = 0;
        for (int i = 0; i < k; i++)
        {
            double limiteSuperior = limiteInferior + h_classe;
            // Contagem fi: a última classe inclui o limite superior [a, b], as outras são [a, b[
            int fi = dados.Count(x => x >= limiteInferior && (i == k - 1 ? x <= limiteSuperior : x < limiteSuperior));
            fa += fi;

            resultado.Linhas.Add(new LinhaTabela
            {
                Classe = $"{limiteInferior} |- {limiteSuperior}",
                Fi = fi,
                Fr = (double)fi / n,
                Fa = fa,
                Fra = (double)fa / n,
                Xm = (limiteInferior + limiteSuperior) / 2.0
            });
            limiteInferior = limiteSuperior;
        }

        // Cálculos Estatísticos Exatos
        resultado.Media = dados.Average();
        
        // Mediana
        if (n % 2 == 0)
            resultado.Mediana = (dados[(n / 2) - 1] + dados[n / 2]) / 2.0;
        else
            resultado.Mediana = dados[n / 2];

        // Moda
        var grupos = dados.GroupBy(v => v);
        int maxRepeticoes = grupos.Max(g => g.Count());
        var modas = grupos.Where(g => g.Count() == maxRepeticoes).Select(g => g.Key);
        resultado.Moda = string.Join(", ", modas);

        // Variância Amostral e Desvio Padrão
        resultado.Variancia = dados.Select(x => Math.Pow(x - resultado.Media, 2)).Sum() / (n - 1);
        resultado.DesvioPadrao = Math.Sqrt(resultado.Variancia);

        return resultado;
    }
}