using tabela_frequencia.classes;

// CONFIGURAÇÃO DE SAÍDA: 1 = Excel, 2 = Texto
int saida = 2; 

string caminhoArquivo = "dados/dados1.xlsx";

LeitorDados leitor = new LeitorDados();
double[]? dados = leitor.LerArquivo(caminhoArquivo);

if (dados == null) return; 

Array.Sort(dados);

MotorEstatistico motor = new MotorEstatistico();
ResultadoCompleto resultado = motor.Processar(dados);

TabelaFrequencia tabela = new TabelaFrequencia();
tabela.Imprimir(resultado);

EstatisticaExata estatisticas = new EstatisticaExata();
estatisticas.Imprimir(resultado);

Exportador exp = new Exportador();
exp.Exportar(resultado, saida);