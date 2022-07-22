using System;
namespace _2SintaxisBasica_V7{
    class Program{
        static void Main(string[] args){
            //----------------Video 7 - Convertir Texto a Número
           /* 
           System.Console.WriteLine("Programa para sumar");

            System.Console.WriteLine("Introduce el primer numero: ");
            int num1;

            num1 =  int.Parse(Console.ReadLine()); //Convierte el valor de texto introducido por el usuario
            //a un numero de tipo entero

            System.Console.WriteLine("Introduce el segundo número");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("El resultado es " + (num1 + num2));//1
            System.Console.WriteLine($"El resultado es {num1 + num2}");//2  
            System.Console.WriteLine("El resultado es {0}",(num1+num2));//Otra forma de concatenar strings
            */

            //_------------------------- Video 8 Constantes-----------------------------------
            const double PI = 3.1416;
            double radio;
            Console.WriteLine("El valor para PI es: {0}",PI);//Otra forma de concatenar strings
            Console.WriteLine($"Programa para calcular el area de un circulo");
            
            Console.WriteLine($"Introduce el valor para el radio: ");
            
            radio = double.Parse(Console.ReadLine());

            double areaCirculo = radio * radio * PI;
            System.Console.WriteLine($"El area del circulo es: {areaCirculo}");
            
            //otra forma de hacer calculos es usar Math (De la biblioteca)
            double areaCirculo2 = Math.Pow(radio,2) * PI; 
            Console.WriteLine($"El area del circulo es: {areaCirculo2}");
            
        }
    }
}