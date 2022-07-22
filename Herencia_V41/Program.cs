using System;

namespace Herencia_V41{
    class Program{
        //La herencia es la caracteristica mas importante de la POO
        static void Main(string[] args)
        {

            //La clase objetoc o superclase o superclase cósmica
            //La clase object siempre estara el la cuspide, en la parte superior de cualquier
            //jerarquia de herencia
            //no importa si no la colocamos, por eso en cualquie instancia que realicemos
            //nos aparecen los metodos GetType, GetHashCode,Equals, etc.
            
            //La utilidad de la herencia es la reutilizacion de codigo
            Mamiferos miMamifero = new Mamiferos();

            Caballo miCaballo  = new Caballo();

            Humano miHumano = new Humano();

            Gorila miGorila = new Gorila();

            miCaballo.Galopar();
            Console.WriteLine($"--------------------");
            miHumano.Pensar();
            Console.WriteLine($"--------------------");
            miGorila.Trepar();
            
        }
    }

    class Mamiferos: Object//Seria como colocar este object al crear la clase padre
    //o la que heredara, pero este object no es necesario colocarlo, ya que implicitamente ya 
    //ya se coloco o ya esta heredando a cada clase que creemos
    {

        public void Respirar(){
            Console.WriteLine($"Soy capaz de respirar");
        }

        public void CuidarCrias(){
            Console.WriteLine($"Cuido de mis crias hasta que se valgan por si solas");
            
        }
    }
   //sintaxis de herencia, simplemente colocar dos puntos
    class Caballo: Mamiferos {
        public void Galopar(){
            Console.WriteLine($"Soy capaz de galopar");
            
        }
    }

    class Humano: Mamiferos{
        public void Pensar(){
            Console.WriteLine($"Soy capaz de pensar");
            
        }
    }

    class Gorila:Mamiferos{
        public void Trepar(){
            Console.WriteLine($"Soy capaz de trepar");
        }
    }
}