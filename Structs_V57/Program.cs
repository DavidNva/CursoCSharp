using  System;

namespace Structs_V57{
   //Las clases se almacenan en la memoria Heap
   //Y las structs se almacenan en la memoria Stack
   //Los structs solo usaran la memoria Stack, incluso con objetos creados
   //En stack se almacenan los tipo primitivo
   //En heap se almacenan los objetos (para acceder a ellos desde la stack se hace una referencia (como con indice de un libro))
   //COn las clases, cuando creamos una variable de tipo primitivo (int, string,...)se usa stack
   //Pero como tal la clase se alamcena en heap, asi como las instacias que hagamos (los objetos) se iran a heap
   //por lo que cuando usemos un objeto (este estara en stack) hara una referencia a heap de la clase istanciada
    
   //Al crear una aplicacion, existen dos tipos de memoria:
   /*
     *El heap permite almacenar variables adquiridas dinámicamente (via funciones
      como malloc o calloc) durante la ejecución de un programa.
      Es el desordenado
      Es una memoria dinamica
      No hay reglas para  + o - (Para agregar o eliminar)
      No es ordenado como el estack
      *Es de acceso un poca mas lenta
      *La ventaja es qye la informacion que almacenamos en el Heap suele estar disponible en toda la ejecucion del programa, a diferencia del stack que 
      su almacenamiento es temporal
      *Su traduccion seria monton
      OutOfMemoryException (Si no controlamos el heap, podremos tener esta excepcion)
     -----------------------------------------------------------
     *El stack permite almacenar argumentos y variables locales durante la ejecución de
      las funciones en las que están definidas.
      *IMPORTANTE
      *Es de acceso rapido
      Ademas lo que almacenamos en el stack es temporal, por ejemplo: variables que declaramos dentro de un metodo
      El stack es el ordenado:
      El stack almacena
      *Structs
      *Guarda variables de tipo primitivo
      *Y las referencias (tambien denominados punteros)a objetos (que se encuentran en heap)
      *El stack significa pila, es una estructura lifo, El ultimo en entrar es el primero en salir
      es como si apilaramos platos, el ultimo en apilar, es el primero que ocuparemos
      *Estructura LIFO
      *Last In, First Out
      *StackOverFlow  (Si no controlamos esta pila, o esta memoria, podria dar este error)

   */ 

   //Memoria 
    class Program{
        static void Main(string[] args)
        {
            Empleado empleado1 = new Empleado(1200,250);
            empleado1.cambiaSalario(empleado1,100);
            Console.WriteLine(empleado1);//Trabajando con clases se puede ver reflejado el cambio de salario
            //Porque la referencia al objeto hace una modificacion en dicho objeto
            //*SIN ENCAMBIO SI USAMOS UN STRUCT, este cambio no se vera reflejado
            //porque como lo dicho anteriormente, las structs usan stack
            //y los objetos tienen una copia de ese struct, por lo que independientemente de lo que se haga con la instancia
            //*el struct (plantilla) original digamos (el objeto original) se mantiene intacto
            //*por lo que nos seguira arrojando los valores de 1200, y 250

            //Otro ejemplo, pero esta vez demostrando la parte de heap, cuando se hace referencia con dos puntes hacia un mismo objeto
            Console.WriteLine($"------------------------------------");
            
            Console.WriteLine($"Segundo ejemplo: Punteros con su propio objeto ");
            
           
            //*Cuando indicamos: El tipo de instancia y el identificador: en este caso, Empleado2 empleado2 = 
            //Estamos indicando o creando el apuntador o referencia que se almacena en stack
            //apuntando a la posicion donde se encuentra ese objeto empleado en heap
            //*Y En la instancia del objeto cuando indicamos new, es cuando estamos reservando el espacio en la memoria, en heap
            Empleado2 empleado2 = new Empleado2(1500,100);

            Console.WriteLine(empleado2);
            
            Empleado2 empleado3 = new Empleado2(2000,200);//Hasta este punto los dos objetos son diferentes
            //bueno, tienen cada quien un puntero hacia un objeto diferente en heap

            Console.WriteLine(empleado3);//Lo comprobamos imprimiendo los valores a cada uno

            //Pero si ahora los igualamos
            empleado2 = empleado3;//Los valores del empleado2 (1200,100) ahora pasaran a ser igual a: los del empleado3 (2000,200)
            //hacemos modificacion en alguno de los dos, vmaos a ver que los dos se veran afectados
            //porque ahora son dos referencias o punteros apuntando al mismo objeto en heap (es decir, los dos objetos que estaban en heap, ahora es uno)
            //Por ejemplo, hagamos una modificacion en empleado2, con un aumento de salario de 500
            empleado2.cambiaSalario(empleado2,500);
            //Ahora imprimamos
            Console.WriteLine($"Comprobación de puntero a un mismo objeto de heap");
            Console.WriteLine(empleado2);//Ahora los dos objetos tendran salario y comision igual a (2500, 700)
            Console.WriteLine(empleado3);//Y se supone que no hemos tocado a empleado 3, pero como lo dicho, estan apuntando al mismo objeto
            //por lo que cualquier cambia de una instancia perjudica a la otra
            //y como en este caso, estamos diciendo que empleado2 = empleado3, significa, que toma los valores de empleado 3
            //por lo que al modificar el salario usa esos valores (en lugar de en teoria usar el (1200,100) de empleado 2) y le incremente los 500
            //para imprimier en consola los valores de (2500, 700)
            
            
            
            
        }
    }
    public struct Empleado{
        public double salarioBase, comision;

