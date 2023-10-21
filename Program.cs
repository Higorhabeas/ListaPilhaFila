using System;

class StaticFila
{
    private int[] Fila;
    private int tamanhoMax;
    private int primeiroFila;
    private int ultimoFila;

    public StaticFila(int tamanho)
    {
        tamanhoMax = tamanho;
        Fila = new int[tamanho];
        primeiroFila = -1;
        ultimoFila = -1;
    }

    public bool EstaVazia()
    {
        return primeiroFila == -1;
    }

    public bool EstaCheia()
    {
        Console.WriteLine("Ulimo dafila +1 :" + (ultimoFila + 1));
        
        Console.WriteLine((ultimoFila + 1) % tamanhoMax);
        return (ultimoFila + 1) % tamanhoMax == primeiroFila;
    }

    public void Enfileirar(int item)
    {
        if (EstaCheia())
        {
            Console.WriteLine("Fila está cheia. Não é possível inserir mais elementos.");
            return;
        }

        if (primeiroFila == -1)
        {
            primeiroFila = 0;
        }

        ultimoFila = (ultimoFila + 1) % tamanhoMax;
        Fila[ultimoFila] = item;
    }

    public int Desenfileirar()
    {
        if (EstaVazia())
        {
            Console.WriteLine("Fila está vazia. Não é possível remover elementos.");
            return -1; // Valor padrão para indicar erro
        }

        int item = Fila[primeiroFila];

        if (primeiroFila == ultimoFila)
        {
            primeiroFila = ultimoFila = -1;
        }
        else
        {
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
        StaticFila Fila = new StaticFila(5);

        Fila.Enfileirar(1);
        Fila.Enfileirar(2);
        Fila.Enfileirar(3);

        Console.WriteLine("Elemento da frente: " + Fila.Verificar());

        int removedItem = Fila.Desenfileirar();
        Console.WriteLine("Elemento removido: " + removedItem);

        Console.WriteLine("Elemento da frente após a remoção: " + Fila.Verificar());

        Fila.Enfileirar(4);
        Fila.Enfileirar(5);

        Console.WriteLine("Fila está cheia? " + Fila.EstaCheia());

        while (!Fila.EstaVazia())
        {
            Console.WriteLine("Elemento removido: " + Fila.Desenfileirar());
        }

        Console.WriteLine("Fila está vazia? " + Fila.EstaVazia());
    }
}
