using System;
namespace ArraysImplicitos_V37{
    class Program{
        static void Main(string[] args)
        {
            //Arrays implicitos (No especificamos ni el tipo, ni el numero de elementos)
            //Un tipo de array muy flexible

            //var  datos = new[] {"David","Nava","México",12};//Error

            var valores = new [] {15,28,75.5,30.30,4};//Esto si es posible,
            //aunque tengamos dos tipos de datos, con int y double
            //el interprete le asigna al array un tipo double, para que acepte todos los valores

//-----------------------------------------------------------
            
            //Arrays de objetos
            Empleados[] arrayEmpleados = new Empleados[2];

            arrayEmpleados[0] = new Empleados("David",20);//A la vez que lo almacenamos en el array
            //lo estamos creando, es decir, instanciando (creando el objeto y guardandolo en el array)
            //otr forma seria por ejemplo

            Empleados Tere = new Empleados("Tere",43);//Ahora primero creamos el objeto

            arrayEmpleados[1] = Tere;//Esto seri otra forma, primero creamos el objeto 
            // y luego lo guardamos en el array
            //antes de usar cualquier objeto, debemos inicializarlo antes            

//--------------------------------------------------------------------------
            //Arrays de tipos o clases anonimas
            var personas = new []{
                new{Nombre = "Maria",Edad = 73 },//Todos los objetos espeficiados deben concidir en orden, tipo y nombre
                new {Nombre= "Iveth",Edad = 19},//Debe ser asi en el resto de valores 
                new{Nombre = "Valente",Edad = 17}//Cada new con corchetes,seria como 
                //especifica los parametros de un constructor, como en el ejemplo anterior
            };
            //Cada new seria un nuevo objeto de ese tipo de clase, entonces tenemos 3 posiciones: 0,1,2

            Console.WriteLine(personas[1]);//Imprimira los datos de la posicion 1: Iveth, 19
            


        }
        class Empleados{
            string nombre;
            int edad;
            public Empleados(string nombre, int edad){
                this.nombre = nombre;
                this.edad = edad;
            }
        }
    }
}