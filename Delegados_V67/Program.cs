using System;

namespace Delegados_V67{
    class Program{
        //Un de legado es una referencia (o puntero) a un método
        //Son funciones que delegan tareas en otras funciones
        //Para que sirven los delegados
        /*
          Muy utilizados en C# para llamar a eventos.
          Se reduce significativamente el codigo al manejar diferentes escenarios
          Codigo muy reutilizable
        */

        //El delegado esta obligado a tener el mismo tipo al que apunta

        /*
          Sintaxis: 
          delegate tipo NombreDelegado(argumentos);
          Los delegados podran llamar solo a métodos con misma estructura

          ES DECIR, mismo tipo (sea void, o un tipo primitivo) y mismo numero de parametros(argumentos), ademas de 
          que los arguementos (si los tiene) deben ser del mismo tipo

        */
        //------------------------------------------------------------
        delegate void ObjetoDelegado();//En este caso podemos hacer referencia a los metodos mensaje
        //de las otras dos clases, porque el dalegado que estamos declarando tiene la misma estructura que estos 
        //seria como crear un metodo de tipo delegado
      //------------------------Delegado para segundo ejemplo -------------------------------------------------
        delegate void ObjetoDelegado2(string msj);//AHORA como se debe apuntar a metodos
            //con parametros (en este caso de tipo string), pues el delegado tambien debe ser de tipo string

        static void Main(string[] args){
            Console.WriteLine("Delegados");
            //Creacion del objeto delegado apuntando al metodo de la clase MensajeBienvenida
            ObjetoDelegado ElDelegado = new ObjetoDelegado(MensajeBienvenida.SaludoBienvenida);
            //En la linea anterior es como si instanciaramos un objeto con el delegado qu creamos
            //Es como si instanciraramos un tipo metodo, porque el identificador: ObjetoDelegado es un metodo de tipo delegado
            //Es confuso, pero asi estaria funcionando
            //Primero creamos el delegado, indicando el tipo y es como si declararamos un metodo (solo que su tipo es delegado, jaja)
            //Luego usamos ese identificador que creamos (en este caso lo llamamos ObjetoDelegado)
            //Lo usamos como si fuera una clase a la cual podemos instanciar
            //Entonces ahora instanciamos con ese delegado creado, como si crearamos un objeto normal
            //Y como parametros debemos pasar el metodo al que apunta o hace referencia, en este caso al saludoBienvenida de la clase MensajeBienvenida
            //Y listo, es la forma de usar el delegado, si nos damos cuenta el delegado tienen un tipo el cual coincide con el metodo al que referencia
            //ademas de coincidir con el numero de paramtros y tipo (en este caso no tiene), pero como tal esas son las reglas

            //Ahora simplementa utilizamos el delegado para llamar al metodo que indicamos en los argumentos o parametros: saludoBienvenida

            ElDelegado();//Lo llamamos como si fuera un metod (que es eso, jaja), con los parentesis y punto y coma
            //Esto hara referencia al metodo de la clase mencionada e imprimira o hara las intrucciones del metodo apuntado, en este caso imprimira el saludo de bienvenidda

            Console.WriteLine($"-----------------------------------------------");
            //Podemos a partir del identificado de instancia que tenemos de delegado
            //igualarlo a una nueva referencia o puntero
            //de esta forma, ahora apunta a otro metodo para realizar otras tareas
            ElDelegado = new ObjetoDelegado(MensajeDespedida.SaludoDespedida);

            ElDelegado();//imprime el salido despedida 

            Console.WriteLine();
            Console.WriteLine($"-----------------------------------------------");
            Console.WriteLine($"Segundo ejemplo, con delegados con parametros (argumentos) apuntando a metodos que de igual forma tienen parametros");
            Console.WriteLine();
            
            ObjetoDelegado2 ElDelegado2 = new ObjetoDelegado2(MensajeBienvenida.SaludoBienvenida2);//Para que no de error en los parametros o argumentos
            //que indicamos para referenciar a un metodo, el delegado debe tener la misma estructura, como los metodos referenciados tiene  un parametro
            //pues el delegado asi debe ser
            ElDelegado2("Hola David, ¡como estas!");//Por eso cuando utilizmaos el delegado (como si utilizaramos un metodo)
            //como lleva parametros, debemos especificar esos parametros, o si no igual daria error
            //
             Console.WriteLine($"-----------------------------------------------");
            ElDelegado2 = new ObjetoDelegado2(MensajeDespedida.SaludoDespedida2);

            ElDelegado2("Adios David, ¡Un gusto verte!");//imprime el salido despedida 
            
            //EN conclusion del proceso decimos
            /*
              *Primero: creamos el metodo delegado (de tipo delegado) asegurandonos que sea de igual estructura a los metodos que va a referenciar (que va a delegar o apuntar)
              *Segundo: instanciamos ese delegado que hemos creado, (ese identificador lo tomaremos como una clase a instanciar)
              *Tercera: En esa misma instancia que estas inicializando, en los argumentos (parametros) indicamos el metodo a apuntar, o referenciar
              *Cuarto: Usamos esa instancia, pero no como un objeto, sino como un metodo normal (Si, es como si estuvieramos usando un metodo normal de alguna clase)
               Es decir, lo de instanciar el delegado solo sirve para hacer la referencia (apuntar a cierto metodo), solo eso. EN realidad como tal no funciona como un objeto 

            */
        }
       
    }

    class MensajeBienvenida{
        public static void SaludoBienvenida(){
            Console.WriteLine($"Hola, acabo de llegar. ¡Que tal!");
            
        }
        public static void SaludoBienvenida2(string mensaje){
            Console.WriteLine($"Mensaje: {mensaje}");//para el segundo ejemplo
            //Si quisieramos referenciar a este metodo mediante el primer delegado que creamos daria error, porque
            //no estariamos respetando la regla de la misma estructura con el delegado y la estructura del metodo apuntado
            //por eso solo funciona para el segundo delegado quue creamos, porque tambien lleva por parametros un string
        }
    }

    class MensajeDespedida{
        public static void SaludoDespedida(){
            Console.WriteLine($"Hola, ya me marcho. ¡Hasta luego!");
            
        }
        public static void SaludoDespedida2(string mensaje){//Para el segundo ejemplo
            Console.WriteLine($"Mensaje: {mensaje}");
            
        }
    }
}