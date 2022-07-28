using System;

namespace DelegadosPredicados_V68{
    
    class Program{
        
        static void Main(string[] args)
        {
            //Practica con predicamos
            //LOs predicados son clases genericas
            //LOs predicados son delegados de tipo bool (en teoria jaja)
            //ya que solo llaman a metodos de este tipo
            //Por ejemplo, creemos un metodo que nos diga si los numeros pares de una lista
            //Bueno cuando creemos el predica, al inicializarlo en los parametros indicaremos ese metodo a apuntar

            //Para usar el predicado creado por ejemplo, podemos usar un metodo de las colecciones list
            //FindALL, quien nos pide por parametro un predicado
            //El predicado como tal, esta apuntando a una respueta de un si o no (con el metodo bool)
            //y esa es su utilidad, en este caso para el metodo FindAll, dependiendo si se cumple la condicion true o false del metodo, pues devuvelve o no los valores
            //A diferencia de los predicados normales que no se pueden crear dentro del metodo
            //los predicate si


            //Funcion de numeros primos, solo con ejemplo del metodo normal, con tipo void
            //DamePrimos(15);
            
            //Ejemplo, con metodos que nos muestra los pares
            List<int> numeros = new List<int>();
            numeros.AddRange(new int[]{1,2,3,4,5,6,7,8,9,10});
  
            Predicate<int> elDelegadoPred = new Predicate<int>(DamePares);
           
           //AHora que ya tenemos el predicado, usaremos el metodo FindAll de List
           //Como ese metodo devuelve una lista, entonces usaremos una variable (un coleccion en realidad) de tipo lista para guardar esos valores
           List <int> numerosPares = numeros.FindAll(elDelegadoPred);
           //ahora solo leemos esa lista de numeros obtenida
           
           foreach (var item in numerosPares){
                  Console.WriteLine(item);
           }

           //eJEMPLO DOS DE PREDICADOS, PERO AHORA CON UN METODO BOOL QUE TENGA PARAMETROS STRING, ADEMMAS QUE LA COLECCION
           //EN LA QUE VAMOS A EVALUAR LOS VALORES SEAN STRING IGUALMENTE
           //Con una clase creada por nosotros
           //EN ESTE CASO al crrear el delegado predicado 
           
        }

        //Creamos el metodo tipo bool para el predicado

        public static bool DamePares(int num){
            if (num % 2 == 0) return true;
            else return false;
        }
        //Ejemplos con un metodo que solo devuelve numeros primos
        //Los numeros primos son los que solo pueden ser dividos entre si mismos, y entre uno
        //obviamente hablando solo de enteros
        //Por ejemplo 2,3,5,7,11
        public static bool DamePrimosBool(int numParametro){//
            int numDivisible = 0;//Numero de veces que se puede dividir ese numero
            int num = 2;//Inicio de primo y numero limite de divisores
            bool esPrimo = false;
            while( num <= numParametro){//Para recorrer cada numero desde el 2 (porque desde el 2 seria el primer numero primo)
                //Por cada numero iniciando en el 2, pasa por el for
                //Ese num va ir creciendo, incrementandose hasta que sea menor o igual al numero que demos por parametro
                //For para saber el numero de divisores
                for(int i = 1; i <= num; i ++){//Este for solo llega al 2, porque num = 2;
                //Este for no sobrepasa de 2 repeticiones con cada numero
                //porque cuando i vale 3, lo que significa que ya hayy tres divisibles, pues se sale del for
                //

                    if(num % i == 0) numDivisible++;
                    //if(numDivisible > 2) break;   
                }
                
                if(numDivisible == 2){//SI el numero solo tiene dos divisibles (que seria el 1 y el mismo)
                    Console.WriteLine("{0}: Es primo", num);//pues entonces si es primo
                    esPrimo = true;
                } else esPrimo = false;
            
                numDivisible = 0;//Para iniciar los divisiones de otro numero, regresamos a 0 esta variable
                num++;//y pasamos verificar otro numero
            } 
            return true; //Lo intente, no pude, jaja
        }
        //Segundo memtodo pero normal, siendo un void, y llamandolo directamente con la clase
        public static void DamePrimos(int numParametro){//
            int numDivisible = 0;//Numero de veces que se puede dividir ese numero
            int num = 2;//Inicio de primo y numero limite de divisores
            
            while( num <= numParametro){//Para recorrer cada numero desde el 2 (porque desde el 2 seria el primer numero primo)
                //Por cada numero iniciando en el 2, pasa por el for
                //Ese num va ir creciendo, incrementandose hasta que sea menor o igual al numero que demos por parametro
                //For para saber el numero de divisores
                for(int i = 1; i <= num; i ++){//Este for solo llega al 2, porque num = 2;
                //Este for no sobrepasa de 2 repeticiones con cada numero
                //porque cuando i vale 3, lo que significa que ya hayy tres divisibles, pues se sale del for
                //

                    if(num % i == 0) numDivisible++;
                    //if(numDivisible > 2) break;   
                }
                
                if(numDivisible == 2){//SI el numero solo tiene dos divisibles (que seria el 1 y el mismo)
                    Console.WriteLine("{0}: Es primo", num);//pues entonces si es primo
                } 
            
                numDivisible = 0;//Para iniciar los divisiones de otro numero, regresamos a 0 esta variable
                num++;//y pasamos verificar otro numero
            } 
        }
    }

    class Persona{
        private string nombre;
        private int edad;
        //Creamos dos propieades con estas dos variables: GETTERS Y SETTERS
        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }

    }
}