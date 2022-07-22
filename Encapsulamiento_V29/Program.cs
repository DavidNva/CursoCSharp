using System;

namespace Encapsulamiento_V29{
    class Program{
        /*
          El encapsulamiento es para que no se pueda acceder  a variales  
          metodos desde otra clase externa
          Es una medida de seguridad y buen funcionamiento del programa
          Los datos de una clase no sean accesibles para una clase externa
          a no ser que sea necesario
        */
        //Para encapsular metodos y variables se pone el privated antes
        static void Main(string[] args){
            
            Console.WriteLine($"Hola de nuevo");
            Circulo miCirculo= new Circulo();
            Console.WriteLine(miCirculo.AreaCirculo(5));

            //_-----------------------------------
            Console.WriteLine($"------------------------------");

            ConversorPesoDolar miDinero = new ConversorPesoDolar();
           
            //miDinero.peso = -7;//Esto logicamente y econimicamente es un error, ya que el valor de la moneda no puede ser negativa
            //seria una de las desventajas de no encapular la variable peso, ya que estamos
            //acediendo desde otra clase para cambiarle el valor de manera erronea
            //asi para no poder hace este tipo de cosas, debemos encapsular la variable
            
            //ahora con el metodo hecho podemos cambiar el valor del peso
            miDinero.CambiaValorEuro(21.5);

            Console.WriteLine(miDinero.Convierte(100));//100 dolares = 2000 pesos
            
        }
        class ConversorPesoDolar{
            private double peso = 20; //20 pesos = un dolar//en teoria

            public double Convierte(double cantidad){
                return cantidad * peso;
            }
            //para solucionar el cambio de valor de la variable peso, estando encapsulada
            //debemos crear un metodo de tipo void (no devuelve nada) para acceder a la variable
            public void CambiaValorEuro(double nuevoValor){
                if(nuevoValor<0){
                    peso = 20;
                }else peso = nuevoValor;
            }
            //la ventaja de crear un metodo para acceder o modificar el valor de una variable
            //es que podemos controlar como se hara
            //por ejemplo, ahora indicamos que si ingresamos un peso negativa, por logica no tendria sentido
            //entonces seguimos con el mismo valor anterior, pero si no es negativo
            //entonces si se puede cambiar, eso lo especificamos en la condicion if
            //ayudandonos asi a estar seguros o validar los datos y modificaciones que se puedan 
            //hacer con la variable peso 
        }
        //-------------------------------------------------------------
        class Circulo{
            //Cuando creamo variables, se recomienda que este encapsuladas y si necesitamos
            //acceder a ello o modificarlas, se hagan a traves de un metodo de acceso (setters and getters)

            //
            //Con el private indicamos un encapsulamiento de la variabl PI, YA QUE NO SE NECESARIO
            //ACCEDER A EL DESDE OTRA CLASE O CAMBIAR SU VALOR
            //En C#, para este lenguaje, si no indicamos ningun modificador de acceseo 
            //por defecto lo vuelve private, es decir, que podemos ponerlo o no el private
            //antes, por default le da ese modificador
            //pero se recomienda que si vamos a encapsular datos, usemos el private
            //para una mejor lectura del codigo  a pesar de que en C# es lo mismo que si no lo pusieramos

            //POR Convencion los identificadores de las constantes deben estar en mayusculas
            private const double PI = 3.1416;//La constante PI no es necesaria fuera de su ambito (que esta dentro de una llave de apertura y de cierre)
            //Para poder acceder al metodo intanciando un objeto en otra clase, indicamos un public
            //el modificardor de acceso (public: visible para todas las clases)
            //Por convencion a los identificadores (nombre de variables y metodo)
            //deben comenzar con letra mayúscula: "AreaCirculo"
            public  double AreaCirculo(int radio){//Que pueden hacer los objetos de tipo circulo
                return Math.Pow(radio,2) * PI;
            }
        }
    }
}