using System;

namespace HerenciaConstructoresYBase_V43{
    class Program{
        static void Main(string[] args)
        {
            
            

            Caballo miCaballo  = new Caballo("Potro");

            Humano miHumano = new Humano("David");

            Gorila miGorila = new Gorila("King Kong");
            miCaballo.GetNombreSerVivo();
            miCaballo.Galopar();
            Console.WriteLine($"--------------------");
            miHumano.GetNombreSerVivo();
            miHumano.Pensar();
            Console.WriteLine($"--------------------");
            miGorila.GetNombreSerVivo();
            miGorila.Trepar();

            Console.WriteLine($"-----------------Video 44-------------");
            Console.WriteLine($"Principio de Sustitucion: Diseño de Herencia");
            
            Mamiferos animal = new Caballo("Otro Caballo");//Un caballo es siempre un mamifero
            
            //Humano gente = new Mamiferos("Pedro");//Aunque leyendolo suena coherente
            //esto da un error, porque no podemos almacenar un mamifero en un humano, es decir
            //un mamifero no siempre es un humano, por eso este tipo de instrucciones
            //conviene leerlas de derecha a izquierda para tomar sentido, como en la siguiente linea
            Mamiferos persona = new Humano ("Juan"); //Esto si es posible, leyendolo de derecha a izquierda
            //es decir, un humano es simepre un mamifero,
            //por eso un Humano se puede almacenar o igualar con un mamifero

            //Pero en este caso, si nos damos cuenta los objetos creados son de tipo mamiferos
            //por lo que solo podremos acceder a las propieades y metodos de la clase mamiferos
            //es decir, para caballo, no podemos ver el metodo galopar
            //y en persona no podemos ver el metodo pensar, aun cuando su iniciacion sea con esas clases
            //es muy importante tener en cuenta esto

            //Otra forma de ver el principio de sustitucion

            Mamiferos animal2 = new Mamiferos("Perro");

            Caballo casahuate = new Caballo("Casahuate");
            //Para no confundirnos seguimos leyendo de derecha a izquierda, entonces
            animal2 = casahuate; //Un caballo siempre es un mamifero, es decir, el casahuate siempre sera un mamifer
            //casahuate = animal2; //Pero un mamifero (animal2) no siempre sera un caballo (casahuate)
            

           //Mas ejemplos de principios de sustitucion
           //La clase object esta en la cuspide de todas las clases
           //entonces puede ser lo que sea, un caballo, un mamifero, un humano, etc.
           
           //Entendiendo a la programacion orientada a objetos 
           //que todo lo que creemos sera un objeto (animal, persona, etc)
           Object miAnimal = new Caballo("NuevoCaballo");

           Object miPersona = new Humano("Angel");

           Object miMamifero = new Mamiferos("Wally");

           //aplicando estos conceptos teoricos, seria util, por ejemplo, en los arrays
           //al elegir un tipo para almacenar ciertos objetos 

           //Array para almacenar los objetos creados

           Mamiferos[] almacenAnimales = new Mamiferos[3];

           almacenAnimales[0] = miCaballo ;//POdemos alamcenar un caballo y un humano en mamiferos
           almacenAnimales[1] = miHumano;//porque es lo que son, siempre un mamifero
           //si la situacion fuera al reves y el array fuera de tipo humano o caballo
           //al querer ingresar distintos tipos en el array no se podria
           //es decir, en un array caballo, no podemos meter gorilas o humanos y asi respectivamente

           //almacenAnimales[1].
           //Como el array es de tipo mamiferos
           //solo podemos acceder a los metodos de mamiferos
           //aun cuando nuestros objetos almacenados como miCaballo, o miHumano 
           //tengan sus propios metodos
            
            
        }
    }

    class Mamiferos
    {
        //La instruccion base siempre llama al constructor de la clase padre
        private string nombreSerVivo;

        public Mamiferos(string nombreSerVivo){//Esto ocasiona que el constuctor que implicitamente estaba creado
            this.nombreSerVivo = nombreSerVivo;//ha sido reemplazado por este
        }
        
        public void Respirar(){
            Console.WriteLine($"Soy capaz de respirar");
        }

        public void CuidarCrias(){
            Console.WriteLine($"Cuido de mis crias hasta que se valgan por si solas");
            
        }

        public string GetNombre(){
            return nombreSerVivo;//devuelve el nombre (no imprime)
        } 

        public void GetNombreSerVivo(){//Imprime el nombre
            Console.WriteLine($"El nombre del ser vivo es: " + nombreSerVivo);
            
        }
        
    }
   //sintaxis de herencia, simplemente colocar dos puntos
    class Caballo: Mamiferos {//Implicitamente la clase Caballo, ademas de su constructor por defecto
    //o si agregaramos uno, llama al constructor de Mamiferos, que para este ejemplo, 
    //tambien tienen un constructor por defecto, pero esto se hace con la instruccion :base()
        public Caballo(string nombreCaballo):base(nombreCaballo){//La instruccion base llama al constructor
        //de la clase padre, en este caso es mamiferos, como el constructor tiene un parametro, se debe indicar
        //en los parentesis de base()
        //de esta forma, cuando instanciemos la clase caballo, ingresemos el nombre
        //ese dato, ira primero al constructor de caballo, luego con base, enviara
        //ese dato al constructor de la clase principal, quien tiene una variable
        //nombre ser vivo, donde se guardara el valor del ser vivo
        }
        public void Galopar(){
            Console.WriteLine($"Soy capaz de galopar");
            
        }
    }

    class Humano: Mamiferos{

        public Humano(string nombreHumano):base(nombreHumano){

        }
        public void Pensar(){
            Console.WriteLine($"Soy capaz de pensar");
            
        }
    }

    class Gorila:Mamiferos{

        public Gorila(string nombreGorila):base(nombreGorila){

        }
        public void Trepar(){
            Console.WriteLine($"Soy capaz de trepar");
        }
    }
}