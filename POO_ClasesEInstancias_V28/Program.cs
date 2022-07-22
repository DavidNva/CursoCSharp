using System.Net.NetworkInformation;
using System;

namespace POO_ClasesEInstancias_V28{
    class Program{
        static void Main(string[] args){
            Circulo miCirculo; //Declaracion, creacion de variable tipo objeto
            //*Creacion de objeto perteneciente a la clase circulo, a la plantilla circulo
            //Siendo una variable/objeto de tipo circulo
            //Estamo creando un tipo de variable si lo queremos ver asi, un tipo como lo es el int, el string o el bool
            //*Es como decir que string es un objeto o una instancia de la clase String (con mayuscula, jaja)
            //*En lugar de decir que es de tipo double, tipo int o string, decimos que es de tipo circulo
            //porque a esa clase pertenece
            miCirculo = new Circulo();//Iniciar el objeto,instanciar una clase,
                                      //ejemplarizacion, creacion de ejemplar de clase ,iniciar la variable objeto
            //Al inicializarla les estamo dando ya un valor a esa variable objeto de tipo circulo
            //Seria como si al iniciar un nuevo objeto, o hacer la instancia de clase, a traves de el
            //podemos acceder a los metodos o variables de dicha clase con la nomenclatura del punto (esto mientras no sean 
            //metodos de clase, los que tienen static, ya que estos no se acceden desde un objeto, sino desde una clase)
            //Tambien depende de como esten sus modificadores de acceso, pero como tal
            //las instancias de objetos, sirve para tener con la nomenclatura del punto
            //acceso a esos comportamientos(metodos) y variables de la clase (propiedades)

            miCirculo.areaCirculo(3);//Nos devuelve el area, pero no la esta imprimiendo

            Console.WriteLine(miCirculo.areaCirculo(5));//Ahora si lo imprime           

            //*Podemos crear infinidad de objetos que pertenezcan a la misma clase
            //por ejemplo, si ahora:
            Circulo miCirculo2 = new Circulo();//Tambien podemos crear (declarar) e inicializar el objeto al mismo tiepo
            //como con las variables primitivas 
            Console.WriteLine(miCirculo2.areaCirculo(9)); 
           //* miCirculo.PI= 50.45;//Esto no tiene sentido porque PI es un valor fijo
            //y nadie deberia cambiarle ese valor, si lo cambiamos alteramos todo el programa
            Console.WriteLine(miCirculo.areaCirculo(5));//El primer calculo lo hace bien, pero este seguno
            //ya toma el nuevo valor de PI, que como lo dicho, eso seria incorrecto

        }
    }
    //Construccion de una clase para hacer un circulo
    //es decir hacer circulos diferentes, seria de diferente tamaño o area
    class Circulo{//que esta clase circulo sea capaz de crear circulos de diferente area
        //AREA DE CIRCULO: PI * radio * radio = PI * Radio al cuadrado
       
        //Propiedades de la clase circulo
        //lo de hace publica un variable no se recomienda siempre a menos que se tenga la certeza de que no ocurra algun detalle
        //*en este caso la variable PI, no conviene declararla publica, porque PI solo puede tener un valor
        //y no debe ser cambiado ni por error o afectaria al program
        /*public *///double PI = 3.1416;//Propiedad de clase. campo de clase (ya que seria global en la clase)
        
        //en este caso, para no tener problema, podemos declararla como constant
        //para que ni dentro de la propia clase, pueda cambiar su valor
        public const double PI = 3.1416;

        //Aunque obviamente esto no va aplicar con cada programa que hagamos, es alli donde debemos
        //tener en cuenta los modificadores de acceso y el concepto de encapsulamiento

        //Métodos (Calcular el area del ciruclo) //METODO DE CLASE
        //Para poder acceder al metodo intanciando un objeto en otra clase, indicamos un public
        //el modificardor de acceso (public: visible para todas las clases)
     public double areaCirculo(int radio){//Que pueden hacer los objetos de tipo circulo
            return Math.Pow(radio,2) * PI;
        }
    }
}