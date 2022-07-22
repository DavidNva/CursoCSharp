using System;

namespace Interfaces_V48{
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

            //Imaginemos que estamos trabajando en equipo, es muy  probable por ejemplo que para este programa se agregen mas animales
            //esto hipoteticamente, ya que como tal el programa no tienen ninguna utilidad
            //Imaginando esto, supongamos que deseamos obligar a futuros programadores a que en el caso de que creen una clase nueva
            //que pertenezca a un mamifero, esten obligados a indicar cuantas patas tiene el animal
            //es decir, el programa necesita si o si, indicar el numero de patas del animal
            //entonces para que el programador no se salte este metodo, heredaremos una interfaz, donde declararemos el metodo
            //hacindo asi obligatorio su uso
            
             Console.WriteLine($"Funcionamiento de Interfaces");

            Ballena miBallena = new Ballena("Wally");
            miBallena.Nadar();//Nos damos cuenta que al usar la nomenclatura del punto
            //no nos aparece el metodo patas (porque no lo especificamos con la interfaz) una ballena no tiene patas

            //*SIn embargo, cuando resolvemos el caso de la ambiguedad, como nuestros metodos ahora estan encapsulados no podemos acceder directamente
            //esto tiene sentido por parte de la logica de C#, YA QUE si los metodos fueran public, al final, el compilador no sabria que metodo
            //de cierta interfaz declarada estamos llamando (esto solo cuando tenemos la ambiguedad de nombres, que como lo dicho es poco común)
            //*para resolverlo debemos usar el principio de es un, por ejemplo

            //*PRINCIPIO ES UN: Un caballo es una mamifero terrestre
            IMamiferosTerrestres ImiCaballo = miCaballo;
            Console.WriteLine("Número de patas de mi Caballo: " + ImiCaballo.NumeroPatas());
            //Ahora si tiene sentido, y es asi, como aparece para miCaballo el metodo de la interfaz (numero de patas)
            ISaltoConPatas ImiCaballosalta = miCaballo;
            Console.WriteLine($"Número de patas que usa mi Caballo para saltar: " + ImiCaballosalta.NumeroPatas());
            //De esta forma, si recordamos habiams indicado estos metodos con el mismo nombre para las dos interfaces
            //pero en la clase caballo especificamos con la nomenclatura del punto que indicacion iria en cada interface
            //pero al estar encapsulados, la unica forma de acceder es creando un objeto con el mismo tipo de la interfaz
            //ademas, como necesitamos inicializarlo, pues usamos una instancia de la clase caballo, que al heredar la interfaz crea una relacion con ella
            //por eso decimos que el principio de sustiticion: un caballo es un animal terrestre
            //y un caballo es un animals que tiene SaltoConPatas
            //asi es como funciones este principio
            //y asi es como resolvemos el tema de la ambiguedad y el acceso a estos metodos desde una clase externa
            
        
        }
    }
    //creacion de interfaz
    //es similar a crear una clase, per se sustituye la palabra reservada class por un interface
    //por convencion en los nombres de las interfaces deben comenzar con al I MAYÚSCULA
    interface IMamiferosTerrestres{//suponiendo que todos los mamiferos terrestres tienen patas
         //El numero de parametros y el tipo debe coincidir al heredar la interfaz
         int NumeroPatas();//En C# NO se pone modificador de acceso 
         //ya que si pones public va a funcionar, pero si ponemos private NO va a funcionar
         //por lo que es mejor no indicar ninguno (aunque en teoria al inicio dijimos que si no colocamos nada entonces es un private, para las interfaces esto no aplica)

         //Para las interfaces los metodos solo se declaran, nada mas. 

         //IMPORTANTE
         //Al heredar o implementar la interfaz en una clase
         //el nombre del metodo debe coincidir con el declarado en esta (Mayusculas, minusculas, numeros, tipo de datos, parametros, etc)
         //Para asi indicar a la interfaz que ya estamos realizando su instruccion de usar el metodo
    }

    //vamos hacer que una clase tenga mas de una interfaz
    //imaginemos que algunos animales se usan en los deportes, pues para implementar si o si, los metodos para deportes 
    //usaremos otra interface
    interface IAnimalesDeportes{
        string TipoDeporte();

        bool esOlimpico();
    }
