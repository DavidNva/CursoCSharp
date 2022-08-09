using System;
using System.Threading.Tasks;
namespace Thread_Ejemplo3_TareasCompletadas_V111
{
    class Program
    {
        static void Main(string[] args)
        {
            var tareaTerminada = new TaskCompletionSource<bool>();
            //Con los TaskCompletionSource es como si usaramos el metodo join de los threads (hilos)
            //Con esta clase no forzosamente debemos estar utilizando dichos hilos, como tal podemos usarlo tambien
            //para verificar que una tarea ya termino o no, y asi poder seguir avanzando de cualquier programa con C#

            //Se aplican en BBDD por ejemplo para cerrar conexiones, o continuar algo despues de cerrar la conexion
            //O con ficheros, al cambiar de rutas, etc.
            //Con esto podemos preguntar si el programa ha terminado una tarea o no, y en funcion de eso continuar con la ejecucion o lo que queramos que haga el programa
            var hilo1 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Hilo 1");
                    Thread.Sleep(1000);
                }
                tareaTerminada.TrySetResult(true);
            });

            var hilo2 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Hilo 2");
                    Thread.Sleep(1000);
                }
                //tareaTerminada.TrySetResult(true);//Con esto el método hilo 2 tambien tiene el retorno de si la tarea ha terminado
            });
            var hilo3 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Hilo 3");
                    Thread.Sleep(1000);
                }
            });

            hilo1.Start();
            hilo2.Start();
            //En esta linea de abajo nos da el resultado de que la tarea se terminó  y se puede seguir avanzando (en este caso ejecuta primero las tareas de los dos primeros hilos),
            //si la colocamos arriba pues solo tomara en cuenta a las tareas del hilo 1
            var resultadoTarea = tareaTerminada.Task.Result;//Nos devuelve el valor (que seria true) y a partir de aqui termina una tarea y luego la siguiente
            //En este caso primero termina las dos tareas anteriores, en este caso la ejecucion de los dos hilos, y cuando terminan esas dos, es alli donde comienza con el tercer hilo
            hilo3.Start();
        }
    }
}