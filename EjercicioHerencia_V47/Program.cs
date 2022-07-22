using System;

namespace EjercicioHerencia_V47{
    class Program{
        static void Main(string[] args)
        {
            Console.WriteLine($"Ejercicio práctico de herencia");
            Avion miAvion = new Avion();

            Coche miCoche = new Coche();

            miAvion.Conducir();
            miCoche.Conducir();
            
            Vehiculo[] AlmacenVehiculos = new Vehiculo[2];

            AlmacenVehiculos[0]=miAvion;
            AlmacenVehiculos[1]=miCoche;
            //Recorriendo el array
            Console.WriteLine($"Polimorfismo en accion 1");
            
            Console.WriteLine($"Con array");
           
            
            for (int i = 0; i < AlmacenVehiculos.Length; i++)
            {
                AlmacenVehiculos[i].Conducir();//El mismo objeto toma distintas formas
            }
            Console.WriteLine();
            
            Console.WriteLine($"Polimorfismo en accion 2");

            Vehiculo miVehiculo; //El objeto vehiculo se comportará de una u otra forma, de acuerdo al contexto
            miVehiculo = miAvion;
            miVehiculo.Conducir();//Es decir, si es un avion, ejecutara conducir como surcando los cielos

            miVehiculo = miCoche;
            miVehiculo.Conducir();//y si es un coche, ejecutara lo indicado para conducir en coche
            //el mismo objeto miVehiculo, comportandose de diferentes formas
            
        }
    }

    class Vehiculo{
        public void ArrancarMotor(){
            Console.WriteLine($"Arrancando motor");
            
        }
        public void PararMotor(){
            Console.WriteLine($"Parando motor");
            
        }

        public virtual void Conducir(){
            Console.WriteLine($"Conduciendo vehiculo");
            
        }
    }

    class Avion: Vehiculo{
        public void volar(){
            Console.WriteLine($"Puedo volar por los aires");
            
        }

        public override void Conducir()
        {
            //base.Conducir(); //Esto estaria ejecutando lo inicialmente de vehiculo
            Console.WriteLine($"Surcando los cielos");
            
        }
    }

    class Coche: Vehiculo{
        public void Acelerar(){
            Console.WriteLine($"Puedo acelerar a una mayor velocidad");
            
        }
        public override void Conducir(){
            Console.WriteLine($"Modificando metodo inicial: Conducir coche Bombordi");
            
        }
    }
}