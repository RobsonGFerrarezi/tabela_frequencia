using System.IO; 
using System.Linq;

string caminhoArquivo = "dados.txt";

if (!File.Exists(caminhoArquivo))
{
    Console.WriteLine($"Erro: O arquivo '{caminhoArquivo}' não foi encontrado na pasta do projeto.");
    return;
}

string textoBruto = File.ReadAllText(caminhoArquivo);

double[] dados = textoBruto
.Split(new [] {',', ' ', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries)
.Select(double.Parse)
.ToArray();

Array.Sort(dados);

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
Console.WriteLine($"Desvio Padrão: {desvioPadrao:F2} anos");