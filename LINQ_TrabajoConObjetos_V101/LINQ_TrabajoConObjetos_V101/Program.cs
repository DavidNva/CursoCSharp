namespace LINQ_TrabajoConObjetos_V101
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Empleados CEO: ");
            ControlEmpresasEmpleados empresasEmpleados = new ControlEmpresasEmpleados();
            empresasEmpleados.getCEO();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Empleados CO-CEO: ");
            empresasEmpleados.getCO_CEO();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Empleados Gerentes: ");
            empresasEmpleados.getGerentes();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Empleados de la Empresas 2: ");
            empresasEmpleados.getEmpleadosEmpresa2();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Empleados de la Empresas 2: Ahora con el inner join ");
            empresasEmpleados.EmpleadosCuboRubikCode();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Empleados ordenados por nombre: A-Z ");
            empresasEmpleados.EmpleadosOrdenados();

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Ejemplo de forma mas dinamica para el usuario");
            Console.WriteLine("Hay dos empresas: \n   Google con un ID = 1 \n   CuboRubikCode con un ID = 2");
            Console.Write("Indica un ID para ver los empleados de esa empresa: ");
            //int idEm = int.Parse(Console.ReadLine()); ó
            try
            {
                int idEm = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------------------------------------------------------");
                Console.WriteLine("Imprimiendo empleados de la empresa con ID = " + idEm + ": ");
            
                empresasEmpleados.getEmpleadosEmpresa(idEm);
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Solo puedes indicar un número en el ID");
            }
            catch(Exception)
            {
                Console.WriteLine("Error");
            }

        }
    }
    class ControlEmpresasEmpleados
    {
        //Declaracion de listas
        public List<Empresa> listaEmpresas;
        public List<Empleado> listaEmpleados;
        public ControlEmpresasEmpleados()//Constructor 
        {
            listaEmpresas = new List<Empresa>();//Inicializacion de listas
            listaEmpleados = new List<Empleado>();//Hasta aqui tenemos dos listas vacias
            //Creando y agregamos dos empresas
            listaEmpresas.Add(new Empresa { IDEmpresa = 1, NombreEmpresa = "Google" });
            listaEmpresas.Add(new Empresa { IDEmpresa = 2, NombreEmpresa = "CuboRubikCode" });
            //Creando y agregando empleados
            listaEmpleados.Add(new Empleado { IDEmpleado = 1, NombreEmpleado = "Teresa", Cargo = "CEO", Salario = 21000, ID_Empresa = 1 });
            listaEmpleados.Add(new Empleado { IDEmpleado = 2, NombreEmpleado = "David", Cargo = "CEO", Salario = 20000, ID_Empresa = 2 });
            listaEmpleados.Add(new Empleado { IDEmpleado = 3, NombreEmpleado = "Maria", Cargo = "CO-CEO", Salario = 22000, ID_Empresa = 1 });
            listaEmpleados.Add(new Empleado { IDEmpleado = 4, NombreEmpleado = "Iveth", Cargo = "CO-CEO", Salario = 21000, ID_Empresa = 2 });
            listaEmpleados.Add(new Empleado { IDEmpleado = 5, NombreEmpleado = "Nava", Cargo = "Gerente", Salario = 23000, ID_Empresa = 2 });
        }
        //Metodo de consulta tipo LINQ
        public void getCEO()
        {
            //Selecciona los empleados que su cargo sea == "CEO"
            //Esta interface es de tipo coleccion por decirlo de alguna forma, por lo que podemos tener listas de varios tipos
            //en este caso la lista(de IEnumerable) tipo Empleado se rellena con el resultado de la consulta de la derecha. 
            IEnumerable<Empleado> CEOS = from empleado in listaEmpleados where empleado.Cargo == "CEO" select empleado;
            foreach (Empleado emp in CEOS)
            {
                emp.InfoEmpleado();
            }
        }
        public void getCO_CEO()
        {
            IEnumerable<Empleado> CO_CEOS = from empleado in listaEmpleados where empleado.Cargo == "CO-CEO" select empleado;
            foreach (Empleado emp in CO_CEOS)
            {
                emp.InfoEmpleado();
            }
        }
        public void getGerentes()
        {
            IEnumerable<Empleado> gerentes = from empleado in listaEmpleados where empleado.Cargo == "Gerente" select empleado;
            foreach (Empleado emp in gerentes)
            {
                emp.InfoEmpleado();
            }
        }
        public void getEmpleadosEmpresa2()
        {
            IEnumerable<Empleado> DeEmpresa2 = from empleado in listaEmpleados where empleado.ID_Empresa == 2 select empleado;
            foreach (Empleado emp in DeEmpresa2)
            {
                emp.InfoEmpleado();
            }
        }
        public void EmpleadosCuboRubikCode()//Este es con un ejemplo de innner join, en realidad hace lo mismo que el anterior
        {//pero es para ver como se haria una consulta de este tipo
            IEnumerable<Empleado> cuboRubikCode = from empleado in listaEmpleados
                                                  join empresa in listaEmpresas
                                                  on empleado.ID_Empresa equals empresa.IDEmpresa
                                                  where empresa.NombreEmpresa == "CuboRubikCode" select empleado;
            //Estas consultas respetan o difieren de mayusculas y minusculas, por lo que para encontrar un valor se debe escribir tal cual esta
            foreach (Empleado emp in cuboRubikCode)
            {
                emp.InfoEmpleado();
            }
        }
        public void EmpleadosOrdenados()
        {
            IEnumerable<Empleado> empleadosOrdenados = from empleado in listaEmpleados orderby empleado.NombreEmpleado /*descending*/ select empleado;
            //El descending es como el DESC de SQL, los ordena al reves digamos, en este caso de Z-A
            foreach (Empleado emp in empleadosOrdenados)
            {
                emp.InfoEmpleado();
            }
        }
        public void getEmpleadosEmpresa(int Id)//Metodo usado de forma dinamica por el usuario
        {
            IEnumerable<Empleado> empresas = from empleado in listaEmpleados
                                                  join empresa in listaEmpresas
                                                  on empleado.ID_Empresa equals empresa.IDEmpresa
                                                  where empresa.IDEmpresa == Id//Esto ultimo seria el id por parametro
                                                  select empleado;
            //Estas consultas respetan o difieren de mayusculas y minusculas, por lo que para encontrar un valor se debe escribir tal cual esta
            foreach (Empleado emp in empresas)
            {
                emp.InfoEmpleado();
            }
        }

    }
    class Empresa
    {
        public int IDEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public void InfoEmpresa()
        {
            Console.WriteLine($"Empresa {NombreEmpresa} con ID: {IDEmpresa}");
        }
    }
    class Empleado
    {
        public int IDEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
        //Clave foranea (en teoria, para poder hacer consultas LINQ, como si fuera SQL)
        public int ID_Empresa { get; set; }
        public void InfoEmpleado()
        {
            Console.WriteLine($"Empleado {NombreEmpleado} con ID: {IDEmpleado}, cargo: {Cargo} con salario ${Salario} pertenece a la empresa {ID_Empresa}");
        }
    }
}