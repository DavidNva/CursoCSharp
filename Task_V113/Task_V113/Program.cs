using System;
namespace Task_V113
{
    class Program
    {
        static void Main(string[] args)
        {
            //Las task estan un un nivel de abstraccion superior a los threads, su funcionamiento es como los pool de threads
            //porque estas task asignan algun numero posible de hilos a ejecutar o no solo hilos, sino algunas otras tareas a ejecutar, dependiendo de la capacidad del procesador
            //Internamente las task tendria un pool de threads, o esa dinamica manejan 
            Console.WriteLine("Tasks");
            /*
            Task tarea = new Task(EjecutarTarea);
            tarea.Start();
            */
            //El codigo anterior, la manera en realizar  y poner en ejecucion un thread se puede simplificar en una linea con el metodo run:
            //Usando la expresion lamda
            Task tarea = Task.Run(() => EjecutarTarea());//De esta forma crea e indica la tarea a realizar y ademas lo pone en ejecucion

            Task tarea2 = tarea.ContinueWith(EjecutarOtraTarea);//Esta continueWith necesita que la tarea que esta llamando, en este caso el metodo pueda recibir un parametro de tipo task
            //para poderindicar que ha terminado la tarea anterior y continuar con esta
            //De esta forma las tareas se sincronizan una despues de otra
            
            //Tercera tarea indicando con expresiones lamba para ahorra lineas
            //Es como si definieramos un metodo sin nombre
            /*EJEMPLO
            Task tarea3 = new Task(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    var miThread = Thread.CurrentThread.ManagedThreadId;//Obtiene el id del thread en el que estamos
                    Thread.Sleep(1000);//Duerme un segundo
                    Console.WriteLine("Tarea correspondiente al hilo: " + miThread + 
                        " ejecutándose desde el Main"); //Ejecuta esto 100 veces
                }
            });
            tarea3.Start();
            */
            Console.ReadLine();
        }

        static void EjecutarTarea()//Para tarea 1
        {
            for (int i = 0; i < 10; i++)
            {
                var miThread = Thread.CurrentThread.ManagedThreadId;//Obtiene el id del thread en el que estamos
                Thread.Sleep(1000);//Duerme un segundo
                Console.WriteLine("Esta vuelta de bucle corresponde al Thread: " + miThread); //Ejecuta esto 100 veces
            }
        }

        static void EjecutarOtraTarea(Task obj)//Para tarea 2, con el ejemplo de task consecutivas, por ello se debe usar un parametro tipo task
            //seria como avisar que la otra tarea termino su ejecucion y poder seguir con la siguient
        {
            for (int i = 0; i < 10; i++)
            {
                var miThread3 = Thread.CurrentThread.ManagedThreadId;//Obtiene el id del thread en el que estamos
                Thread.Sleep(1000);//Duerme un segundo
                Console.WriteLine("Esto es otra tarea y ésta vuelta de bucle corresponde al Thread: " + miThread3); //Ejecuta esto 100 veces
            }
        }
    }
}