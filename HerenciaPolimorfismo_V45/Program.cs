﻿using System;

namespace HerenciaPolimorfismo_V45{
    class Program{
        static void Main(string[] args)
        {
            Caballo miCaballo  = new Caballo("Potro");

            Humano miHumano = new Humano("David");

            Gorila miGorila = new Gorila("King Kong");

            //miHumano.Respirar();  Esto da un error por el nivel de proteccion del metodo respirar
            //aunque en teoria se esta heredado ese metodo desde mamifero a humano
            //no podemos acceder porque al metodo es protected, entonces solo puede acceder la clase que la crea
            //y a las clases que heredan. es decir, podemos usar el metodo respirar
            //dentro de la clse mamiferos( clase padre), o dentro de las que heredan, como humano, gorila, caballo
            //sin embargo al intentar acceder desde otra clase (en este caso desde el Main) con lo cual
            //no se cumplen las condiciones para el protected (main no hereda de mamiferos), por eso no podemos acceder al metodo
            //es una forma de entender el funcionamiento del modificador de acceso protected

            Console.WriteLine($"-----------------Video 44-------------");
            Console.WriteLine($"Principio de Sustitucion: Diseño de Herencia");
            
            Mamiferos animal = new Caballo("Otro Caballo");//Un caballo es siempre un mamifero
      //conviene leerlas de derecha a izquierda para tomar sentido, como en la siguiente linea
            Mamiferos persona = new Humano ("Juan"); //Esto si es posible, leyendolo de derecha a izquierda
          

            Mamiferos animal2 = new Mamiferos("Perro");

            Caballo casahuate = new Caballo("Casahuate");
            //Para no confundirnos seguimos leyendo de derecha a izquierda, entonces
            animal2 = casahuate; //Un caballo siempre es un mamifero, es decir, el casahuate siempre sera un mamifer

           Object miAnimal = new Caballo("NuevoCaballo");

           Object miPersona = new Humano("Angel");

           Object miMamifero = new Mamiferos("Wally");

           Mamiferos[] almacenAnimales = new Mamiferos[3];

           almacenAnimales[0] = miCaballo ;//POdemos alamcenar un caballo y un humano en mamiferos
           almacenAnimales[1] = miHumano;
           almacenAnimales[2] = miGorila;
           Console.WriteLine($"------Virtual y New-------");
           
           miGorila.Pensar();
           
           for (int i = 0; i < almacenAnimales.Length; i++)
           {
             almacenAnimales[i].Pensar();//COmo polimorfismo (muchas formas)
             //el objeto tomara muchas formas, es decir, almacen animales
             //tomara pensar(); dependiendo del contexto y la situcion de una forma diferente
             //es decir, si sobreescribimos un metodo, hara lo que se haya moficado en ese metodo
             //y si no modifico nada (por ejemplo, si solo lo oculto (lo cual se tomaria como un metodo independiente))
             //lo que lleva a decir, que no modifico nada, entonces se toma al metodo creado inicialmente
             //Es el caso de gorila, como solo estamos usando un metodo pensar
             //pero sin el override, entonces solo estamos ocultando el metodo pensar de mamiferos
             //lo cual al imprimir o recorrer el array, toma como metoto pensar para gorila, al declarado en mamiferos
             //imprimiendo el string inicial, que es: "pensamiento básico intuitivo" (aun cuando en gorila estemos indicando un metodo pensar cons otras instrucciones)
             //recordando que ese metodo pensar() solo esta ocultando al de mamiferos
             
             //A esta manera de cambiar formas se le llama polimorfismo

           }
            
        }
    }

    class Mamiferos
    {
        //La instruccion base siempre llama al constructor de la clase padre
        private string nombreSerVivo;//*No es recomendable declarar las variables como publicas
        //*por ello, es mejor encapsularlas con el modificador de acceso private
        //*Entonces private solo permite el acceso desde la propia clase
        
