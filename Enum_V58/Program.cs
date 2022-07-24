using System.Net.Http.Headers;
using System;

namespace Enum_V58{
    //Enum (Tipos enumerados)
    //Son un conjunto de constantes con nombre

    //Su sintaxis es: enum NombreEnumeracion{nombre1, nombre2, nombre3, ...};
    //Es como si fuera un array de constantes (no es un array, jaja)
    //Sirven para representar y manejar valores fijos (constantes) en un programa
    //Los enum se suelen crear para que lo utilicen diferentes clases y no solo una

    //Por eso se crean regularmente en el namespace, para que su ambito se accesible para todas las clses del mismo
    enum Estaciones{Primavera, Verano, Otoño, Invierno};//No son valores de tipo strings
    
    //Cuando creamos estas constantes, se les asigana por defecto un valor, desde 0, 1, 2, sucesivamente
    enum Bonus{Bajo = 500, Normal =1000, Bueno = 1500, Extra = 3000};//Pero tambien podemos darles valores como este enum

    class Program{
        static void Main(string[] args){
            Console.WriteLine($"hola");
            Estaciones frio = Estaciones.Invierno;//COmo vemos en el menu, solo nos muestra cuantro opciones, y son la unicas que podemos elegir
            //Es la ventaja de los enum, ya que al trabajar en equipo estamos indicando que solo podemos usar  esas opciones
            Console.WriteLine(frio);
            //NO condundamos, frio no es de tipo string, es de tipo Estaciones, es una constante enum
            //es como si instanciaramos una clase
            //Para comprobarlo por ejemplo
            string el_frio;
            //el_frio = frio;//ESto da error
            el_frio = frio.ToString();//La forma de cambiarlo a string seria esta
            Console.WriteLine(el_frio);

            //Si se necesita trabajar con un enum null, la sintaxis es la siguiente
            Estaciones? calor = null;//Usamos el signo de interrogacion hacia abajo, e indicamos null
            Console.WriteLine(calor);

            Console.WriteLine($"---------------------------------------------");
            Console.WriteLine($"Segundo ejemplo enum: Bonus empleado");
            Console.WriteLine();
            
            Bonus David = Bonus.Normal;

            Console.WriteLine( "Tipo de Bonus: " + David);//Esto solo imprimira el tipo de bonus (Normal)
            //Si queremos trabajar con el valor de normal (1000), tenemos que hacer un casting a un tipo numero o decimal

            double bonusDavid = (double) David;//Ahora si se toma el valor 1000. Que es el bonus que tiene ahora David

            Console.WriteLine("Valor de Bonus: " + bonusDavid); //Imprime el valor numerico
            //Ademas ya podemos operar con este valor

            double salarioDavid = 1500 + bonusDavid;

            Console.WriteLine("El salario total del empleado es: " + salarioDavid);//El salario total es 2500;
            
            System.Console.WriteLine();
            Console.WriteLine($"Tercer ejemplo: Ahora con una clase Empleado, y el tipo enum irá como parametro");

            Empleado Teresa = new Empleado(Bonus.Normal,3500.50);
            Console.WriteLine("El salario del empleado es: " + Teresa.GetSalario());
            
      
            
            

            
            
            
            
            
            
        }
        class Empleado{
            double bonus, salario;
            public Empleado(Bonus bonusEmpleado, double salario ){
                this.bonus = (double) bonusEmpleado;//Como en el ejemplo anterior, para acceder al valor del tipo enum, tenemos que hacer un casting
                this.salario = salario;
            }

            public double GetSalario(){
                return salario + bonus;//Otra forma seria declarar la variable bonus como tipo enum: Bonus
                //Y en el retrn hace el casting:
                //return salario + (double)bonus;//En caso de que bonus fuera de dicho tipo, es el mismo casting que ahora se hace en el constructor
            }
        }
    }
}