namespace tabela_frequencia.classes;

using System.Collections.Generic;

public class LinhaTabela
{
    public string Classe { get; set; } = "";
    public int Fi { get; set; }
    public double Fr { get; set; }
    public int Fa { get; set; }
    public double Fra { get; set; }
    public double Xm { get; set; }
}

public class ResultadoCompleto
{
    public List<LinhaTabela> Linhas { get; set; } = new();
    public int TotalN { get; set; }
    public double Min { get; set; }
    public double Max { get; set; }
    public double H_Total { get; set; }
    public int K_Classes { get; set; }
    public double h_Classe { get; set; }
    public double Media { get; set; }
    public double Mediana { get; set; }
    public string Moda { get; set; } = "";
    public double Variancia { get; set; }
    public double DesvioPadrao { get; set; }
}