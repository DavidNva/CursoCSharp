using System;

namespace BucleWhile_V19{

    class Program{
        //Los bucles son otro tipo de control de flujo de ejecucion
        /*
          Permiten repetir l ejecucion de lineas de codigo un numero determinado o indeterminado
          de veces

          Ventajas:
           * Permite repetir codigo de forma rapida y sencilla
           * Ahorro de tiempo a la hora de programar
           * Permite trabajar con grandes volumenes de datos (Muy util en el 
             manejo de una base de datos)
           *Permite trabajar con arrays

           Tipos de bucles

           *Determinados: Son los que en el mismo codigo, solo leyendolo
           sabes cuantas veces se repetira, 7 veces, 15 veces, etc.
           En este tipo, entra el bucle:
           *For
           *El bucle for, en C# cuenta con su variante For Each

           *Indeterminados: En cambio, con estos no sabes cuantas
           veces repetira el codigo de su interior solo leyendo el codigo fuente
           necesitamos ejecutarlo para saberlo
           Estos son: 
           * While -- Significa mientras
           Es decir, mientras se cumpla cierta condicion, se seguira ejecutando el codigo
           obviamente es recomendable usarlo cuando no sepamos el n° d veces que se 
           reperira el codigo de su interior
           Por ejemplo, cuando manejemos una Base de Datos, cuando consultemos
           nosostros casi nunca sabremos cuantos registros exactamente existen en una base de datos
           asi que el bucle while recorrera cada uno
           pero al no saber cuantos son, no podemos usar un for indicando un numero exacto, 
           es por eso que el bucle while se vuelve muy util

           *Un bucle while puede jamas ejecutarse, como ocurre en el ejemplo siguiente al indicar no como respuesta
           o puede ejecutarse infinidad de veces
           En el ejemplo, si el usuario siempre contestara si, o alguna otra palabra o letra
           el bucle seguira ejecutandose
           hasta que el indique no
           * Do-While

        */
        static void Main(string[] args){
            Console.WriteLine($"¿Deseas entrar en el bucle while");
            string respuesta = Console.ReadLine();
            
            while(respuesta != "no"){
                Console.WriteLine($"Estas ejecutando el interior del bucle while");
                Console.Write($"Introduce tu nombre, por favor: ");
                string nombre = Console.ReadLine();
                Console.WriteLine($"Hola {nombre}, saldrás del bucle cuando respondas 'no' a la pregunta");
                Console.WriteLine($"Deseas repetir otra vez");
                respuesta = Console.ReadLine(); //Como la variable respusta la declaramos 
                //parte del metodo, podemos usarla dentro de este metodo las veces que sea necesario
                //a la vez, podemos cambiar su valor,es decir es una variable de metodo
                //o con ambito de metodo
            }

            Console.WriteLine($"Has salido del primer bucle");
            Console.WriteLine($"Aqui termina el primer programa ");

            //Programa para generar un numero aleatorio de 0 -100, como tal un juego
            //El usuario debe adivinar que numero es, indicando si es mayo o menor
            //podra salir del bucle cuando adivine el numero
            //ademas cuando acabe, indicar cuantos intentos realizamos
            Console.WriteLine($" -----------------------------------");
            //Para llo instancionamos un objeto de tipo Random
            Random numero = new Random();
            int numeroAleatorio = numero.Next(0,100);
            Console.WriteLine(numeroAleatorio);
            Console.WriteLine($"Hola, este es un juego en el que debes adivinar un número");
            Console.WriteLine($"Los números comprendidos entre 0 y 100");
            Console.Write($"Ingresa tu nombre por favor: ");
            string nombreP = Console.ReadLine();
            
    
            Console.Write($"Por favor {nombreP}, ingresa el número: ");
            int numeroP = int.Parse(Console.ReadLine());
            int intentos = 1;//Porque al ingresar por primera vez el numeroP, ya se cuenta como un intento

            while( numeroP != numeroAleatorio ){
                
                if(numeroP >100 || numeroP <0){
                    Console.WriteLine($"Solo puedes indicar numeros entre 0 y 100");
                    Console.Write($"Por favor {nombreP}, ingresa el número: ");
                    numeroP = int.Parse(Console.ReadLine());   
                    intentos ++;
                }

                else if(numeroP > numeroAleatorio){
                    Console.WriteLine($"El número es menor");
                    Console.Write($"Por favor {nombreP}, ingresa el número: ");
                    numeroP = int.Parse(Console.ReadLine());
                    intentos ++;
                }
                else if(numeroP < numeroAleatorio) {
                    Console.WriteLine($"El número es mayor");
                    Console.Write($"Por favor {nombreP}, ingresa el número: ");
                    numeroP = int.Parse(Console.ReadLine());
                    intentos ++;
                } 
            }
            System.Console.WriteLine();
            Console.WriteLine($"----------------------------------------------------------------------");
            Console.WriteLine($"Felicidades {nombreP}, has adivinado, el numero es: " + numeroAleatorio);
            Console.WriteLine($"Necesitaste de {intentos} intentos");    
            Console.WriteLine($"Has salido del segundo bucle");
            Console.WriteLine($"Aqui termina el segundo programa");       
//Tercer programa: juego de adivinar un numero (codigo mas simplificado)
            Console.WriteLine($"----------------------------------------------------------------------");
            Console.WriteLine($"Tercer programa");
            Random numero2 = new Random();
            int numeroAleatorio2 = numero2.Next(0,100);
            int minumero2 = 101;
            int intentos2 = 0;
            Console.WriteLine(numeroAleatorio2);
            Console.WriteLine($"Hola, este es un juego en el que debes adivinar un número");
            Console.WriteLine($"Introduce un n° entre 0 y 100");

            while(numeroAleatorio2!=minumero2){
                intentos2 ++;
                minumero2 = int.Parse(Console.ReadLine());
                if(minumero2 > numeroAleatorio2) Console.WriteLine("El n° es mas bajo");
                if(minumero2 < numeroAleatorio2) Console.WriteLine("El n° es mas alto");

            }
            Console.WriteLine($"Felicidades, has adivinado, el numero es: {numeroAleatorio2}, has necesitado de {intentos2} intentos");
            Console.WriteLine($"Has salido del tercer bucle");
            Console.WriteLine($"Aqui termina el tercer programa");  

            Console.WriteLine($" -----------------------------------");
            Console.WriteLine($"Cuarto programa");
            //Cuarto programa mejorando o simplificando el segundo creado inicialmente para el juego
            Random numero4 = new Random();
            int numeroAleatorio4 = numero4.Next(0,100);
            Console.WriteLine(numeroAleatorio4);
            Console.WriteLine($"Hola, este es un juego en el que debes adivinar un número");
            Console.WriteLine($"Los números comprendidos entre 0 y 100");
            Console.Write($"Ingresa tu nombre por favor: ");
            string nombreP4 = Console.ReadLine();
            
            int numeroP4 = 101;//= int.Parse(Console.ReadLine());
            int intentos4 = 0;//Porque al ingresar por primera vez el numeroP, ya se cuenta como un intento
            while( numeroP4 != numeroAleatorio4 ){
                    intentos4 ++;
                    Console.Write($"Por favor {nombreP4}, ingresa el número: ");
                    numeroP4 = int.Parse(Console.ReadLine());   //En el segundo programa repetiamos estas 3 lineas 3 veces, ahora solo una
                if(numeroP4 >100 || numeroP4 <0) Console.WriteLine($"Solo puedes indicar numeros entre 0 y 100");
                else if(numeroP4 > numeroAleatorio4) Console.WriteLine($"El número es menor");
                else if(numeroP4 < numeroAleatorio4) Console.WriteLine($"El número es mayor");  
            }
            System.Console.WriteLine();
            Console.WriteLine($"----------------------------------------------------------------------");
            Console.WriteLine($"Felicidades {nombreP4}, has adivinado, el numero es: " + numeroAleatorio4);
            Console.WriteLine($"Necesitaste de {intentos4} intentos");    
            Console.WriteLine($"Has salido del cuarto bucle");
            Console.WriteLine($"Aqui termina el cuarto programa"); 
        }
    }
}