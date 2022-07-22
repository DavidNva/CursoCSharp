using System;

namespace InterfacesAvisos_V51
{
    class AvisosTrafico:IAvisos
    {
        private string remitente;
        private string mensaje;
        private string fecha;
        //Constructor por defecto(modificado)
        public AvisosTrafico(){
            remitente = "DGT";
            mensaje = "Sanción cometida. Pague antes de 3 dias y se beneficiará de una reducción en la sansión del 50%,";
            fecha = "";
        }

        //constructor mas personalizado
        public AvisosTrafico(string remitente, string mensaje, string fecha){
            //EL this siempre refiere al campo de clase
            this.remitente = remitente;
            this.mensaje = mensaje;
            this.fecha = fecha;
        }

        public void MostrarAviso(){
            Console.WriteLine("Mensaje: {0} ha sido enviado por {1} el dia {2}", mensaje,remitente,fecha);
            
        }

        public string GetFecha(){
            return fecha;
        }
    }
}