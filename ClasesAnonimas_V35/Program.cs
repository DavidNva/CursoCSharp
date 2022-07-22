using System;


namespace Static_V34{
    class Program{

        static void Main(string[] args){
            //realizarTarea();
            //Clases anónimas: Son frecuentemente usadas en Base de Datos
            //al hacer Querys (consultas)
            //Las reglas o requisitos para la creacion de clases anonimas son: 
            /*
              *Solo pueden contner campos publicos
              *Todos los campos deben estar iniciados (como en el ejemplo siguiente)
              *Los campos no pueden ser static
              *No se pueden definir métodos
              *Para que dos objetos pertenezcan a la misma clase anonima, 
                   *sus campos deben tener el mismo nombre, tipo y orden
            */
            //Es como si instanciaramos un objeto con un tipo anonimo, un tipo de clas anonimo
            //usamos var porque no sabemos el tipo de esa clase (su nombre), y creamos un objeto
            //como normalmente lo hacemos
            //Campos dentro de la clase son nombre y edad
            var  miVariable = new {Nombre = "David", Edad = 19};
            Console.WriteLine(miVariable.Nombre + " " + miVariable.Edad);
            //Creamos otro objeto de tipo anonimo
            var miOtraVariable = new {Nombre ="Iveth", Edad =19};
            //*Si cambiamos el nombre o el tipo de alguno,
            //*estos dos objetos no pertenecerian a la misma clase
            //*o si cambiaramos el orden siquiera
           
            //Pero como seguimos los requisitos mencionados anteriormente, con nombre, tipo y orden
            //Para el compilaror estos dos objetos son de la misma clase anonima, por eso se pueden igualar
            //esto lo hace siguiendo el numero de variables o campos creados,
            // el nombre,el orden y sus tipos como en este caso
            miVariable = miOtraVariable;
            
        } 
        static void realizarTarea(){
            //Ṕrograma para averiguar la dinstancia entre dos puntos dados, origen y destino
            
            Punto origen = new Punto();//Llama al constructor por defecto e imprime o hace las indicaciones que tiene
            //Este objeto tiene x = 0, y = 0
            Console.WriteLine($"-------");
            //Este objeto tiene x = 128, y = 80;
            Punto destino = new Punto(128,80);//Llama al segundo constructor que imprime las coordenadas dadas
            
            Console.WriteLine(Punto.constantePrueba);//Ejemplo de constante static
            //destino.constantePrueba;
            //El origen x=0, y=0 diferencia con la distnacia destino con x=128, y=80
            double distancia = origen.DistanciaHasta(destino);
            Console.WriteLine($"La dintancia entre los puntos es de: {distancia}");
            //Punto otroPunto = new Punto();
            //Nos arrojara un dos, ya que hasta ahora solo hemos creado dos objetos
            Console.WriteLine($"Número de objetos creados: {Punto.ContadorObjetos()}");
            
            
        }
    }

}