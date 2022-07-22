using System;

namespace Properties_V55{
    class Program{
        static void Main(string[] args)
        {
           Console.WriteLine($"Hola de nuevo");
           Empleado Empleado1 = new Empleado("David");
           Empleado1.GetNombre();
           Empleado1.SetSalario(1500);
           Console.WriteLine(Empleado1.GetSalario());

           //Incrementado salario inicial

           double nuevoSalario = Empleado1.GetSalario() + 700;// La forma correcta de acceder a la variable salario es esta
           //por medio de metodos, aun cuando la sintaxis sea mas complicada

           //*Empleado1.salario +=800; //Si la variable fuera public, podriamos sumar el salario mas facilmente
           //pero esto lleva  a errores, como el igualarlo a numeros negativos o sumar numeros negativos
           //Por ello es importante la encapsulacion: Y crear metodos de acceso a las variables, controlando la forma en 
           //que se pueden moficicar
           //*Empleado1.salario = -3500;

           Console.WriteLine($"El salario del empleado es: " +  Empleado1.GetSalario());
           
           //Ejemplo de acceso a los metodos con una properties (icono de herramienta)

           Empleado Empleado2 = new Empleado("Teresa");
           Empleado2.SALARIO = 1200;
           Console.WriteLine($"El salario del Empleado 2 es: " +  Empleado2.SALARIO);
           Empleado2.SALARIO += 800;
           Console.WriteLine($"El nuevo salario del Empleado 2 es: " + Empleado2.SALARIO);
           Empleado2.SALARIO = -800;
           Console.WriteLine($"El nuevo salario del Empleado 2 es: " + Empleado2.SALARIO);
           //Como vemos con la properties, es como si tuvieramos una variables que tenga acceso a todo desde otra clase
           //que en realidad asi es, al ser publica, la propiedad se puede ver
           //pero si nos damos cuenta, es es una forma mas facil, una sintaxis mas entendible
           //como si usaramos una variable no encapsulada
           //Las properties saca lo mejor de la encapsulacion y del modificador de acceso public
           //con la encapsulacion estamos evaluando con un metodo de control que salaio nunca sea menor a 0
           //y como la propiedad es public, podemos acceder directamente a ella, sin necesidad de algun metodo
           //directamente hacemos las operaciones de suma de salario
           
           
            
        }
    }
    
    class Empleado{
        private string nombre;
        private double salario;

        /*
          En C# POR CONVENCION las variables que tendran properties se declaran con un guion bajo en su identificador
          en teoria para diferenciar entre la propertie y la variable
          sin embargo en mi opinion esta nomenclatura es menos comoda, ya que en el menu intellisense
          no nos aparecera el nombre de la variable  y no porque este encapsulada, sino porqye empieza por guion bajo
          por lo que tendria que escribirse por cuenta propia. 

          Creo que con diferenciar una por:
          Properties : MAYUSCULA : Icono de herramienta(de una llave)
          Variable: minuscula : Icono de cubo (icono de objeto)
          Es mas que suficiente, ademas de los iconos que nos muestran el menu
          private string _nombre;
          private double _salario;
        */
        public Empleado(string nombre){
            this.nombre = nombre;
        }

        //setter para salario
        public void SetSalario(double salario){
            //Evalua que el salario no sea negativo
            if(salario < 0){
                Console.WriteLine($"El salario no puede ser negativo. Se asignara un valor 0 como salario.");
                this.salario = 0;
            }else{
                this.salario = salario;
            }
        }

        public double GetSalario(){
            return salario;
        }

        public void GetNombre(){
            Console.WriteLine($"El nombre del Empleado es: " + nombre);
            
        }

        //Ejemplo de properties

        private double evaluaSalario(double salario){
            if (salario<0) return 0;
            else return salario;
        }
        //CREACION D PROPIEDAD
        public double SALARIO{//Las propiedades pueden tener get y set, o solo una de ellas
            get{
                return this.salario;//Es como un get nomrla, simplemente retorna el valor de salari
            }
            set{
                this.salario = evaluaSalario(value);
            }//Funciona como cualquier setter, es decir, permite asignar un valor a la variable
            //usando el metodo de control, como si fuera encapsulacin, y en parametro indicamos value
        }

        //Ejemplo expresion bodied, con la expresion lamba (como cuando utilizabamos metodos de una sola linea)

        public double SALARIO2{
            get => this.salario;
            set => this.salario = evaluaSalario(value);
        }//Esto funciona exactamente igual que la propiedad anterior, pero el codigo se simplific bastante
        //no usamos llaves ni return


       //Las properties pueden ser de escritura o de lectura o de ambas
       //Por ejemplo, en el tema de las contraseñas
       //Puede ser de escritura, pero no de lectura

       //Para que sea de solo escritura, pues prescindimos del get y viceversa

       //Entonces un 
       //Get = Lectura = Devolver un dato
       //Set = Escritura = Establecer un dato = Modificar un dato
    }
}