//*OTRA COSA A TENER EN CUENTA Es cuando usamos muchas interfaces, puede ocurrir ambiguedad en los nombres de los metodos (es poco probable, pero puede suceder)
//POr ejemplo, supongamos que ahora quiero saber de los animales que pueden saltar (heredarian la siguiente interfaz)
//quiero saber el numero de patas que utilizan para saltar, y supongamos que yo elijo  el mismo nombre
//que el metodo de la primera interfaz. Esto causa ambiguedad, ya que al heredar estas dos interfaces
//cuando especifiquemos el metodo, no se sabra a cual de los dos esta haciendo caso, a que interfaz esta obedeciendo
//Esyo pasa cuando los metodos coinciden en nombre, tipo y numero de parametros

//esto puede ocurrir
    interface ISaltoConPatas{
        int NumeroPatas();//numero de patas con las que salta el animal, por ejemplo caballo
    }
//para solucionar la ambiguedad debemos usar la nomenclatura del punto indicando la interface y despues su metodo, 
//prescindiendo del modificador de acceso public
    //---------------------------------------------CLASES----------------------------------------

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
    class Ballena:Mamiferos{//BALLENA NO tien patas, entonces no tiene sentido heredar la interface con los metodos de patas
    //por lo que en esta clase no usaremos la interfaz, de hecho para eso es, como una medida de seguridad
    //de que la clase ballena no tenga o herede ese metodo: patas() porque no tendria sentido ni utilidad (una ballena NO TIENE PATAS)
        public Ballena(string nombreBallena) :base(nombreBallena){

        }
        public void Nadar(){
            Console.WriteLine($"Soy capaz de nadar");
            
        }
    }
    //Cuando una clase ya esta herdando de una clase, para usar la interfaz, usamos una coma,
    //Debemos respetar que primero va la clase a heredar (si fuera el caso), para caballo es su caso
    //y despues por comas, todas las interfaces implementadas o heredadas
    //Al inicio nos marcara error, porque como tal la interface nos esta obligando a implementar el metodo patas


//Un caballo puede implementar la interfaz animalDeporte
    class Caballo: Mamiferos, IMamiferosTerrestres, IAnimalesDeportes,ISaltoConPatas {//Implicitamente la clase Caballo, ademas de su constructor por defecto
    //o si agregaramos uno, llama al constructor de Mamiferos, que para este ejemplo, 
    //tambien tienen un constructor por defecto, pero esto se hace con la instruccion :base()
        public Caballo(string nombreCaballo):base(nombreCaballo){
        }
        public void Galopar(){
            Console.WriteLine($"Soy capaz de galopar");
            
        }

        //Asi ya estamos especificando a que interface pertenece cada metodo
        int IMamiferosTerrestres.NumeroPatas(){//Ahora que ya indicamos el numero de patas
            return 4;//el metodo que la interfaz pedia, ahora si se quita el error
            //obligando a implementar el metoodo a conveniencia de la clase
        }

        int ISaltoConPatas.NumeroPatas(){//Esta es la forma de resolver la ambiguedad al usar interfaces con metodos del mismo nombre
            return 2;//para ello debemos quitar el modificador de acceso public (solo cuando sucedan estos casos), porque si fuera lo contrario
        }//al no usar public en un metodo para interfaz marcaria error
        //*POR LO QUE AHORA estos metodos estan encapsulados, son private implicitamente 
        public string TipoDeporte(){//implementacion del metodo de la interfaz AnimalesDeporte
            return "carreras"; 
        }
        public bool esOlimpico(){//COmo la interfaz AnimalesDeporte tiene dos metodos, entonces al herdarla, tambien debemos implementarlos
            return true;
        }
    }
//En C# no se admite la herencia multiple de clases, si ya heredamos de una clase (mamiferos) ya no podemos heredar de otra
//lo que si se permite es la herencia multiple de interfaces
    class Humano: Mamiferos{

        public Humano(string nombreHumano):base(nombreHumano){

        }
        public void Pensar(){
            Console.WriteLine($"Soy capaz de pensar");
            
        }
    }

    class Gorila:Mamiferos, IMamiferosTerrestres{

        public Gorila(string nombreGorila):base(nombreGorila){

        }
        public void Trepar(){
            Console.WriteLine($"Soy capaz de trepar");
        }
        public int NumeroPatas(){
            return 2;
        }
    }
    //Hay clases en las que debemos o tiene sentido implementar la interfaz y otras en las que no

    //*RESTRICCIONES EN LAS INTERFACES
    /*
      *No se permite definir campos (variables) en interfaces
      *No se pueden definir constructores
      *No se pueden definir destructores
      *No se pueden especificar modificadores de acceso en métodos (todos son public de forma implícita)
      *No se pueden anidar clases ni otro tipo de estructuras en las interfaces
    */
}