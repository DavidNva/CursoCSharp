using System;

namespace Genericos_V60
{
    class Program{
        //La programacion generica consiste en crear clases que permite manejar cualquier tipo de objeto//maneje string, date, int, empleado, etc
        static void Main(string[] args){
            Console.WriteLine($"Primer ejemplo: Objetos de tipo string");
            
            AlmacenObjetos archivos = new AlmacenObjetos(4);//El array tendra 4 elementos
            archivos.Agregar("David");//Un string es un objeto (Viene de la clase String, que hereda de Object)
            archivos.Agregar("Teresa");
            archivos.Agregar("Iveth");
            archivos.Agregar("Maria");
           // archivos.Agregar("Maria");//NO SE DEBE SOBREEPASAR el numero de elementos indicados en el array

            //Para ver el objeto, podemos hacer esto
         
            string nombrePersona =(string) archivos.GetElemento(2);//Para igualar el string con un tipo objeto general,hacemos un casting
            Console.WriteLine(nombrePersona);//Ahora si ya podemos imprimir el objeto, en este caso el string
            
            Console.WriteLine($"Segundo ejemplo: Ahora con objetos de tipo empleado");
            AlmacenObjetos nuevosArchivos = new AlmacenObjetos(4);
            nuevosArchivos.Agregar(new Empleado(1500));//A cada uno se le indica su salario como parametro
            nuevosArchivos.Agregar(new Empleado(2500));
            nuevosArchivos.Agregar(new Empleado(3500));
            nuevosArchivos.Agregar(new Empleado(4500));
            //La siguiente linea de codio aparentemente esta bien, sin embargo, dará un error en tiempo de ejecucion
            //Es otro de los inconvenientes de intentar realizar programacion generica usando la herencia
            //ya que en esta linea, estamos intentando hacer un casting de tipo string con un objeto de tipo empleado
            //*string nombrePersona2 =(string) nuevosArchivos.GetElemento(2);
            //Lo que se debe hacer es: 
            //*Tenemos que hacer otro casting pero ahora con un tipo empleado
            Empleado salarioEmpleado = (Empleado)nuevosArchivos.GetElemento(2);
            Console.WriteLine("El salario del empleado es: "+salarioEmpleado.GetSalario());

            //-------------------------------------------------------------------------------------------

            Console.WriteLine();
            Console.WriteLine($"Ahora ejemplos con programacion generica: Viendo los mismos resultados");

            //NombreClase   TipoObj  NombreID    IniciacionConClase   TipoObj Parametros (en este caso de tipo int)
            AlmacenObjetos2 <String> archivos2 = new AlmacenObjetos2 <String> (4);
            //Para instanciar una clase generica, obviamente la clase debe estar declarada como generica <T>

            //El array tendra 4 elementos
            archivos2.Agregar("David");
            archivos2.Agregar("Teresa");
            archivos2.Agregar("Iveth");
            archivos2.Agregar("Maria");
         
            string nombrePersona2 = archivos2.GetElemento(0);//Para igualar el string con un tipo objeto general,hacemos un casting
            Console.WriteLine(archivos2.GetElemento(1));//Ahora si ya podemos imprimir el objeto, en este caso porque es string
            System.Console.WriteLine(nombrePersona2);//Sin embargo es mejor almancenarlo en una variable para podr trabajar
            //con ese string de objeto
            
            Console.WriteLine($"Segundo ejemplo: Clases Genericas: Ahora con objetos de tipo empleado");
            //AlmacenObjetos nuevosArchivos2 = new AlmacenObjetos(4);
            AlmacenObjetos2 <Empleado> empleados = new AlmacenObjetos2<Empleado>(4);
            Empleado n = new Empleado(5000);
            empleados.Agregar(new Empleado(1500));//A cada uno se le indica su salario como parametro
            empleados.Agregar(new Empleado(2500));
            empleados.Agregar(new Empleado(3500));
            empleados.Agregar(n);

            Console.WriteLine(empleados.GetElemento(1));//Esto nos impprime el objeto, pero como no es string, pues solo indica el nombre del objeto
            //Si nos damos cuenta, ahora podemos prescindir del casting, en la siguiente linea
            Empleado salarioEmpleados2 = empleados.GetElemento(1);//Esto de igualar a una variable de tipo empleado
            //Es para poder acceder a sus metodos
            //Porque si nos dimos cuenta, al agregar, las inicializamos directamente cada instancia, pero no tienen un identificador o referencia (puntero) digamos directamente
            //Por eso se iguala
            //Si todas las hubieramos declarado e inicializado antes, como lo hicimos con el ultimo empleado:  n
            //Pues ya no tendriamos qe hacer esta igualacion, al final, es lo mismo
            //Como se ve en el segundo ejemplo de impresion a continuacion

            Console.WriteLine("El salario del empleado es: "+salarioEmpleados2.GetSalario());//ESto si imprime el salario
            //porque esramos igualando una variable y desde alli accdemos al salario
            Console.WriteLine($"El salario del ultimo empleado es " + n.GetSalario());

            //Otro ejemplo con la clas generica con un tipo de dato fecha
            AlmacenObjetos2 <DateTime> fechas = new AlmacenObjetos2<DateTime>(10);

            fechas.Agregar(new DateTime());//Agregamos, instanciando un nuevo objeto de tipo fecha
            //otra forma es creando primero el objeto

            DateTime hoy = new DateTime();
            fechas.Agregar(hoy);

            Console.WriteLine(fechas.GetElemento(1));
            //o seria mejor declarar una variable tipo fecha para imprimir o acceder con ella

            DateTime fec = fechas.GetElemento(0);
            Console.WriteLine(fec);
            
            
            
            
            
            

        }
    }

