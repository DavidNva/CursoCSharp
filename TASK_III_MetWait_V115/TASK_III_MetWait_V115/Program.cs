using System;
namespace TASK_III_MetWait_V115
{
    class Programm
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola");
            realizarTodasTareas();
            Console.ReadLine();
        }

        static void realizarTodasTareas()
        {
            //Con las pruebas nos damos cuenta que efectivamente las Task funcionan como los pool de threads, donde se pueden reutilizar los hilos utilizados
            //Al terminar su tarea en concreto. Son las task las que deciden de acuerdo al procesador de la PC, cuentos pool crear o cuantos necesita
            var tarea1 = Task.Run(() =>
            {
                EjecutarTarea();//Tarda un segundo cada impresion
            });

            tarea1.Wait();//Espera que termine la tarea indicada
            var tarea2 = Task.Run(() =>
            {
                EjecutarTarea2();//Tarda medio segundo cada impresion
            });

            //tarea2.Wait();//Con esto sincroniza la ejecucion de tareas , como los metodos join(); de los threads
            Task.WaitAny(tarea1, tarea2);//Espera que al menos una tarea de las indicadas terminen
            //Task.WaitAll(tarea1, tarea2);//Espera a que todas las tareas indicadas terminan

            var tarea3 = Task.Run(() =>
            {
                EjecutarTarea3();//Tarde medio segundo cada impresion
            });
        }
        static void EjecutarTarea()
        {
            for (int i = 0; i < 5; i++)
            {
                var miThread = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(1000);
                Console.WriteLine("Esta vuelta de bucle corresponde a la tarea 1. Thread: " + miThread);
            }
        }

        static void EjecutarTarea2()
        {
            for (int i = 0; i < 5; i++)
            {
                var miThread = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(500);
                Console.WriteLine("Esta vuelta de bucle corresponde a la tarea 2. Thread: " + miThread);
            }
        }

        static void EjecutarTarea3()
        {
            for (int i = 0; i < 5; i++)
            {
                var miThread = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(500);
                Console.WriteLine("Esta vuelta de bucle corresponde a la tarea 3. Thread: " + miThread);
            }
        }
    }
}