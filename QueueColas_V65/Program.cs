using System;
namespace QueueColas_V65{
    class Program{
        static void Main(string[] args)
        {
            Console.WriteLine($"Comprobando que el funcionamiento del metodo Add de List seria igual a: addLast de LinkedList");
            //Es decir, que cada elemento lo agrega al final
            List<int> numeros = new List<int>();
            numeros.Add(1);//Uno al final
            numeros.Add(3);//Tres al final
            numeros.Add(6);//Seis al final
            numeros.Add(10);//Diez al final
            numeros.Add(4);//Cuatro al final
            numeros.Add(23);//Veintitres al final
            //Quedando 1,3,6,19,4,23
        
            int[] array =  new int[]{25,45,12,100};

            foreach (int item in array)
            {
                numeros.Add(item);
            }

            //1, 3,6, 10, 4, 23 //Es como usar el addLast de un LinkedList (Asi funciona el metodo add de List)

            foreach(int i in numeros) Console.Write(i + ", "); 
            Console.WriteLine($"");
            
            Console.WriteLine($"\nPractica con Queues (Colas)");
            //Las colas se usan cuando en una aplicacion manejjemos procesos de forma secuencial, es decir, cuando
            //termine una cosa, siga con la otra y asi, pues se usan las Queue
            //imaginemos una impresora, la primera pagina que enviamos se imprime, luego la segundo y asi
            //o imaginemos una cola al espera en el supermercado para pagar nuestros productos
            //El primer cliente que llega, es al primero que se le atienda
            //primero en entrar a la cola, primero en salir

           Queue <int> datosNum = new Queue<int>();
         
           datosNum.Enqueue(1);
           datosNum.Enqueue(2);
           datosNum.Enqueue(3);
           datosNum.Enqueue(4);
           datosNum.Enqueue(5);
           //LOs acomoda de la siguiente forma: 1, 2, 3, 4, 5
           //Por lo que decimos que el metodo enqueue(); tambien rellena la cola de forma addLast (como LinkedList) y 
           //add (como list)
           //Es decir para agregar, la forma de rellanar la lista para 
           /* 
             Imaginemos que tenemos 1,2,3,4,5
             *LinkedList: addLast(); cada valor lo agrega al ultimo : 1,2,3,4,5
             *List: add(); = addLast(): cada valor lo agrega al ultimo
             *Queue: Enqueue(); = addLast(): cada valor lo agrega al ultimo
           */
           //*La diferencia que tiene queue es la forma en que saca, elimina o descola esos elementos
           //*que como ya lo dijimos, al primero que ingreso es al primero que saca
           //si desencolamos un elemento (eliminamos)
           Console.WriteLine($"Recorriendo el Queue");
           
           foreach(int i in datosNum){//Por cada i(numero entero) que hay en la lista
            Console.WriteLine(i);//Imprime los datos
           }

           //Elimando elementos del Queue
           System.Console.WriteLine("Elimando elementos del Queue (Elimina el primero en entrar, que seria 1, será el primero en salir");
           datosNum.Dequeue();//No tiene parametros porque simplemente va a eliminar el primer valor que se ingreso
           //en este caso va a eliminar el 1, primero en entrar, primero en salir:
           //Ahora imprimira: 2, 3, 4, 5
           foreach(int i in datosNum) Console.WriteLine(i);
           
        }
    }
}