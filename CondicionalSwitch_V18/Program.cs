using System;

namespace CondicionalSwitch_V18{

    class Program {
        static void Main(string[] args){
               //Programa de juguete para elegir un medio de transporte
            Console.WriteLine($"Elige un medio de transporte (coche, tren, avión)");

            string medioTransporte;
            medioTransporte = Console.ReadLine();

            switch(medioTransporte){//Se especifica la variable a evaluar o comparar, en este caso
            //con lo que haya ingresado el usuario
                case "coche":
                    Console.WriteLine($"Velocidad media: 100 km/h");
                    break;
                case "tren":
                    Console.WriteLine($"Velocidad media: 250 km/h");
                    break;
                case "avión":
                    Console.WriteLine($"Velocidad media: 800 km/h");
                    break;
                default:
                    Console.WriteLine($"Transporte no contemplado");
                    
                    break;
            }
            Console.WriteLine($"Aqui termina el primera programa");

            Console.WriteLine($"----------------------");
            Console.WriteLine($"Introduce el n° del mes para calculo de la comision");

            int mes = int.Parse(Console.ReadLine());

            switch(mes){
                case 1:
                Console.WriteLine($"Mes escogido: Enero");
                //Lineas de codigo para calcular la comision
                    break;
                case 2:
                Console.WriteLine($"Mes escogido: Febrero");
                //Lineas de codigo para calcular la comision
                    break;
                case 3:
                Console.WriteLine($"Mes escogido: Marzo");
                //Lineas de codigo para calcular la comision
                    break;
                case 4:
                Console.WriteLine($"Mes escogido: Abril");
                //Lineas de codigo para calcular la comision
                    break;
                case 5:
                Console.WriteLine($"Mes escogido: Mayo");
                //Lineas de codigo para calcular la comision
                    break;
                case 6:
                Console.WriteLine($"Mes escogido: Junio");
                //Lineas de codigo para calcular la comision
                    break;
                case 7:
                Console.WriteLine($"Mes escogido:Julio");
                //Lineas de codigo para calcular la comision
                    break;
                case 8:
                Console.WriteLine($"Mes escogido: Agosto");
                //Lineas de codigo para calcular la comision
                    break;
                case 9:
                Console.WriteLine($"Mes escogido: Septiembre");
                //Lineas de codigo para calcular la comision
                    break;
                case 10:
                Console.WriteLine($"Mes escogido: Octubre");
                //Lineas de codigo para calcular la comision
                    break;
                case 11:
                Console.WriteLine($"Mes escogido: Noviembre");
                //Lineas de codigo para calcular la comision
                    break;
                case 12:
                Console.WriteLine($"Mes escogido: Diciembre");
                //Lineas de codigo para calcular la comision
                    break;
                default:
                System.Console.WriteLine("Mes incorrecto");
                    break;

                
            }
            Console.WriteLine($"Aqui termina el segundo programa");
            //En los case y switch, solo se admiten  expresiones constantes
            //nada de operaciones de comparacion o estructuras complejas
            //Ademas cada case debe ser unico, y debe llevar su break;
            //no se puede que dos case esten evaluando el mismo condiconal
        }
    }
}