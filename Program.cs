using System;

class StaticPilha {
    private int[] Pilha;
    private int tamanhoMax;
    private int topo;

    public StaticPilha(int tamanho){

        tamanhoMax = tamanho;
        Pilha = new int[tamanho];
        topo = 0;
    }

    public bool EstaVazia(){

        return topo == 0;
    }
    public bool EstaCheia(){

        return (topo + 1) == tamanhoMax;
    }

    public int ConsultaTopo(){

        if(EstaVazia()){
           Console.WriteLine("Pilha está vazia. Não é possível ler elementos.");
           return -1; // Valor padrão para indicar erro 
        }

        return Pilha[topo];
    }

    public void Empilha(int elemento){

        if(EstaCheia()){
            Console.WriteLine("Pilha está cheia. Não é possível inserir mais elementos.");
            return;
        }
        Console.WriteLine("valor do topo: " + topo);
        topo ++;
        Pilha[topo] = elemento;
    }

    public int Desempilha(){

        if (EstaVazia()){

            Console.WriteLine("Pilha está vazia. Não é possível desempilhar elementos.");
            return -1;
        }
        int elemento = Pilha[topo];
        topo --;
        return elemento;
    }
}

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

        /*TRABALHANDO COM PILHA*/
        /*criando uma pilha com 5 elementos*/
        StaticPilha Pilha = new(5);
         /*inserindo  elementos na pilha*/
        Pilha.Empilha(1);
        Pilha.Empilha(2);
        Pilha.Empilha(3);
        Pilha.Empilha(4);

        /*verificando e consultando o topo da pilha*/
        Console.WriteLine("Elemento do topo: " + Pilha.ConsultaTopo());

        /*removendo o elemento da pilha e mostrando qual elemento foi retirado*/
        int elementoRemovido = Pilha.Desempilha();
        Console.WriteLine("Elemento removido da pilha: " + elementoRemovido);

        Console.WriteLine("Elemento da frente após a remoção da pilha: " + Pilha.ConsultaTopo());

        Pilha.Empilha(5);
        Pilha.Empilha(6);
        /*testando overflow*/
        Pilha.Empilha(7);

        /*removendo elementos da pilha enquanto não estiver vazia*/
        while (!Pilha.EstaVazia()){

            Console.WriteLine("Elemento removido da pilha: "+ Pilha.Desempilha());
        }
        
        Console.WriteLine("Pilha está vazia? " + Pilha.EstaVazia());
    }
}
