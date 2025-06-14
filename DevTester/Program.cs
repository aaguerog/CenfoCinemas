

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
        Console.WriteLine("2. Consultar todos los usuarios");
        Console.WriteLine("3. Consultar usuario por ID");
        Console.WriteLine("4. Actualizar usuario");
        Console.WriteLine("5. Eliminar usuario");
        Console.WriteLine("6. Agregar película");
        Console.WriteLine("7. Consultar películas");
        Console.WriteLine("8. Actualizar película");
        Console.WriteLine("9. Eliminar película");

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

            case 3:
                Console.WriteLine("-- Consultar Usuario por ID --");

                Console.Write("Ingrese el ID del usuario: ");
                int userId;
                while (!int.TryParse(Console.ReadLine(), out userId))
                {
                    Console.Write("Formato inválido. Ingrese un número: ");
                }

                uCrud = new UserCrudFactory();
                var userById = uCrud.RetrieveById<User>(userId);

                if (userById != null)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(userById));
                }
                else
                {
                    Console.WriteLine("Usuario no encontrado.");
                }

                break;

            case 6:
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

                var movie = new Movie()
                {
                    Title = title,
                    Description = description,
                    ReleaseDate = releaseDate,
                    Genre = genre,
                    Director = director
                };

                var mCrud = new MovieCrudFactory();
                mCrud.Create(movie);

                break;

            case 7:
                Console.WriteLine("-- Consultar Películas --");

                mCrud = new MovieCrudFactory();
                var listMovies = mCrud.RetrieveAll<Movie>();

                foreach (var m in listMovies)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(m));
                }
                break;

            case 8:
                Console.WriteLine("-- Consultar Película por ID --");

                Console.Write("Ingrese el ID de la película: ");
                int movieId;
                while (!int.TryParse(Console.ReadLine(), out movieId))
                {
                    Console.Write("Formato inválido. Ingrese un número: ");
                }

                mCrud = new MovieCrudFactory();
                var movieById = mCrud.RetrieveById<Movie>(movieId);

                if (movieById != null)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(movieById));
                }
                else
                {
                    Console.WriteLine("Película no encontrada.");
                }
                break;

            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }
}