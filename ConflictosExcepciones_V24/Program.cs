using System;

namespace ConflictosExcepciones_V24{
    class Program {
//*Regla de orden de excepciones y Excepciones con filtros.
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
                //Por ejemplo, si tenemos un programa donde conocemos algunas excepciones, pero tenemos duda de las demas, podemos declarar una general
                //obviamente que generalice los errores, pero tambien, podemos capturas las excepciones una a una, de las que tengamos conocimiento
                //la regla en esta forma, es que las excepciones especificas deben ir antes de la general, de lo contrario causaria un conflicto entre 
                //las excepciones, ya que seria como decirle primero has esto, y luego otra cosa, por eso se debe declarar antes como con el ejemplo 
                //Primeros los especificos y por ultimo el generico
                //Otra cosa, es que el compilador toma la captura de excepciones al que mas se adecue, cuando encuentra una
                //ignora las demas que tambien podria aplicar (si se especificaran), pero entonces quizas no tomaria la mejor para dicha excepcion (solo quizas)
                //podemos omitir esta regla de primero los especificos y luego los generales, si indicamos en la excepcion generica que no contemple alguna excepcion
                //para asi poderle dar una intruccion diferente
                }catch (FormatException ex){ //De esta forma el programa no cae para esta excepcion 
                    Console.WriteLine($"No se admite valores de texto. Solo puedes indicar número.\nSe toma como número introducido el 0");//E indica al usuario su error
                    miNumero = 0;
                    //*FILTRO DE EXCEPCIONES  O EXCEPCION CON FILTRO, JAJA
                    //*LA SINTAXIS ES LA SIGUIENTE
                }catch (Exception ex) when (ex.GetType()!=typeof(OverflowException))/*(Exception ex)*/{//*En este caso vemos que aun cuando ya declaramos la excepcion general
                    Console.WriteLine($"Ha habido un error.\nSe toma como número introducido el 0");//*Abajo indicamos la de OverflowException, esto porque hicimos un filtro de excepciones
                    Console.WriteLine(ex.Message);//Imprime el mensaje del porque fue el error (en ingles).
                    miNumero = 0;//para no interrumpiar el juego, y no dar error al inicializar la variable miNumero, la iniciamos en 0
                }catch (OverflowException ex){ //De esta forma el programa no cae para esta excepcion 
                    Console.WriteLine($"Has introducido un valor demasiado alto. Solo puedes indicar numeros entre 0 y 100.\nSe toma como número introducido el 0");//E indica al usuario su error
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
        }
    }
}