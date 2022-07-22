using System;
namespace Metodos_V9{
    class Program{
        /*
          Cosas a tener en cuenta para los metodos en C#
          No se ejecutaran hasta su llamada
          Todos los métodos iran dentro de una clase
          Se debe especificar el tipo devuelto y los parametros
          No hay distincion entre los metodos y funciones. En C#
          ambos terminos son los mismos
        */
        static void Main(string[] args){ 
              //Video 10 - Metodos de tipo void (NO devuleven ningun valor)
              /*mensajeEnPantalla();

              mensajeEnPantalla();
              Console.WriteLine($"Mensaje desde el Main ");

               mensajeEnPantalla();
               mensajeEnPantalla();
               mensajeEnPantalla();
               sumaNumeros(5,7);//Como el metodo tiene dos parametros
               //en la llamada obligatoriamente debemos indicar dos parametros
               //Ademas los parametros ingresados deben ser iguales a los que el metodo espera
               //en este caso, se solicitan dos numeros enteros, por lo que se deben ingresar dos enteros
              */
//_--------------------------------------------------------------------------------------------------------------------------------------
               //Video 11 - Metodos RETURN o de con un tipo de dato  (SI o SI devuleven un valor)
               Console.WriteLine(sumaNumeros2(10,15));
               Console.WriteLine(sumaNumeros4(15.5,15));

               //-----------------
               Console.WriteLine(divideNumeros(18,6));//Al nosotros usar una division
               //18/6 es igual a 3, un valor entero claro pero si cambiamos
                Console.WriteLine(divideNumeros(18,7));//El valor cambiara a 2.5714...
                //es decir un valor decimal, sin embargo como el metodo es de tipo int
                //simplemente devolvera un entero, que en este caso seria 2
                //como tal serian datos inexatos
                //entonces se debe cambiar el tipo de metodo a double, y ademas que al menos de uno de 
                //los parametros sea de tipo double, porque de nada sirve que el metodo sea double
                //si los parametros todos son int, el resultado seria igual int

                //despues de cambiar al menos un parametro a double, debemos tener cuidado al declararlo
                //en el parametro, ya que si indicamos un decimal en el parametro de tipo int, dara error claramente
                //entonces es debido colocarlo con su respectivo parametro de igual tipo

                //por ejemplo, arreglando la division anterior
                System.Console.WriteLine("Division correcta con decimales");
                Console.WriteLine(divideNumeros2(18,7));//De esta forma el resultado sera decimal
                //Teniendo en cuenta que el parametro decimal es el 18, es decir, puedo especificar
                //en el un 18.5 o mas decimales de tipo double, sin embargo si quisiera especificar 
                //decimales con el 7, esto daria error, ya que su tipo de parametro es int, es a lo que 
                //haciamos referencia al comentario anterior
                divideNumeros2(18.5,7);//SI se puede
               // divideNumeros2(18,7.5);//NO se puede
                divideNumeros2(18,7);
                Console.WriteLine($"-----------------------");
                
                Console.WriteLine($"Divison con nomengratura de lamba o flechita");
                Console.WriteLine(divideNumeros3(18,7));
                
                
               
               sumaNumeros2(10,15);
               sumaNumeros4(15.5,15);

        }
         
        //Video 10 - Metodos de tipo void (NO devuleven ningun valor)
        //Las references indican el numero de veces que dicho metodo ha sido llamado
        //Para este ejemplo, el metodo se ha usado 5 veces, por lo que serian 5 referencias
        static void mensajeEnPantalla(){
             Console.WriteLine($"Mensaje desde el metodo mensajeEnPantalla");
             
        }
        //Como no hay objetos para llamar a un metodo, se usa el static que significa pertence a la clase
        //es decir, que para usarlo, se debe usar la clase donde fue creada
        //Si es llamado en su propia clase, no es necesario mencionar a la clase (tomando en cuenta su ambito de visibilidad)
        static void sumaNumeros(int num1,int num2){
            Console.WriteLine($"La suma de los numeros es: {num1 + num2}");
            Console.WriteLine("La suma de los numeros es:" + num1 + num2);//Se debe
            //tener cuidado con la concatenacion, ya que, en el segundo ejemplo
            //no sumaria los numeros, sino que los concatena como num1 y num2
            //imprimiendo los dos juntos
            //Esto lo podemos solucionar tambien poniendo entre parentesis la suma
               Console.WriteLine("La suma de los numeros es:" + (num1 + num2));
               //o con otra forma de concatenar (Uso de comas)
               Console.WriteLine("La suma de los numeros es: {0}", num1 + num2);
        }
//-------------------------------------------------------------------------------------------------------------------------------------------
         //Video 11 - Metodos RETURN o de con un tipo de dato  (SI o SI devuleven un valor)
        static int sumaNumeros2(int num1, int num2){
            return num1 + num2;
            //System.Console.WriteLine(num1);
            /*
            Un metodo return simpre devuelve el flujo de ejecucion a la llamada
            Es decir, cuando encuentra un return automaticamente se sale del metodo 
            y continua el flujo de ejecucion del program

            Si en este metodo existieran mas lineas de codigo, despues del return
            nunca serian ejecutadas, ya que como lo dicho, al encontrar un return
            automaticamente se saldria del metodo
            */

            //Se puede usar un return por ejemplo para salir de un bucle
            //aunque no es una muy buen practica
        }
        //EJemplo de un metodo erroneo por su tipo y sus parametros
        /*
            static int sumaNumeros3(double num1, int num2){

            return num1 + num2; //En este caso, si declaramos un parametro de tipo
            //double, aunque la suma sea con uno de tipo int, el resultado siempre
            //sera de tipo double, es decir 
            //double con int  = double, por esa razon este metodo da error
            //la solucion es cambiando el tipo del metodo a un double
            //como se ve en el siguiente
            }
        */
        //Ejemplo metodo correcto, cambiando de int a double
        static double sumaNumeros4(double num1, int num2){
            return num1 + num2; //En este caso, si declaramos un parametro de tipo
            //double, aunque la suma sea con uno de tipo int, el resultado siempre
            //sera de tipo double, es decir 
            //double con int  = double, por esa razon este metodo da error
            //la solucion es cambiando el tipo del metodo a un double
            //como se ve en el siguiente
            
        }

        static int divideNumeros(int num1,int num2){

            return num1 / num2;
        }

        static double divideNumeros2(double num1,int num2){

            return num1 / num2;
        }
        //Cuando tenemos metodos sencillos o de una sola linea, se recomienda usar lamba: => 
        //para simplificar el codigo, prescindiendo del return
        //Prescindiendo tambien de las llaves
        static double divideNumeros3(double num1,int num2) =>  num1 / num2;
         //Despues de lamba o flechita, jaja, se indica el dato que se desea devolver
        
        static double divideNumeros4(double num1,int num2){
            
            double resultado;
            resultado  = num1 + num2;
            return resultado;//Esto daria exactamente lo mismo que el metodo anterior
            //Osea que el declararlo en una linea de codigo, o extendernos con mas lineas
            //dependera del contexto o de lo que estemos realizando
            //es decir, por ejemplo, si hicieramos mas operaciones con resultado
            //el hacerlo en una sola linea no seria factible o permitido
            //por lo que hacerlo como un metodo normal, seria lo mas recomendable
            //entonces decimos que el usar la flecha o lamba dependera del tipo
            //de metodo que estemos realizando o el uso que le daremos
            
        }
    }
}