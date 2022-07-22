using System;

namespace Checked_V24{
    class Program {
        static void Main (string[] args){
            //En ocaciones por una cuestion de rendimiento el compilador se salta 
            //por ejemplo las excepciones de OverflowException


            //los checked se usan como tal para tumbar practicamente el programa
            //como ocurre, en el ejemplo, el checked hace que el programa caiga al detectar el desbordamiento de pila
            //mandando la excepcion OverflowException
            //* checked{
            //*int numero = int.MaxValue;//Indicamos el máximo valor de un int
            //*int resultado = numero + 20;//Esto deberia dar un error, porque ya hemos dado el valor maximo
            //* Console.WriteLine(resultado);//Pero al imprimir, el compilador solo nos marca un valor
            //negativo, es como si tuviera una excepcion para mandar un valor erroneo
            //como tal, si surge desbordamiento en nuestra aplicacion, esto no seria muy utl
            //*  }
            //En Visual Studio se puede activar la opcion del checked en opciones avanzadas del proyecto
            
            //Si se activara esa opcion del checked, la situacion seria diferente, quizas ahora
            //necesitamos indicar que aun cuando exista un error, se lo salte, aun cuando no de un dato diferente
            //erroneo, como se mostraba en el ejemplo que imprimia un numero negativo sin razon alguna
            //en estos casos (para regresarlo a su forma normal) usamos el unchecked (es decir que no lo cheque)
            
            //checked y unchecked solo funcionan con los valores de tipo int y long
            // Tambien indicando la linea a la que se la hara el checked, se puede indicar entre parentesis
            
            int numero2 = int.MaxValue;//Indicamos el máximo valor de un int
            int resultado2 = checked(numero2 + 20);//Esto deberia dar un error, porque ya hemos dado el valor maximo
            Console.WriteLine(resultado2);//Pero al imprimir, el compilador solo nos marca un valor
            //negativo, es como si tuviera una excepcion para mandar un valor erroneo
            //como tal, si surge desbordamiento en nuestra aplicacion, esto no seria muy utl
            

        }
    }
}