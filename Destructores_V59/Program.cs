using System;

namespace Destructores_V59{

    //existe un garbage collection (coleccion de basura) que se crea cuando un objeto o recurso ya no es utilizado
    //los lenguajes modernos o actuales, regularmente ya traen sus propias instrucciones para vaciar este garbage collection
    //pero hay casos en que programador es mejor asegurarnos de que esto se haga luego, al usar el programa
    //por ejemplo cerrar conexiones inecesarias, ya sean de ficheros, consultas, etc.
    class Program{
        ///media/davidnava/DAVID SD/Documentos/Cursos/CursoCSharp/Destructores_V59
        static void Main(string[] args){
            //Para explicar el destructor. vamos a crear un programa para leer un archivo de texto
            //que esta dentro de este mismo proyecto
            Console.WriteLine($"-------");


            ManejoArchivos archivo = new ManejoArchivos();
            
            Console.WriteLine($"------------");
            
            archivo.mensaje();
            
        }
        class ManejoArchivos{
            StreamReader archivo = null;
            int contador = 0;
            string linea;
            public ManejoArchivos(){
                //Esta conexion (cuando usamos new, creamos la conexion y reservamos memoria en heap)
                //Una vez que la terminemos de ocupar, la debemos cerrar,y para eso ocuparemos el destructor
                archivo = new StreamReader(@"/media/davidnava/DAVID SD/Documentos/Cursos/CursoCSharp/Destructores_V59/Practica.txt");

                while((linea = archivo.ReadLine())!=null){//Mientras haya texto
                    Console.WriteLine(linea);//Va leyendo (imprimiendo) cada linea de archivo
                    contador ++;
                }
            }

            public void mensaje(){
                Console.WriteLine($"El archivo tienen {contador} lineas");
                
            }
            //La sintaxis de un destructor es solo colocar una virgulilla (la tilde de la ñ)
            //y hacer como un constructor normal (ademas debe llamar igual a este)
            ~ManejoArchivos(){//Y aqui indicamos lo que deba hacer
                archivo.Close();//Cerramo el strim de datos
            }
        }
        //*A tener en cuenta con los destructores
        /*
          *Los destructores solo se usan en clases
          *Cada clase solo puede tener un destructor
          *Los destructores no se heredan ni se sobrecargan
          *Los destructores no se llaman. Son invocados automáticamente.
          *Los destructores no tienen modificadores de acceso ni parámetros

          *Ademas, se recomienda usar poco estos destructores
          *Evitarlos en la medida de lo posible, a menos que estemos seguros de que recursos debemos liberar
          *Podemos usar los finally en lugar de un constructo, aunque la dinamica es casi la misma
          *Porque si no estamos bien seguros de que conexion estamos cerrando, podriamos afectar en el funcionamiento del programa
          *Sera mejor dejar que el Garbage Collection haga su trabajo, cerrando o quitando el mismo estas conexiones, ficheros, objetos, etc.
        */
    }
}