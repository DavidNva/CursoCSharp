using System;

namespace Arrays_BucleFor_V38{
    class Program{

        /*
          Los bucles for sirven para repetir el codigo de sus interior
          parecido al while,pero en este caso, se indica un numero 
          determiando de veces a repetir

          Se utilizan mucho para recorrer arrays

          sintaxis BucleFor
          Consta de 3 partes separadas por punto y coma
          
          *int i = 0; iniciacion del bucle (Se suelen utilizar j o k, cuando se necesita anidar bucles)
          
          *i <= 8:  Condicion del bucle, es decir menor o igual que 8 (Es decir hasta cuando va a repetir el codigo dentro)
          cuando i no sea menor o igual que ocho, saldra del bucle, por eso sabemos cuantas repeticiones tendra
          y cuando lo hará

          *i++ : Incremento o decremento del bucle 
          *(Cuanto varia la variable i a cada vuelta de bucle )

          for(int i=0, i<=8,i++){
            codigo interior del bucle
          }
          Entonces sin necesidad de ejecutar el programa
          solo leyendo el codigo sabremos las veces que se repetira dichos programa

        */
        static void Main(string[] args)
        {
            //Array implicito
            var valores = new [] {15,28,75.5,30.30,4};
//-----------------------------------------------------------

            //Arrays de objetos
            Empleados[] arrayEmpleados = new Empleados[2];

            arrayEmpleados[0] = new Empleados("David",20);
            Empleados Tere = new Empleados("Tere",43);//Ahora primero creamos el objeto

            arrayEmpleados[1] = Tere;//--------------------------------------------------------------------------
            //Arrays de tipos o clases anonimas
            var personas = new []{//La propiedad nombre y edad, serian campos de la clase instanciada (anonima)
            //es decir, intanciamos objetos que tienen estas propiedades 
            //estas propiedades son publicas, esa es la regla
                new{Nombre = "Maria",Edad = 73 },//Todos los objetos espeficiados deben concidir en orden, tipo y nombre
                new {Nombre= "Iveth",Edad = 19},//Debe ser asi en el resto de valores 
                new{Nombre = "Valente",Edad = 17}//Cada new con corchetes,seria como 
            };
            //Cada new seria un nuevo objeto de ese tipo de clase, entonces tenemos 3 posiciones: 0,1,2

            //Console.WriteLine(personas[1]);//Imprimira los datos de la posicion 1: Iveth, 19
            //Recorrer el array implicito: valores mediante un bucle for 
            //: var valores = new [] {15,28,75.5,30.30,4}; Tiene 5 valores
            for (int i = 0; i<5; i++)
            {
              Console.WriteLine(valores[i]);//El i, indicara el indice a imprimir
                 
            }
            Console.WriteLine("-----------------------");
            for (int i = 0; i<=4; i++)
            {
              Console.WriteLine(valores[i]);//El i, indicara el indice a imprimir
                 
            }
            Console.WriteLine("-----------------------");
            int contador = 0;
            for (int i = 15; i>=11; i--)//En este caso no estamo usando la variable i
            {//simplemente la ocupamos para decirle al bucle cuando detenerse, despues de dar
            //varias repeticiones i sera = 10, entonces el bucle terminara, comienza con 
            //15,14,13,12,11 (Son las 5 posiciones de los datos ingresados en ese array a recorres)
              Console.WriteLine(valores[contador]);//El i, indicara el indice a imprimir
              contador++;
            }
            Console.WriteLine("-----------------------");
            //SI ingresamos un valor mas al array valores no pasa nada, solo que 
            //a como tenemos nuestro for, no leeria ese dato
            //pero si quitamos un valor del array valores, y seguimos con este for que estamos usando
            //aqui si daria el mismo error comentado en proyectos anteriores, sobre el fuera de rango
            //ya que el bucle for estaria intentando leer un indice, un valor que no existe, lo cual llevaria a dicho error
            //Es la desventaja de especificar en cada array el numero de valores
            //y especificarlos en el bucle for
            for (int i = 0; i<5; i++)//mismo for inicial
            {
              Console.WriteLine(valores[i]);//El i, indicara el indice a imprimir
                 
            }
            Console.WriteLine("-----------------------");
            //Esto es muy util con arrays dinamicos y flexibles
            //cuando no tenemos claro el numero de valores dentro del array
            //ademas para evitar el error mencionado anteriormente al
            //intentar acceder a valores que no existen (indices que no estan)
            //con esto se soluciona ese error, ya que le estamos diciendo que recorra
            //el array hasta que i < la cantidad de valores del array
             for (int i = 0; i<valores.Length; i++)//mismo for inicial
            {
              Console.WriteLine(valores[i]);//El i, indicara el indice a imprimir
                 
            }
             Console.WriteLine("-----------------------");
              Console.WriteLine("-----------ForEach-----------");
            //Recorrer el array valores con un foreach
            foreach (var miValor in personas)
            {
              System.Console.WriteLine(miValor);
            }//De esta forma recorre todo lo que hay en el array valores

//Recorrer con un bucle for el arry personas
Console.WriteLine($"Array con for, pero de la clase anonima, es decir un array anonimo");

              for (int i = 0; i<personas.Length; i++)//mismo for inicial
            {
              Console.WriteLine(personas[i].Nombre);//El i, indicara el indice a imprimir
              //Estamos imprimiendo la propiedad del objeto EMpleados, que estan almacenados
              //en el array, con un lengh para no estar en un error
            }

//Recorrer un array con objetos de clase anonimo (objetos de tipo anonimo)


        }
        class Empleados{
            string nombre;
            int edad;
            public Empleados(string nombre, int edad){
                this.nombre = nombre;
                this.edad = edad;
            }
        }
        
    }
    
}