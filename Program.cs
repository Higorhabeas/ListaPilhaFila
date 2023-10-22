using System;

class StaticLista{
    private int[] Lista;
    private int tamanhoMax;
    private int indArray;

    public StaticLista(int tamanho){

        tamanhoMax = tamanho;
        Lista = new int[tamanho];
        indArray = -1;
    }

    public bool EstaVazia(){

        return indArray == -1;
    }

    public bool EstaCheia(){
        
        return indArray == tamanhoMax -1;
    }

    public int LerElemento(int j){

        if(EstaVazia())
        {
            Console.WriteLine("Lista está vazia. Não é possível ler elementos.");
            return -1; // Valor padrão para indicar erro             
        }
       
        if(j >= 1 && j <= tamanhoMax)
        {

            return Lista[j];
        }
        else
        {

            Console.WriteLine("ERRO: elemento não existe.");
            return -1; // Valor padrão para indicar erro
        }

       
    }

    public int LocalizarElemento(int elemento){

        if(EstaVazia()){
            Console.WriteLine("Lista está vazia. Não é possível ler elementos.");
            return -1; // Valor padrão para indicar erro    
        }
        int i = 0;
        int posicaoElemento = -1;
        bool achou = false;
        while (!achou && i < tamanhoMax){
            
            if(Lista[i] == elemento){
                achou = true;
                posicaoElemento = i;
            }
            i++;
        }

        if(!achou){
            Console.WriteLine("Elemento não encontrado.");
            return -1; // Valor padrão para indicar erro    
        }

        return posicaoElemento;
    }

    public int RemoverElemento(int posElemento){
        if(EstaVazia()){
            Console.WriteLine("Lista está vazia. Não é possível remover elementos.");
            return -1; // Valor padrão para indicar erro  
        }
        int elementoRemovido = 0;
        if(posElemento >= 1 && posElemento <= tamanhoMax){
            elementoRemovido = Lista[posElemento-1];
            for (int i = posElemento; i < tamanhoMax - 1; i++){
                Lista[i] = Lista[i-1];
            }
        }else{
            Console.WriteLine("Elemento não existe.");
            return -1; // Valor padrão para indicar erro  
        }

        return elementoRemovido;
    }

    public void InserirElemento(int elemento){
        if(EstaCheia()){
            Console.WriteLine("Lista está cheia. Não é possível inserir elementos.");
            return ; 
        }
        bool achouElementoVazio = false;
        int i = 0;
        while (!achouElementoVazio && i < tamanhoMax)
        {
            if( Lista[i] == 0 ){
                Lista[i] = elemento;
                indArray = i;
                Console.WriteLine("Elemento inserido: " + Lista[i] + " Posição: " + i);
                achouElementoVazio = true;
            }
            i++;
        }
    }

    public  void ConcatenaListas(int[] Lista1, int[] Lista2){
        int posicaoVazia1 = -1;
        int posicaoVazia2 = -1;
        
        for ( int i = 0; i < Lista1.Length; i++){
            if(Lista1[i] == 0){
                posicaoVazia1 = i;
            }
        }

        for (int j = 0; j < Lista2.Length; j++){
            if(Lista2[j] ==0){
                posicaoVazia2 = j;
            }
        }
        int[] vetorResultante = new int[Lista1.Length + Lista2.Length];

        for (int m = 0; m < posicaoVazia1; m++ ){

            vetorResultante[m] = Lista1[m];
        }

        for(int n = 0; n < posicaoVazia2; n++){

            vetorResultante[posicaoVazia1] = Lista2[n];
            posicaoVazia1 ++;
        }

        for (int r = 0; r < vetorResultante.Length; r++){
            Console.Write(" " + vetorResultante[r]);
        }

    }
}

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

        /*criando a Lista com 5 elementos*/
        StaticLista Lista = new(5);
         /*inserindo  elementos na lista*/
        Lista.InserirElemento(10);
        
        Lista.InserirElemento(20);
        
        Lista.InserirElemento(30);

        /*verificando e consultando a posição do elemento na lista*/
        Console.WriteLine("A posição do elemento é: " + Lista.LocalizarElemento(20));

        Lista.InserirElemento(40);

        Lista.RemoverElemento(Lista.LocalizarElemento(20));

        /*concatenando listas*/

        StaticLista Lista1 = new(5);
        Lista1.InserirElemento(10);
        
        Lista1.InserirElemento(20);
        
        Lista1.InserirElemento(30);

        StaticLista Lista2 = new(5);

        Lista2.InserirElemento(11);
        
        Lista2.InserirElemento(22);
        
        Lista2.InserirElemento(33);

        int[] vetorLista1 = new int[5];

        for (int p = 0; p < vetorLista1.Length; p++){

            vetorLista1[p] = Lista1.LerElemento(p);
        }

        int[] vetorLista2 = new int[5];

        for (int q = 0; q < vetorLista2.Length; q++){

            vetorLista2[q] = Lista2.LerElemento(q);
        }

        Lista.ConcatenaListas(vetorLista1,vetorLista2);



        
    }
}
