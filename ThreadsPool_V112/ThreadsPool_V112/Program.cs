using System;
using System.Threading;
using System.Threading.Tasks;
namespace ThreadsPool_V112
{
    class Program
    {
        static void Main(string[] args)
        {
            //Los threads, hilos, o tambien podemos llamarlos subprocesos

            //Los pool de threads son como los pool de conexiones a base de datos
            //Se usan cuando tenemos que realizar muchas tareas, quizas a la vez
            //Cuando tenemos 60, 100 , 200 tareas a realizar, etc. Y no seria muy recomendable tener que hacer un thread o hilo por cada una de esas tareas
            //Entonces es aqui donde se aplican lo pool de Threads
            //Para ello creamos el pool de threas y dejamos que sea la pc y sus recursos que thread va a ejecutar cierta tarea
            //Es decir si creamos este pool, cada uno de estos hilos que forman parte de pool realizara una tarea en concreto

            //La diferencia esta en que cuando un thread termine de realizar una tarea, se reutiliza para realizar las siguientes tareas, hablando de 60 o ma tareas
            //por eso ya no tendriamos que crear un thread para cada tarea, si reutilizar solo 3 threads indicados en el pool por ejemplo.
            //Reutilizandolos sucesivamente.

            //Obviamente si crearamos un threads para cada tarea, se ejecutarina mas rapido pero esto a cambio del consumo de recursos
            //Y como tal los pool de threads es lo que soluciona, sirve para una optimizacion de recursos
            Console.WriteLine("Threads Pools");
            for (int i = 0; i < 100; i++)//Con esto crearemos 100 hilos y los inicializaremos
            {
                /*
                Thread t = new Thread(EjecutarTarea);//En cada vuelta de bucle crea un nuevo hilo y ejecuta la tarea del metodo indicado
                t.Start();//Al igual que en cada vuelta de bucle comienza el hilo creado
                */
                //Creacion de pool de threads
                ThreadPool.QueueUserWorkItem(EjecutarTarea, i);//Con esto podemos eliminar la creacion de un thread por cada tarea
                //Ahora cada vez que ejutemos las 100 tareas (porque eso indica el iterador i que indicamos, repetir 100 veces algo, en este caso el metodo ejecutarTarea
                //Anteriormente creabamos un hilo por cada tarea (y las tareas se realizaban mas rapido claro, pero tecnicamente consumia mas recursos)
                //En cambio con el ThreadPool crea threads o hilos a la conveniencia del procesador de la PC, en las pruebas por ejemplo, creaba 12 o 17 hilos, pero cada
                //Vez que un hilo terminaba una tarea, pues tomaba una nueva y asi sucesivamente, por eso no es neceario crear un hilo por cada tarea
                //sino reutilizar los threads con este ThreadPool, y asi optimizar los recursos, esa es la ventaja
                //No confundamos el 100 del for (eso solo indica el numero de veces que se realiza la tarea)
                //la creacion de hilos depende del ThreadPool con el procesador, teniendo una forma de reutilizando de los hilos
            
            }
            Console.ReadLine();
        }//Al declarar un parametro y usarlo, en el Pool the threads tambien se debe usar, por que si no el metodo devolvera un valor null para la variable nTareas y esto dara una excepcion que tumbara el programa en consola
        static void EjecutarTarea(Object o)//El parametro es para el threadPool y no de error, ademas lo podemos usar poe ejemplo para indicar en que tarea nos encontramos   
        {
            int nTarea = (int)o;//Haciendo un casting de ese objeto a int
            Console.WriteLine($"Thread n°: {Thread.CurrentThread.ManagedThreadId} ha comenzado la tarea n° {nTarea}");//Obtiene el ID del hilo
            Thread.Sleep(1000);//Duerme 1 segundo la ejecucion del hilo para pasar a la siguiente instruccion
            Console.WriteLine($"Thread n°: {Thread.CurrentThread.ManagedThreadId} ha terminado la tarea n° {nTarea}");
        }
    }
}