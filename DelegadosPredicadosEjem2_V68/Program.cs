using System;

namespace DelegadosPredicadosEjem2_V68{
    
    class Program{
        
        static void Main(string[] args)
        {
            
            //Ahora en este ejemplo trabajaremos con una coleccion pero de tipo Persona
            List<Persona> gente = new List<Persona>();//SERA la coleccion para las personas

            //Empezamos a instancair objetos de tipo persona, para colocar un nombre y edad a cada objeto
            Persona P1 = new Persona();//
            P1.Nombre = "David";//Tambien estos valores los podiamos pedir por parametro si asi lo quiisieramos, para ahorra codigo
            P1.Edad = 20;//Estamos accediendo con las propiedades creadas

            Persona P2 = new Persona();
            P2.Nombre = "Teresa";
            P2.Edad = 43;

            Persona P3 = new Persona();
            P3.Nombre = "Iveth";
            P3.Edad = 17;//por ejemplo, ahora ya no tomara en cuenta para el segundo metodo al evaluar la mayoria de edad

            gente.AddRange(new Persona[]{P1,P2,P3} ); //Ya tenemos dentro de gente a tres personas con nombre y edad
            //Listo, ya tenemos 3 personas creadas, ahora crearemos el delegado predicado
            //Por lo que el predicado tambien debe ser de tipo personas
            Predicate<Persona> elDelegadoPred = new Predicate<Persona>(ExistePersona);
           
            //AHora que ya tenemos el predicado, usaremos el metodo FindAll de List
            //Como ese metodo devuelve una lista, entonces usaremos una variable (un coleccion en realidad) de tipo lista para guardar esos valores
            List <Persona> personaEncontrada = gente.FindAll(elDelegadoPred);
            //ahora solo leemos esa lista de numeros obtenida
           
           foreach (Persona i in personaEncontrada){
                  Console.WriteLine(i.Nombre);
           }
           
           //Otro metodo para ver si el metodo al que esta apuntando el metodo es true o false;
           //en este caso verifica si hay personna o no
           bool existe = gente.Exists(elDelegadoPred);
           if(existe) Console.WriteLine($"Persona encontrada");
           else Console.WriteLine($"Persona no encontrada");
           Console.WriteLine();
           Console.WriteLine($"--------------------------------------------------");
           Console.WriteLine();
           
           
           //Segundo ejemplo de predicado ahora evaluando la edad de las personas
           Predicate<Persona> elDelegadoPredicado2 = new Predicate<Persona>(ExisteMayoresEdad);//El predicado apunta a otro metodo
     
            List <Persona> mayoresEdad = gente.FindAll(elDelegadoPredicado2);
            System.Console.WriteLine("Segundo ejemplo, verificando edad");      
           //Otro metodo para ver si el metodo al que esta apuntando el metodo es true o false;
           //en este caso verifica si hay mayores de edad
           bool existeMayorEdad = gente.Exists(elDelegadoPredicado2);
           if(existeMayorEdad) Console.WriteLine($"Hay personas mayores de edad");
           else Console.WriteLine($"No hay personas mayores de edad");

           //Imprime las personas mayores de edad que encontro
           foreach (Persona i in mayoresEdad){
                  Console.WriteLine(i.Nombre);
           }
           
           
           

        }

        //Creamos el metodo tipo bool para el delegado  predicado
        static bool ExistePersona(Persona pers){
            if (pers.Nombre =="Iveth") return true;
            else return false; 
        }
        
        //Si quisieramos evaluar si hay mayores de edad (aunque sea una persona)
        static bool ExisteMayoresEdad(Persona pers){
            if (pers.Edad >=18) return true;
            else return false; 
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