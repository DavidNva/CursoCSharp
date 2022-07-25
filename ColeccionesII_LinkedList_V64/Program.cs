using System;

namespace ColeccionesII_LinkedList_V64{
    class Program{
        //Internamente cuando eliminamos un elementos de una lista, las posiciones se recorren, por ejemplo
        //la siguiente lista de numeros: 1,2,3,4,5,6,7
        //                   Posiciones: 0,1,2,3,4,5,6
        //Si por ejemplo, eliminaramos el numero 4, que se encuentra en la posicion 3
        //La lista recorre las posiciones, tomando la 3 que se elimino: 
         //Quedando de l siguiente forma: 1,2,3,5,6,7
        //                    Posiciones: 0,1,2,3,4,5
        //Ahora ya solo qudan 6 elementos, por lo que son 5 posiciones
        //como vemo, la posicion 3 que tenia almacenado el numero 4, ahora almacena el numero 5 (porque ya se elimino el 4)
        //es decir, ese espacio se recorrio al siguiente elemento para tomar su lugar
        //Es decir, en una lista todos los datos estan juntos, uno seguido de otro
        //Si en una lista estamos eliminando, agregando elementos, las list son pocas eficientes, haran que el programa vaya mas lento

        //En cambio las linkedlist son mas eficientes porque en lugar de posiciones elementos uno despues de otro
        //Las LinkedList estan formadas por nodos
        /*
          Los nodos son lugares de la memoria donde se almacenan la informacion, pero en este caso todos los nodos tienen 
          unos polos, vertices o enlaces, como lo queramos llamar
          De alli el nombre de link(enlace)
          Es decir, todos los nodos donde almacenamos la informacion tienen dos links que conectan con el siguiente elementos y con el anterior
          Los nodos realmente son tambien objetos (pertenenciente a la clase linkedlist)
          Las linkedList seria una coleccion de objetos de tipo nodo, son los objetos que se pueden instanciar con esta clase generica
          Por logica, el primer nodo de una linkedlist tiene un nodo que apunta a null
          imaginemos     null  <=s Nodo(Dato) => SiguienteEnlace de nodo
          y el ultimo elemento (el ultimo nodo) de una linkedList tambien tienen un polo, un enlace que apunta a null
          es decir:       EnlaceNodoAnterior <= Nodo(Dato) => null
          Pero todos los demas, (los datos de en medio, los nodo de en medio) estan apuntando respectivamente con el siguiente nodo y con el anterior

          Cuando eliminamos un dato(nodo) en concreto lo unico que ocurre es que se actualizan los links
          En vez de mover o recorre todos los datos a una posicion anterior como ocurria con las lista, en este tipo
          pues solo actualizamos los elnaces (links) apuntando a una nueva direccion, a un nuevo nodo, pero como tal esos nodos (datos) no se mueven de su lugar
          esto hace que las linkedList sean mucho mas eficientes que las list 

          Esto nos lleva a preguntarnos cuando elegir una u otra?
          PUes sucede que cuando vamos a usar colecciones y en este caso vamos a estar constantemente agregando o eliminando
          pues conviene usar una linkedList
          Ahora, si solo queremos la coleccion para usar sus metodos, como buscar, ir agregando solamente, etc. Pues conviene solo una list

        */
        static void Main(string[] args){
            Console.WriteLine("Hola video 64");
            Console.WriteLine($"Primer ejemplo con LinkedList");
            LinkedList<int> numeros = new LinkedList<int>();
            foreach (int i in new int[]{10, 8, 6, 4, 2, 0})//Por cada i (numero) en el array
            {
                numeros.AddFirst(i);//Agregalo al principio de la lista
                //Por lo que ira de esta forma, primero el 10, luego primero el 8, luego primero el 4
                //por lo que la lista quedara asi: 0, 2, 4, 6, 8, 10. Cada que agrega un nuevo numero lo coloca al principio
                //por eso esta seria la forma del metodo AddFirst();
                //Si usaramos el metodo AddLast(); Pues la forma seria agregar al ultimo
                //ahora si quedara: Coloca al ultimo el 10, luego coloca al ultimo el 8, luego coloca al ultmo el 6, sucesivament
                //por lo que la lista quedaria rellena: 10, 8, 6, 4, 2, 0. Cada que agrega un nuevo numero lo coloca al final
            }
            //POdemos eliminar un valor de la lista
            numeros.Remove(2);//Por ejemplo
            //POdemos agregar otro valor a la lista mediante nodos
            LinkedListNode <int> nuevo = new LinkedListNode<int>(15);//Esto es un objeto de tipo nodo, un int 
            numeros.AddLast(nuevo);//Lo agregara al final, entonces despues del 10
            //Estamos trabajando con nodos (de la clase LinkedListNode) e int
            numeros.AddBefore(nuevo,12);//En este caso dice, agrega antes del nodo: nuevo (antes del 15)
            numeros.AddAfter(nuevo,20);//En este caso dice, agrega despues del nodo: nuevo (despues del 15)

            foreach(int num in numeros){
                Console.WriteLine(num);
                
            }
            //Recordemos que ahora la coleccion tiene nodos (datos) indicados de la forma: 0, 2, 4, 6, 8, 10
            Console.WriteLine($"Segundo ejemplo con LinkedList (Usando la instancia inicial) y recorriendolo por sus nodos");
            //POdemos crear un un bucle for usando linkedListNOde, y leer la lista que tenemos

            //Es como cuando hacemos un for normal o basico con un int i = 0;
            //en este caso el tipo es de int pero instanciado de una clase generica
            //EL primer elemento del for estamos diciendo que empiece desde la primera posicion que tiene la lista numeros
            // (el valor que tiene esa posiscion es  0)
            //El segundo elemento (condicion) del for, solo verifica que el nodo no sea null, es decir que haya valor en la lista, cuando 
            //ya no encuentre nada saldra del bucle for
            //El tercer elemento indica el incremente, en este caso el paso a otro numero, es como cuando decimos i++; Que se refiere a cambiar 
            //su valor a uno mayor, por ejemplo si es 0, lo cambia a 1, sucesivamente
            //Lo mismo pasa con el nodo, decimos que nodo = nodo.next ( A cada vuelta de bucle el nodo cambia su valor al siguiente nodo)
            //De esta forma el console.writeline puede ir leyendo cada valor de la lista, igual que lo haciamos con el foreach anterior
            for (LinkedListNode<int> nodo = numeros.First; nodo != null; nodo = nodo.Next)
            {
                Console.WriteLine(nodo.Value);
                
            }
            //EJemplo bucle normal
            /*
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
                
            }*/
        }
    }
}