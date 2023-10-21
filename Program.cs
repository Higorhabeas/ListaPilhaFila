using System;

class StaticFila
{
        /*declarando o que iremos precisar para FILA
        Fila como array; Comprimento de Fila; Primeira e Ultima posição*/
    private int[] Fila;
    private int tamanhoMax;
    private int primeiroFila;
    private int ultimoFila;

    /*inicialização e criação da fila vaizia*/
    public StaticFila(int tamanho)
    {
        tamanhoMax = tamanho;
        Fila = new int[tamanho];
        primeiroFila = -1;
        ultimoFila = -1;
    }

    /*verifiação se a fila esta vazia*/
    public bool EstaVazia()
    {
        return primeiroFila == -1;
    }

    /*verifiação se a fila esta cheia
    com uma verificação matemática que será verdadeira quando o resto da divisão for igual ao primeiro
    ou seja quando realmento tiver resto, pois quando o dividendo for menor que o divisor o resultado 
    é sempre o divisor*/
    public bool EstaCheia()
    {
        return (ultimoFila + 1) % tamanhoMax == primeiroFila;
    }

    public void Enfileirar(int item)
    {
        if (EstaCheia())
        {
            /*evitando transbordamento overflow*/
            Console.WriteLine("Fila está cheia. Não é possível inserir mais elementos.");
            return;
        }
        /*se ao enfileirar e o primeiro  é -1 significa que a fila esta vazia e este também 
        será o primeiro elemento*/
        if (primeiroFila == -1)
        {
            primeiroFila = 0;
        }
        /*inserindo e elemento  na ultima posição*/
        ultimoFila = (ultimoFila + 1) % tamanhoMax;
        Fila[ultimoFila] = item;
    }

    public int Desenfileirar()
    {
        if (EstaVazia())
        {
            /*evitando transbordamento negativo underflow*/
            Console.WriteLine("Fila está vazia. Não é possível remover elementos.");
            return -1; // Valor padrão para indicar erro
        }

        int item = Fila[primeiroFila];

        if (primeiroFila == ultimoFila)
        {
            /*fila vazia*/
            primeiroFila = ultimoFila = -1;
        }
        else
        {
            /*se o primeiro da fila sai o primeiro passa a ser o segundo*/
            primeiroFila = (primeiroFila + 1) % tamanhoMax;
        }

        return item;
    }

    public int Verificar()
    {
        if (EstaVazia())
        {
            Console.WriteLine("Fila está vazia. Não é possível ler elementos.");
            return -1; // Valor padrão para indicar erro
        }

        return Fila[primeiroFila];
    }
}

class Program
{
    static void Main(string[] args)
    {
        /*criando a fila com 5 elementos*/
        StaticFila Fila = new(5);

        /*inserindo  elementos na fila*/
        Fila.Enfileirar(1);
        Fila.Enfileirar(2);
        Fila.Enfileirar(3);

        /*verificando e consultando o primeiro elemento da fila*/
        Console.WriteLine("Elemento da frente: " + Fila.Verificar());

        /*removendo o elemento da fila e mostrando qual elemento foi retirado*/
        int removedItem = Fila.Desenfileirar();
        Console.WriteLine("Elemento removido: " + removedItem);

        Console.WriteLine("Elemento da frente após a remoção: " + Fila.Verificar());

        Fila.Enfileirar(4);
        Fila.Enfileirar(5);
        Fila.Enfileirar(6);
        /*testando overflow*/
        Fila.Enfileirar(7);

        Console.WriteLine("Fila está cheia? " + Fila.EstaCheia());

        /*removendo elementos da fila enquanto não estiver vazia*/
        while (!Fila.EstaVazia())
        {
            Console.WriteLine("Elemento removido: " + Fila.Desenfileirar());
        }

        Console.WriteLine("Fila está vazia? " + Fila.EstaVazia());
    }
}
