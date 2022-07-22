using System;

namespace Arrays_V36{
    class Program{
        /*
          *Los arrays son una estructura de datos qe contieneuna coleccion de
          valores del mismo tipo.

          Sirven para almacenar valores que normalmente tienen una relacion entre si
          Por ejemplo la edad de unos trabajadores.
          
          Al igual que con los objetos, no se reserva un espacio en la memoria hasta que 
          se inicializa el objeto, array con "new"

          *Dar valores
          *Un array tieneindices o posiciones que comienzan desde el 0


        */
        static void Main(string[] args)
        {
            int[] edades;//Declaracion del arrays (Aun no se reserva ningun espacio)
            edades = new int[5];//Inicializacion del aray (Se reserva el espacio en memoria)
            
            //En C# si no especificamos los valores de un array, entonces se colocan 
            //los valores por defecto del tipo de dato
            //para int seria 0
            //para string seria null
            //para objetos seria null
            Console.WriteLine(edades[4]);//Por ejemplo, esto imprime un 0, porque asi esta el array
                                         //Como el array es de 5 elementos, (recordando que se comienza desde el 0)
                                         //Entonces quedaria como {0,0,0,0,0}
            //Dar valores a cada posicion
            edades[0]=15;//Posicion 0 //Dato 1
            edades[1]=27;//Posicion 1 //Dato 2
            edades[2]=19;//Posicion 2 //Dato 3
            edades[3]=80;//Posicion 3 //Dato 4
          //edades[4]=1; //Posicion 4 //Dato 5
            
            //edades[5] = 65;//Esto da error en la ejecucion porque la posicion 5 no existe:
            //IndexOutOfRangeException: Index was outside the bounds of the array.
            //Console.WriteLine(edades[5]);//Esto tambien daria el mismo error anterior
            //porque estamos intentando acceder a un valor o posicion que no existe
            //Si no especificamos un valor, como lo dicho, toma el valor por defecto = 0
            
            Console.WriteLine(edades[2]);//Ahora la posicion 2 tiene el valor 19
           
            //Sintaxis simplificada para declarar un array cuando
            //sabemos el numero de valores que tendra un array

            //esta es mas simplificada y mas flexible
            int [] edades2 = {15,27,19,80,1};//Como vemos son los mismo datos anteriores
            //indicados en la misma declaracion e inicializacion del array, podemos ir agregando valores

            Console.WriteLine(edades2[2]);//De nueva forma, respetando las posiciones indicaria un 19
            //Aplican los mismos errores mencionados, de intentar acceder a indices inexistentes

            //Tambien sigueindo la logica del segundo y primer ejemplo, podemos
            //inicalizar los valores del array y a la vez indicar cuantos valores se agregaran
            //Esto quitaria la flexibilidad a la del anterior array (edades2),
            //pero en C# es una forma mas declarar arrays  
            int[] edades3 = new int[5] {15,27,19,80,1};

            
           

        }
    }
}