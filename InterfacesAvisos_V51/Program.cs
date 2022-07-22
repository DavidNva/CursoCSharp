using System;

namespace InterfacesAvisos_V51{
    class Program{
        static void Main(string[] args)
        {
            Console.WriteLine($"Practica sobre avisos ");
            Console.WriteLine($"--------- Primer aviso tipo general ------------");
            
            AvisosTrafico AV1 = new AvisosTrafico();//Esta tomando el consturtor 1, el por defecto modificado

            AV1.MostrarAviso();
            Console.WriteLine(AV1.GetFecha());//Esto no imprime nada, solo "", porque en el primer constructor fecha = ""
            Console.WriteLine($"---------- Segundo aviso ----------");
            
            AvisosTrafico AV2 = new AvisosTrafico("SEDENA", "Sanción de velocidad: $300.00","21-07-22");
            Console.WriteLine( AV2.GetFecha());
            AV2.MostrarAviso();
        }
    }
}