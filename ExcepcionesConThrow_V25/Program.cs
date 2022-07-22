using System;

namespace ExcepcionesConThrow_V25{
    class Program{
        static void Main(string[] args){
            Console.WriteLine($"Introduce el numero de mes");
            
            int numeroMes = int.Parse(Console.ReadLine());//De esta forma, como el metodo tiene la excepcion, obliga al programador que use dicho metodo
            try{//o nosotros mismos, tenemos que capturar la excepcion que envia
                Console.WriteLine(NombreMes(numeroMes));
            }catch(Exception ex){//ex es un objeto que tiene propiedades y metodos, 
            //y una de sus propiedaes es el mensaje
                Console.WriteLine($"Mensaje de excepcion: " + ex.Message);
            }
            Console.WriteLine($"Aqui continuaria la ejecucion del resto del programa");
        }
        public static string NombreMes(int mes){
            switch(mes){
                case 1:
                    return "Enero";
                case 2:
                    return "Febrero";
                case 3:
                    return "Marzo";
                case 4:
                    return "Abril";
                case 5:
                    return "Mayo";
                case 6:
                    return "Junio";
                case 7:
                    return "Julio";
                case 8:
                    return "Agosto";
                case 9:
                    return "Septiembre";
                case 10:
                    return "Octubre";
                case 11:
                    return "Noviembre";
                case 12:
                    return "Diciembre";
                //En este caso de manera teorica, podemos indicarle al programa
                //que en vez de indicar un default lance una excepcion a proposito
                //eso se hace con un throw
                //para por ejemplo, otros programadores que quieran utilizar el metodo
                //este obligados a utilizar un bloque try catch para controlar las excepciones que lance este metodo
                //entonces quitamos lo de return "mes erroneo"
                default:
                //generamos un objeto que tiene propiedades y metodos, y la prop
                    throw new ArgumentOutOfRangeException();//Ahora estamos haciendo un objeto de tipo excepcion
                //    return "Mes erroneo";                 //para enviarla en caso de que el usuario ingrese un numero fuera del rango de mes
                                                            //nos mostrara este error (excepcion)
            }//De esta forma estamos obligando a que cualquier persona (programador) que use este metodo, vea la forma de solucionar esta excepcion
            //es decir, que de acuerdo al uso o contexto de lo que este haciendo, hará su propio try...catch
        }
    }
}           
            //Se puede forzar a un lanzamiento de excepciones, para  obligar a otros programadores
            //que estan participando en la elaboracion de ese programa, a capturar una excepcion, 
            //por ejemplo cuando llaman a un metodo
            //
            //Pagina Biblioteca de clases de .NET Framework

