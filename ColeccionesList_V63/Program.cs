using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;

namespace ColeccionesList_V63{
    class Program{
        //Las colecciones permiten agregar elementos en timpo de ejecución
        static void Main(string[] args){
            Console.WriteLine($"Colecciones de tipo List");
            List <int> numeros = new List<int>();

            numeros.Add(5);
            numeros.Add(7);
            numeros.Add(9);
            Console.WriteLine($"Imprimiendo con for");
            
            for (int i = 0; i < numeros.Count;i++){
                Console.WriteLine(numeros[i]);
            }  
            Console.WriteLine($"Imprimiendo ahora con un foreach");
            foreach (int num in numeros)//Por cada elementos, por cada num (numero)
            {
                System.Console.WriteLine(num);//Imprimimos dicho numero //Para estos casos es mas conveniente el foreach
            }
            System.Console.WriteLine();
            Console.WriteLine($"Segundo ejemplo, pero ahora rellenando la lista con un array");

            List <int> numerosConArray = new List<int>();//Al final estamos instanciando una clase, una clase generica
            int[] listaNumeros = new int[] {4,9,12,34,6};

            for (int i = 0; i < 5; i++){//El primer for lo ocupamos para añadir los datos del array a la lista
                numerosConArray.Add(listaNumeros[i]);
            }
            //Podemos usar count para saber el numero de elementos que tiene la lista(como en el primer ejemplo),
            // o usar el mismo array para contar con Lenght 
            for (int i = 0; i < listaNumeros.Length; i++){//Y el segundo como anteriormente, para leer los datos que hay en la lista
                Console.WriteLine(numerosConArray[i]);
                
            }
            System.Console.WriteLine();
            Console.WriteLine($"--------------------------------------------------------------------------------------");
            
            Console.WriteLine($"Tercer ejemplo: Ahora haciendolo mas dinamico, preguntando el numero de elementos");
            List <int> elementos = new List<int>();
            Console.WriteLine($"¿Cuántos elementos deseas para la lista?");
            int elem = int.Parse(Console.ReadLine());
            Console.WriteLine($"Introduce los " + elem + " elementos por favor: ");
            
            for(int i = 0; i < elem; i++){//For para agregar elementos a la lista de acuerdo al numero de elementos que el usuario indique
                elementos.Add(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine($"Elementos introducidos: ");
            
             for (int i = 0; i < elementos.Count; i++){//Como anteriormente, para leer los datos que hay en la lista
                Console.WriteLine(elementos[i]);
            }
            System.Console.WriteLine();
            Console.WriteLine($"Cuarto ejemplo: Ahora con un bucle while");
            Console.WriteLine($"Introduce valores a la lista (indica un 0 para salir)");
            List <int> NumeroCuartoEj = new List<int>();
            int elementoLista;
            do
            {
                elementoLista = int.Parse(Console.ReadLine());
                NumeroCuartoEj.Add(elementoLista);

            } while (elementoLista!=0);

            //Ahora es cuando mas conviene un foreach, porque en teoria no sabemos cuantos elementos tendra la lista
            //ya que eso lo hara el usuario en tiempo de ejecucion (aunque podemos usar for, con la propiedad count de la lista)
            Console.WriteLine($"Elementos introducidos");
            //Las siguientes listas en teoria tambien nos imprimira el 0, pero ese numero solo fue la condicion para salir
            //si no queremos que se vea al imprimir los numeros, podemos eliminarlo de la lista con el metodo remove, haciendo uso de indexOF
            //Entonces:
            NumeroCuartoEj.RemoveAt(NumeroCuartoEj.Count-1);//Con esta instruccion estamos eliminando ese 0 introducido al final
            //es decir, removeAt, en el indice, cuanta todos los elementos, menos 1, da igual a la ultima posicion
            foreach (int num in NumeroCuartoEj)
            {
                Console.WriteLine(num);
                
            }
            Console.WriteLine($"------------------------------**************Sexto Ejemplo************------------------------------------");
            
            Console.WriteLine($"Sexto ejemplo: Intentando la pratica del array, pero ahora indicando el num de elementos (solo asi se podra, jaja) y con un for");
            Console.WriteLine($"Introduce el numero de elementos para el array");
            int elementosSextoEj = int.Parse(Console.ReadLine());
            int[] elemNumSextiEj = new int[elementosSextoEj];
            Console.WriteLine($"Introduce los elementoss");
            int numSexto;
            for (int i = 0; i < elementosSextoEj; i++)
            {
                numSexto = int.Parse(Console.ReadLine());
                elemNumSextiEj[i] = numSexto;
            }
           
            Console.WriteLine($"Elementos introducidos al array: ");
          
            //NumeroCuartoEj.RemoveAt(NumeroCuartoEj.Count-1);//Con esta instruccion estamos eliminando ese 0 introducido al final
            //es decir, removeAt, en el indice, cuanta todos los elementos, menos 1, da igual a la ultima posicion
            foreach (int num in elemNumSextiEj)
            {
                Console.WriteLine(num);
                
            }
            Console.WriteLine($"------------------------------**************------------------------------------");
            
            Console.WriteLine($"Quinto ejemplo: Intentando la cuarta practica, ahora con un array (sin especificar el numero de elementos), y seguir con un bucle while");
            Console.WriteLine($"Introduce valores a la lista (indica un 0 para salir)");
            int[] elemNum;
            int elementoLista2 = 1;

            while (elementoLista2 != 0);{

                elementoLista2 = int.Parse(Console.ReadLine());

                elemNum = new int[]{elementoLista2};//Ahora estamos rellenando el array
        
            }
            Console.WriteLine($"Elementos introducidos al array: ");
          
            //NumeroCuartoEj.RemoveAt(NumeroCuartoEj.Count-1);//Con esta instruccion estamos eliminando ese 0 introducido al final
            //es decir, removeAt, en el indice, cuanta todos los elementos, menos 1, da igual a la ultima posicion
            foreach (int num in elemNum)
            {
                Console.WriteLine(num);
                
            }
            
            //Con este quinto ejemplo, comprobamos la limitacion del array, y es que no podemos agregar elementos en tiempo de ejecucion
            //lo cual las listas si nos permiten (bueno, a menos que indicaramos cuantos elementos vamos a agregar)

            //Como conclusion en este proyecto, nos damos cuenta que los array de alguna forma tambien puede ser dinamicos, y ser llenados en tiempo de ejecucion
            //esto se ve en el ejemplo sexto: Sin embargo, la unica forma de hacer esto, es especificando el numero de elementos para el array
            //esa seria realmente la limitacion del array en comparacion de una lista
            //ya que las listas ademas de ser dinamicas, y dejar agregar elementos en tiempo de ejecucion, tambien podemos ingresar los elementos
            //que nosotros queremos, o en este caso, que el usuario quiera, sin tener que limitarlo a que en principio eliga un numero (por ejemplo, que tal si ni 
            //el propio usuario sabe cuantos elementos va a inggresar), pues las listas nos proveen estas herramientas y accesibilidad de agregar elementos sin tener
            //forzosamente que indicar el numero de elementos, esto se ve en el ejemplo 4, con el bucle whiel
            //ya que el usuario podia ingresar todos los numeros que quisiera, y cuando escribe 0, pues se cierra el bucle

            /* 
              Entonces:
              *Los arrays si permiten agregar en tiempo de ejecucion, pero se debe indicar el numero de elementos que contendra (lo puede indicar el usuario)
              ese es su limite y desventaja
              
              *En cambio, las listas tienen sobre esto, porque ellas pueden agregar sin saber el numero de elementos inicialmente

              *Ademas con las listas no solo podemos agregar, tambien eliminar, buscar, ordenar, acceder a cierta elemento, contar los elementos, etc.
              Esas son las ventajas

              *La desventaja es que a cambio de esto, nos consume mas recursos, por eso se recomienda usarlas cuando manejemos grandes cantidades de datos
              o cuando tengamos que realizar muchas operaciones de las mencionadas(ordenar, eliminar, agregar, etc) con ellas.
            }
            */
            
            
        }
    }
}