    class AlmacenObjetos{//Simulando la programacion generica usando la herencia
    //Esta clase nos va  permitir manejar cualquier tipo de objeto, ya sea string, int, empleado, etc
    //De aqui veremos las desventajas de esta herencia (usando object) con la programacion generica
    //La 
    private Object[] datosElemento;//Usaremos un array de tipo object, para almacenar cualquier tipo de objeto
    private int i = 0;//Posicion del array

    public AlmacenObjetos(int x /*Definicar el num de elementos del array*/){
        datosElemento = new Object[x];//Inicializamos el array
        //aqui es cuando ya se reserva espacio en la memoria
    } 
    public void Agregar(Object obj){
        datosElemento[i] = obj;//En la posicion i (que en principio es 0) se va almacenar el objeto que pasemos por parametro
        //si es de tipo int, string, empleado, etc
        i++;//incrementa i para avanzar en las posiciones del array
    }
    public Object GetElemento(int i){//Para encontrar la posicion del elemento, usamos i, que se pasa por parametro
        return datosElemento[i];//retorna el objeto (sea string, int, empleado, etc) que se encuentra en la posicion i
    }

    }

    class Empleado{
        private double salario;
        public Empleado(double salario){
            this.salario = salario;
        }
        public double GetSalario(){
            return salario;
        }
    }

    //En el siguiente proyecto veremos las ventajas de usar mejor la programacion generica para estos casos
    //Las desventajs de usar la herencia para estos casos (por ejemplo lo de usar muchos castings, o lo de no marcar errores sino hasta en tiempo de ejecucion
    //lo cual se vuelve un problema y es mas relajoso el estar volviendo a ejecutar el programa para testearlo
    //en lugar de primero poder hacer una comprobacion con la compilacion del programa)
    //-------------------------------------------------------------------------------------------------------------------
    //*Sintaxis para declarar una clase generica

    class AlmacenObjetos2<T>{//Para indicar una clase genérica se usa los parentesis angulares, colocando una letra en medio
    //por convencion se usa T MAYUSCULA
    private T[] datosElemento;//Cambiamos cada tipo a T (Que seria generica) //Cambiamos cada object
    //En lugar de un tipo de array, ahora es un tipo Generico
    private int i = 0;//Posicion del array

    public AlmacenObjetos2(int x /*Definicar el num de elementos del array*/){
        datosElemento = new T[x];//Ahora el array se inicia como un tipo generico
    } 
    public void Agregar(T obj){
        datosElemento[i] = obj;
        i++;
    }
    public T GetElemento(int i){//Este metodo devuelve cualquier tipo de valor, dependiendo de lo que contenga el array
        return datosElemento[i];
    }

    }
}