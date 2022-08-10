namespace CancelacionTask_V117
{
    class Program
    {
        //Break; Salir de un bucle, un if, etc.
        //Return: Devuelve al flujo de ejecucion. (Sale de un metodo, de un condicional, de un if, etc. Igual que el break, solo que este return sirve para salir completamente del metodo
        //y continuar la ejecucion de demas lineas de codigo del programa principal
        static int acumulador = 0;
        static void Main(string[] args)
        {
            //Creamos cancellation token y hay que propagarlo
            CancellationTokenSource miToken = new CancellationTokenSource();//Señala quien es el cancellation token que debe cancelar la tarea

            CancellationToken cancelaToken = miToken.Token;//Este es el cancellation token mencionado 
            //Se da por parametro, por si existen un cancelacion, de acuerdo a la condicional
            Task tarea = Task.Run(() => RealizarTarea(cancelaToken));//Recordar que las Task al final de cuentas ocupan o crean un hilo nuevo, un subproceso,un thread, como lo queramos llamar
            
            for (int i = 0; i < 100; i++)//Incremento de acumulador (a proposito) para sobrepasar a un valor de 100
            {//Ejecutado desde el hilo principal
                acumulador += 30;//Tambien depende del tiempo que le lleve realizar la tarea, por ejemplo, si indicamos un sleep  de 1000 en el metodo que incrementa al acumulador
                //Pues tardará mas que el main (osea esa tarea, task, o hilo creado, tardara mas) e imprimirá menos valores de acumulador, pero si le damos un sleep de 100 por ejemplo, ira mas a la par del main
                //por lo que le dara tiempo de mostrar mas valores de acumulador
                Thread.Sleep(1000);//Para que lo podamos observar
                if(acumulador > 100)
                {
                    miToken.Cancel();//Esta es la forma de propagar la cancelacion de una tarea
                    break;//Para que salga del bucle for (del hilo principal), para que asi ya no se ejecute ni este hilo principal
                    //ni el declarado al inicio (el cual en teoria lo estamos cancelando con el metodo del token: cancel();
                }
            }
            Thread.Sleep(1000);
            Console.WriteLine("EL VALOR DEL ACUMULADOR ES: " + acumulador);
            Console.ReadLine();
        }
        //La idea para explicar las cancelaciones de Task es que si
        //el acumulador vale mas de 100 que cancele el programa (detenga la ejecucion del metodo, aunque no haya recorrido los 100 ciclos indicados)
        //Para ello, en el hilo principal a proposito incrementaremos a un valor grande la variable acumulador
        static void RealizarTarea(CancellationToken token)//Recibe el parametro de este tipo por si de acuerdo a lo que haga el metodo en algun punto se deba cancelar su ejecucion
        {//ademas ese token de parametro se usara para saber si se ha llamado para una cancelacion o no
            for (int i = 0; i < 100; i++)
            {
                acumulador++;
                var miThread = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(1000);
                Console.WriteLine("Ejecutando tarea del Thread: " + miThread);
                Console.WriteLine(acumulador);
                //Para saber si ha habido una cancelacion y salir de este metodo, entonces
                if (token.IsCancellationRequested)//Si ha habido una cancelacion, por parte del parametro
                {
                    acumulador = 0;//En esta parte indicamos todo lo que queramos hacer antes de regresar al flujo principal
                    //Por ejemplo, en teoria si hubo una cancelacion,significa que la tarea no termino, pues entonces seria mejor regresarla a como estaba al inicio
                    //Por eso en el ejemplo, regresamos el valor de acumulador a 0. 
                    //Pero es en este if en que deberian ir dichas instrucciones de reversion, en caso de un programa real, mas grande.
                    return;//Recordar que el return nos devuelve al flujo de ejecucion, en este caso se saldria del metodo y seguiria con las demas lineas del Main
                }//Si solo usaramos un break (como en el Main), pues solo saldria del bucle for, y lo que necesitamos es que salga por completo del metodo, como tal es al metodo que estamos cancelando
                 ////imaginando que despues del for, existiran mas lineas de codigo en este metodo
            }
        }
    }
}