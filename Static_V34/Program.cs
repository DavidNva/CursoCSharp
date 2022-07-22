//using System.Security.AccessControl;
using System;
using static System.Math;//Esto es posible, y simplifica la escritura de algun metodo, ya 
//que no debemos especificar cada clase, las veces que lo utilicemos
using static System.Console;//Pero al final no se recomienda,porque al trabajar en equipo o para leer el codigo
//se puede confundir o complicar, ya que no sabremos distinguir entre algun metodo creado por nosotros
//o los metodos de la clase math o console, por poner de ejemplo los dos anteriores.



namespace Static_V34{
    class Program{

        static void Main(string[] args){
            realizarTarea();
            //Ejemplos de importar metodos static para simplificar la escritura de los mismos
            double raiz = Sqrt(9);//COmo se ve ahora no es necesario indicar al Math.
            double potencia = Pow(5,4);//Pero como lo dicho, esto puede confundir

            WriteLine("raiz de 9: "+ raiz);
            WriteLine("5 elevado a la 4 es: " + potencia);
            
            
        
        } 
        static void realizarTarea(){
            //Ṕrograma para averiguar la dinstancia entre dos puntos dados, origen y destino
            
            Punto origen = new Punto();//Llama al constructor por defecto e imprime o hace las indicaciones que tiene
            //Este objeto tiene x = 0, y = 0
            Console.WriteLine($"-------");
            //Este objeto tiene x = 128, y = 80;
            Punto destino = new Punto(128,80);//Llama al segundo constructor que imprime las coordenadas dadas
            
            Console.WriteLine(Punto.constantePrueba);//Ejemplo de constante static
            //destino.constantePrueba;
            //El origen x=0, y=0 diferencia con la distnacia destino con x=128, y=80
            double distancia = origen.DistanciaHasta(destino);
            Console.WriteLine($"La dintancia entre los puntos es de: {distancia}");
            //Punto otroPunto = new Punto();
            //Nos arrojara un dos, ya que hasta ahora solo hemos creado dos objetos
            Console.WriteLine($"Número de objetos creados: {Punto.ContadorObjetos()}");
            
            
        }
    }

}