using System;
using System.Linq;

namespace ConsoleAppEntityUsuarios
{
    class Program
    {
        static String NombreUsuario="";
        static String id;
        static String ContraseñaUsuario = "";
        static String seleccioncontra;
        static int TipoUsuario;
        static Usuario SeleccionUsu;
        static int respu = 1;
        static String resp;
        static void Main(string[] args)
        {
            while (respu == 1)
            {
                Console.Clear();
                Console.WriteLine("Ingresa tu usuario:\n\nID: ");
                id = Console.ReadLine();
                Console.WriteLine("\nContraseña: ");
                seleccioncontra = Console.ReadLine();
                try
                {
                    Selecciona(Convert.ToInt32(id));
                }
                catch(Exception ex)
                {

                }

                if (ContraseñaUsuario == seleccioncontra)
                {
                    Console.WriteLine("\nB I E N V E N I D O, "+ NombreUsuario+" ! ! !");
                    Console.WriteLine("\n¿Qué desea hacer?\n1.Insertar\n2.Actualizar\n3.Eliminar\n\nDigite su respuesta: ");
                    resp = Console.ReadLine();
                    if (resp.Equals("1"))
                    {

                        Console.WriteLine("\n I N G R E S A R ");

                    }
                    Console.ReadKey();
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine("\nError: ID o Contraseña incorrecta");
                    Console.WriteLine("Desea reintentar o salir?\n1.Reintentar\n2.Salir\n\nDigite su respuesta: ");
                    try
                    {
                        respu = Convert.ToInt32(Console.ReadLine());
                    }
                    catch(Exception e)
                    {

                    }
                    

                }



            }



        }

        static void Selecciona(int IDusuario)
        {
            using (var context = new ApplicationDbContext())
            {
                SeleccionUsu = context.Usuarios.Where(x => x.ID == IDusuario).FirstOrDefault();
                
            }
            try { 
            NombreUsuario = SeleccionUsu.Nombre;
            ContraseñaUsuario = SeleccionUsu.Contraseña;
            TipoUsuario = SeleccionUsu.tipo;                
            }
            catch (Exception ex)
            {

            }
        }
        static void Eliminar(Usuario Buscado)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(Buscado).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        
        static void Actualizar(Usuario Buscado)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(Buscado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

            }
        }

        static void Insertar()
        {
            using (var context = new ApplicationDbContext())
            {
                var usuario = new Usuario();
                usuario.Nombre = NombreUsuario;
                usuario.Contraseña = ContraseñaUsuario;
                usuario.tipo = TipoUsuario;
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }
            Console.WriteLine("Listo");
        }

    }




    class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public int tipo { get; set; }

    }
}
