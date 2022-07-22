using System;

namespace ClasesAbstractas_V52{
    class Program{
        static void Main(string[] args){
            /*
            Lagartija miLagartija = new Lagartija("Lagarto Nuevo");
            miLagartija.GetNombre();
            miLagartija.Respirar();
            Console.WriteLine("----------------------------------------");
            humano miYo = new humano("David Nva");
            miYo.GetNombre();//Se usan los mismos metodos, pero como son abstractos fueron declarados de
            //forma perzoalizada en cada uno
            miYo.Respirar();//El método respirar es el mismo para todos(en este caso el mismo mensaje)
            //Esa el la utilizadad de las clases y metodos abstractos, a diferencia de una interface donde
            //todos sus metodos son pbligatorias(en caso de heredar la interface), en cambio aqui
            //si que podemos iniciar un metodo y decidir que métodos seran obligatorios si se requiere 
            //heredar de esa clase, en este caso tenemos el metodo abstracto GetNombre...
            //Si sabemos que la clase contara con algunos o simplemente un metodo abstractos, entonces
            //si o si, tambien las clases deben se abstractas.
            miYo.Pensar();
            Console.WriteLine("------------------------------------");
            */
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

            //OTRA DIFERENCIA IMPORTANTE ENTRE INTERFACE Y CLASE ASBSTRACTA
            //y del porque usar una u otra, es que la 
            //*interface: Solo permite declarar los metodos //no deja crear variables, indicar instrucciones en el metodo, etc. (porque obviamente no es una clase)
            //Sin encambio
            //*Una clase abstracta, obviamente tambien es una clase
            //por lo que ademas de actuar como una interface donde tenemos metodos abstractos que al heredar de la clase, nos obliga a utilizarlos
            //*con la clase abtracta tambien nos permite heredar metodos ya con sus instrucciones realizadas, de alli la gran diferencia
            //obviamente aqui tambien podemos declarar variables, constructores, etc.
            //Esa el la utilizadad de las clases y metodos abstractos, a diferencia de una interface donde
            //todos sus metodos son obligatorias(en caso de heredar la interface), en cambio aqui
            //si que podemos iniciar un metodo y decidir que métodos seran obligatorios si se requiere 
            //heredar de esa clase, en este caso tenemos el metodo abstracto GetNombre... //Es el metodo obligatorio de sobreescribir
            //Si sabemos que la clase contara con algunos o simplemente un metodo abstractos, entonces
            //si o si, tambien las clases deben se abstractas.

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
        public abstract void GetNombre();//solo abra metodos abstractos dentro de clases abstractas, y estos
        //funcionaran como si se tratase de una interfaz, es decir cuando son abstractos solo pueden
        //declararse, solo eso; La palabra reservada se recomienda usarla como en el ejemplo, aunque no marca
        //error si primero escribimos abstract y despues public
    }
    class Mamiferos:Animales{//Mamiferos esta heredando de la clase abstract Animales
        private string nombreSerVivo;
        public Mamiferos(string nombre){
            nombreSerVivo = nombre;
        }

        //Este metodo respirar de mamiferos, estaria ocultando el metodo heredado, lo cual no tiene sentid
        //porque para eso usamos la herenci, para no reescribir codigo, entonces el metodo respirar
        //podemos quitarlo de mamiferos, ya que, ya lo esta heredando de la clase animales
        //*public void Respirar(){Console.WriteLine($"Soy capaz de respirar");
        //*}

        public virtual void Pensar() { Console.WriteLine("Pensamiento básico instintivo"); }
        public void CuidarCrias() { Console.WriteLine("Cuido mis crías hasta que se valgan por si solas"); }
        //Este es el metodo GetNombre que estamos heredando (pero es abstracto, por lo que si o si debemos usarlo)
        //*La diferencia con la sintaxis y dinamica de una interfaz, es que los metodos de la interfaces como tal vendrian siendo independientes
        //*por eso con solo escribir de nuevo el metodo con el mismo identificador (nombre) podriamos decirle a la interfaz que ya estamos haciendo uso del metodo
        //*EN CAMBIO con la clase y metodo abstracto, estamos haciendo uso verdaderamente de la herencia entre clases
        //por lo que si solo colocamos el metodo, estariamos simplemente ocultando el que heredamos, como pasaba con proyectos anteriores
        //es decir, es como si estuvieramos usando el new implicitamente (ocultar el metodo)
        //*Entonces para  quitar el error y hacer caso a lo que nos indica la clase abstracta heredada (usar su metodo)
        //*debemos sobreescribirlo con un override, de esta forma, estariamos diciendo a la clase heredada y abstracta que ya estamos aplicando su instruccion
        public override void GetNombre() { Console.WriteLine("El nombre del mamifero es: {0}", nombreSerVivo); }
    }
    class Lagartija : Animales{//Nueva clase largartija, que  no pertenecera a mamiferos, sino hereda a Animales
        //Como Animales es una clase abstracta, y ademas cuenta con un metodo abstracto, funciona como
        //con las interfaces, si tenemos un metodo abstract, si o si, se debe implementar ese metodo
        //solo que sobreescribiendolo con un override

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
    class Humano : Mamiferos{//Como humano hereda de mamiferos quien a su vez, esta heredando Animales, 
        //entonces la clase humano tendra las metodos de ella, de mamiferos y por tal tambien de Animales
        public Humano(string nombreHumano) : base(nombreHumano) { }
        public override void Pensar() { Console.WriteLine("Soy capaz de pensar"); }
    }
    class Gorila : Mamiferos, ImamiferosTerrestres {
        public Gorila(string nombreGorila) : base(nombreGorila) { }
        public override void Pensar() { Console.WriteLine("Pensamiento instintivo avanzado"); }
        public void Trepar() { Console.WriteLine("Tengo la habilidad de trepar."); }
        public int NumeroPatas() { return 2; }
    }
}
