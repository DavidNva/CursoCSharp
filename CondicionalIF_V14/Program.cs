using System;
namespace CondicionalIF_V14{
    class Program{
        //Se ocupan los operadores de comparacion
        /*
          Igual que          ==
          Diferente que      !=
          Menor que           <
          Menor o igual que  <=
          Mayor que           >
          Mayor o igual que  >=
        */

        //Operadores lógicos
        /*

          Y lógico          &&
          O lógico          ||

        */
        //
        
        
        static void Main(string[] args){
            //Console.WriteLine($"Hola");
            //El operador !, es de negacion
            //Es decir invierte el valor de la expresion o variable booleana
            //En el ejemplo, en lugar de false sería true
            //bool haceFrio = true;
            //haceFrio;
            //Console.WriteLine(!haceFrio);
            /*
            int edad  = 25;
            Console.WriteLine($"Vamos a evaluar si eres mayor de edad ");
            if(edad >=18){
                System.Console.WriteLine("Adelante puedes pasar poque eres mayor de edad");
            }
            */
            /*
            int edad;
            Console.WriteLine($"Vamos a evaluar tu edad");
            Console.Write($"Introduce tu edad: ");
            
            edad = int.Parse(Console.ReadLine());
            if(edad >=18)//{//Las llaves se pueden omitir cuando el condicional solo tiene una linea de codigo
                System.Console.WriteLine("Adelante puedes pasar poque eres mayor de edad");
          //  }//Entonces si no utilizamos las llaves el compilador asume que la condicional
          //solo tiene una lina de codigo, aun si existieran mas, no las tomaria en cuenta
          //como parte de if condicional
            else 
            Console.WriteLine($"Lo sentimos, no puedes pasar porque eres menor de edad");
            //
            */
            //--------------------Video 15 -------------------------
            Console.WriteLine($"Vamos a evaluar si puedes conducir un vehiculo");
            
            bool carnet = false;
            if(carnet)//si el valor boolean es true para la condicional, entonces
            //no se necesita especificar el == true, ya que el if asi lo entendera
            //siendo una forma mas estetica para el mismo
            Console.WriteLine($"Puedes conducir vehiculos");

            else
            Console.WriteLine("¡Lo siento!, no puedes conducir vehiculos.");
            //Se recomienda o es muy comun observar que si la condicional solo tiene
            //una linea de codigo, y la especificamos sin llaves 
            //pues entonces todo se resumen en una sola linea de codigo, es decir
            //sin el salto de linea desde el if y su condicional
            
            Console.WriteLine($"Aquí termina el primer programa");//Esta linea de codigo no pertenece
            //ni al if, ni al else, simplemente es la continuacion del flujo de ejecucion
            //del programa, y se imprimira sin importar si la condicional entra en el if o en el else
            
            //----------------------Segundo ejemplo similar, con mas variables o condicionales
            int edad;
            string carnetPersona = "";
            Console.WriteLine($"-----------------------------------------------------------");
            Console.WriteLine($"Segundo ejemplo similar con mas variables y condicionales");
            Console.Write($"Introduce tu edad: ");
            edad = Int32.Parse(Console.ReadLine());

            if(edad >=18){//en este caso si es mayor de edad, le pregunta si tiene carnet
                Console.WriteLine($"¡Muy bien!, Ahora indica:");
                Console.WriteLine($" s si tu respuesta es si ");
                Console.WriteLine($" n si tu respuesta es no");
                Console.Write($"¿Tienes carnet?: ");
                carnetPersona = Console.ReadLine();
                Console.WriteLine($"---------------");
                //dependiendo si su respuesta es si o no, dejara conducir el vehiculo
                if(carnetPersona == "S" || carnetPersona == "s")//usando el o logico
                    Console.WriteLine($"Adelante, usted puede conducir un vehiculo");
                    
                else Console.WriteLine($"Lo sentimos, no puede conducir un vehiculo");//si la respuesta
                //es no, entonces mostrara el mismo mensaje que le hubiera dado a un menor de edad
                //es decir, no puede conducir vehiculos porque aun siendo mayor de edad
                //no tiene carnet
               // int variablePrueba = 7;
                

            }
            else  Console.WriteLine($"Lo sentimos, no puede conducir un vehiculo");
            // variablePrueba = 9;
            //Como vemos no podemos usar esta variable, porque solo le pertenece al condicional if
            //al no ser variable del metoodo, no podemos hacer uso de ella

            Console.WriteLine($"Aqui termina el segundo programa");
            Console.Write($"El carnet de la persona es ");
            Console.WriteLine(carnetPersona);
            //Dependiendo, si es menor de edad
            //el carnet de la persona no existe, por lo que no muestra nada
            //pero si es mayor de edad, depende si su respues es n = no, o s = si, 
            //eso imprimira la linea de codigo anterior, observando asi como el valor de la variable cambió
            

            /*
               Esto pasa porque la variable carnetPersona se vuelve global, siendo una variable de todo el meotod
               es decir que pertenece al metodo Main
               Por eso respecto al flujo de ejecucion, el valor va cambiando, sin embargo, si 
               la variable carnetPersona la indicaramos e inicializaramos dentro de un condicional
               sucede como con los metodos, sobre el ambito de las variables, ya que como tal, la variable
               pertenecera a esa condicional y cuando salga de alli, la variable como si no existiera
            */

            //-------------------Tercer ejemplo con if anidados, simplificando y mejorando el segundo
            //con metodos de comparacion
            Console.WriteLine($"-----------------------------------------------------------");
            Console.WriteLine($"Tercer ejemplo similar con if anidados y mejorando el segundo con metodos de comparacion");
            Console.Write($"Introduce tu edad: ");
            edad = Int32.Parse(Console.ReadLine());

            if(edad >=18){//en este caso si es mayor de edad, le pregunta si tiene carnet
                Console.WriteLine($"¡Muy bien!, Ahora indica Si/No:");
                Console.Write($"¿Tienes carnet?: ");
                carnetPersona = Console.ReadLine();
                Console.WriteLine($"---------------");
                int compara = String.Compare(carnetPersona,"si",true);
                //En este caso se usa el metodo compare de la clase String
                //deonde estamos ocupando 3 paraametros, el primero de la variable a evaluar, el segundo el valor a comparar
                //en este caso la respuesta de si es "si", y el tercero para no diferenciar si el usuario ingresa si
                //en mayusculas o minusculas
                //dependiendo si su respuesta es si o no, dejara conducir el vehiculo
                if(compara == 0)//Si es 0, significa que la comparacion es correcta, entonces puede pasar
                    Console.WriteLine($"Adelante, usted puede conducir un vehiculo");
                    
                else Console.WriteLine($"Lo sentimos, no puede conducir un vehiculo");//si la respuestas
                //es no, entonces mostrara el mismo mensaje que le hubiera dado a un menor de edad
                //es decir, no puede conducir vehiculos porque aun siendo mayor de edad
                //no tiene carnet
               // int variablePrueba = 7;

            }
            else  Console.WriteLine($"Lo sentimos, no puede conducir un vehiculo");

            Console.WriteLine($"Aqui termina el tercer programa");
            Console.Write($"El carnet de la persona es ");//Dependiendo de si entro a la condicional if 
            //el valor del carnet cambiara 
            Console.WriteLine(carnetPersona);


            //Cuarto programa del promedio de un alumno
            Console.WriteLine($"-----------------------------------------------------");
            Console.WriteLine($"Cuarto programa del promedio de un alumno");

            Console.WriteLine($"Introduce el primer parcial");

            double parcial1 = int.Parse(Console.ReadLine());

            Console.WriteLine($"Introduce el primer parcial");
            double parcial2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"Introduce el primer parcial");
            double parcial3 = int.Parse(Console.ReadLine());
            //En este programa se exige que los parciales deben estar aprobados si o si
            //para realizar la media
            if(parcial1 >=70 && parcial2 >=70 && parcial3 >=70 )
                Console.WriteLine($"La nota media es: " + (parcial1+parcial2+parcial3)/3);
            else 
                Console.WriteLine($"Vuelve en agosto");
                
            

            Console.WriteLine($"Aqui termina el cuarto programa");
            
             //Quinto programa, practica con el condicional else if
            Console.WriteLine($"-----------------------------------------------------");
            Console.WriteLine($"Quinto programa");
            Console.Write($"Introduce tu edad : ");
            int edadP =int.Parse(Console.ReadLine());
            if(edadP<18)Console.WriteLine($"Eres un niño");

            else if(edadP<30)Console.WriteLine($"Eres un joven");

            else if(edadP<60)Console.WriteLine($"Eres mayor");

            else Console.WriteLine($"Debes cuidarte ya");
            
            Console.WriteLine($"Aqui termina el quinto programa");
            
            //Los else if sirven para tener un seria de opciones dependiendo de lo que el usuario realice
            //es decir, que si entra en el if, o en algun else if, lo ejecutara pero ingnorara a los demas que siguen
            //evitando redundancia en las condiciones o validaciones
            //seri un tipo de if con el uso del operador logico &&, pero de manera simplificada
            //escribiendo else if
            
            //Todo lo que se puede hacer con un switch en C# lo podemos hacer con un if
            //Pero no viceversa, es decir, no todo lo que podemos hacer con un if
            //se puede hacer con un switch
            


        
            

            

            
            
        }
        
    }
}