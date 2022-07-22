using System;
//using System.Collections.Generic;
//using System.Text;

namespace Static_V34{
    class Punto{

      public const int constantePrueba = 7;//EN C# todas las constantes 
      //se asume que son static sin especificar dicha palabra reservada antes
       private int x,y;
       //Encapsulamos los datos
       private static int contadorObjetos = 0;//Una variable static, seria una variable de clase
        //no es lo mismo una varible normal, donde para cada objeto se hace una copia de las propiedades y metodos
        //en los static, no se hace una copia, sino se asigna el mismo valor de esa varieble a cada objeto  creado
        //por eso los metodos y variables static se dice que son de clase
        //varibles de clase
        //metodos de clase
        //Los objetos no pueden actuar sobre ellos, no pueden modificar sus datos
        //ni siquiera tendran acceso de esa forma(nomenclatura del punto)
        //Solo la clase podra tener acceso a ellos
       public Punto(){
        x = 0;
        y= 0;
        contadorObjetos++;//Cada vez que creemos un objeto de tipo punto, incrementamos en 
        //uno el valor de la variable estatica
       }
       public Punto(int x, int y){
        this.x = x;
        this.y= y;
        contadorObjetos ++;
       }
       //Metodo para averiguar la dinstancia entre los puntos
       public double DistanciaHasta(Punto otroPunto){//Es como si dijeramos int variable, double variable, etc. ES decir es una variable de tipo punto
        /*
         ***
         *****
         ******
         *******
         ********
         *********
         **********
 //128   ***********   //150.9436 
         ************
         *************
         **************
         ***************
         ****************
         *****************
         ******************
               //80
        */
        //Es decir,la raiz cuadrada (128 al cuadrado + 80 al cuadrado) = hipotenusa: 150.9436
        int xDif = this.x - otroPunto.x;//El otro punto, seria por ejemplo, la variable destino 
        //para sacer la diferencia con origen
        int yDif = this.y -otroPunto.y;//Estamo detectando la coordenada del punto o el lugar donde se encuentra el punto
        
        //una vez que tenemos claro donde estan esos puntos, ahora vamos a calcular la distancia entre ellos
        //esto con el teorema de pitagoras
        double distanciaPunto = Math.Sqrt(Math.Pow(xDif,2) + Math.Pow(yDif,2));
        return distanciaPunto; 
        //Teorema de pitagoras : El cuadrado de la hipotenusa es igual a la suma del cuadrado de los catetos

        //a al cuadrado + b al cuadrado = c al cuadrado        
       }

        //Metodo para acceder a la variable static contador objetos
        public static int ContadorObjetos()=>contadorObjetos;
    }
}