        public Empleado(int salarioBase, int comision){//En el constructor iniciamos los dos campos anteriores
            this.salarioBase = salarioBase;
            this.comision = comision;
        }
      /*
      public Empleado(double N,Double s){
           this.salarioBase=N;
           this.comision = s;
      }*/
      //COmo lo comentado al final de estas  lineas de codigo, no puede haber sobrecarga de constructores y no existe un constructor por defecto (a menos que no usemos variables en el struct, lo cual no seria muy util)
      //el constructor debemos declararlo nosotros
      //Esto porque sitenemos variables, el compilador no las inicializa, las podemos inicializar en el constructor
      //que por cada variable creada, se debe usar e iniciailizar en el contructor que creemos, o dara error
      //ademas de que no se permite la sobrecarga de constructores (al usar obvimente las variables, no tienen sentido un consructor nuevo que realice lo mismo, ya que de otra forma, no habria sobrecarga)





        public override string ToString()//Sobreescribirmos el meodo ToString (Heredado de la clase Object)
        {//para que nos indique el siguiente mensaje
            return string.Format("Salario y comisión del empleado ({0},{1})",this.salarioBase,this.comision);
        }
        public void cambiaSalario(Empleado emp, double incremento){
            emp.salarioBase += incremento;//Lo que tenga en salario base el objeto, se le suma el incremento
            emp.comision += incremento;//Trabajando con clases esto si podra visualizarse
        }
    }
     public class Empleado2{
        public double salarioBase2, comision2;

        public Empleado2(int salarioBase, int comision){//En el constructor iniciamos los dos campos anteriores
            this.salarioBase2 = salarioBase;
            this.comision2 = comision;
        }
        public override string ToString()//Sobreescribirmos el meodo ToString (Heredado de la clase Object)
        {//para que nos indique el siguiente mensaje
            return string.Format("Salario y comisión del empleado ({0},{1})",this.salarioBase2,this.comision2);
        }
        public void cambiaSalario(Empleado2 emp2, double incremento2){
            emp2.salarioBase2 += incremento2;//Lo que tenga en salario base el objeto, se le suma el incremento
            emp2.comision2 += incremento2;//Trabajando con clases esto si podra visualizarse
        }
    }
    /*
      ------------------ Diferencias de structs con clases -----------------
      -- Struct
      *No permite la declaracion de constructor por defecto
      *El compilador no inicia los campos. Puedes iniciarlos en el constructor.
      *No puede haber sobrecarga de constructores
      *No heredan de otras clases pero si implementan interfaces
      *Son selladas (sealed)
    */
    /*
      --------------------- Cuándo usar struct -------------------------
      *Cuando necesitas trabajar con una cantidad elevada de datos en memoria (representacion
      de primitivos, numeros complejos, puntos tridimenionales, etc).
      *Cuando las intancias no deban cambiar (inmutables)
      *Cuando la instancia tenga tamaño inferior a 16 bytes.
      *Cuando no necesites convertir a objeto (boxed)
      *Por razone de rendimiento
    */
}
