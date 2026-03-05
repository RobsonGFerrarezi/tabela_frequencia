string caminhoArquivo = "dados.txt";

LeitorDados leitor = new LeitorDados();
double[]? dados = leitor.LerArquivo(caminhoArquivo);

if (dados == null) return; 

Array.Sort(dados);

TabelaFrequencia tabela = new TabelaFrequencia();
tabela.GerarEImprimir(dados);

EstatisticaExata estatisticas = new EstatisticaExata();
estatisticas.CalcularEImprimir(dados);