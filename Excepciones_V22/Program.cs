using System;

namespace Excepciones_V22{
    class Program {
        /*
          Las excepciones son errores en tiempo de ejecución del programa que escapan al control del programador
          Por ejemplo:
          *Datos ingresados por el usuario
          *Memoria corrupta
          *Desbordamiento de pila
          *Sectores de disco duro defectuoso
          *Acceso a ficheros inexistentes (Por ejemplo si queremos acceder a una ruta de imagen o archivo y ya no existe)
          *Conexiones a BBDD interrumpidas 
          * ETC.
          La solucion a excepciones son los bloques try...catch
          try   --  intenta
          catch -- Captura
        */
        /*
          Si estamos seguros de las posibles excepciones podemos especificar
          o si queremos como tal especificar que hacer en caso de cada excepcion tendriamos que hacer varios catch
          aunque tambien es posible, que si no sabemos exactamente las posibles excepciones
          podemos indicar una general, que indique que hacer en caso de mostrar una excepcion cualquiera que no conozcamos
        */
        static void Main (string[] args){
        
            Console.WriteLine($"---------------------------");
            Random numero = new Random();
            int numeroAleatorio = numero.Next(0,100);
            Console.WriteLine(numeroAleatorio);
            Console.WriteLine($"Hola, este es un juego en el que debes adivinar un número");
            Console.WriteLine($"Los números comprendidos entre 0 y 100");
            Console.Write($"Ingresa tu nombre por favor: ");
            string nombre = Console.ReadLine();
            int miNumero;
            int intentos = 0;
            do{
                intentos ++;
                try{//intenta ejecutar estas lineas, pero si el usuario ingresa otro dato que no sea numero
                Console.Write($"Por favor {nombre}, ingresa el número: ");
                miNumero = int.Parse(Console.ReadLine());
                }catch(FormatException ex){//Si no logra ejecutar, entonces captura la excepcion, en este caso captura la excepcion de formato
                    Console.WriteLine($"No has introducido un valor numérico valido.\nSe toma como número introducido el 0");//E indica al usuario su error
                    miNumero = 0;//para no interrumpiar el juego, y no dar error al inicializar la variable miNumero, la iniciamos en 0
                }catch(OverflowException ex){ //De esta forma el programa no cae para esta excepcion 
                    Console.WriteLine($"Has introducido un valor demasiado alto. Solo puedes indicar entre 0 y 100.\nSe toma como número introducido el 0");//E indica al usuario su error
                    miNumero = 0;
                }
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
            Console.WriteLine($"A partir de esta linea el codigo del programa continuaria");
            
            //------Captura de varias excepciones--Video 23
            /*
            try{
                //Codigo a intentar
            }catch(FormatException e){
                //Codigo a ejecutar si hay FormatException
                
            }catch(OverflowException e){
                //Codigo a ejecutar si hay OverFlowException
            }
            */
        }
    }
}