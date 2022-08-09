using System;
namespace Threads_V108
{
    class Program
    {
        static void Main(string[] args)
        {
            //Para crear un hilo se usa la clase thread
            Thread t = new Thread(MetodoSaludo);//En sus argumentos se le indica la accion a realizar por ese segundo hilo al principal
            t.Start();//Este metodo pone en ejecucion ese hilo
            t.Join();
            //Con esto, nos damos cuenta que se esta realizando con el hecho de que imprime los valores de manera aleatoria por decirlo de alguna forma
            //Por que como son dos hilos, se van ejecutando y es el procesador el que les da atencion o prioridad a uno, luego a otro, etc.
            
            Console.WriteLine("Ejemplo trabajar con hilos");
            Console.WriteLine("Imprimiendo desde el thread (o hilo ) 1");
            Thread.Sleep(500);//Duerme el hilo, medio segundo (500 milisegundos)
            Console.WriteLine("Imprimiendo desde el thread (o hilo ) 1");
            Thread.Sleep(500);
            Console.WriteLine("Imprimiendo desde el thread (o hilo ) 1");
            Thread.Sleep(500);
            Console.WriteLine("Imprimiendo desde el thread (o hilo ) 1");
            Thread.Sleep(500);
            Console.WriteLine("Imprimiendo desde el thread (o hilo ) 1");
            //La depuracion no mantiene en un punto en concreto y nos muestras los subprocesos que tenemos
            //o los hilos como tal
            //MetodoSaludo();

            Thread t2 = new Thread(MetodoSaludo);//En sus argumentos se le indica la accion a realizar por ese segundo hilo al principal
            t2.Start();//POdemos indicar otro hilo, que ejecuta el mismo metodos
            //Al ejecutar nos darmeos cuenta del funcionamiento de esto
            //Ademas si depuramos podremos observar los subprocesos
            t2.Join();//Metodo para sincronizar los hilos e indicar cuando termine uno, comienece otro y no como en los primeros ejemplos donde
            //el procesador decidia cuando hacer caso a uno y cuando a otro


            //Ahora si va hilo por hilo
            //Primero el primer hilo t que inidicamos
            //luego continua con el principal, donde tenemos en teoria el hilo uno{
            //y luego el t2 (seria el tercer hilo, o segundo subhilo) 
            //Al imprimir veremeos primero 5 veces el dos, luego 5 veces el 1 y por ultimo 5 veces el 2, sincronizadamente
        }
        static void MetodoSaludo()
        {
            Console.WriteLine("Imprimiendo desde el thread (o hilo ) 2");
            Thread.Sleep(500);//Duerme el hilo, medio segundo (500 milisegundos)
            Console.WriteLine("Imprimiendo desde el thread (o hilo ) 2");
            Thread.Sleep(500);
            Console.WriteLine("Imprimiendo desde el thread (o hilo ) 2");
            Thread.Sleep(500);
            Console.WriteLine("Imprimiendo desde el thread (o hilo ) 2");
            Thread.Sleep(500);
            Console.WriteLine("Imprimiendo desde el thread (o hilo ) 2");
        }
    }
}