using System;

namespace PrimeraAplicacion
{
    class Program
    {
        static void Main(string[] args){
            
            //-----------------------------------------------------------------------------------------------
            /*Console.WriteLine("Hola Mundo");//El flujo de ejecucion es de arriba
            Console.WriteLine("Iniciando en C#, jsjsjs");
            int edad = 28;
            System.Console.WriteLine( edad);//No se puede utilizar una variable que no se ha iniciado*/
            //-----------------------------------------------------------------------------------------------
            //Tipos de datos
            /*
            int: Números enteros
            long Números enteros muy grandes
            float: Números decimales
            double: Números decimales con parte decimal mas larga
            String: Cadena de caracteres
            Char: Un unico carácter 
            Bool: Booleanos
            */
            /*
            Enteros con signo: sbyte, short, int, long.
            Enteros sin signo: byte, ushort, uint, ulong
            Reales: Float, double, decimal
            Booleanos: True, false
            */
            //----------------------------Video 5 - Sintaxis Básica III --------------------------------------
            //Operadores aritmeticos
            /*
             Suma +
              -Se puede usar como suma artimetica
              -Como concatenacion de strings
              -Como incremento con ++
             Resta -
              -Se puede usar como resta aritmetica
              -Decremento con--
             Multiplicacion *
             Division /
             Residuo o Módulo % 
              -Este devuelve el valor del resiudo
               de una division.    
            */
            //Cuando trabajamos con valores indicados en la propia instruccion
            //Por ejemplo, al dividir 5/2, en la consola el resultado sera un 2
            //esto sucede porque en c# se esta considerando a los dos
            //valores como tipo entero, por lo que el resultado tambien debe ser de tipo entero
            //por lo que en lugar de devolver un 2.5, como seria normalmente pasa
            //a devolver un 2 entero solamente
            // Esto podemos solucionarlo indicando al valor un .0, para que asi
            //el compilador lo interprete como un double
            /*
            Console.WriteLine(5/2);//Los considera como int
            Console.WriteLine(5.0/2);//Los considera como double
            Console.WriteLine(7/2.0);//Los considera como double

            //Ejemplos con residuo--
            //Devolviendo el resto/residuo de una division
            Console.WriteLine(9 % 3);//Devolvera un 0
            Console.WriteLine(9 % 4);//Devolvera un 1

            //Ejemplos de concatenación  de string con el operador +
            int edad = 19;
            //Usandola como sufijo:
            //edad++;//Ahora devolvera una edad de 20 años
            //Usandola como prefijo
            //Ejemplos de incremento o decremente de un valor

            //En el siguiente ejemplo,en teoria podremos imaginar que el valor de la edad
            //seria 20, ya que le indicamos un ++, pero como el flujo de ejecucion
            //es de arriba hacia abajo, y de izquierda a derecha, el compilador
            //esta leyendo que la edad es de 19, y aunque se indique un nuevo valor 
            //de 20, simplemente seguira imprimiendo el 19
            //esto lo comprobamos indicando la impresion nuevamente de edad
            //y esta vez si mostrara el valor de 20: Tienes una edad de 19 años 20
            //Console.WriteLine("Tienes una edad de " + edad++ + " años " + edad);

            //Entonces por logica, corrigiendo el "digamos" error anterior
            //debemos especificar antes ese incremento, ahora si impremirá un valor de 20 años (obviamente
            //debemos comentar o quitar la linea anterior, o el no veremos el 20 sino el 21, jaja)
            //Console.WriteLine("Tienes una edad de " + ++edad + " años ");//Usandolo el ++ como prefijo

            //Otra opcion en C# es la: Interpolacion de strings
            // Console.WriteLine($"Tienes una edad de {edad} años");

            //Otras operaciones que se pueden hacer con el incremento o decremento es:
            //Comentando o elimando las lineas anteriores, tenemos que edad es 19
            //entonces al indicar un incremento de
            edad += 8;//Devolvera un 27, es decir 27 años
            Console.WriteLine("Tienes una edad de " + edad + " años");
            //Si decrementamos uno simplemete debemos indicar --
            edad--;//Ahora devolvera 26 años
            Console.WriteLine("Tienes una edad de " + edad + " años");
            //Si ahora decrementamos el valor en 5
            edad -= 5;//Devolvera una edad de 21 
            Console.WriteLine("Tienes una edad de " + edad + " años");
           // ------------------------------------------------Video 6-----------------------------------
           //Operador =
           
         /*  int edadPersona1;  
           int edadPersona2;
           int edadPersona3;
           int edadPersona4;

           edadPersona1=edadPersona2 = edadPersona3 = edadPersona4 = 27;

           System.Console.WriteLine(edadPersona4);*/

           //De la forma anterior podriamos igualara 27 todas las edades de las 4 personas

           //Pero si quisieramos inicializarlas con el valor 27 como se muestra a continuacion
           //no se podria, ya que no todas estarian inicializada, al menos en c# no se puede */
           /*
           //Ejemplo
           int edadPersonas1,edadPersona2,edadPersona3,edadPersona4 = 27;//en este caso
           //se esta inicializando solo la variable: edadPersona4. Es la unica que podemos utilizar
           //a menos que le demos valor a las demas
           //System.Console.WriteLine(edadPersona2);//La variable al no estar declarada, enviará un error
        //a menos que le demos valor a cada uno
           int edadPers1=5,edadPers2=10,edadPers3=15,edadPers4 = 27;
           System.Console.WriteLine(edadPers2);

           //Ejemplos de declaracion implicita
           var precioPlayera = 19;//El compilador solo iterpretara o asignara el valor de int a esta variable
           //sin embargo, en c# despues de declarar la variable ya no se puede
           //cambiar el tipo de dato, es decir, que si el precioPlayera quisieramos
           //cambiarlo a 19.5 (tipo double), nos generará un error. Ya no se puede cambiar ese tipo int
           //precioPlayera =19.5;//Esto seria el error al usar var //En otros lenguajes si lo admiten, pero en C# no
           System.Console.WriteLine(precioPlayera);

           //Otra cosa que no se permite al usar var (declarar variables implicitas)
           //Es declarar una variable sin iniciar
           */
           /*var playera;
           playera= "David";*///Esto seria error
           //Se debe inicializar si o si, al declarar la variable
           /*
           var playera = "David";
           System.Console.WriteLine(playera);

           /////////////////// //Conversiones explicitas
           //Conversion explicita o casting
           double temperatura = 34.5;
           //Para pasar esta variable a tipo entero, por ejemplo
           int temperaturaMexico;
           //Se haria de la siguiente forma
           //temperaturaMexico=temperatura;//Esto da un error porque el primero es int y el segundo duble
           //ESto se soluciona indicando el tipo a convertir
            temperaturaMexico = (int)temperatura;//Es decir, temperatura era de tipo double
            //le indicamos primera int, entonces eliminara la parte decimal o el .5 de 34.5
            //igualando asi que la temperaturaMexico = 34;
            System.Console.WriteLine(temperaturaMexico);//Resultado 34
            
           ////Ahora mostraremos ejemplos de conversion implicita
           //Conversiones implicitas, (sin necesidades de casting)
           int habitantesCiudad = 10000000;

           long habitantesCiudad2022 = habitantesCiudad;
           System.Console.WriteLine(habitantesCiudad2022);

           //Otro ejemplo
           float pesoMaterial = 10.57F;//Todos los valores de tipo float, cuando se indique el valor
           //debe terminar en una f mayuscula o minuscula
           double pesoMaterialPrec = pesoMaterial;
           System.Console.WriteLine(pesoMaterialPrec);
           //Debemos checar tambien las operaciones númericas implicitas permitidas
           //es decir, por ejemplo el pesoMango de 2 SE PUEDE pasar a un tipo double
           //es decir de int a double
           //sin embargo si lo hacemos inversamente, de double a int, esto causaria error
           //no se podria hace la conversion implicita, sino hacer un casting como el ejemplo anterior (conversion explicita)
           //para quitar los valores decimales posibles

           int pesoMango = 3;
           System.Console.WriteLine(pesoMango);

           double pesoTodosMangos = 5.5;
           pesoTodosMangos = pesoMango;
           //o
           double pesoTodosMangos2 = pesoMango;
           System.Console.WriteLine(pesoTodosMangos);

           System.Console.WriteLine(pesoTodosMangos2);
           //int pesoMitadMango1 = pesoTodosMangos;//Esto daria un error
           int pesoMitadMango2 = (int)pesoTodosMangos;//Como lo mencionamos, la solucion seria un casting
           System.Console.WriteLine(pesoMitadMango2);

           //Para explicar mejor esto decimos:
           //Se puede pasar de int a double (De manera implicita)
           //Ya que como tal el int entraria a un double quien admite valores enteros y decimales

           //Pero si quisieramos pasar de double a int, esto no se puede de manera implicita
           //es aqui donde se tendria que hacer un casting indicando tipo
           //ya que un double no entra en un int (quien no acepta decimales)
           int temp=5;
           double tempMex = 6.5;
           tempMex = temp;//COnversion implicita

           int tempMex1 = 6;
           double temp1=5.5;
           tempMex1=(int)temp1;//COnversion explicita */
                      //--------------------------------------------------Video 7 ---------------------Conversion de texto a numeros
           System.Console.WriteLine("Programa para sumar");
           System.Console.WriteLine("Introduce el primer número: ");
           Console.ReadLine();

        }      
    }
} 