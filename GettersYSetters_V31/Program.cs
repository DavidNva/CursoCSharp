﻿using System;

namespace GettersYSetters_V31{
    class Program{  

        //Algo que nos ofrece C# y visual Studio
        //Es que cuando tengamos muchas lineas de codigo en una clase
        //tener la opcion de dividirla en trozos
        //Esto se hace
        //Primero determinar que dividir en cada trozo
        //Por ejemplo, podemos dividir la clase coche como se ve en la segunda clase
        //de las siguientes lineas
        static void Main(string[] args){
            Console.WriteLine($"-----------------------------");
                            //Al indicar new estamos llamando al constructor, es decir dar un estado inicial al coche
            Coche miChoche = new Coche();//Instanciar la clase Coche, crear objeto tipo Coche
            
            Coche miCoche2 = new Coche();//Entonces serian dos coches diferentes, pero los dos tinen un estado inicial
            //miChoche.ruedas = 27;//ESto no tiene sentido, por eso debemos encapsular la variable
            //ahora con el encapuslamiento no podemos cambiar el valor, a menos que declaremos un metodo para hacerlo
            //lo cual no tendria necesidad de hacer (un auto la mayoria de veces tendra 4 ruedas)
            Console.WriteLine(miChoche.GetInfoCoche());//con el metodo getter vemos el valor
            
            Console.WriteLine($"------------------------------------");
            Console.WriteLine(miCoche2.GetInfoCoche());//tendras de forma inplicita el mismo estado inicial
            //pero si quisieramos cambiar el estado inicial, con la sobrecarga de constructores
            Console.WriteLine($"------------------------------------");
            //Con el constructor cambiamos el largo y el ancho de un choche
            Coche miCoche3 = new Coche(4500.25,1200.35);//ahora este si es diferente

            Console.WriteLine(miCoche3.GetInfoCoche());
            
            miCoche3.SetExtras(true,"Cuero");
            System.Console.WriteLine(miCoche3.GetExtras());
             Console.WriteLine($"---------------------------");
             Console.WriteLine($"TELA"); 
        }
    }
}
//Ejemplo como dividir una clasee //usando partial
partial class Coche{
    public Coche(){//Primer constructor
    //Este es el estado inicial que van a tener estos coches 
       ruedas = 4;
       largo = 2300.5;
       ancho = 0.800;
       tapiceria = "Tela";
    }
    public Coche(double largoCoche, double anchoCoche){
        ruedas = 4;
        largo = largoCoche;
        ancho = anchoCoche;
        tapiceria = "Tela"; 

    }
}
//------------------------------------------------------------------------
partial class Coche{
    //--------------------------------------------------------------------
    //*Los metodos getter devuelven el valor 
    //(El metodo debe ser de algun tipo privitivo, string, int, double, etc)
    public string GetInfoCoche(){
        return "Información del coche:\n" + "Ruedas: " + ruedas +  "\nLargo: " + largo + "\nAncho: " + ancho;//Cada objeto creado de tipo coche tendra accese a este metodo
    }
    //---------------------------------------------------------------------
    //*los metodos setter establecen un valor (permiten modificar variables)
    //Conviene establecer metodos setters para poder establecer valores desde fuera desde esta clase
    //para poder cambiar los valores
    //*Los metodos Setters son de tipo void, es decir no devuelven nada, solo establecen
    //dan valor a las propiedades
    
    //Metodo setter
    public void SetExtras(bool climatizador, string tapiceria){
        this.climatizador = climatizador;//Debemos usar this para especificar o diferneciar al valor del objeto inicial
        this.tapiceria = tapiceria;//El this.tapiceria indica el valor de la variable de clase
        //es decir this.tapiceria (variable de clase) tapiceria es = a climatizador (variable por parametro) 
        //COmo tal this la usamos para diferenciar un campo de clase a una
        //Funcionaria si las variables tuvieran distintos nombres, pero no seria una muy buena practica
    }    
    //Normalmente lo metodos setter estan acompañados de sus metodos getters
    //para imprimir los extras, obtener, devolver (getters)
    //Entonces hacemos el metodo getter
    public string GetExtras(){
        return  "Extras del coche: \nTapiceria: "+ tapiceria + "\nClimatizador: " + climatizador;
        //Si usamos este metodo sin haber usado el setters (haber establecido valores a estas dos variables)
        //Entonces nos enviara los valores por defecto para estas variables
        //tapiceria = "", Climatizador = False;
    }

 
    private int ruedas;

    private double largo;

    private double ancho;

    private bool climatizador; //El valor por defecto de una variable boolean es siempre false

    private string tapiceria; //El valor por defecto es una cadena vacia = "";

   



}