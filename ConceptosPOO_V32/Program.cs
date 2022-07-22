//using System.Security.AccessControl;
using System;

namespace ConceptosPOO_V32{
    class Program{
        static void Main(string[] args){
            Console.WriteLine($"D");
            realizarTarea();//Como el metodo es de tipo void, es decir no devuelve ningun valor, solo imprime o establce
            //entonces es como si ya trajera la indicacion de imprimir: el console.writeline
            //Por lo que no se puede indicar ahora de nuevo el Console.WriteLine

            //Si fuera de tipo primitivo (string, int, double, etc)
            //si se debe indicar el console.writeline para imprimir los valores que devuelven o retornan esos metodos
            
            
        } 
        static void realizarTarea(){
            //Ṕrograma para averiguar la dinstancia entre dos puntos dados, origen y destino
            
            Punto origen = new Punto();//Llama al constructor por defecto e imprime o hace las indicaciones que tiene
            //Este objeto tiene x = 0, y = 0
            Console.WriteLine($"-------");
            //Este objeto tiene x = 128, y = 80;
            Punto destino = new Punto(128,80);//Llama al segundo constructor que imprime las coordenadas dadas
            
            //El origen x=0, y=0 diferencia con la distnacia destino con x=128, y=80
            double distancia = origen.DistanciaHasta(destino);
            Console.WriteLine($"La dintancia entre los puntos es de: {distancia}");
            
            //Imaginemos trabajar en una APP muy compleja,uuuuuuuuuuuuuuuu llevando varios dias, meses, etc.
            //Para recordar donde nos quedamos en una tarea
            //Por ejemplo, si nos quedaramos en este metodo, sabes donde seguir
            //al volver a abrir el proyecto
            //para esto usamos los comentarios tipo todo

            //TODO:
        }
    }

}