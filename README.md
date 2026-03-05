# Analisador Estatístico de Frequências

Este projeto é uma ferramenta robusta desenvolvida em **C#** para realizar análises estatísticas descritivas a partir de diferentes fontes de dados (Excel, JSON e Texto). O sistema foi projetado com foco em modularidade e escalabilidade, aplicando princípios de engenharia de software como a **Separação de Preocupações (SoC)**.

## 🚀 Funcionalidades

* **Leitura Multiformato**: Suporte para ficheiros `.txt`, `.csv`, `.json` e `.xlsx` (Excel).
* **Distribuição de Frequências**: Geração automática de tabelas de classes com cálculos de Frequência Absoluta ($f_i$), Relativa ($f_r$), Acumulada ($F_a$) e Ponto Médio ($x_m$).
* **Cálculos Estatísticos Exatos**:
    * **Média**: $$\bar{x} = \frac{\sum_{i=1}^{n} x_i}{n}$$
    * **Mediana**: Cálculo preciso para conjuntos de dados com número par ou ímpar de elementos.
    * **Moda**: Identificação de valores mais frequentes (suporta distribuições bimodais/multimodais).
    * **Variância e Desvio Padrão**: Medidas de dispersão amostral fundamentais para análise de dados.
* **Exportação de Relatórios**: Opção para salvar os resultados processados em ficheiros `.txt` ou planilhas `.xlsx` formatadas conforme a variável de configuração.

## 🛠️ Tecnologias Utilizadas

* **.NET 10.0 SDK**
* **ClosedXML**: Biblioteca para manipulação avançada de ficheiros Excel (.xlsx).
* **System.Text.Json**: Ferramenta nativa para processamento de dados estruturados.
* **LINQ (Language Integrated Query)**: Utilizado para filtragem e processamento eficiente de coleções de dados.

## 📂 Estrutura do Projeto

A arquitetura do sistema é organizada em pastas para garantir clareza e facilitar a manutenção:

```text
├── Program.cs             # Orquestrador do sistema e interface de console
├── classes/               # Namespace: tabela_frequencia.classes
│   ├── MotorEstatistico.cs # Núcleo de processamento matemático
│   ├── LeitorDados.cs       # Estratégias de leitura (TXT, JSON, Excel)
│   ├── Exportador.cs        # Lógica de persistência de resultados
│   ├── Modelos.cs           # Definição das estruturas de dados (POCOs)
│   ├── TabelaFrequencia.cs  # Formatação da saída para tabela
│   └── EstatisticaExata.cs  # Formatação da saída para medidas exatas
├── dados/                 # Diretório para armazenamento dos ficheiros de entrada
└── tabela_frequencia.csproj
```

## 💻 Como Executar

1. Certifique-se de ter o **.NET SDK** instalado em sua máquina.
2. Clone este repositório para o seu diretório local.
3. No terminal, acesse a pasta raiz do projeto e restaure as dependências:
   ```bash
   dotnet restore
   ```
4. Configure o caminho do ficheiro de entrada desejado no ficheiro `Program.cs` (variável `caminhoArquivo`).
5. Execute o projeto:
   ```bash
   dotnet run
   ```

## 📄 Exemplo de Entrada (JSON)

Para processar ficheiros no formato JSON, o sistema espera uma estrutura de lista numérica simples:
```json
[
  25, 42, 38, 29, 35, 45, 51, 28, 33, 40, 23, 31, 48, 55, 30
]
```

---

## 👤 Autores

**Robson Guilherme Ferrarezi**
* **Profissão**: Estudante de Engenharia de Computação
* **Localização**: São Bernardo do Campo, SP, Brasil
* **Contexto**: Este projeto foi desenvolvido como parte integrante das atividades práticas de Estatística.

**Kauê dos Santos Andrade**
* **Profissão**: Estudante de Engenharia de Computação
* **Localização**: Diadema, SP, Brasil
* **Contexto**: Este projeto foi desenvolvido como parte integrante das atividades práticas de Estatística.
---
