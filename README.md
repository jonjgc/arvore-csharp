# Construção de Árvore

Este projeto contém a implementação em C# para a construção de uma árvore a partir de um array, conforme foi especificado.

## Descrição do Problema

O objetivo é construir um algoritmo que cria uma árvore binária a partir de um array de inteiros, seguindo um conjunto específico de regras:

1.  **Raiz**: A raiz da árvore deve ser o maior valor contido no array.
2.  **Galho da Esquerda**: Deve ser composto por todos os números que estavam à esquerda do valor raiz no array original. A estrutura desse galho deve seguir uma ordem decrescente.
3.  **Galho da Direita**: Deve ser composto por todos os números que estavam à direita do valor raiz no array original, também seguindo uma ordem decrescente na sua estrutura.

O algoritmo deve produzir uma estrutura de árvore idêntica à apresentada nos diagramas dos cenários de exemplo.

## Lógica da Implementação

A solução foi desenvolvida de forma a interpretar as regras e replicar fielmente a estrutura visual dos diagramas fornecidos. A lógica principal pode ser dividida em três etapas:

### 1. Encontrar a Raiz Principal (`BuildTree` method)

O primeiro passo é varrer o array de entrada completo para identificar o maior valor e sua posição (índice). Este valor é utilizado para criar o nó raiz (`TreeNode`) da árvore.

### 2. Divisão para os Galhos

Uma vez que a raiz é encontrada, o array original é dividido em dois subarrays:
-   Um contendo todos os elementos que estavam à esquerda do índice da raiz.
-   Outro contendo todos os elementos que estavam à direita.

### 3. Construção dos Galhos (`BuildBranchAsChain` method)

Esta é a etapa chave para replicar a estrutura do diagrama. Para cada subarray (seja da esquerda ou da direita), o algoritmo executa os seguintes passos:
-   **Ordena** o subarray em ordem decrescente.
-   **Cria uma "corrente" de nós**: O primeiro elemento (o maior) se torna o primeiro nó do galho. O segundo elemento se torna filho do primeiro, o terceiro se torna filho do segundo, e assim sucessivamente, criando uma estrutura linear que corresponde visualmente aos diagramas.

## Estrutura do Código

O código está organizado nas seguintes classes dentro do arquivo `Program.cs`:

-   **`TreeNode`**: Uma classe simples que representa um nó na árvore. Contém o `Value` (valor inteiro) e referências para os filhos `Left` e `Right`.
-   **`TreeBuilder`**: A classe principal que contém toda a lógica de construção da árvore, incluindo os métodos `BuildTree` e `BuildBranchAsChain`.
-   **`Program`**: A classe de entrada da aplicação, responsável por executar os dois cenários de teste e imprimir o resultado no console.

## Como Executar

1.  **Pré-requisitos**: Ter o SDK do .NET (versão 8 ou superior) instalado.
2.  **Execução**: Abra um terminal na pasta raiz do projeto e execute o seguinte comando:

    ```bash
    dotnet run
    ```

O terminal exibirá a representação textual das árvores para os dois cenários, conforme especificado no problema.
