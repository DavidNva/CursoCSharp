using System.Dynamic;
using System;

namespace ArrayPorParametros_V40{
    class Program{
        static void Main(string[] args){
           int[] numeros = new int[4];

           numeros[0] = 7;
           numeros[1] = 9;
           numeros[2] = 15;
           numeros[3] = 3;

           ProcesaDatos(numeros);//Aqui estaria sumando 10 con el metodo llamado

           /*
             foreach(int i in datos){
                Console.WriteLine(i);
                
            }
           */
            foreach(int i in numeros){//Al volver a leer al array, ya se han sumado 10
                Console.WriteLine(i);
                
            }

            Console.WriteLine($"------------------------");
            Console.WriteLine($"Un metodo con return de tipo array");
            int[] arrayElementos = LeerDatos();

            Console.WriteLine($"Imprimiendo arrayElementos");
            
            foreach (int i in arrayElementos)
            {
                Console.WriteLine(i);
                
            }                        
        }

        static void ProcesaDatos(int[] datos){//El array a ingresar debe ser de tipo entero
            for (int i = 0; i < 4; i++)
            {
                datos[i] += 10;
            }
        }

        //-----------------Metodo que devuelve un tipo array -------------------
        static int[] LeerDatos(){
            Console.WriteLine($"¿Cuantos elementos quieres que tenga el array?");

            string respuesta = Console.ReadLine();

            int numElementos = int.Parse(respuesta);
            
            int[] datos = new int[numElementos];

            for (int i = 0; i < numElementos; i++)
            {
                Console.WriteLine($"Introduce el dato para la posicion: " + i);
                respuesta = Console.ReadLine();
                int datosElemento = int.Parse(respuesta);
                datos[i] = datosElemento;
            }
            return datos;
        }
    }
}