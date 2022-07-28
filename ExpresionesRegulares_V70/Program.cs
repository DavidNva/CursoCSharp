using System;
using System.Text.RegularExpressions;//Usando este espacio de nombres, namespaces
namespace ExpresionesRegulares_V70{
    //Ejemplo de expresion regular: \d{3}
    //Bien, la d minuscula indica que va a evaluar numeros, si le enviaramos una cadena(texto) no funcionaria aunque tuviera 3 caracteres

    class Program{
        static void Main(string[] args){
            Console.WriteLine("Hola video 70");
            string frase = "Mi nombre es David y mi numero de telefono es: (+52)764-129-184 y el codigo postal es 73310";

            //*string patron = "[D]";//Esta es la expresion regular, la estamos especificando en corchetes
            //es deicr, es lo que vamos a buscar en frase
            //otro ejemplo para buscar un numero de telefono, con la siguiente estructura
            string patron = @"\d{3}-\d{3}-\d{4}";//el arroba nos permite escribir valores de escape, en este caso la barra invertida sin que nos de error
            //Por ejemplo, el signo + es un signo de escape
            //el signo \ es un signo de escape
            //La d minuscula indica que va a buscar valores decimales (por lo que igual numericos)
            //Otto rjrmplo seria buscar numeros de telefono de un pais en concreto, por ejemplo, en este caso de mexico: +52
            //entonces la expresiono seria
            //*string patron2 = @"\+52";
            //podemos seguir jugando con esto y ver que las posibilidad al usarlo como buscador, las expresiones regulares son muy buenas

            Regex miRegex = new Regex (patron);//POdemos inicializarlo normal o ya con la expresion a evaluar

            MatchCollection elMatch = miRegex.Matches(frase);//Como el metodo matches (el cual busca un dato en un caracter)
            //regresa una coleccion, por lo que declaramos una MathColecction para guardar esos valores, decimos
            // if(elMatch.Count > 0) Console.WriteLine($"Se ha encontrado D");Ejemplo con buscar una letra D
             //Ejemplo con numeros
            if(elMatch.Count > 0) Console.WriteLine($"Se ha encontrado numeros de telefono");//lE ESTAMOS DICIENDO QUE SI LA VARIABLE O LA COLECCION EL MATCH TIENE carracteres, pues significa que encontro algo

            else Console.WriteLine($"No se ha encontrado numeros de telefono");
            // if(elMatch.Count > 0) Console.WriteLine($"No se ha encontrado la letra D");//pARA EL SEGUNDO EJEMPLO DE BUSCAR LA LETRA D
//----------------------------------------------------------------------------------------------------------------------------------
            Console.WriteLine($"------------------------------------------------------------------------------------");

            Console.WriteLine($"Segundo ejemplo buscando extensiones de numeros de telefonos de paises con el operador logico o: |");
            string frase2 = "Mi nombre es David y mi numero de telefono es: (+52)764-129-18, (+34)123-45-67 y el codigo postal es 73310";

            string patron2 = @"\+52|\+34";
            Regex miRegex2 = new Regex (patron2);//POdemos inicializarlo normal o ya con la expresion a evaluar

            MatchCollection elMatch2 = miRegex2.Matches(frase2);
            if(elMatch2.Count > 0) Console.WriteLine($"Se ha encontrado numeros de teléfono de Mexico o España");//lE ESTAMOS DICIENDO QUE SI LA VARIABLE O LA COLECCION EL MATCH TIENE carracteres, pues significa que encontro algo

            else Console.WriteLine($"No se ha encontrado numeros de teléfono de México ni de España");

            //----------------------------------------------------------------------------------------------------------------------------------
            Console.WriteLine($"------------------------------------------------------------------------------------");

            Console.WriteLine($"Tercer ejemplo buscando dominio de web");
            string frase3 = "Mi web es: https://www.davidnavaitssnp.blogspot.com";
            
            //El simbolo de interrogacion final ? significa que va a tomar en cuenta el valor si esta una vez o no esta ninguna
            //en este caso, como es un grupo de carateres: www, pues podemos encontrar la red si se escribe www o no

            //si solo se va a verificar con ? un caracter, no hace falta encerralo entre parentesis, por ejemplo, para la s (de web segura)
            //con el ?, es como si dijeramos: si lo encuentras esta bien, y si no pues tambien, jaja, claro para ciertos caracteres
            string patron3 = "https?://(www.)?davidnavaitssnp.blogspot.com";
            Regex miRegex3 = new Regex (patron3);//POdemos inicializarlo normal o ya con la expresion a evaluar

            MatchCollection elMatch3 = miRegex3.Matches(frase3);
            if(elMatch3.Count > 0) Console.WriteLine($"Se ha encontrado web");//lE ESTAMOS DICIENDO QUE SI LA VARIABLE O LA COLECCION EL MATCH TIENE carracteres, pues significa que encontro algo

            else Console.WriteLine($"No se ha encontrado web");

            //----------------------------------------------------------------------------------------------------------------------------------
            Console.WriteLine($"------------------------------------------------------------------------------------");

            Console.WriteLine($"Cuarto ejemplo, para verificar un correo electronico, haciendo uso de un generador de expresiones regulares online");
            string correo = "davidnavagarcia@gmail.com";
            //Usando  un metodo boolean 
            if(useRegex(correo))Console.WriteLine($"Correo correcto");  //SIi el correo es correcto, es decir si el metodo devuelve true
            else Console.WriteLine($"Correo incorrecto");
            
            
            
        }
        public static bool useRegex(String input){
            Regex regex = new Regex("@.*\\.", RegexOptions.IgnoreCase);//Ignora si son mayusculas o minusculas
            return regex.IsMatch(input);
        }
    } 
}