using System;

namespace BloqueFinally_V26{
    //Los bloques finally
    /*
      En caso de tener un codigo que necesitamos que se ejecute siempre
      Porque, si dado el caso, al capturar una excepcion, no se ejecute todo lo que hay dentro de una try
      entonces para asegurarnos de que ciertas lineas se ejecuten si o si, por ejemplo, que estan dentro del try
      entonces
      Usamos el bloque finally
      Con esto nos aseguramos que lo que hay en su interior se va a ejecutar siempre
      tanto si el flujo de ejecucion cambia, tanto si entra en el try o en el catch

      Es necesario generalmente con temas de BBDD y con lectura de ficheros externos
      Es decir trabajar con directorios, consultos, etc.  

      En BBDD por ejempplo, y regularmente el finally lo usamos cuando deseamos liberar recursos
      en un programa. En BBDD, debemos abrir una conexion y esta debe permanecer abierta siempre que estemos
      accediendo (esto consume recursos),entonces si dejamos de utilizar la BBDD esa conexion deberia de cerrarse
      para liberar recursos

      El cierre viene meterlo bien en un bloque finally, para asegurarnos de que se va a ejecutar
      el cierre de la conexion cuando no se utilice, sin importar si entra en el try...
      o el el catch para capturar alguna excepcion

      Lo mismo ocurre cuando hacemos una lectura de ficheros externos (directorios)
      se abra un canal de conexion con el sistema de archivos, lo cual igual consume recursos
      asi que cuando ya no la utilicemo, lo mas recomendable seria cerrar la conexion
    */
    class Program{
        static void Main(string[] args){
            //Vamos a elaborar un programa que pueda accder a un archivo de texto y pueda leerlo
            //EL nombre del archivo se encuentra en la carpeta de este proyecto como: Practica.txt
            //Como lo describimos, abrimos la conexion al sistema de ficheros cuando sea necesario 
            //y cuando no, la cerramos
            System.IO.StreamReader archivo = null;
            try{
                string linea;//Se iran almacenando las lineas que tiene el fichero (leerlo)

                int contador = 0;//Para ir avanzando linea a linea
                //media/davidnava/DAVID SD/Documentos/Cursos/Curso CSharp/BloqueFinally_V26
                //string path = @"/home/davidnava/Documentos/Practica.txt";//ruta del archivo
                string path = @"/media/davidnava/DAVID SD/Documentos/Cursos/Curso CSharp/BloqueFinally_V26/Practica.txt";//ruta del archivo
                //abrir el canal hacia el archivo (ruta)
                archivo = new System.IO.StreamReader(path);//un canal de comunicacion con el sistema de archivos

                //ahora recorremos lo que hay dentro del fichero con un bucle while
                while ((linea = archivo.ReadLine())!= null)//Mientras haya linea de codigo para leer (Mientras sea diferente de null)
                {
                    Console.WriteLine(linea);
                    contador ++;//(Investiagar uso de contador)
                    
                }
            }catch(Exception e){
                Console.WriteLine($"Error con la lectura del archivo");
                
            }finally{
                if(archivo != null) archivo.Close();//No interverndria si entra en el try o el catch
                //con el finally nos aseguramos que el flujo de ejecucion pase por estas lieas de codigo
                //y como tal nos aseguramos de cerrar la conexion con el archivo o con una hipotetica base de datos
                Console.WriteLine($"Conexión con el fichero cerrada");
                
                //Si archivo es diferente de null
                //obviamente si el archivo no se esta utilizando, si el canal no esta abierto
                //entonces cierra el archivo, o cierra la conexion con el archivo
            }
            
        }
    }
}