        //*El modificador de acceso public nos da acceso total al metodo
        //*desde cualquier parte de nuestro programa, es decir, desde cualquier clase
        public Mamiferos(string nombreSerVivo){//Esto ocasiona que el constuctor que implicitamente estaba creado
            this.nombreSerVivo = nombreSerVivo;//ha sido reemplazado por este
        }
        
        //El protected es una mezcla de los dos, private y public
        //El modificador de acceso protected, ya que tendra acceso desde la propia clase donde se declar
        //y de aquellas clases que hereden
        protected void Respirar(){
            Console.WriteLine($"Soy capaz de respirar");
        }
       //Con virtual estamos indicando que todas las clases a heredar
       //debe usar este metodo, modificandolo algo posiblemente

       //Ejemplo virtual

       //public virtual string ToString();//Metodo de la clase object
       //quiere decir que todas las clases que creemos en C# deberian de heredar el metodo ToString
       //Y todas las clases deberian modificar a su conveniencia ese metodo string
       //para adaptarlo a cada clase

       //Es decir, permite dar acceso a modificar ese metodo adaptandolo a una nueva clase
       //no realizandolo de nuevo, sino adaptandolo
        public virtual void Pensar(){
            Console.WriteLine($"Pensamiento básico instintivo");
            
        }//Si ahora quitaramos la palabra reservada "virtual"
        //en los metodos de las subclases que heredan, al ya haber indicado un override
        //entonces marcara un error, porque no se podria sobreescribir un metodo al que no esta declarado como virtual
        //Por eso es necesario usarlo
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
    class Caballo: Mamiferos {
        public Caballo(string nombreCaballo):base(nombreCaballo){
      
        }
        public void Galopar(){
            Console.WriteLine($"Soy capaz de galopar");

            Respirar();//Esto no tendria sentido, pero es una forma de ver
            //que podemos acceder al metodo respirar, ya que aunque sea protected
            //pero como se esta heredando de mamiferos, por eso, podemos acceder a este metodo
            //sin embargo, si deseamos acceder desde el main, esto no se podra, ya que no tenemos acceso desde alli
        }//Si el metodo respirar fuer private, entonces no podriamos acceder desde esta subclase
        //aun cuando estemos heredando de ella, ya que el private solo permite acceder desde la propia clase

    
    }

    class Humano: Mamiferos{

        public Humano(string nombreHumano):base(nombreHumano){

        }
        //Para que se trate de una modificacion y no de un metodo diferente
        //Se usa la palabra reservada override

        //De esta forma indicamos que solo es una modificacion del metodo heredado de mamiferos
        //llamado Pensar();

        //override indica una sobreescritura (es diferente a una ocultacion de método, que indicaba que no tenia nada que ver con el metodo heredado )
        public override void Pensar(){//Este metodo pensar esta ocultando el metodo pensar de mamiferos
        //esto es porque tiene el mismo nombre, el mismo tipo de dato, y recibe el mismo numero de parametros
        //entonces oculta o invalida el metodo heredado de mamiferos
            Console.WriteLine($"Soy capaz de pensar");
            
        }
    }

    class Gorila: Mamiferos{

        public Gorila(string nombreGorila):base(nombreGorila){

        }
        public void Trepar(){
            Console.WriteLine($"Soy capaz de trepar");
        }
        //Al indicar new, es como decirle al compilador o al IDE que estamos
        //consientes de que estamos sustituyendo el metodo pensar de la clase Mamiferos
        //que se hereda a la clase Gorila
        new public void Pensar(){//Este metodo pensar no esta referenciado al metodo pensar de mamiferos
        //porque no estamos usando override, podemos darnos cuenta por el new que usamos (y si no lo usaramos marcaria una advertencia)
        //el punto, es que este metodo esta ocultando al metodo pensar(); de mamiferos, como tal
        //es otro metodo, totalmente independiente del otro, de alli la diferencia entre
        //solo sobreescribir con ocultar un metodo heredado
            Console.WriteLine($"Pensamiento instintivo avanzado");
            
        }//

    }
}