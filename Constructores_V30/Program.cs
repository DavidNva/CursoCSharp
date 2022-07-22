using System;

namespace Constructores_V30{
    class Program{ 
        static void Main(string[] args){
            Console.WriteLine($"-----------------------------");
                            //Al indicar new estamos llamando al constructor, es decir dar un estado inicial al coche
            Coche miChoche = new Coche();//Instanciar la clase Coche, crear objeto tipo Coche
            
            Coche miCoche2 = new Coche();//Entonces serian dos coches diferentes, pero los dos tinen un estado inicial
            //miChoche.ruedas = 27;//ESto no tiene sentido, por eso debemos encapsular la variable
            //ahora con el encapuslamiento no podemos cambiar el valor, a menos que declaremos un metodo para hacerlo
            //lo cual no tendria necesidad de hacer (un auto la mayoria de veces tendra 4 ruedas)
            Console.WriteLine(miChoche.getInfoCoche());//con el metodo getter vemos el valor
            
            Console.WriteLine($"------------------------------------");
            Console.WriteLine(miCoche2.getInfoCoche());//tendras de forma inplicita el mismo estado inicial
            //pero si quisieramos cambiar el estado inicial, con la sobrecarga de constructores
            Console.WriteLine($"------------------------------------");
            //Con el constructor cambiamos el largo y el ancho de un choche
            Coche miCoche3 = new Coche(4500.25,1200.35);//ahora este si es diferente

            Console.WriteLine(miCoche3.getInfoCoche());
            

            
        }
    }
}
class CocheSolo{
    //Cuando en una clase no indicamos un constructor,
    // se dice que tiene constructor por defecto
    //El interprte C# interpreta que aunque no este presente hay un 
    //constructor public CocheSolo(){}, sin parametros.
    //Un constructor por defecto

    public CocheSolo(){

    }//Este es el constructor que intepreta C# al no declarar ninguno
    //es decir da igual que ahora lo declaramos vacio, o que si no lo hicieramos
    //ya que para el constructor por defecto seria igual a este 
}
class Coche{
    //un constructor obligatoriamente debe tener el mismo nombre de la clase
    //ademas ese metodo no podra devolver ningun dato, y no es void

    //La finalidad de un constructor es dar un estado inicial a los objetos de tipo coche
    public Coche(){//Primer constructor
    //Este es el estado inicial que van a tener estos coches 
       ruedas = 4;
       largo = 2300.5;
       ancho = 0.800;
    }
    //SObrecarga de constructores (aplica como la sobrecarga de metodos)
    //No hay limite para crear constructores, simpre que se respete la regla de la sobrecarga
    //es decir, con diferentes paratros o de distintos tipos
    public Coche(double largoCoche, double anchoCoche){
        ruedas = 4;
        largo = largoCoche;
        ancho = anchoCoche;

    }







    //Los metodos getter devuelven el valor (El metodo debe ser de algun tipo privitivo, string, int, double, etc)
    public string getInfoCoche(){
        return "Información del coche:\n" + "Ruedas: " + ruedas +  "\nLargo: " + largo + "\nAncho: " + ancho;
    }//Cada objeto creado de tipo coche tendra accese a este metodo

    //Los metodos setters establecen un valor, entonces solo deben de ser de tipo void
    //ya que no devolveran nada, solo estableceran
     
    //los metodos setter establecen un valor (permiten modificar)
    //Estas variables aunque esten debajo del metodo y contructor creado, son accesibles dentro de la clase
    //porque tienen ambito de clase, en este caso, aunque el flujo de ejecucion es de arriba a abajo, 
    //respeta el ambito de estas variables haciendolas accsibles a metodos de esta clase
    /// aun cuando estas se declaren por decirlo de alguna forma: abajo de dichos metodos

    private int ruedas;

    private double largo;

    private double ancho;

    private bool climatizador; //Tiene o no tiene climatizador

    private string tapiceria; //De cuero o de tela



}