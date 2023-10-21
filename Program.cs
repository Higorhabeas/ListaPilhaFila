// See https://aka.ms/new-console-template for more information
using System;
class Program{
    static void Main(String[] args){
        int [] vetor = {3,6,1,2,3,6,4,2,3,1};
        PrintVetor(vetor);
    }

    public static void PrintVetor(int[] vetorPrint){
        foreach( var num in vetorPrint){
            Console.Write(num + " ");
            Console.WriteLine();
        }
    }
}
