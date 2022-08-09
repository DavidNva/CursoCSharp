using System;
namespace Threads_Bloqueo_EjemploBanco_V109
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola");
            CuentaBancaria CuentaFamilia = new CuentaBancaria(2000);//En inicio la cuenta tendra 2000 pesos de saldo
            Thread[] hiloPersonas = new Thread[15];
            for(int i = 0; i< 15; i++)
            {
                //La instancia thread no permite metodos con parametro, por eso creamos otro para acceder a la informacion
                //de retiro y su saldo con otro metodo sin parametros
                Thread t = new Thread(CuentaFamilia.VamosRetirarEfectivo);
                t.Name = i.ToString();//Se le da un nombre a cada hilo, comenzando desde el cero
                hiloPersonas[i] = t;//En cada posicion del array hilosPersonas, insertamos la nueva instancia creada (hilo creado)
            }
            for (int i = 0; i < 15; i++)
            {
                hiloPersonas[i].Start();//Comenzamos esos 15 threads creados, con sus intrucciones especificados
                                        //en este caso inican con elmetodo de vamos a retirar efectivo
                //Sincronizacion de hilos con join();
                hiloPersonas[i].Join();//De esta forma primero ejecuta el hilo 0 y con cuatro retiros de 500 el hilo vacia la cuenta de 2000
                //pues cuando se ejecuten los demas hilos, la cuenta estará en 0
                //NOTA, si se desea hacer pruebas de como funciona bloqueando los hilos: Entonces comentar esta ultima linea
                //y descomentar el metodo look de las lineas de abajo
            }
        }
    }

    class CuentaBancaria
    {
        private Object bloqueaSaldoPositivo =  new object();//Como parametro del bloque de hilos
        double Saldo { get; set; }
        public CuentaBancaria(double Saldo)
        {
            this.Saldo = Saldo;
        }
        public double RetirarEfectivo(double cantidad)
        {
            if ((Saldo - cantidad) < 0) { //La instruccion nos muestra el thread desde el que se ejecuta este metodo(recordando que tenemos 15 thread, hilos)
                Console.WriteLine($"Lo sentimos solo quda {Saldo} persos en la cuenta: Hilo: {Thread.CurrentThread.Name}");
                return Saldo;
            }

            //Este trozo de codigo es el que importa al acceder a un thread, porque si algun hilo esta accediendo, pues bloqueamos los demas hilos
            //usando el metodo look
           // lock (bloqueaSaldoPositivo) {
           //Si solo sincronizamos los hilos, entonces primero hará los procesos del metodo 1, o el que haya entrado y cuando termine seguira con los otros
                if (Saldo >= cantidad)
                {
                    Console.WriteLine($"Retiro de {cantidad}. Queda {Saldo - cantidad} de saldo en la cuenta. Hilo: {Thread.CurrentThread.Name}");
                    return Saldo -= cantidad; //
                                              //return Saldo  = Saldo - cantidad
                }
                return Saldo;//Dependiendo de a cual if entro, si al primero no retorna el mismo saldo porque en realidad no se hizo ninguna operacon
                             //pero en el segundo if, si lo hace, por eso se le da un nuevo valor a saldo
            //}//De esta forma, si un hilo esta accediendo a este codigo (el cual encontró que la cuenta aun tiene dinero) los demas no podran acceder
            //y lo que dirá será lo de no queda saldo en la cuenta//Obviamente es como ejemplo. En teoria si hay dinero, pues se puede seguir sacando dinero
        }
        public void VamosRetirarEfectivo()
        {
            Console.WriteLine($"Está sacando dinero del Hilo: {Thread.CurrentThread.Name}");
            for (int i = 0; i < 4; i++) RetirarEfectivo(500);//Para reperit cuatro veces el retiro, y de forma visual veamos la distorcion de hilo
            //al interntar sacar dinero, que se supone ya no existe al estar retirado por un hilo. Y ademas de que en teoria no deberia permitir que el saldo tenga valores negativo

        }
    }
}