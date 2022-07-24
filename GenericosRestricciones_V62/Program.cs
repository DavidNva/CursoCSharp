using System.Globalization;
using System;

namespace  GenericosRestricciones_V62
{
    class Program{
        static void Main(string[] args)
        {
            //Comprobamos que la clase AlmacenEmpleado solo nos deja instanciar objetos que implementan la interface mencionada, donde viene un metodo en concreto (salario)
            AlmacenEmpleado <Secretaria> Empleados = new AlmacenEmpleado<Secretaria>(4);
            Empleados.Agregar(new Secretaria(1500));
            Empleados.Agregar(new Secretaria(2500));
            Empleados.Agregar(new Secretaria(3500));

            Secretaria secretaria = Empleados.GetElemento(1);
            Console.WriteLine(secretaria.Salario());

           //Pero si intentamos instanciar una clase de otro tipo, que no este implementando dicha interface, como lo es estudiante, ya que en teoria
           //un estudiante no tienen salario, pues al intentar instanciar este tipo, no no dejara, dará error
           //aun cuando la clase es generica, pero como declaramos cierta restriccion no se puede

            /*
              AlmacenEmpleado <Estudiante> Empleados = new AlmacenEmpleado<Estudiante>(4);
              Empleados.Agregar(new Estudiante(1500));
              Empleados.Agregar(new Estudiante(2500));
              Empleados.Agregar(new Estudiante(3500));
            */
        }
    }

    //Ahora crearemos una clase generica para poder almacenar distintos tipos de empleados, con la diferencia, de asignarle una restriccion
    //para que solo acepte a empleados, esto con la palabra reservada: where, indicando una interface
    //la dinamica con este ejemplo es crear una interface que obligue a las clases empleado usar dicho metodo (getsalario)
    //entonces, cuaundo hacemos la clase generica, va a distinguir a estas clases, con la interface, con quienes usen estas interface:

    //Asi que todas las clases que esten implementando la interface tendran la capacidad de instanciar con esta clas generica

    class AlmacenEmpleado <T> where T:IParaEmpleados{//Es decir, clase generica para todo tipo donde se herede la interfaz indicado
        //De lo contrario no admitira otro tipo, por ejemplo, si ahora queremos indicar un string, int, bool, etc. No podemos hacerlo por esta restriccion
        //bueno, ahora crearemos metodos para alamcenar empleados, codigo igual al del proyecto anterior
        private int i = 0;
        private T[] datosEmpleado;
        public AlmacenEmpleado(int x){
            datosEmpleado = new T[x];
        }

        public void Agregar(T objEmpleado){
            datosEmpleado[i]  = objEmpleado;//El valor inicial de i es 0
            i++;//La proxima vez será uno, sucesivamente
        }

        public T GetElemento(int i){
            return datosEmpleado[i];//Devuelve datos empleado de i, osea el dato, o el objeto, que este en la posicion i del array
        }
    }
    interface IParaEmpleados{
        double Salario();
    }

    class Estudiante{
        private double edad;
        public Estudiante(int edad){
            this.edad = edad;
        }
        public double GetEdad(){
            return edad;
        }
    }
    class Director:IParaEmpleados{
        private double salario;
        public Director (double salario){
            this.salario = salario;
        }

        public double Salario()
        {
            return salario;
        }
    }
    class Secretaria:IParaEmpleados{
        private double salario;
        public Secretaria (double salario){
            this.salario = salario;
        }

        public double Salario()
        {
            return salario;
        }
    }
    class Electricista:IParaEmpleados{
        private double salario;
        public Electricista (double salario){
            this.salario = salario;
        }

        public double Salario()
        {
            return salario;
        }
    }
}