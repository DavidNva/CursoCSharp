using System;
namespace Metodos_V12{
    class Program{
       int numero1 = 5; //tiene un ambito global o de clase //ambito de clase
       int numero2 = 7;//Este tipo de variables tambien se conocen como campos de clase
        static void Main(string[] args){ 

            Console.WriteLine(suma(5.5,1));
            //Para distinguir a que metodo estamos haciendo referencia, podemos guiarnos
            //del menu que ofrece el editor, o teniendo en cuanto al numero de referencias
            //de una metodo, que lo muestra encima de su nombre

            int valor1 =7; 
            double valor2 = 5.2;
            double valor3 = 8.3;
            //_-------------------------- practica con parametros opcionales
            Console.WriteLine(sumaOpcional(valor1,valor2));//En este caso nosotros decidimos si queremos o no
            //utilizar ese parametro, es opcional
            //es decir, es como si tuvieramos una sobrecarga del metodo, teniendo es posibilidad
            //de agregar o eliminar el valor
            

        }  
//Cuando se quiera o se requiera compartir variables en diferentes metodos, se debe declarar
//en la clase, seria una variable de clase, o una variable global
//en este caso, no importa si la variable se declara antes o despues de un metodo que lo utiliza
//ya que se esta tomando desde la clase, entonces no importa o ocurre la excepcion con la regla
//del flujo de ejecucion de arriba a abajo, es decir, por ejemplo
//si declaramos nuestras variables al final de la clase, SI seria factible  
        void primerMetodo(){
           // int numero1 = 5; //tiene un ambito local
            //int numero2 = 7;
            Console.WriteLine(numero1 + numero2);
            System.Console.WriteLine();
            

        }

        void segundoMetodo(){
            Console.WriteLine(numero3 + numero4);//Como se observa al inicio, si quisieramos hacer uso de la 
            //variable numero1, no se puede porque esta variable solo le pertenece al primerMetodo
            //su ambito o alcance terman con las llaves del mismo
            //como tal entonces, la variable numero1 tiene un ambito local
            //Pero si cambiamos a una variable de claseo global, estos errores desaparecen
        }
        int numero3 = 10; //tiene un ambito global o de clase //ambito de clase
        int numero4 = 10;

        //-------Existe tambien la sobrecarga de métodos
        //Esto es cuando tenemos dentro de la misma clase dos o mas metodos con el mismo nombre
        //Para que exista una sobre carga o bien
        //deben tener diferentes tipos de parametros
        // o bien diferente numero de parametros
        
        static int suma(int operador1, int operador2) => operador1 + operador2;

        static int suma(int operador1, double operador2) => operador1;

        static double suma(double operador1, int operador2) => operador1 + operador2;

        static int suma(int numero1, int numero2, int numero3) => numero1 + numero2;
  
        static int suma(int numero1, int numero2, int numero3, int numero4) => numero1 + numero2;      
        
        /*private static double resta(int v1, double v2){
            return v1-v2;
        }*/

        //------------------------------
        //La sobrecarga de metodos tambien puede estar definida con parametros opcionales
        //es decir, indicarlos, pero no usarlos, relacionado como los dos ultimos ejemplos
        //esto es cuando una aplicacion requiere ser realizada u ocupa dos o mas lenguajes de 
        //programacion y quizas alguno de ellos no admite la sobrecarga, entonces se crean este tipo
        //de metodos
        private static double sumaOpcional(int num1, double num2, double num3 = 0){
            return num1 + num2 + num3;
        }
        //solo que para estos metodos se debe indicar al parametro opcional un valor por defecto
        //que para las operaciones seria conveniente un 0, que no alteraria la operacion 
        //pero si queremos usar el tercer parametro y darle un nuevo valor, si se podria
        //teniendo indirectamente asi una simulacion  de la sobrecarga del metodo
        //sin necesidad de declarar mas con el mismo nombre
        //esto claro depende del contexto en que estemos realizando una aplicacion, donde quizas
        //necesitemos agregar o quitar, usar o no usar ciertos parametros
        //pero como lo dicho, para aplicaciones que usan distintos lenguajes, donde algunos
        //no soportan la sobrecarga, esta forma de parametros opcionales seria la solucion al mismo

        //La regla que se debe respetar, es que los parametros opcionales se deben indicar
        //despues o acontinuación de los obligatorios 

        //Para estos casos si hacemos una sobrecarga real de sumaOpcional
        //dependiendo si indicamos los tres parametros tomara el metodo 1
        //Pero si solo indicamos dos parametros, aunque como el primero tiene
        //parametros opcionales y seria factible para usarse con dos parametros
        //la ejecucion tomara al segundo que tenemos como sobrecarga
        //ya que es el que mas se adapta a los valores ingresados
         private static double sumaOpcional(int num1, double num2){
            return num1 + num2 ;
        }
    }
}