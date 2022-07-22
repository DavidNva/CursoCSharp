using System;

namespace ClasesSelladas_V54{
    class Program{
        static void Main(string[] args){
            //Las clases selladas impiden la herencia 
            //y la sobreescritura de metodos (en dado caso se permita la herencia, pero no la de algun metodo en concreto)
            //Las clases selladas son mas cuestion o tema de diseño, es decir, si estamos seguros de que una clase
            //ya no debe heredar a otra, pues la sellamos con sealed

            //O a lo mejor la clase aun puede heredar pero existe un metodo en particular que necesitamos ya no se modifique,
            // entonces sellamos dicho metodo

            Lagartija miLagartija =new Lagartija("Juancho");
            miLagartija.Respirar();//Este metodo es heredado de Animales
           //LOs mensajes del metodo repsirar seran lso mismos para todos
            miLagartija.GetNombre();//Sin embargo, para el metodo get nombre, a pesar de que se trata del mismo metodo heredado de animales
            //cada clase adapto su propio metoto (sobreescribio) para conseguir los nombres de cada objeto
            //de esta forma no estamos creando un nuevo metodo, el mismo solo se reescribe, ademas con la clase abstracta nos obliga a realizarlo 
            
            Humano miHumano = new Humano("David");
            miHumano.Respirar();//La clase humano esta heredando de mamiferos, y a su vez hereda de animales
            //por lo que tambien tiene el metodo respirar
            miHumano.GetNombre();

            Adolescente miAdolescente = new Adolescente("Ado");
            miAdolescente.GetNombre();
            miAdolescente.Pensar();
        }
    }
    interface ImamiferosTerrestres{
        int NumeroPatas();
    }
    interface ISaltoConPatas{
        int NumeroPatas();
    }
    interface IAnimalesYDeporte{
        string tipoDeporte();
        Boolean esOlimpico();
    }
    abstract class Animales{//Sintaxis para declarar una clase abstracta, solo colocar el prefijo abstract
        public void Respirar() { Console.WriteLine("Soy capaz de respirar"); }//Funciona al ser heredada
        public abstract void GetNombre();
    }
    class Mamiferos:Animales{//Mamiferos esta heredando de la clase abstract Animales
        private string nombreSerVivo;
        public Mamiferos(string nombre){
            nombreSerVivo = nombre;
        }

        public virtual void Pensar() { Console.WriteLine("Pensamiento básico instintivo"); }
        public void CuidarCrias() { Console.WriteLine("Cuido mis crías hasta que se valgan por si solas"); }
        public override void GetNombre() { Console.WriteLine("El nombre del mamifero es: {0}", nombreSerVivo); }
    }
    class Lagartija : Animales{

        private string nombreReptil; //Es como teniamos la variable nombreSerVivo
        public Lagartija(string nombre){
            nombreReptil = nombre;
        }
        
        public override void GetNombre(){//Para sobreescrbir usamos override
            Console.WriteLine("El nombre del reptil es: {0}", nombreReptil);
        }
    }
    class Ballena : Mamiferos{
        public Ballena(string nombreBallena) : base(nombreBallena) { }
        public void Nadar() { Console.WriteLine("Soy capaz de nadar"); }

    }
    class Caballo : Mamiferos, ImamiferosTerrestres, IAnimalesYDeporte, ISaltoConPatas{
        public Caballo(string nombreCaballo) : base(nombreCaballo) { }
        public void Galopar() { Console.WriteLine("Soy capaz de galopar"); }
        int ImamiferosTerrestres.NumeroPatas(){//En caso de ambiguedad se requiere espeificar a que interfacese refiere
            return 4;
        }
        int ISaltoConPatas.NumeroPatas() { return 2; }
        public string tipoDeporte(){
            return "Futbol, jaja";
        }
        public Boolean esOlimpico(){
            return true;
        }
    }
    class Humano : Mamiferos{
        public Humano(string nombreHumano) :base(nombreHumano) { }
        //Supongamos que nuestro metodo Pensar de la clase Humano debe ser igual para todas las clases que herede
        //un posible niño, adolescente, adulto, etc. Ya que todos piensan igual (todos son humanos)
        //entonces no tendria sentido cambiar o modificar ese metodo (en teoria)
        //Pues entonces sellamos el metodo
        public sealed override void Pensar() { Console.WriteLine("Soy capaz de pensar"); }
    }
    class Adolescente:Humano{
        public Adolescente(string nombreAdolescente) :base(nombreAdolescente){

        }
        //Como el metodo esta sellado ya no podemos sobreescribirlo
        /*public override void Pensar()
        {
            Console.WriteLine($"Adolescente pensando");
            
        }*/

        //AHORA SUPONGAMOS QUE QUEREMOS BURLAR ESTA INDICACION DE NO SOBREESCRIBIR
        //Porque se podria al no declarar el override, estariamos simplemente ocultando el metodo Pensar (Como ya lo vimos
        //en proyectos anteriores) o indicar el new para que no parque siquiera advertencias, de esta forma
        //ya se tendria un metodo independiente pensar de adolescente
        //esto por parte del programador seria un error y una irresponsabilidad, ya que esta saltando la indicacion
        //del metodo sellado (que significa no muevas este metodo, jaja)
    }



    //Supongamos que en el diseño la clase Gorila ya no puede heredar, pues la sellamos
    sealed class Gorila : Mamiferos, ImamiferosTerrestres {
        public Gorila(string nombreGorila) : base(nombreGorila) { }
        public override void Pensar() { Console.WriteLine("Pensamiento instintivo avanzado"); }
        public void Trepar() { Console.WriteLine("Tengo la habilidad de trepar."); }
        public int NumeroPatas() { return 2; }
    }
    //Pero como sellamos la clase, ahora Chimpance ya no puede heredar de gorila, por lo que marca error
    /*class Chimpance:Gorila{
        public Chimpance(string nombreChimpance):base(nombreChimpance){

        }
    }*/
}
