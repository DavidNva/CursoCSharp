using System;

namespace BucleForEach_V39{
    class Program{

        /*

        */
        static void Main(string[] args)
        {
            //Array implicito
            var valores = new [] {15,28,75.5,30.30,4};
//-----------------------------------------------------------

            //Arrays de objetos
            Empleados[] arrayEmpleados = new Empleados[3];

            arrayEmpleados[0] = new Empleados("David",20);
            Empleados Tere = new Empleados("Tere",43);//Ahora primero creamos el objeto

            arrayEmpleados[1] = Tere;//--------------------------------------------------------------------------
            arrayEmpleados[2] = new Empleados("Jose",59);
            Console.WriteLine("-----------------------");


            //Uso de lenght
            //Esto es muy util con arrays dinamicos y flexibles
            //cuando no tenemos claro el numero de valores dentro del array
            //ademas para evitar el error mencionado anteriormente al
            //intentar acceder a valores que no existen (indices que no estan)
            //con esto se soluciona ese error, ya que le estamos diciendo que recorra
            //el array hasta que i < la cantidad de valores del array
            for (int i = 0; i<arrayEmpleados.Length; i++)//mismo for inicial
            {
              Console.WriteLine(arrayEmpleados[i].GetEmpleado());//El i, indicara el indice a imprimir
              //Estamos imprimiendo la propiedad del objeto EMpleados, que estan almacenados
              //en el array, con un lengh para no estar en un error
            }
            
            //Uso del bucle forEach
            //Cuando no sabemos donde comienza o donde termina un array, ni el nombre del arrya
            //SOlo sirve para recorrer la informacion de todo los elementos de un arrya
            //pero si  queremos modificar los valores de un array, esto no sirve

            Console.WriteLine($"-----------ForEach----------");
            
            //ejemplo de bucle foreach (recorrer el array empleados)
            //Debemos crear una variable del mismo tipo del array a recorrer
            //en este caso recorreremos empleados,  entonces el tipo debe ser eso
            
            //Es como si dijeramos, la variable empleados este en arrayEMpleados
            //Imprime la informacion (al ser un objeto del mismo tipo, puede acceder a estos metodos getter(GetEmpleado))
            foreach(Empleados miVariable in arrayEmpleados ){
                Console.WriteLine(miVariable.GetEmpleado());
                
            }//



        }
        class Empleados{
            string nombre;
            int edad;
            public Empleados(string nombre, int edad){
                this.nombre = nombre;
                this.edad = edad;
            }

            public string GetEmpleado(){
                return "Nombre del Empleado: " + nombre + ", Edad: " + edad;
            }
        }
        
    }
    
}