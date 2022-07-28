using System;
namespace ExpresionesLamda_V69{
//Sinstaxis de expresiones lamda
//Es como si crearamos una funcion (un metodo) pero de una forma mas simplificado
//Es decir, la sintaxis:
//Parametros => expresion/bloque de sentencia
//Viendolo asi seria como tener un metodo que tiene parametros y los bloques de sentencia, a lo que estaria dentro del metodo
//Es decir, el  bloque de sentencia es lo que hace el metodo, en este caso la expresion

    class Program{
        static void Main(string[] args)
        {                                            //Esta seria la sintaxis de la expresion lamda
            OperacionesMatematicas operacionCuadrado = new OperacionesMatematicas(num => num * num);

            Console.WriteLine(operacionCuadrado(5));

            OperacionesMatematicas2 operacionSuma = new OperacionesMatematicas2((num1,num2) => num1+ num2);
            Console.WriteLine(operacionSuma(3,5));


            //Pongamos el ejemplo del proyecto anterior sobre imprimir numeros pares de una lista
            List<int> numeros = new List<int>(new int[]{1,2,3,4,5,6,7,8,9,10});
            List<int> numerosPares = numeros.FindAll(i => i % 2 == 0);//Es como si dijeramos:
            //Con lamda nos ahorramos estar llamando a un metodo, crear mas variables, etc. Por eso es muy util para reducir codigo
            //Tdoo el proyecto anterior sobre hacer unp predicado, y llamar a un metodo, luego colocarlo como parametro de la lista, etc. se redujo a esto
            Console.WriteLine($"Usando condicion dentro del mismo metodo usando lamda");
            Console.WriteLine($"Con foreach");
            
            foreach(int num in numerosPares)Console.WriteLine($"Numero par: " + num);
            Console.WriteLine($"----------------------------------------------------------------------");
            //Otra forma de escribir con foreach
            Console.WriteLine($"Otra forma de escribir con foreach, uando le metodo de la propia lista");
            numerosPares.ForEach(numeros => {//Siempre que a la derecha de una expresion lambda haya mas de una linea de codigo, debe entrar en llaves
                Console.Write($"Numeros pares: ");
                Console.WriteLine(numeros);
                });

            Console.WriteLine($"\n----------------------------------------------------------------------");
            Console.WriteLine($"Condicion con for");

            for (int i = 1; i<numeros.Count;i++){
                if(i % 2 == 0) Console.WriteLine(i);                 
            }
            //y todo se reduce en una expresion lambda
            //------------------------------------------------------------------------------------------------------------------------

            Console.WriteLine($"\n----------------------------------------------------------------------");
            Console.WriteLine($"EJemplos con lambda, con la clase persona");
            Console.WriteLine($"Compara edades:");
            
            Personas P1 = new Personas();
            P1.Nombre = "David";
            P1.Edad = 20;

            Personas P2 = new Personas();
            P2.Nombre = "Iveth";
            P2.Edad = 20;
            //INstanciamos el objeto de tipo delegado con su identificador
            ComparaPersonas comparaEdad = new ComparaPersonas((edadPersona1,edadPersona2) => edadPersona1 == edadPersona2);
            Console.WriteLine(comparaEdad(P1.Edad,P2.Edad));//Como las dos personas tienen mismas edades, devuelve true

            Console.WriteLine($"Compara nombres:");
            
            ComparaPersonas2 comparaNombre = new ComparaPersonas2((nomPersona1,nomPersona2)=> nomPersona1 ==nomPersona2);
            Console.WriteLine(comparaNombre(P1.Nombre,P2.Nombre));//Ahora devolvera false, porque los nombres no son los mismos
            
            
            



            
            
            
        }
        public delegate bool ComparaPersonas(int edad1, int edad2);//Delgado para que apuntara a un metodo que compara peronas, con dos parametros 
        
        public delegate bool ComparaPersonas2 (string n1, string n2);//Para el segundo ejemplo, compara nombres
        //En los delegados no se permite la sobrecarga 
        delegate int OperacionesMatematicas(int numero);
        delegate int OperacionesMatematicas2(int numero1, int numero2);
        /*public static int Cuadrado(int num){//ESto es reducido en la expresion lamba
            return num*num;
        }*/
        // num => num * num;

        //POngamos otro ejemplo, ahora con dos parametros
        /*public static int Suma (int num1,int num2) { //ESTO IGUAL se reduce con la expresion lambda (dentro de la iniciacion de la instancia delegadpo)
            return num1 + num2;
        }*/ 
    }
    class Personas{
        private string nombre;
        private int edad;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }
    }
}