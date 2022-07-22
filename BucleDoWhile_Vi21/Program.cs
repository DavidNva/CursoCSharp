using System;

namespace BucleDoWhile_Vi21{
    class Program {
        static void Main (string[] args){
            int x = 10;

            do{
                Console.WriteLine("Impresión: " + x);
                x++;
            }while(x<10);

            Console.WriteLine($"---------------------------");
            Console.WriteLine($"Cuarto programa (Del programa anterior");
            //Cuarto programa mejorando o simplificando el segundo creado inicialmente para el juego
            Random numero = new Random();
            int numeroAleatorio = numero.Next(0,100);
            Console.WriteLine(numeroAleatorio);
            Console.WriteLine($"Hola, este es un juego en el que debes adivinar un número");
            Console.WriteLine($"Los números comprendidos entre 0 y 100");
            Console.Write($"Ingresa tu nombre por favor: ");
            string nombre = Console.ReadLine();
            int miNumero;//Ahora no necesitamos darle el valor 101 para que entre el bucle, ya que el do while lo ejecuta dicha vez
            int intentos = 0;//Porque al ingresar por primera vez el numeroP, ya se cuenta como un intento
            do{
                intentos ++;
                Console.Write($"Por favor {nombre}, ingresa el número: ");
                miNumero = int.Parse(Console.ReadLine());   //En el segundo programa repetiamos estas 3 lineas 3 veces, ahora solo una
                if(miNumero >100 || miNumero <0) Console.WriteLine($"Solo puedes indicar numeros entre 0 y 100");
                else if(miNumero > numeroAleatorio) Console.WriteLine($"El número es menor");
                else if(miNumero < numeroAleatorio) Console.WriteLine($"El número es mayor"); 

            }while( miNumero != numeroAleatorio);

            System.Console.WriteLine();
            Console.WriteLine($"----------------------------------------------------------------------");
            Console.WriteLine($"Felicidades {nombre}, has adivinado, el número es: " + numeroAleatorio);
            Console.WriteLine($"Necesitaste de {intentos} intentos");    
            Console.WriteLine($"Has salido del cuarto bucle");
            Console.WriteLine($"Aqui termina el cuarto programa"); 
        
        }
    }
}