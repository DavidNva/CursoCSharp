using System;

namespace Excepciones_V23{
    class Program {
        /*
          Si estamos seguros de las posibles excepciones podemos especificar
          o si queremos como tal especificar que hacer en caso de cada excepcion tendriamos que hacer varios catch
          aunque tambien es posible, que si no sabemos exactamente las posibles excepciones
          podemos indicar una general, que indique que hacer en caso de mostrar una excepcion cualquiera que no conozcamos
        */
        static void Main (string[] args){
            //Se recomienda afinar la mayoria de las excepciones posibles, pero si es un programa
            //con demasiados posibles excepciones que no sabemos, entonces si declaramos una de manera general
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
                //Lo de declarar una excepcion generaal que capture todas las excepciones, a pesar de esa ventaja que tiene, las desventajas son
                //que no dejamos claro al usuario de lo que sucedio realmente, o del porque esta cometiendo error con el programa
                //ademas tambien, el programador que lea el codigo, si comparte dicho proyecto, sera dificil saber que errores pudiera ocurrir con el mismo

                //En C#, cuando se va  a indica una excepcion general, se puede omitir la captura de la excepcion, 
                //solo indicando el catch, aunque no se considera una buena practica, es mejor indicarle la excepcion, aun cuando sea de manera general
                }catch (Exception ex)/*(Exception ex)*/{//Si no logra ejecutar, entonces captura la excepcion, en este caso captura la excepcion de formato
                    Console.WriteLine($"No has introducido un valor numérico valido.\nSe toma como número introducido el 0");//E indica al usuario su error
                    Console.WriteLine(ex.Message);//Imprime el mensaje del porque fue el error (en ingles).
                    
                    miNumero = 0;//para no interrumpiar el juego, y no dar error al inicializar la variable miNumero, la iniciamos en 0
                }/*catch(OverflowException ex){ //De esta forma el programa no cae para esta excepcion 
                    Console.WriteLine($"Has introducido un valor demasiado alto. Solo puedes indicar entre 0 y 100.\nSe toma como número introducido el 0");//E indica al usuario su error
                    miNumero = 0;
                }*/
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