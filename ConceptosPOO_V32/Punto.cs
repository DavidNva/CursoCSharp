using System;
//using System.Collections.Generic;
//using System.Text;

namespace ConceptosPOO_V32{
    //Clases en ficheros diferentes
    //Aplicando el concepto de modularizacion
    //siendo una forma de  organizar las clases de un proyecto mejor
    
    class Punto{//Crear objetos de tipo punto
    //utilizando el eje de coordenadas, se asignara una posicion para el punto
      //una clase usa el contructor por defecto no tenga constructor
      //pero si especificamos uno, entonces, es preferible indicar un constructor
      //normal (que vendria siendo por defecto, para no tener errores cuando no usemos
      // parametros en los constructores de las instanciaciones de clase)
      private int x,y;
       public Punto(){
        x = 0;
        y= 0;
        //Console.WriteLine($"Este es el constructor por defecto");
        
       }
       public Punto(int x, int y){
        this.x = x;
        this.y= y; //This hace referencia a la propia clase donde nos encontramos
        //This. va a mostrar un listado de propiedades y metodos que pertenecen a la clase donde nos encontramos
        //Console.WriteLine($"Coordenada x: {x}\nCoordenada y: {y}");
        
       }
       //Metodo para averiguar la dinstancia entre los puntos
       public double DistanciaHasta(Punto otroPunto){//Es como si dijeramos int variable, double variable, etc. ES decir es una variable de tipo punto
       //el lugar de una variable de tipo string, int, double, etc
        //Es como si siempre empezaramos con coordenadas = 0,0;
        //Es decir el origen con x=0, y=0 se resta las coordenadas de cada x, y y, del otro punto que seria destino
        //ESte valor dara negativo, pero no importa, porque al elevarlo al cuadrado volvera a ser positivo
        //ya que tengamos la dinstancia entre cada punto, de 0 a x, y de 0 a y
        //de 0 de origen a x  destino
        //de 0 de origen a y destino
        //Por ejemplo con las coordenadas indicadas para la explicacion
        //Pasamos a calcular la distancia con el teorema de pitagoras
        /*
         ***
         *****
         ******
         *******
         ********
         *********
         **********
 //128   ***********   //150.9436 
         ************
         *************
         **************
         ***************
         ****************
         *****************
         ******************
               //80
        */
        //Es decir,la raiz cuadrada (128 al cuadrado + 80 al cuadrado) = hipotenusa: 150.9436
        int xDif = this.x - otroPunto.x;//El otro punto, seria por ejemplo, la variable destino 
        //para sacer la diferencia con origen
        int yDif = this.y -otroPunto.y;//Estamo detectando la coordenada del punto o el lugar donde se encuentra el punto
        
        //una vez que tenemos claro donde estan esos puntos, ahora vamos a calcular la distancia entre ellos
        //esto con el teorema de pitagoras
        double distanciaPunto = Math.Sqrt(Math.Pow(xDif,2) + Math.Pow(yDif,2));
        return distanciaPunto; 
        //Teorema de pitagoras : El cuadrado de la hipotenusa es igual a la suma del cuadrado de los catetos

        //a al cuadrado + b al cuadrado = c al cuadrado
       }
    }
}