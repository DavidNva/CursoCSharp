using System.Security.Authentication.ExtendedProtection;
using System;

namespace StacksYDictionary{
    class Program{
        static void Main(string[] args){
            Console.WriteLine($"Practica con Stacks (Pilas)");
            //Las pilas o stacks como su nombre lo indica, son colecciones que almacenan sus elementos en forma de pilas
            //imaginemos cuando lavamos platos y los acomodamos (una pila de platos)
            //El ultimo en ser lavado, se coloca al inicio, 
            //Ese ultimo en ser lavado, sera el primero que tomemos a la hora de comer
            //Es decir, las pilas son una estructura de datos que siguen la filosofia de LIFO: Last In - First Out
            //                                                                        Ultimo en entrar - Primero en salir
            //                 Ultimo plato en entrar, en acomodarse, en apilarse (en ser lavado jaja) - Es el primero en salir(el primero que utilizamos)
            Stack <int> datosNum = new Stack<int>();

            datosNum.Push(1);//Para agregar elementos a la pila, se usa push
            datosNum.Push(2);
            datosNum.Push(3);
            datosNum.Push(4);
            datosNum.Push(5);
            //EL metodo push funciona como el metodo addFirst de una LinkedList
            //Porque agrega al principio cada elemento, por ejemplo esta sucesion del 1al 5 que agregamos
            //pues los agregaria asi:  5,4,3,2,1. Es decir, cada valor que agrega lo coloca al inicio, si ahora ingresamos otro numero
            //por ejemplo el 6, pues lo agregara al inicio, antes que el 5, 
            //de esta forma: 6, 5, 4, 3, 2, 1.
            //

            Console.WriteLine($"Recorriendo el Stack");
           
            foreach(int i in datosNum){//Por cada i(numero entero) que hay en la lista
             Console.WriteLine(i);//Imprime los datos
            }
            Console.WriteLine($"//Como vemos agrega los elementos como pila, el ultimo en entrar, se agrega al inicio"
                              +"(el ultimo en entrar fue el 5, pue sse agrego al inicio de la lista");
           
            //Elimando elementos del Stack
            System.Console.WriteLine("Elimando elementos del Stack (Elimina el ultimo en entrar, en este caso el 5");
            datosNum.Pop();//Para eliminar elementos a la pila se usa pop (quita el 5)
            foreach(int i in datosNum) Console.WriteLine(i);

            System.Console.WriteLine();
            Console.WriteLine($"-----------------------------------------------------------");
            
            Console.WriteLine($"Practica con Dictionary -Diccionarios");
            System.Console.WriteLine();
            //Los diccionarios son muy comdos, por ejemplo, al almacenar informacion en base de datos
            //Se debe recalcar que este tipo de coleccion consume mas recursos que cualquier otra colección
            //Esto es como una ley, jaja
            //Todo aquello que es muy practico, y muy util, consume mas recursos
            //Los diccionarios se basan en tener una clave y un valor 
            //Podemos guiarnos de la clave (puede ser de cualquier tipo, solo que no se repita en una misma coleccion) para encontrar cierto valor
            //EL tipo de clase y tipo de valor se indican cuando se declara o se instancia la clase generica de tipo dictionary:
            //Por ejemplo, imaginemos que tenemos ciertas nombres de personas con edades, pues usemos su nombre como identificador y el valor sera su edad
            //entonces la clave sera de tipo string, y el valor de tipo int:

            Dictionary<string,int> edades = new Dictionary<string, int>();
            edades.Add("David",20);//Para agregar usa el metodo add (como las listas), y debemos señalar los dos parametros
            // dependiendo del tipo que indicamos en la instancia
            edades.Add("Teresa",43);
            edades["Maria"] = 73;//Tambien se pued agregar de esta forma, como si fueran arrays
            edades["Iveth"] = 19;

            //para imprimir usamos el foreach, en este caso sera mas especial el tipo para poder obtener la key y el valor
            foreach (KeyValuePair<string,int> persona in edades)//COn la instancia persona de la clase KeyValuePair podremos acceder a sus propiedades
                                                                //teniendo asi el valor y la llave
            {
                Console.WriteLine("Nombre: {0}, Edad: {1}",persona.Key,persona.Value);
                
            }
            //La forma de rellenar estos diccionarios seria com el metodo addLast de una LinkedList, ya que cada elemento nuevo lo agrega al final 

            
        }
    }
}