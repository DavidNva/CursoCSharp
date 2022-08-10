using System;
namespace ClaseParallel_V116
{
    class Program
    {
        private static int acumulador = 0; 
        static void Main(string[] args)
        {
            //Cuando necesitamos que un metodo de forma paralela, de manera concurrente sea ejecutado
            Console.WriteLine("Hola");
            /*
            for (int i = 0; i < 100; i++)
            {
                 RealizarTarea(i);
                Console.WriteLine($"Acumulador vale {acumulador}. Tarea realizada por el hilo {Thread.CurrentThread.ManagedThreadId}");
            }
            */
            Parallel.For(0, 50, RealizarTarea);//Conseguimos que el metodo RealizarTareas se ejecute de forma concurrente por varias Task
            //Al ejecutar nos vamos a dar cuenta, de que eta usando varios hilos para la ejecucion, por ello, la impresion de los valores es mas rapida
            //Tener en cuenta igual que nosotros nunca indicamos realizar un hilo, o alguna Task. Por lo que es la clase Parallel la que los crea de acuerdo
            //a los recursos del procesador o los que esten ejecutando actualmente
            //Paralela, concurrente o al mismo tiempo
            //Y no hemos que tenido que declarar variaas task e inicializarlas, no usamos ningun metodo run, ni start, etc. 
            //Y el inicio, estamos haciendo lo mismo que el bucle for anterior, pero ahora con varias Task
            //Todo esto simplifica el codigo cuando un metodo se necesita ejecutar concurrentemente con un monton de tareas
            //La clase parallel es la que se encarga de crear los hilos que sean adecuados y los que pueda generar
            //para ejecutar la tarea, si nosotros declarar ninguna Task

            //Varia tareas realizar de forma concurrente (al mismo tiempo) lo que hay en un metodo
            //SEGUNDO EJEMPLO USANDO EXPRESION LABDA Y ESPECIFICANDO LA ACCION DESDE EL PROPIO PARALLEL
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("Segundo ejemplo");//Usando expresion lambda hace lo mismo que lo especificado anteriormente
            Parallel.For(0, 100, dato =>
            {
                Console.WriteLine($"Acumulador vale {acumulador}. Tarea realizada por el hilo {Thread.CurrentThread.ManagedThreadId}");
                if (acumulador % 2 == 0)
                {
                    acumulador += dato;
                    Thread.Sleep(100);
                }
                else
                {
                    acumulador -= dato;
                    Thread.Sleep(100);
                }
            });
        }

        static void RealizarTarea(int dato)
        {
            Console.WriteLine($"Acumulador vale {acumulador}. Tarea realizada por el hilo {Thread.CurrentThread.ManagedThreadId}");
            if (acumulador % 2 == 0)
            {
                acumulador += dato;
                Thread.Sleep(100);
            }
            else
            {
                acumulador -= dato;
                Thread.Sleep(100);
            }
        }
    }
}