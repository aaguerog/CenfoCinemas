

using DataAccess.CRUD;
using DataAccess.DAO;
using DataAccess.DAOs;
using DTOs;
using Newtonsoft.Json;

public class Program
{
    public static void Main(string[] args)
    {

        //Crear un menu y capturar la data de consola

        var sqlOperation = new SqlOperation();

        Console.WriteLine("Bienvenido a CenfoCinemas");
        Console.WriteLine("Seleccione una opción:");
        Console.WriteLine("1. Crear usuario");
        Console.WriteLine("2. Consultar usuarios");
        Console.WriteLine("3. Actualizar usuario");
        Console.WriteLine("4. Eliminar usuario");
        Console.WriteLine("5. Agregar película");
        Console.WriteLine("6. Consultar películas");
        Console.WriteLine("7. Actualizar película");
        Console.WriteLine("8. Eliminar película");
        Console.WriteLine("9. Salir");

        var option = Int32.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                Console.WriteLine("-- Crear Usuario --");

                Console.Write("Código de usuario: ");
                var userCode = Console.ReadLine();

                Console.Write("Nombre: ");
                var name = Console.ReadLine();

                Console.Write("Correo electrónico: ");
                var email = Console.ReadLine();

                Console.Write("Contraseña: ");
                var password = Console.ReadLine();

                var status = "AC";

                Console.Write("Fecha de nacimiento (yyyy-MM-dd): ");
                DateTime birthDate;
                while (!DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    Console.Write("Formato incorrecto. Intente de nuevo: ");
                }

                var user = new User()
                {
                    UserCode = userCode,
                    Name = name,
                    Email = email,
                    Password = password,
                    Status = status,
                    BirthDate = birthDate
                };

                var uCrud = new UserCrudFactory();
                uCrud.Create(user);

                break;

            case 2:

                Console.WriteLine("-- Consultar Usuarios --");

                uCrud = new UserCrudFactory();
                var listUsers = uCrud.RetrieveAll<User>();

                foreach(var u in listUsers)
                { 
                    Console.WriteLine(JsonConvert.SerializeObject(u));
                }

                break;

            case 5:
                Console.WriteLine("-- Agregar Película --");

                Console.Write("Título: ");
                var title = Console.ReadLine();

                Console.Write("Descripción: ");
                var description = Console.ReadLine();

                Console.Write("Fecha de estreno (yyyy-MM-dd): ");
                DateTime releaseDate;

                while (!DateTime.TryParse(Console.ReadLine(), out releaseDate))
                {
                    Console.Write("Formato incorrecto. Intente de nuevo: ");
                }

                Console.Write("Género: ");
                var genre = Console.ReadLine();

                Console.Write("Director: ");
                var director = Console.ReadLine();

                sqlOperation.ProcedureName = "CRE_MOVIE_PR";
                sqlOperation.AddStringParameter("P_Title", title);
                sqlOperation.AddStringParameter("P_Description", description);
                sqlOperation.AddDateTimeParam("P_ReleaseDate", releaseDate);
                sqlOperation.AddStringParameter("P_Genre", genre);
                sqlOperation.AddStringParameter("P_Director", director);

                break;

            case 9:
                Console.WriteLine("Saliendo del sistema.");
                break;

            default:
                Console.WriteLine("Opción no válida.");
                break;
        }



    }
}