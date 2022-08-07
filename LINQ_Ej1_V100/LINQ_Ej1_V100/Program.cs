using System;
using System.Linq;

namespace LINQ_Ej1_V100
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola");
            int[] numeros = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Numeros pares");

            /*List<int> numerosPares = new List<int>();
            foreach(int i in numeros)
            {
                if(i%2==0)
                {
                    numerosPares.Add(i);
                }            
            }
            */
            //Ahora el codigo anterior con LINQ se reducira en un linea
            //Instanciamos de unainterface
            //Es como si instanciaramos la interface, pero en realidad solo amos un valor
            //Siendo una coleccion
            IEnumerable<int> numerosPares = from num in numeros where num % 2 == 0 select num;//Esta es la consulta LINQ
            foreach(int i in numerosPares)
            {
                Console.WriteLine(i);
            }
        }
    }
    
}
